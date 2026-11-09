namespace Lab4_Basic_Command
{
    partial class BillDetailsForm
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
            dgvBillDetails = new DataGridView();
            panelBottom = new Panel();
            lblTotal = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvBillDetails).BeginInit();
            panelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // dgvBillDetails
            // 
            dgvBillDetails.AllowUserToAddRows = false;
            dgvBillDetails.AllowUserToDeleteRows = false;
            dgvBillDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBillDetails.Dock = DockStyle.Fill;
            dgvBillDetails.Location = new Point(0, 0);
            dgvBillDetails.Name = "dgvBillDetails";
            dgvBillDetails.ReadOnly = true;
            dgvBillDetails.RowHeadersWidth = 50;
            dgvBillDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBillDetails.Size = new Size(680, 360);
            dgvBillDetails.TabIndex = 0;
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(lblTotal);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 360);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(680, 45);
            panelBottom.TabIndex = 1;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(15, 15);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(130, 15);
            lblTotal.TabIndex = 0;
            lblTotal.Text = "Tổng tiền chi tiết: 0 VNĐ";
            // 
            // BillDetailsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(680, 405);
            Controls.Add(dgvBillDetails);
            Controls.Add(panelBottom);
            Name = "BillDetailsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chi tiết hóa đơn";
            Load += BillDetailsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvBillDetails).EndInit();
            panelBottom.ResumeLayout(false);
            panelBottom.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvBillDetails;
        private Panel panelBottom;
        private Label lblTotal;
    }
}
