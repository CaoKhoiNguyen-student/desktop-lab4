using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab4_Basic_Command
{
    public partial class BillsForm : Form
    {
        public BillsForm()
        {
            InitializeComponent();
        }

        private void BillsForm_Load(object sender, EventArgs e)
        {
            dtpFromDate.Value = DateTime.Today.AddMonths(-1);
            dtpToDate.Value = DateTime.Today;
            LoadBills();
        }

        private void LoadBills()
        {
            try
            {
                string fromDate = dtpFromDate.Value.ToString("yyyy-MM-dd 00:00:00");
                string toDate = dtpToDate.Value.ToString("yyyy-MM-dd 23:59:59");
                bool allDates = chkAllDates.Checked;

                string query = @"
                    SELECT b.ID, 
                           b.Name, 
                           ISNULL(t.Name, 'Mang về') AS TableName, 
                           b.Amount, 
                           ISNULL(b.Discount, 0) AS Discount, 
                           ISNULL(b.Tax, 0) AS Tax,
                           b.Status, 
                           b.CheckoutDate, 
                           b.Account
                    FROM Bills b
                    LEFT JOIN [Table] t ON b.TableID = t.ID
                    WHERE (@AllDates = 1) 
                       OR (b.CheckoutDate IS NOT NULL AND b.CheckoutDate >= @FromDate AND b.CheckoutDate <= @ToDate)
                    ORDER BY b.ID DESC";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@FromDate", fromDate),
                    new SqlParameter("@ToDate", toDate),
                    new SqlParameter("@AllDates", allDates ? 1 : 0)
                };

                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

                dt.Columns.Add("TotalPay", typeof(double));
                dt.Columns.Add("StatusText", typeof(string));

                double totalAmount = 0;
                double totalDiscount = 0;
                double totalActualPay = 0;

                foreach (DataRow row in dt.Rows)
                {
                    double amount = row["Amount"] != DBNull.Value ? Convert.ToDouble(row["Amount"]) : 0;
                    double discountRate = row["Discount"] != DBNull.Value ? Convert.ToDouble(row["Discount"]) : 0;
                    double taxRate = row["Tax"] != DBNull.Value ? Convert.ToDouble(row["Tax"]) : 0;
                    bool status = row["Status"] != DBNull.Value && Convert.ToBoolean(row["Status"]);

                    double discountMoney = amount * discountRate;
                    double actualPay = (amount - discountMoney) + (amount * taxRate);

                    row["TotalPay"] = actualPay;
                    row["StatusText"] = status ? "Đã thanh toán" : "Chưa thanh toán";

                    totalAmount += amount;
                    totalDiscount += discountMoney;
                    totalActualPay += actualPay;
                }

                dgvBills.DataSource = dt;
                ConfigureColumns();

                // Cập nhật 3 thông số tổng kết
                lblTotalAmount.Text = $"Tổng tiền chưa giảm: {totalAmount:N0} VNĐ";
                lblTotalDiscount.Text = $"Tổng tiền giảm giá: {totalDiscount:N0} VNĐ";
                lblActualPay.Text = $"Thực thu: {totalActualPay:N0} VNĐ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureColumns()
        {
            if (dgvBills.Columns["ID"] != null)
            {
                dgvBills.Columns["ID"].HeaderText = "Mã HĐ";
                dgvBills.Columns["ID"].Width = 70;
            }
            if (dgvBills.Columns["Name"] != null)
            {
                dgvBills.Columns["Name"].HeaderText = "Tên hóa đơn";
                dgvBills.Columns["Name"].Width = 150;
            }
            if (dgvBills.Columns["TableName"] != null)
            {
                dgvBills.Columns["TableName"].HeaderText = "Bàn";
                dgvBills.Columns["TableName"].Width = 80;
            }
            if (dgvBills.Columns["Amount"] != null)
            {
                dgvBills.Columns["Amount"].HeaderText = "Tiền hàng (VNĐ)";
                dgvBills.Columns["Amount"].DefaultCellStyle.Format = "N0";
                dgvBills.Columns["Amount"].Width = 120;
            }
            if (dgvBills.Columns["Discount"] != null)
            {
                dgvBills.Columns["Discount"].HeaderText = "Giảm giá";
                dgvBills.Columns["Discount"].DefaultCellStyle.Format = "P0";
                dgvBills.Columns["Discount"].Width = 80;
            }
            if (dgvBills.Columns["Tax"] != null)
            {
                dgvBills.Columns["Tax"].HeaderText = "Thuế";
                dgvBills.Columns["Tax"].DefaultCellStyle.Format = "P0";
                dgvBills.Columns["Tax"].Width = 70;
            }
            if (dgvBills.Columns["TotalPay"] != null)
            {
                dgvBills.Columns["TotalPay"].HeaderText = "Thực thu (VNĐ)";
                dgvBills.Columns["TotalPay"].DefaultCellStyle.Format = "N0";
                dgvBills.Columns["TotalPay"].Width = 120;
            }
            if (dgvBills.Columns["StatusText"] != null)
            {
                dgvBills.Columns["StatusText"].HeaderText = "Trạng thái";
                dgvBills.Columns["StatusText"].Width = 110;
            }
            if (dgvBills.Columns["Status"] != null)
            {
                dgvBills.Columns["Status"].Visible = false;
            }
            if (dgvBills.Columns["CheckoutDate"] != null)
            {
                dgvBills.Columns["CheckoutDate"].HeaderText = "Ngày thanh toán";
                dgvBills.Columns["CheckoutDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                dgvBills.Columns["CheckoutDate"].Width = 140;
            }
            if (dgvBills.Columns["Account"] != null)
            {
                dgvBills.Columns["Account"].HeaderText = "Người lập";
                dgvBills.Columns["Account"].Width = 100;
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadBills();
        }

        private void chkAllDates_CheckedChanged(object sender, EventArgs e)
        {
            dtpFromDate.Enabled = !chkAllDates.Checked;
            dtpToDate.Enabled = !chkAllDates.Checked;
            LoadBills();
        }

        private void dgvBills_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            object idObj = dgvBills.Rows[e.RowIndex].Cells["ID"].Value;
            if (idObj != null && idObj != DBNull.Value)
            {
                int invoiceId = Convert.ToInt32(idObj);
                BillDetailsForm frm = new BillDetailsForm(invoiceId);
                frm.ShowDialog();
            }
        }
    }
}
