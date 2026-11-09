using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab4_Basic_Command
{
    public partial class TableBillsForm : Form
    {
        private int currentTableID;
        private string currentTableName;

        // Lớp đại diện cho mục trong ListBox
        private class BillDateItem
        {
            public int BillID { get; set; }
            public string BillName { get; set; }
            public DateTime? CheckoutDate { get; set; }
            public string DisplayText { get; set; }

            public override string ToString()
            {
                return DisplayText;
            }
        }

        public TableBillsForm(int tableID, string tableName)
        {
            InitializeComponent();
            currentTableID = tableID;
            currentTableName = tableName;
        }

        private void TableBillsForm_Load(object sender, EventArgs e)
        {
            this.Text = $"Danh mục hóa đơn - Bàn: {currentTableName} (Mã: {currentTableID})";
            LoadBillDates();
        }

        private void LoadBillDates()
        {
            try
            {
                lbDates.Items.Clear();

                string query = @"SELECT ID, Name, CheckoutDate, Amount, Account 
                                 FROM Bills 
                                 WHERE TableID = @TableID 
                                 ORDER BY ISNULL(CheckoutDate, '1900-01-01') DESC, ID DESC";

                SqlParameter[] parameters = { new SqlParameter("@TableID", currentTableID) };
                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

                foreach (DataRow row in dt.Rows)
                {
                    int billId = Convert.ToInt32(row["ID"]);
                    string billName = row["Name"].ToString();
                    DateTime? date = row["CheckoutDate"] != DBNull.Value ? Convert.ToDateTime(row["CheckoutDate"]) : (DateTime?)null;

                    string dateText = date.HasValue ? date.Value.ToString("dd/MM/yyyy HH:mm") : "(Chưa thanh toán)";
                    string displayText = $"{dateText} - HĐ #{billId}: {billName}";

                    lbDates.Items.Add(new BillDateItem
                    {
                        BillID = billId,
                        BillName = billName,
                        CheckoutDate = date,
                        DisplayText = displayText
                    });
                }

                if (lbDates.Items.Count > 0)
                {
                    lbDates.SelectedIndex = 0;
                }
                else
                {
                    lblBillInfo.Text = "Bàn này chưa có hóa đơn nào!";
                    lblBillTotal.Text = "Tổng tiền: 0 VNĐ";
                    dgvBillDetails.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải ngày lập hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lbDates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbDates.SelectedItem is BillDateItem item)
            {
                LoadBillDetails(item.BillID, item.BillName, item.CheckoutDate);
            }
        }

        private void LoadBillDetails(int invoiceID, string billName, DateTime? date)
        {
            try
            {
                string dateStr = date.HasValue ? date.Value.ToString("dd/MM/yyyy HH:mm") : "Chưa thanh toán";
                lblBillInfo.Text = $"HĐ #{invoiceID} - {billName} | Ngày: {dateStr}";

                string query = @"SELECT f.Name AS [Tên món], 
                                        f.Unit AS [Đơn vị tính],
                                        f.Price AS [Đơn giá], 
                                        bd.Quantity AS [Số lượng], 
                                        (f.Price * bd.Quantity) AS [Thành tiền] 
                                 FROM Food f 
                                 INNER JOIN BillDetails bd ON bd.FoodID = f.ID 
                                 WHERE bd.InvoiceID = @InvoiceID";

                SqlParameter[] parameters = { new SqlParameter("@InvoiceID", invoiceID) };
                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

                double total = 0;
                foreach (DataRow row in dt.Rows)
                {
                    if (row["Thành tiền"] != DBNull.Value)
                    {
                        total += Convert.ToDouble(row["Thành tiền"]);
                    }
                }

                dgvBillDetails.DataSource = dt;

                if (dgvBillDetails.Columns["Tên món"] != null) dgvBillDetails.Columns["Tên món"].Width = 180;
                if (dgvBillDetails.Columns["Đơn vị tính"] != null) dgvBillDetails.Columns["Đơn vị tính"].Width = 90;
                if (dgvBillDetails.Columns["Đơn giá"] != null)
                {
                    dgvBillDetails.Columns["Đơn giá"].DefaultCellStyle.Format = "N0";
                    dgvBillDetails.Columns["Đơn giá"].Width = 100;
                }
                if (dgvBillDetails.Columns["Số lượng"] != null) dgvBillDetails.Columns["Số lượng"].Width = 80;
                if (dgvBillDetails.Columns["Thành tiền"] != null)
                {
                    dgvBillDetails.Columns["Thành tiền"].DefaultCellStyle.Format = "N0";
                    dgvBillDetails.Columns["Thành tiền"].Width = 110;
                }

                lblBillTotal.Text = $"Tổng tiền chi tiết: {total:N0} VNĐ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải chi tiết sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
