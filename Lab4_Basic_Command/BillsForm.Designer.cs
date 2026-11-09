namespace Lab4_Basic_Command
{
    partial class BillsForm
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
            panelTop = new Panel();
            chkAllDates = new CheckBox();
            btnFilter = new Button();
            dtpToDate = new DateTimePicker();
            label2 = new Label();
            dtpFromDate = new DateTimePicker();
            label1 = new Label();
            dgvBills = new DataGridView();
            panelBottom = new Panel();
            lblActualPay = new Label();
            lblTotalDiscount = new Label();
            lblTotalAmount = new Label();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBills).BeginInit();
            panelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.Controls.Add(chkAllDates);
            panelTop.Controls.Add(btnFilter);
            panelTop.Controls.Add(dtpToDate);
            panelTop.Controls.Add(label2);
            panelTop.Controls.Add(dtpFromDate);
            panelTop.Controls.Add(label1);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1000, 50);
            panelTop.TabIndex = 0;
            // 
            // chkAllDates
            // 
            chkAllDates.AutoSize = true;
            chkAllDates.Location = new Point(600, 15);
            chkAllDates.Name = "chkAllDates";
            chkAllDates.Size = new Size(81, 19);
            chkAllDates.TabIndex = 4;
            chkAllDates.Text = "Xem tất cả";
            chkAllDates.UseVisualStyleBackColor = true;
            chkAllDates.CheckedChanged += chkAllDates_CheckedChanged;
            // 
            // btnFilter
            // 
            btnFilter.Location = new Point(720, 10);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(130, 30);
            btnFilter.TabIndex = 5;
            btnFilter.Text = "Xem hóa đơn";
            btnFilter.UseVisualStyleBackColor = true;
            btnFilter.Click += btnFilter_Click;
            // 
            // dtpToDate
            // 
            dtpToDate.CustomFormat = "dd/MM/yyyy";
            dtpToDate.Format = DateTimePickerFormat.Custom;
            dtpToDate.Location = new Point(410, 13);
            dtpToDate.Name = "dtpToDate";
            dtpToDate.Size = new Size(150, 23);
            dtpToDate.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(320, 17);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 2;
            label2.Text = "Đến ngày:";
            // 
            // dtpFromDate
            // 
            dtpFromDate.CustomFormat = "dd/MM/yyyy";
            dtpFromDate.Format = DateTimePickerFormat.Custom;
            dtpFromDate.Location = new Point(100, 13);
            dtpFromDate.Name = "dtpFromDate";
            dtpFromDate.Size = new Size(150, 23);
            dtpFromDate.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 17);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 0;
            label1.Text = "Từ ngày:";
            // 
            // dgvBills
            // 
            dgvBills.AllowUserToAddRows = false;
            dgvBills.AllowUserToDeleteRows = false;
            dgvBills.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBills.Dock = DockStyle.Fill;
            dgvBills.Location = new Point(0, 50);
            dgvBills.MultiSelect = false;
            dgvBills.Name = "dgvBills";
            dgvBills.ReadOnly = true;
            dgvBills.RowHeadersWidth = 50;
            dgvBills.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBills.Size = new Size(1000, 450);
            dgvBills.TabIndex = 1;
            dgvBills.CellDoubleClick += dgvBills_CellDoubleClick;
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(lblActualPay);
            panelBottom.Controls.Add(lblTotalDiscount);
            panelBottom.Controls.Add(lblTotalAmount);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 500);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(1000, 50);
            panelBottom.TabIndex = 2;
            // 
            // lblActualPay
            // 
            lblActualPay.AutoSize = true;
            lblActualPay.Location = new Point(680, 18);
            lblActualPay.Name = "lblActualPay";
            lblActualPay.Size = new Size(93, 15);
            lblActualPay.TabIndex = 2;
            lblActualPay.Text = "Thực thu: 0 VNĐ";
            // 
            // lblTotalDiscount
            // 
            lblTotalDiscount.AutoSize = true;
            lblTotalDiscount.Location = new Point(340, 18);
            lblTotalDiscount.Name = "lblTotalDiscount";
            lblTotalDiscount.Size = new Size(149, 15);
            lblTotalDiscount.TabIndex = 1;
            lblTotalDiscount.Text = "Tổng tiền giảm giá: 0 VNĐ";
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Location = new Point(20, 18);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(157, 15);
            lblTotalAmount.TabIndex = 0;
            lblTotalAmount.Text = "Tổng tiền chưa giảm: 0 VNĐ";
            // 
            // BillsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 550);
            Controls.Add(dgvBills);
            Controls.Add(panelBottom);
            Controls.Add(panelTop);
            Name = "BillsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Danh sách hóa đơn";
            Load += BillsForm_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBills).EndInit();
            panelBottom.ResumeLayout(false);
            panelBottom.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private DateTimePicker dtpFromDate;
        private Label label1;
        private DateTimePicker dtpToDate;
        private Label label2;
        private Button btnFilter;
        private CheckBox chkAllDates;
        private DataGridView dgvBills;
        private Panel panelBottom;
        private Label lblTotalAmount;
        private Label lblTotalDiscount;
        private Label lblActualPay;
    }
}
