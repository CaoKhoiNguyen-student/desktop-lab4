using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab4_Basic_Command
{
    public partial class BillDetailsForm : Form
    {
        private int currentInvoiceID;

        public BillDetailsForm(int invoiceID)
        {
            InitializeComponent();
            currentInvoiceID = invoiceID;
        }

        private void BillDetailsForm_Load(object sender, EventArgs e)
        {
            this.Text = "Chi tiết hóa đơn ID: " + currentInvoiceID;
            LoadBillDetails();
        }

        private void LoadBillDetails()
        {
            try
            {
                string query = @"SELECT f.Name AS [Tên món], 
                                        f.Unit AS [Đơn vị tính],
                                        f.Price AS [Đơn giá], 
                                        bd.Quantity AS [Số lượng], 
                                        (f.Price * bd.Quantity) AS [Thành tiền] 
                                 FROM Food f 
                                 INNER JOIN BillDetails bd ON bd.FoodID = f.ID 
                                 WHERE bd.InvoiceID = @InvoiceID";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@InvoiceID", currentInvoiceID)
                };

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

                if (dgvBillDetails.Columns["Tên món"] != null)
                {
                    dgvBillDetails.Columns["Tên món"].Width = 200;
                }
                if (dgvBillDetails.Columns["Đơn vị tính"] != null)
                {
                    dgvBillDetails.Columns["Đơn vị tính"].Width = 90;
                }
                if (dgvBillDetails.Columns["Đơn giá"] != null)
                {
                    dgvBillDetails.Columns["Đơn giá"].DefaultCellStyle.Format = "N0";
                    dgvBillDetails.Columns["Đơn giá"].Width = 110;
                }
                if (dgvBillDetails.Columns["Số lượng"] != null)
                {
                    dgvBillDetails.Columns["Số lượng"].Width = 80;
                }
                if (dgvBillDetails.Columns["Thành tiền"] != null)
                {
                    dgvBillDetails.Columns["Thành tiền"].DefaultCellStyle.Format = "N0";
                    dgvBillDetails.Columns["Thành tiền"].Width = 120;
                }

                lblTotal.Text = $"Tổng tiền chi tiết: {total:N0} VNĐ";

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Hóa đơn này chưa có chi tiết món ăn nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải chi tiết hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
