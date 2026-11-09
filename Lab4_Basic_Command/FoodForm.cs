using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab4_Basic_Command
{
    public partial class FoodForm : Form
    {
        private SqlDataAdapter adapter;
        private DataTable foodTable;
        private int currentCategoryID;

        public FoodForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Nạp danh sách món ăn theo mã nhóm
        /// </summary>
        public void LoadFood(int categoryID)
        {
            currentCategoryID = categoryID;

            try
            {
                // Lấy tên nhóm hiển thị trên tiêu đề Form
                string nameQuery = "SELECT Name FROM Category WHERE ID = @CategoryID";
                SqlParameter[] nameParams = { new SqlParameter("@CategoryID", categoryID) };
                object result = DatabaseHelper.ExecuteScalar(nameQuery, nameParams);
                string categoryName = result != null ? result.ToString() : "";
                this.Text = "Danh sách món ăn thuộc nhóm: " + categoryName;

                // Nạp dữ liệu qua SqlDataAdapter
                string query = "SELECT ID, Name, Unit, FoodCategoryID, Price, Notes FROM Food WHERE FoodCategoryID = @CategoryID";
                SqlCommand cmd = new SqlCommand(query, DatabaseHelper.GetConnection());
                cmd.Parameters.AddWithValue("@CategoryID", categoryID);

                adapter = new SqlDataAdapter(cmd);
                adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

                foodTable = new DataTable("Food");
                adapter.Fill(foodTable);

                if (foodTable.Columns.Contains("FoodCategoryID"))
                {
                    foodTable.Columns["FoodCategoryID"].DefaultValue = categoryID;
                }

                dgvFood.DataSource = foodTable;

                // Cấu hình hiển thị tiêu đề và độ rộng các cột
                ConfigureColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách món ăn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureColumns()
        {
            if (dgvFood.Columns["ID"] != null)
            {
                dgvFood.Columns["ID"].HeaderText = "Mã món";
                dgvFood.Columns["ID"].ReadOnly = true;
                dgvFood.Columns["ID"].Width = 80;
            }
            if (dgvFood.Columns["Name"] != null)
            {
                dgvFood.Columns["Name"].HeaderText = "Tên món ăn";
                dgvFood.Columns["Name"].Width = 220;
            }
            if (dgvFood.Columns["Unit"] != null)
            {
                dgvFood.Columns["Unit"].HeaderText = "Đơn vị tính";
                dgvFood.Columns["Unit"].Width = 100;
            }
            if (dgvFood.Columns["FoodCategoryID"] != null)
            {
                dgvFood.Columns["FoodCategoryID"].HeaderText = "Mã nhóm";
                dgvFood.Columns["FoodCategoryID"].ReadOnly = true;
                dgvFood.Columns["FoodCategoryID"].Width = 90;
            }
            if (dgvFood.Columns["Price"] != null)
            {
                dgvFood.Columns["Price"].HeaderText = "Đơn giá (VNĐ)";
                dgvFood.Columns["Price"].DefaultCellStyle.Format = "N0";
                dgvFood.Columns["Price"].Width = 130;
            }
            if (dgvFood.Columns["Notes"] != null)
            {
                dgvFood.Columns["Notes"].HeaderText = "Ghi chú";
                dgvFood.Columns["Notes"].Width = 200;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                dgvFood.EndEdit();

                if (adapter == null || foodTable == null) return;

                // Kiểm tra tính hợp lệ của dữ liệu trước khi lưu
                foreach (DataRow row in foodTable.Rows)
                {
                    if (row.RowState == DataRowState.Added || row.RowState == DataRowState.Modified)
                    {
                        if (row["Name"] == DBNull.Value || string.IsNullOrWhiteSpace(row["Name"].ToString()))
                        {
                            MessageBox.Show("Tên món ăn không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (row["Price"] == DBNull.Value)
                        {
                            MessageBox.Show("Đơn giá món ăn không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }

                // Dùng SqlCommandBuilder tự động phát sinh INSERT/UPDATE/DELETE
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                int rowsAffected = adapter.Update(foodTable);

                MessageBox.Show($"Lưu thành công! Đã cập nhật {rowsAffected} dòng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadFood(currentCategoryID);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi lưu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dgvFood.SelectedRows.Count > 0 ? dgvFood.SelectedRows[0] : dgvFood.CurrentRow;

            if (selectedRow == null || selectedRow.IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn một món ăn hợp lệ để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            object idValue = selectedRow.Cells["ID"].Value;

            // Nếu dòng mới trên lưới chưa lưu xuống CSDL
            if (idValue == null || idValue == DBNull.Value)
            {
                dgvFood.Rows.Remove(selectedRow);
                return;
            }

            int foodID = Convert.ToInt32(idValue);
            string foodName = selectedRow.Cells["Name"].Value?.ToString() ?? "";

            DialogResult dialogResult = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa món ăn '{foodName}' (Mã: {foodID}) không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dialogResult != DialogResult.Yes) return;

            try
            {
                string query = "DELETE FROM Food WHERE ID = @ID";
                SqlParameter[] parameters = { new SqlParameter("@ID", foodID) };

                int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Xóa món ăn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadFood(currentCategoryID);
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                {
                    MessageBox.Show("Không thể xóa món ăn này vì đã có hóa đơn liên quan trong hệ thống!", "Lỗi ràng buộc khóa ngoại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Lỗi cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
