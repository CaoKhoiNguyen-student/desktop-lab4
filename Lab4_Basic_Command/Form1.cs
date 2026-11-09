using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab4_Basic_Command
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            lvCategory.FullRowSelect = true;
            if (cboType.Items.Count > 0)
            {
                cboType.SelectedIndex = 0;
            }
        }

        private void ClearInputs()
        {
            txtID.Clear();
            txtName.Clear();
            cboType.SelectedIndex = 0;
            btnCapNhat.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT ID, Name, Type FROM Category ORDER BY ID";
                DataTable dt = DatabaseHelper.ExecuteQuery(query);

                lvCategory.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row["ID"].ToString());
                    item.SubItems.Add(row["Name"].ToString());

                    string typeStr = row["Type"].ToString() == "0" ? "0 - Thức uống" : "1 - Đồ ăn";
                    item.SubItems.Add(typeStr);

                    lvCategory.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Vui lòng nhập tên nhóm món ăn!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            int type = cboType.SelectedIndex == 1 ? 1 : 0;

            try
            {
                string query = "INSERT INTO Category(Name, [Type]) VALUES (@Name, @Type)";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Name", name),
                    new SqlParameter("@Type", type)
                };

                int rows = DatabaseHelper.ExecuteNonQuery(query, parameters);
                if (rows > 0)
                {
                    MessageBox.Show("Thêm nhóm món ăn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnLoad.PerformClick();
                    ClearInputs();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm nhóm món: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lvCategory_Click(object sender, EventArgs e)
        {
            if (lvCategory.SelectedItems.Count == 0) return;

            ListViewItem item = lvCategory.SelectedItems[0];
            txtID.Text = item.Text;
            txtName.Text = item.SubItems[1].Text;

            string typeText = item.SubItems[2].Text;
            cboType.SelectedIndex = typeText.StartsWith("1") ? 1 : 0;

            btnCapNhat.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Vui lòng chọn nhóm món ăn cần cập nhật!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string name = txtName.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Vui lòng nhập tên nhóm món ăn!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            int type = cboType.SelectedIndex == 1 ? 1 : 0;
            int id = Convert.ToInt32(txtID.Text);

            try
            {
                string query = "UPDATE Category SET Name = @Name, [Type] = @Type WHERE ID = @ID";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Name", name),
                    new SqlParameter("@Type", type),
                    new SqlParameter("@ID", id)
                };

                int rows = DatabaseHelper.ExecuteNonQuery(query, parameters);
                if (rows > 0)
                {
                    MessageBox.Show("Cập nhật nhóm món ăn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnLoad.PerformClick();
                    ClearInputs();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật nhóm món: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Vui lòng chọn nhóm món ăn cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(txtID.Text);
            string name = txtName.Text;

            DialogResult dialogResult = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa nhóm món ăn '{name}' (Mã: {id}) không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dialogResult != DialogResult.Yes) return;

            try
            {
                string query = "DELETE FROM Category WHERE ID = @ID";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@ID", id)
                };

                int rows = DatabaseHelper.ExecuteNonQuery(query, parameters);
                if (rows > 0)
                {
                    MessageBox.Show("Xóa nhóm món ăn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnLoad.PerformClick();
                    ClearInputs();
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                {
                    MessageBox.Show(
                        "Không thể xóa nhóm món ăn này vì hiện đang có các món ăn thuộc nhóm này trong cơ sở dữ liệu!\n" +
                        "Vui lòng xóa các món ăn thuộc nhóm trước khi xóa nhóm.",
                        "Lỗi ràng buộc khóa ngoại",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Lỗi cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa nhóm món: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsmDelete_Click(object sender, EventArgs e)
        {
            if (lvCategory.SelectedItems.Count > 0)
            {
                btnXoa.PerformClick();
            }
        }

        private void tsmViewFood_Click(object sender, EventArgs e)
        {
            int categoryId = 0;
            if (lvCategory.SelectedItems.Count > 0)
            {
                categoryId = Convert.ToInt32(lvCategory.SelectedItems[0].Text);
            }
            else if (!string.IsNullOrWhiteSpace(txtID.Text))
            {
                categoryId = Convert.ToInt32(txtID.Text);
            }

            if (categoryId > 0)
            {
                FoodForm foodForm = new FoodForm();
                foodForm.Show(this);
                foodForm.LoadFood(categoryId);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhóm món ăn để xem danh sách món!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
