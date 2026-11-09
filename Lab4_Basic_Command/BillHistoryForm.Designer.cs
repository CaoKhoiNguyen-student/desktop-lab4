namespace Lab4_Basic_Command
{
    partial class BillHistoryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelSummary = new Panel();
            lblActualPay = new Label();
            lblTotalTax = new Label();
            lblTotalDiscount = new Label();
            lblTotalAmount = new Label();
            lblBillCount = new Label();
            dgvHistory = new DataGridView();
            panelSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).BeginInit();
            SuspendLayout();
            // 
            // panelSummary
            // 
            panelSummary.Controls.Add(lblActualPay);
            panelSummary.Controls.Add(lblTotalTax);
            panelSummary.Controls.Add(lblTotalDiscount);
            panelSummary.Controls.Add(lblTotalAmount);
            panelSummary.Controls.Add(lblBillCount);
            panelSummary.Dock = DockStyle.Top;
            panelSummary.Location = new Point(0, 0);
            panelSummary.Name = "panelSummary";
            panelSummary.Size = new Size(1000, 60);
            panelSummary.TabIndex = 0;
            // 
            // lblActualPay
            // 
            lblActualPay.AutoSize = true;
            lblActualPay.Location = new Point(680, 35);
            lblActualPay.Name = "lblActualPay";
            lblActualPay.Size = new Size(93, 15);
            lblActualPay.TabIndex = 4;
            lblActualPay.Text = "Thực thu: 0 VNĐ";
            // 
            // lblTotalTax
            // 
            lblTotalTax.AutoSize = true;
            lblTotalTax.Location = new Point(350, 35);
            lblTotalTax.Name = "lblTotalTax";
            lblTotalTax.Size = new Size(100, 15);
            lblTotalTax.TabIndex = 3;
            lblTotalTax.Text = "Tổng thuế: 0 VNĐ";
            // 
            // lblTotalDiscount
            // 
            lblTotalDiscount.AutoSize = true;
            lblTotalDiscount.Location = new Point(20, 35);
            lblTotalDiscount.Name = "lblTotalDiscount";
            lblTotalDiscount.Size = new Size(122, 15);
            lblTotalDiscount.TabIndex = 2;
            lblTotalDiscount.Text = "Tổng giảm giá: 0 VNĐ";
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Location = new Point(350, 10);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(115, 15);
            lblTotalAmount.TabIndex = 1;
            lblTotalAmount.Text = "Tổng số tiền: 0 VNĐ";
            // 
            // lblBillCount
            // 
            lblBillCount.AutoSize = true;
            lblBillCount.Location = new Point(20, 10);
            lblBillCount.Name = "lblBillCount";
            lblBillCount.Size = new Size(111, 15);
            lblBillCount.TabIndex = 0;
            lblBillCount.Text = "Số lượng hóa đơn: 0";
            // 
            // dgvHistory
            // 
            dgvHistory.AllowUserToAddRows = false;
            dgvHistory.AllowUserToDeleteRows = false;
            dgvHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistory.Dock = DockStyle.Fill;
            dgvHistory.Location = new Point(0, 60);
            dgvHistory.MultiSelect = false;
            dgvHistory.Name = "dgvHistory";
            dgvHistory.ReadOnly = true;
            dgvHistory.RowHeadersWidth = 50;
            dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistory.Size = new Size(1000, 440);
            dgvHistory.TabIndex = 1;
            // 
            // BillHistoryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 500);
            Controls.Add(dgvHistory);
            Controls.Add(panelSummary);
            Name = "BillHistoryForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nhật ký hóa đơn";
            Load += BillHistoryForm_Load;
            panelSummary.ResumeLayout(false);
            panelSummary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSummary;
        private Label lblTotalAmount;
        private Label lblBillCount;
        private Label lblActualPay;
        private Label lblTotalTax;
        private Label lblTotalDiscount;
        private DataGridView dgvHistory;
    }
}
