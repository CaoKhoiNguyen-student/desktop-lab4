using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab4_Basic_Command
{
    public partial class BillHistoryForm : Form
    {
        private int? currentTableID;
        private string currentTableName;

        public BillHistoryForm(int? tableID = null, string tableName = "")
        {
            InitializeComponent();
            currentTableID = tableID;
            currentTableName = tableName;
        }

        private void BillHistoryForm_Load(object sender, EventArgs e)
        {
            if (currentTableID.HasValue)
            {
                this.Text = $"Nhật ký hóa đơn - Bàn: {currentTableName} (Mã: {currentTableID.Value})";
            }
            else
            {
                this.Text = "Nhật ký hóa đơn - Toàn hệ thống nhà hàng";
            }

            LoadHistory();
        }

        private void LoadHistory()
        {
            try
            {
                string query = @"
                    SELECT b.ID, 
                           b.Name, 
                           ISNULL(t.Name, 'Mang về') AS TableName, 
                           b.CheckoutDate, 
                           b.Account, 
                           b.Amount, 
                           ISNULL(b.Discount, 0) AS Discount, 
                           ISNULL(b.Tax, 0) AS Tax,
                           b.Status
                    FROM Bills b
                    LEFT JOIN [Table] t ON b.TableID = t.ID
                    WHERE (@TableID IS NULL OR b.TableID = @TableID)
                    ORDER BY ISNULL(b.CheckoutDate, '1900-01-01') DESC, b.ID DESC";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@TableID", currentTableID.HasValue ? (object)currentTableID.Value : DBNull.Value)
                };

                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

                dt.Columns.Add("DiscountMoney", typeof(double));
                dt.Columns.Add("TaxMoney", typeof(double));
                dt.Columns.Add("TotalPay", typeof(double));
                dt.Columns.Add("StatusText", typeof(string));

                int count = dt.Rows.Count;
                double sumAmount = 0;
                double sumDiscount = 0;
                double sumTax = 0;
                double sumActual = 0;

                foreach (DataRow row in dt.Rows)
                {
                    double amount = row["Amount"] != DBNull.Value ? Convert.ToDouble(row["Amount"]) : 0;
                    double discountRate = row["Discount"] != DBNull.Value ? Convert.ToDouble(row["Discount"]) : 0;
                    double taxRate = row["Tax"] != DBNull.Value ? Convert.ToDouble(row["Tax"]) : 0;
                    bool status = row["Status"] != DBNull.Value && Convert.ToBoolean(row["Status"]);

                    double discountMoney = amount * discountRate;
                    double taxMoney = amount * taxRate;
                    double actualPay = (amount - discountMoney) + taxMoney;

                    row["DiscountMoney"] = discountMoney;
                    row["TaxMoney"] = taxMoney;
                    row["TotalPay"] = actualPay;
                    row["StatusText"] = status ? "Đã thanh toán" : "Chưa thanh toán";

                    sumAmount += amount;
                    sumDiscount += discountMoney;
                    sumTax += taxMoney;
                    sumActual += actualPay;
                }

                dgvHistory.DataSource = dt;
                ConfigureColumns();

                // Hiển thị tóm tắt
                lblBillCount.Text = $"Số lượng hóa đơn: {count}";
                lblTotalAmount.Text = $"Tổng số tiền: {sumAmount:N0} VNĐ";
                lblTotalDiscount.Text = $"Tổng giảm giá: {sumDiscount:N0} VNĐ";
                lblTotalTax.Text = $"Tổng thuế: {sumTax:N0} VNĐ";
                lblActualPay.Text = $"Thực thu: {sumActual:N0} VNĐ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải nhật ký hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureColumns()
        {
            if (dgvHistory.Columns["ID"] != null)
            {
                dgvHistory.Columns["ID"].HeaderText = "Mã HĐ";
                dgvHistory.Columns["ID"].Width = 70;
            }
            if (dgvHistory.Columns["Name"] != null)
            {
                dgvHistory.Columns["Name"].HeaderText = "Tên hóa đơn";
                dgvHistory.Columns["Name"].Width = 140;
            }
            if (dgvHistory.Columns["TableName"] != null)
            {
                dgvHistory.Columns["TableName"].HeaderText = "Bàn";
                dgvHistory.Columns["TableName"].Width = 70;
            }
            if (dgvHistory.Columns["CheckoutDate"] != null)
            {
                dgvHistory.Columns["CheckoutDate"].HeaderText = "Ngày lập / Thanh toán";
                dgvHistory.Columns["CheckoutDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                dgvHistory.Columns["CheckoutDate"].Width = 150;
            }
            if (dgvHistory.Columns["Account"] != null)
            {
                dgvHistory.Columns["Account"].HeaderText = "Người lập";
                dgvHistory.Columns["Account"].Width = 100;
            }
            if (dgvHistory.Columns["Amount"] != null)
            {
                dgvHistory.Columns["Amount"].HeaderText = "Tiền hàng (VNĐ)";
                dgvHistory.Columns["Amount"].DefaultCellStyle.Format = "N0";
                dgvHistory.Columns["Amount"].Width = 120;
            }
            if (dgvHistory.Columns["Discount"] != null)
            {
                dgvHistory.Columns["Discount"].HeaderText = "Giảm (%)";
                dgvHistory.Columns["Discount"].DefaultCellStyle.Format = "P0";
                dgvHistory.Columns["Discount"].Width = 80;
            }
            if (dgvHistory.Columns["DiscountMoney"] != null)
            {
                dgvHistory.Columns["DiscountMoney"].HeaderText = "Tiền giảm (VNĐ)";
                dgvHistory.Columns["DiscountMoney"].DefaultCellStyle.Format = "N0";
                dgvHistory.Columns["DiscountMoney"].Width = 110;
            }
            if (dgvHistory.Columns["Tax"] != null)
            {
                dgvHistory.Columns["Tax"].HeaderText = "Thuế (%)";
                dgvHistory.Columns["Tax"].DefaultCellStyle.Format = "P0";
                dgvHistory.Columns["Tax"].Width = 70;
            }
            if (dgvHistory.Columns["TotalPay"] != null)
            {
                dgvHistory.Columns["TotalPay"].HeaderText = "Thực thu (VNĐ)";
                dgvHistory.Columns["TotalPay"].DefaultCellStyle.Format = "N0";
                dgvHistory.Columns["TotalPay"].Width = 120;
            }
            if (dgvHistory.Columns["StatusText"] != null)
            {
                dgvHistory.Columns["StatusText"].HeaderText = "Trạng thái";
                dgvHistory.Columns["StatusText"].Width = 110;
            }
            if (dgvHistory.Columns["Status"] != null) dgvHistory.Columns["Status"].Visible = false;
            if (dgvHistory.Columns["TaxMoney"] != null) dgvHistory.Columns["TaxMoney"].Visible = false;
        }
    }
}
