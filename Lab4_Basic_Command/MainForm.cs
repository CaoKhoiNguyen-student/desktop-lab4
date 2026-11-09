using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab4_Basic_Command
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            cboTableStatus.SelectedIndex = 0;
            LoadTables();
        }

        private void LoadTables()
        {
            try
            {
                lvTables.Items.Clear();

                string query = "SELECT ID, Name, Capacity, Status FROM [Table] ORDER BY ID";
                DataTable dt = DatabaseHelper.ExecuteQuery(query);

                foreach (DataRow row in dt.Rows)
                {
                    int id = Convert.ToInt32(row["ID"]);
                    string name = row["Name"] != DBNull.Value ? row["Name"].ToString() : "";
                    int capacity = row["Capacity"] != DBNull.Value ? Convert.ToInt32(row["Capacity"]) : 0;
                    int status = Convert.ToInt32(row["Status"]);

                    ListViewItem item = new ListViewItem(id.ToString());
                    item.SubItems.Add(name);
                    item.SubItems.Add(capacity.ToString());

                    string statusStr = status == 1 ? "1 - Có khách" : "0 - Bàn trống";
                    item.SubItems.Add(statusStr);

                    lvTables.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách bàn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReloadTables_Click(object sender, EventArgs e)
        {
            LoadTables();
        }

        private void lvTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvTables.SelectedItems.Count == 0) return;

            ListViewItem item = lvTables.SelectedItems[0];
            int tableId = Convert.ToInt32(item.Text);

            txtTableID.Text = item.Text;
            txtTableName.Text = item.SubItems[1].Text;
            if (decimal.TryParse(item.SubItems[2].Text, out decimal cap))
            {
                nudCapacity.Value = cap > 0 ? cap : 4;
            }

            string statusText = item.SubItems[3].Text;
            cboTableStatus.SelectedIndex = statusText.StartsWith("1") ? 1 : 0;

            // Nạp hóa đơn hiện tại của bàn
            LoadCurrentBillOfTable(tableId, item.SubItems[1].Text);
        }

        private void LoadCurrentBillOfTable(int tableId, string tableName)
        {
            try
            {
                // Tìm hóa đơn chưa thanh toán (Status = 0)
                string queryBill = @"SELECT TOP 1 ID, Name, Account 
                                     FROM Bills 
                                     WHERE TableID = @TableID AND Status = 0 
                                     ORDER BY ID DESC";
                SqlParameter[] pBill = { new SqlParameter("@TableID", tableId) };
                DataTable dtBill = DatabaseHelper.ExecuteQuery(queryBill, pBill);

                int currentBillId = 0;
                string billName = "";
                string account = "";
                bool isUnpaid = false;

                if (dtBill.Rows.Count > 0)
                {
                    DataRow r = dtBill.Rows[0];
                    currentBillId = Convert.ToInt32(r["ID"]);
                    billName = r["Name"].ToString();
                    account = r["Account"].ToString();
                    isUnpaid = true;
                }
                else
                {
                    // Nếu không có hóa đơn chưa thanh toán, lấy hóa đơn gần nhất
                    string queryLatest = @"SELECT TOP 1 ID, Name, Account 
                                           FROM Bills 
                                           WHERE TableID = @TableID 
                                           ORDER BY ID DESC";
                    SqlParameter[] pLatest = { new SqlParameter("@TableID", tableId) };
                    DataTable dtLatest = DatabaseHelper.ExecuteQuery(queryLatest, pLatest);

                    if (dtLatest.Rows.Count > 0)
                    {
                        DataRow r = dtLatest.Rows[0];
                        currentBillId = Convert.ToInt32(r["ID"]);
                        billName = r["Name"].ToString();
                        account = r["Account"].ToString();
                        isUnpaid = false;
                    }
                }

                if (currentBillId > 0)
                {
                    string statusLabel = isUnpaid ? "Chưa thanh toán" : "Đã thanh toán";
                    lblCurrentBillInfo.Text = $"Bàn: {tableName} | HĐ #{currentBillId}: {billName} | NV: {account} ({statusLabel})";

                    string queryDetails = @"SELECT f.Name AS [Tên món], 
                                                   f.Unit AS [ĐVT], 
                                                   f.Price AS [Đơn giá], 
                                                   bd.Quantity AS [Số lượng], 
                                                   (f.Price * bd.Quantity) AS [Thành tiền] 
                                            FROM Food f 
                                            INNER JOIN BillDetails bd ON bd.FoodID = f.ID 
                                            WHERE bd.InvoiceID = @InvoiceID";
                    SqlParameter[] pDetails = { new SqlParameter("@InvoiceID", currentBillId) };
                    DataTable dtDetails = DatabaseHelper.ExecuteQuery(queryDetails, pDetails);

                    double total = 0;
                    foreach (DataRow r in dtDetails.Rows)
                    {
                        if (r["Thành tiền"] != DBNull.Value) total += Convert.ToDouble(r["Thành tiền"]);
                    }

                    dgvCurrentBillDetails.DataSource = dtDetails;

                    if (dgvCurrentBillDetails.Columns["Tên món"] != null) dgvCurrentBillDetails.Columns["Tên món"].Width = 180;
                    if (dgvCurrentBillDetails.Columns["ĐVT"] != null) dgvCurrentBillDetails.Columns["ĐVT"].Width = 70;
                    if (dgvCurrentBillDetails.Columns["Đơn giá"] != null)
                    {
                        dgvCurrentBillDetails.Columns["Đơn giá"].DefaultCellStyle.Format = "N0";
                        dgvCurrentBillDetails.Columns["Đơn giá"].Width = 100;
                    }
                    if (dgvCurrentBillDetails.Columns["Số lượng"] != null) dgvCurrentBillDetails.Columns["Số lượng"].Width = 80;
                    if (dgvCurrentBillDetails.Columns["Thành tiền"] != null)
                    {
                        dgvCurrentBillDetails.Columns["Thành tiền"].DefaultCellStyle.Format = "N0";
                        dgvCurrentBillDetails.Columns["Thành tiền"].Width = 110;
                    }

                    lblCurrentBillTotal.Text = $"Tạm tính chi tiết: {total:N0} VNĐ";
                }
                else
                {
                    lblCurrentBillInfo.Text = $"Bàn: {tableName} | Hiện chưa có hóa đơn nào.";
                    lblCurrentBillTotal.Text = "Tạm tính: 0 VNĐ";
                    dgvCurrentBillDetails.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải hóa đơn hiện tại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            string name = txtTableName.Text.Trim();
            int capacity = (int)nudCapacity.Value;
            int status = cboTableStatus.SelectedIndex == 1 ? 1 : 0;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Vui lòng nhập tên bàn!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTableName.Focus();
                return;
            }

            try
            {
                string query = "INSERT INTO [Table](Name, Capacity, Status) VALUES (@Name, @Capacity, @Status)";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Name", name),
                    new SqlParameter("@Capacity", capacity),
                    new SqlParameter("@Status", status)
                };

                int rows = DatabaseHelper.ExecuteNonQuery(query, parameters);
                if (rows > 0)
                {
                    MessageBox.Show("Thêm bàn mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnClearTable_Click(null, null);
                    LoadTables();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm bàn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateTable_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTableID.Text))
            {
                MessageBox.Show("Vui lòng chọn bàn cần cập nhật!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int tableId = Convert.ToInt32(txtTableID.Text);
            string name = txtTableName.Text.Trim();
            int capacity = (int)nudCapacity.Value;
            int status = cboTableStatus.SelectedIndex == 1 ? 1 : 0;

            try
            {
                string query = "UPDATE [Table] SET Name = @Name, Capacity = @Capacity, Status = @Status WHERE ID = @ID";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Name", name),
                    new SqlParameter("@Capacity", capacity),
                    new SqlParameter("@Status", status),
                    new SqlParameter("@ID", tableId)
                };

                int rows = DatabaseHelper.ExecuteNonQuery(query, parameters);
                if (rows > 0)
                {
                    MessageBox.Show("Cập nhật thông tin bàn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTables();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật bàn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTableID.Text))
            {
                MessageBox.Show("Vui lòng chọn bàn cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int tableId = Convert.ToInt32(txtTableID.Text);
            string name = txtTableName.Text;

            DialogResult dr = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa bàn '{name}' (Mã: {tableId}) không?",
                "Xác nhận xóa bàn",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dr != DialogResult.Yes) return;

            try
            {
                string query = "DELETE FROM [Table] WHERE ID = @ID";
                SqlParameter[] parameters = { new SqlParameter("@ID", tableId) };

                int rows = DatabaseHelper.ExecuteNonQuery(query, parameters);
                if (rows > 0)
                {
                    MessageBox.Show("Xóa bàn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnClearTable_Click(null, null);
                    LoadTables();
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                {
                    MessageBox.Show("Không thể xóa bàn này vì đã có hóa đơn liên quan trong hệ thống!", "Lỗi ràng buộc khóa ngoại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Lỗi cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa bàn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearTable_Click(object sender, EventArgs e)
        {
            txtTableID.Clear();
            txtTableName.Clear();
            nudCapacity.Value = 4;
            cboTableStatus.SelectedIndex = 0;
            dgvCurrentBillDetails.DataSource = null;
            lblCurrentBillInfo.Text = "Chọn một bàn để xem hóa đơn hiện tại...";
            lblCurrentBillTotal.Text = "Tạm tính: 0 VNĐ";
        }

        private void tsmDeleteTable_Click(object sender, EventArgs e)
        {
            if (lvTables.SelectedItems.Count > 0)
            {
                btnDeleteTable.PerformClick();
            }
        }

        private void tsmViewTableBills_Click(object sender, EventArgs e)
        {
            if (lvTables.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một bàn để xem danh mục hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int tableId = Convert.ToInt32(lvTables.SelectedItems[0].Text);
            string tableName = lvTables.SelectedItems[0].SubItems[1].Text;

            TableBillsForm frm = new TableBillsForm(tableId, tableName);
            frm.ShowDialog();
        }

        private void tsmViewTableHistory_Click(object sender, EventArgs e)
        {
            if (lvTables.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một bàn để xem nhật ký hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int tableId = Convert.ToInt32(lvTables.SelectedItems[0].Text);
            string tableName = lvTables.SelectedItems[0].SubItems[1].Text;

            BillHistoryForm frm = new BillHistoryForm(tableId, tableName);
            frm.ShowDialog();
        }

        private void tsmMenuCategory_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
        }

        private void tsmMenuBills_Click(object sender, EventArgs e)
        {
            BillsForm frm = new BillsForm();
            frm.Show();
        }

        private void tsmMenuAccounts_Click(object sender, EventArgs e)
        {
            AccountManager frm = new AccountManager();
            frm.Show();
        }

        private void tsmMenuAllHistory_Click(object sender, EventArgs e)
        {
            BillHistoryForm frm = new BillHistoryForm(null, "");
            frm.Show();
        }

        private void tsmThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
