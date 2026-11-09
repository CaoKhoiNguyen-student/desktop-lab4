namespace Lab4_Basic_Command
{
    partial class TableBillsForm
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
            splitContainer = new SplitContainer();
            lbDates = new ListBox();
            lblDatesTitle = new Label();
            dgvBillDetails = new DataGridView();
            panelBillInfo = new Panel();
            lblBillTotal = new Label();
            lblBillInfo = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBillDetails).BeginInit();
            panelBillInfo.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer
            // 
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Location = new Point(0, 0);
            splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(lbDates);
            splitContainer.Panel1.Controls.Add(lblDatesTitle);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(dgvBillDetails);
            splitContainer.Panel2.Controls.Add(panelBillInfo);
            splitContainer.Size = new Size(850, 480);
            splitContainer.SplitterDistance = 260;
            splitContainer.TabIndex = 0;
            // 
            // lbDates
            // 
            lbDates.Dock = DockStyle.Fill;
            lbDates.FormattingEnabled = true;
            lbDates.ItemHeight = 15;
            lbDates.Location = new Point(0, 30);
            lbDates.Name = "lbDates";
            lbDates.Size = new Size(260, 450);
            lbDates.TabIndex = 1;
            lbDates.SelectedIndexChanged += lbDates_SelectedIndexChanged;
            // 
            // lblDatesTitle
            // 
            lblDatesTitle.Dock = DockStyle.Top;
            lblDatesTitle.Location = new Point(0, 0);
            lblDatesTitle.Name = "lblDatesTitle";
            lblDatesTitle.Size = new Size(260, 30);
            lblDatesTitle.TabIndex = 0;
            lblDatesTitle.Text = " Ngày lập hóa đơn:";
            lblDatesTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dgvBillDetails
            // 
            dgvBillDetails.AllowUserToAddRows = false;
            dgvBillDetails.AllowUserToDeleteRows = false;
            dgvBillDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBillDetails.Dock = DockStyle.Fill;
            dgvBillDetails.Location = new Point(0, 60);
            dgvBillDetails.Name = "dgvBillDetails";
            dgvBillDetails.ReadOnly = true;
            dgvBillDetails.RowHeadersWidth = 50;
            dgvBillDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBillDetails.Size = new Size(586, 420);
            dgvBillDetails.TabIndex = 1;
            // 
            // panelBillInfo
            // 
            panelBillInfo.Controls.Add(lblBillTotal);
            panelBillInfo.Controls.Add(lblBillInfo);
            panelBillInfo.Dock = DockStyle.Top;
            panelBillInfo.Location = new Point(0, 0);
            panelBillInfo.Name = "panelBillInfo";
            panelBillInfo.Size = new Size(586, 60);
            panelBillInfo.TabIndex = 0;
            // 
            // lblBillTotal
            // 
            lblBillTotal.AutoSize = true;
            lblBillTotal.Location = new Point(12, 35);
            lblBillTotal.Name = "lblBillTotal";
            lblBillTotal.Size = new Size(130, 15);
            lblBillTotal.TabIndex = 1;
            lblBillTotal.Text = "Tổng tiền chi tiết: 0 VNĐ";
            // 
            // lblBillInfo
            // 
            lblBillInfo.AutoSize = true;
            lblBillInfo.Location = new Point(12, 10);
            lblBillInfo.Name = "lblBillInfo";
            lblBillInfo.Size = new Size(155, 15);
            lblBillInfo.TabIndex = 0;
            lblBillInfo.Text = "Chọn ngày để xem chi tiết...";
            // 
            // TableBillsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(850, 480);
            Controls.Add(splitContainer);
            Name = "TableBillsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Danh mục hóa đơn theo bàn";
            Load += TableBillsForm_Load;
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBillDetails).EndInit();
            panelBillInfo.ResumeLayout(false);
            panelBillInfo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer;
        private ListBox lbDates;
        private Label lblDatesTitle;
        private DataGridView dgvBillDetails;
        private Panel panelBillInfo;
        private Label lblBillInfo;
        private Label lblBillTotal;
    }
}
