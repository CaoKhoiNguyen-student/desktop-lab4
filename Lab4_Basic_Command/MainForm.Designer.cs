namespace Lab4_Basic_Command
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            menuStripMain = new MenuStrip();
            menuHeThong = new ToolStripMenuItem();
            tsmThoat = new ToolStripMenuItem();
            menuChucNang = new ToolStripMenuItem();
            tsmMenuCategory = new ToolStripMenuItem();
            tsmMenuBills = new ToolStripMenuItem();
            tsmMenuAccounts = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            tsmMenuAllHistory = new ToolStripMenuItem();
            splitContainerMain = new SplitContainer();
            lvTables = new ListView();
            chTableID = new ColumnHeader();
            chTableName = new ColumnHeader();
            chCapacity = new ColumnHeader();
            chStatus = new ColumnHeader();
            cmsTable = new ContextMenuStrip(components);
            tsmDeleteTable = new ToolStripMenuItem();
            tsmViewTableBills = new ToolStripMenuItem();
            tsmViewTableHistory = new ToolStripMenuItem();
            panelLeftTop = new Panel();
            btnReloadTables = new Button();
            lblTablesTitle = new Label();
            gbCurrentBill = new GroupBox();
            dgvCurrentBillDetails = new DataGridView();
            panelCurrentBillBottom = new Panel();
            lblCurrentBillTotal = new Label();
            lblCurrentBillInfo = new Label();
            gbTableInfo = new GroupBox();
            btnClearTable = new Button();
            btnDeleteTable = new Button();
            btnUpdateTable = new Button();
            btnAddTable = new Button();
            cboTableStatus = new ComboBox();
            label4 = new Label();
            nudCapacity = new NumericUpDown();
            label3 = new Label();
            txtTableName = new TextBox();
            label2 = new Label();
            txtTableID = new TextBox();
            label1 = new Label();
            menuStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            splitContainerMain.Panel2.SuspendLayout();
            splitContainerMain.SuspendLayout();
            cmsTable.SuspendLayout();
            panelLeftTop.SuspendLayout();
            gbCurrentBill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCurrentBillDetails).BeginInit();
            panelCurrentBillBottom.SuspendLayout();
            gbTableInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudCapacity).BeginInit();
            SuspendLayout();
            // 
            // menuStripMain
            // 
            menuStripMain.Items.AddRange(new ToolStripItem[] { menuHeThong, menuChucNang });
            menuStripMain.Location = new Point(0, 0);
            menuStripMain.Name = "menuStripMain";
            menuStripMain.Size = new Size(1100, 24);
            menuStripMain.TabIndex = 0;
            // 
            // menuHeThong
            // 
            menuHeThong.DropDownItems.AddRange(new ToolStripItem[] { tsmThoat });
            menuHeThong.Name = "menuHeThong";
            menuHeThong.Size = new Size(69, 20);
            menuHeThong.Text = "Hệ thống";
            // 
            // tsmThoat
            // 
            tsmThoat.Name = "tsmThoat";
            tsmThoat.Size = new Size(104, 22);
            tsmThoat.Text = "Thoát";
            tsmThoat.Click += tsmThoat_Click;
            // 
            // menuChucNang
            // 
            menuChucNang.DropDownItems.AddRange(new ToolStripItem[] { tsmMenuCategory, tsmMenuBills, tsmMenuAccounts, toolStripSeparator1, tsmMenuAllHistory });
            menuChucNang.Name = "menuChucNang";
            menuChucNang.Size = new Size(77, 20);
            menuChucNang.Text = "Chức năng";
            // 
            // tsmMenuCategory
            // 
            tsmMenuCategory.Name = "tsmMenuCategory";
            tsmMenuCategory.Size = new Size(244, 22);
            tsmMenuCategory.Text = "Quản lý nhóm món (Category)";
            tsmMenuCategory.Click += tsmMenuCategory_Click;
            // 
            // tsmMenuBills
            // 
            tsmMenuBills.Name = "tsmMenuBills";
            tsmMenuBills.Size = new Size(244, 22);
            tsmMenuBills.Text = "Quản lý hóa đơn (Bills)";
            tsmMenuBills.Click += tsmMenuBills_Click;
            // 
            // tsmMenuAccounts
            // 
            tsmMenuAccounts.Name = "tsmMenuAccounts";
            tsmMenuAccounts.Size = new Size(244, 22);
            tsmMenuAccounts.Text = "Quản lý tài khoản (Accounts)";
            tsmMenuAccounts.Click += tsmMenuAccounts_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(241, 6);
            // 
            // tsmMenuAllHistory
            // 
            tsmMenuAllHistory.Name = "tsmMenuAllHistory";
            tsmMenuAllHistory.Size = new Size(244, 22);
            tsmMenuAllHistory.Text = "Xem nhật ký toàn bộ hóa đơn";
            tsmMenuAllHistory.Click += tsmMenuAllHistory_Click;
            // 
            // splitContainerMain
            // 
            splitContainerMain.Dock = DockStyle.Fill;
            splitContainerMain.Location = new Point(0, 24);
            splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            splitContainerMain.Panel1.Controls.Add(lvTables);
            splitContainerMain.Panel1.Controls.Add(panelLeftTop);
            // 
            // splitContainerMain.Panel2
            // 
            splitContainerMain.Panel2.Controls.Add(gbCurrentBill);
            splitContainerMain.Panel2.Controls.Add(gbTableInfo);
            splitContainerMain.Size = new Size(1100, 626);
            splitContainerMain.SplitterDistance = 450;
            splitContainerMain.TabIndex = 1;
            // 
            // lvTables
            // 
            lvTables.Columns.AddRange(new ColumnHeader[] { chTableID, chTableName, chCapacity, chStatus });
            lvTables.ContextMenuStrip = cmsTable;
            lvTables.Dock = DockStyle.Fill;
            lvTables.FullRowSelect = true;
            lvTables.Location = new Point(0, 40);
            lvTables.MultiSelect = false;
            lvTables.Name = "lvTables";
            lvTables.Size = new Size(450, 586);
            lvTables.TabIndex = 1;
            lvTables.UseCompatibleStateImageBehavior = false;
            lvTables.View = View.Details;
            lvTables.SelectedIndexChanged += lvTables_SelectedIndexChanged;
            // 
            // chTableID
            // 
            chTableID.Text = "Mã";
            chTableID.Width = 60;
            // 
            // chTableName
            // 
            chTableName.Text = "Tên bàn";
            chTableName.Width = 130;
            // 
            // chCapacity
            // 
            chCapacity.Text = "Số ghế";
            chCapacity.Width = 80;
            // 
            // chStatus
            // 
            chStatus.Text = "Trạng thái";
            chStatus.Width = 140;
            // 
            // cmsTable
            // 
            cmsTable.Items.AddRange(new ToolStripItem[] { tsmDeleteTable, tsmViewTableBills, tsmViewTableHistory });
            cmsTable.Name = "cmsTable";
            cmsTable.Size = new Size(202, 70);
            // 
            // tsmDeleteTable
            // 
            tsmDeleteTable.Name = "tsmDeleteTable";
            tsmDeleteTable.Size = new Size(201, 22);
            tsmDeleteTable.Text = "Xóa bàn";
            tsmDeleteTable.Click += tsmDeleteTable_Click;
            // 
            // tsmViewTableBills
            // 
            tsmViewTableBills.Name = "tsmViewTableBills";
            tsmViewTableBills.Size = new Size(201, 22);
            tsmViewTableBills.Text = "Xem danh mục hóa đơn";
            tsmViewTableBills.Click += tsmViewTableBills_Click;
            // 
            // tsmViewTableHistory
            // 
            tsmViewTableHistory.Name = "tsmViewTableHistory";
            tsmViewTableHistory.Size = new Size(201, 22);
            tsmViewTableHistory.Text = "Xem nhật ký hóa đơn";
            tsmViewTableHistory.Click += tsmViewTableHistory_Click;
            // 
            // panelLeftTop
            // 
            panelLeftTop.Controls.Add(btnReloadTables);
            panelLeftTop.Controls.Add(lblTablesTitle);
            panelLeftTop.Dock = DockStyle.Top;
            panelLeftTop.Location = new Point(0, 0);
            panelLeftTop.Name = "panelLeftTop";
            panelLeftTop.Size = new Size(450, 40);
            panelLeftTop.TabIndex = 0;
            // 
            // btnReloadTables
            // 
            btnReloadTables.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnReloadTables.Location = new Point(340, 7);
            btnReloadTables.Name = "btnReloadTables";
            btnReloadTables.Size = new Size(100, 26);
            btnReloadTables.TabIndex = 1;
            btnReloadTables.Text = "Làm mới";
            btnReloadTables.UseVisualStyleBackColor = true;
            btnReloadTables.Click += btnReloadTables_Click;
            // 
            // lblTablesTitle
            // 
            lblTablesTitle.AutoSize = true;
            lblTablesTitle.Location = new Point(12, 13);
            lblTablesTitle.Name = "lblTablesTitle";
            lblTablesTitle.Size = new Size(116, 15);
            lblTablesTitle.TabIndex = 0;
            lblTablesTitle.Text = "DANH SÁCH BÀN ĂN";
            // 
            // gbCurrentBill
            // 
            gbCurrentBill.Controls.Add(dgvCurrentBillDetails);
            gbCurrentBill.Controls.Add(panelCurrentBillBottom);
            gbCurrentBill.Controls.Add(lblCurrentBillInfo);
            gbCurrentBill.Dock = DockStyle.Fill;
            gbCurrentBill.Location = new Point(0, 180);
            gbCurrentBill.Name = "gbCurrentBill";
            gbCurrentBill.Size = new Size(646, 446);
            gbCurrentBill.TabIndex = 1;
            gbCurrentBill.TabStop = false;
            gbCurrentBill.Text = "Hóa đơn hiện tại của bàn";
            // 
            // dgvCurrentBillDetails
            // 
            dgvCurrentBillDetails.AllowUserToAddRows = false;
            dgvCurrentBillDetails.AllowUserToDeleteRows = false;
            dgvCurrentBillDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCurrentBillDetails.Dock = DockStyle.Fill;
            dgvCurrentBillDetails.Location = new Point(3, 49);
            dgvCurrentBillDetails.Name = "dgvCurrentBillDetails";
            dgvCurrentBillDetails.ReadOnly = true;
            dgvCurrentBillDetails.RowHeadersWidth = 50;
            dgvCurrentBillDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCurrentBillDetails.Size = new Size(640, 354);
            dgvCurrentBillDetails.TabIndex = 2;
            // 
            // panelCurrentBillBottom
            // 
            panelCurrentBillBottom.Controls.Add(lblCurrentBillTotal);
            panelCurrentBillBottom.Dock = DockStyle.Bottom;
            panelCurrentBillBottom.Location = new Point(3, 403);
            panelCurrentBillBottom.Name = "panelCurrentBillBottom";
            panelCurrentBillBottom.Size = new Size(640, 40);
            panelCurrentBillBottom.TabIndex = 1;
            // 
            // lblCurrentBillTotal
            // 
            lblCurrentBillTotal.AutoSize = true;
            lblCurrentBillTotal.Location = new Point(12, 13);
            lblCurrentBillTotal.Name = "lblCurrentBillTotal";
            lblCurrentBillTotal.Size = new Size(92, 15);
            lblCurrentBillTotal.TabIndex = 0;
            lblCurrentBillTotal.Text = "Tạm tính: 0 VNĐ";
            // 
            // lblCurrentBillInfo
            // 
            lblCurrentBillInfo.Dock = DockStyle.Top;
            lblCurrentBillInfo.Location = new Point(3, 19);
            lblCurrentBillInfo.Name = "lblCurrentBillInfo";
            lblCurrentBillInfo.Size = new Size(640, 30);
            lblCurrentBillInfo.TabIndex = 0;
            lblCurrentBillInfo.Text = "Chọn một bàn để xem hóa đơn hiện tại...";
            lblCurrentBillInfo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // gbTableInfo
            // 
            gbTableInfo.Controls.Add(btnClearTable);
            gbTableInfo.Controls.Add(btnDeleteTable);
            gbTableInfo.Controls.Add(btnUpdateTable);
            gbTableInfo.Controls.Add(btnAddTable);
            gbTableInfo.Controls.Add(cboTableStatus);
            gbTableInfo.Controls.Add(label4);
            gbTableInfo.Controls.Add(nudCapacity);
            gbTableInfo.Controls.Add(label3);
            gbTableInfo.Controls.Add(txtTableName);
            gbTableInfo.Controls.Add(label2);
            gbTableInfo.Controls.Add(txtTableID);
            gbTableInfo.Controls.Add(label1);
            gbTableInfo.Dock = DockStyle.Top;
            gbTableInfo.Location = new Point(0, 0);
            gbTableInfo.Name = "gbTableInfo";
            gbTableInfo.Size = new Size(646, 180);
            gbTableInfo.TabIndex = 0;
            gbTableInfo.TabStop = false;
            gbTableInfo.Text = "Thông tin bàn ăn";
            // 
            // btnClearTable
            // 
            btnClearTable.Location = new Point(460, 130);
            btnClearTable.Name = "btnClearTable";
            btnClearTable.Size = new Size(110, 32);
            btnClearTable.TabIndex = 11;
            btnClearTable.Text = "Làm mới";
            btnClearTable.UseVisualStyleBackColor = true;
            btnClearTable.Click += btnClearTable_Click;
            // 
            // btnDeleteTable
            // 
            btnDeleteTable.Location = new Point(330, 130);
            btnDeleteTable.Name = "btnDeleteTable";
            btnDeleteTable.Size = new Size(110, 32);
            btnDeleteTable.TabIndex = 10;
            btnDeleteTable.Text = "Xóa bàn";
            btnDeleteTable.UseVisualStyleBackColor = true;
            btnDeleteTable.Click += btnDeleteTable_Click;
            // 
            // btnUpdateTable
            // 
            btnUpdateTable.Location = new Point(190, 130);
            btnUpdateTable.Name = "btnUpdateTable";
            btnUpdateTable.Size = new Size(120, 32);
            btnUpdateTable.TabIndex = 9;
            btnUpdateTable.Text = "Cập nhật";
            btnUpdateTable.UseVisualStyleBackColor = true;
            btnUpdateTable.Click += btnUpdateTable_Click;
            // 
            // btnAddTable
            // 
            btnAddTable.Location = new Point(50, 130);
            btnAddTable.Name = "btnAddTable";
            btnAddTable.Size = new Size(120, 32);
            btnAddTable.TabIndex = 8;
            btnAddTable.Text = "Thêm bàn";
            btnAddTable.UseVisualStyleBackColor = true;
            btnAddTable.Click += btnAddTable_Click;
            // 
            // cboTableStatus
            // 
            cboTableStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTableStatus.FormattingEnabled = true;
            cboTableStatus.Items.AddRange(new object[] { "0 - Bàn trống", "1 - Có khách" });
            cboTableStatus.Location = new Point(410, 80);
            cboTableStatus.Name = "cboTableStatus";
            cboTableStatus.Size = new Size(180, 23);
            cboTableStatus.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(320, 84);
            label4.Name = "label4";
            label4.Size = new Size(62, 15);
            label4.TabIndex = 6;
            label4.Text = "Trạng thái:";
            // 
            // nudCapacity
            // 
            nudCapacity.Location = new Point(110, 80);
            nudCapacity.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            nudCapacity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCapacity.Name = "nudCapacity";
            nudCapacity.Size = new Size(160, 23);
            nudCapacity.TabIndex = 5;
            nudCapacity.Value = new decimal(new int[] { 4, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 84);
            label3.Name = "label3";
            label3.Size = new Size(46, 15);
            label3.TabIndex = 4;
            label3.Text = "Số ghế:";
            // 
            // txtTableName
            // 
            txtTableName.Location = new Point(410, 32);
            txtTableName.Name = "txtTableName";
            txtTableName.Size = new Size(180, 23);
            txtTableName.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(320, 36);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 2;
            label2.Text = "Tên bàn:";
            // 
            // txtTableID
            // 
            txtTableID.Location = new Point(110, 32);
            txtTableID.Name = "txtTableID";
            txtTableID.ReadOnly = true;
            txtTableID.Size = new Size(160, 23);
            txtTableID.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 36);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 0;
            label1.Text = "Mã bàn:";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 650);
            Controls.Add(splitContainerMain);
            Controls.Add(menuStripMain);
            MainMenuStrip = menuStripMain;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý Nhà hàng - Sơ đồ bàn & Hóa đơn";
            Load += MainForm_Load;
            menuStripMain.ResumeLayout(false);
            menuStripMain.PerformLayout();
            splitContainerMain.Panel1.ResumeLayout(false);
            splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).EndInit();
            splitContainerMain.ResumeLayout(false);
            cmsTable.ResumeLayout(false);
            panelLeftTop.ResumeLayout(false);
            panelLeftTop.PerformLayout();
            gbCurrentBill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCurrentBillDetails).EndInit();
            panelCurrentBillBottom.ResumeLayout(false);
            panelCurrentBillBottom.PerformLayout();
            gbTableInfo.ResumeLayout(false);
            gbTableInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudCapacity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStripMain;
        private ToolStripMenuItem menuHeThong;
        private ToolStripMenuItem tsmThoat;
        private ToolStripMenuItem menuChucNang;
        private ToolStripMenuItem tsmMenuCategory;
        private ToolStripMenuItem tsmMenuBills;
        private ToolStripMenuItem tsmMenuAccounts;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem tsmMenuAllHistory;
        private SplitContainer splitContainerMain;
        private ListView lvTables;
        private ColumnHeader chTableID;
        private ColumnHeader chTableName;
        private ColumnHeader chCapacity;
        private ColumnHeader chStatus;
        private Panel panelLeftTop;
        private Label lblTablesTitle;
        private Button btnReloadTables;
        private GroupBox gbTableInfo;
        private GroupBox gbCurrentBill;
        private Label label1;
        private TextBox txtTableID;
        private TextBox txtTableName;
        private Label label2;
        private NumericUpDown nudCapacity;
        private Label label3;
        private ComboBox cboTableStatus;
        private Label label4;
        private Button btnClearTable;
        private Button btnDeleteTable;
        private Button btnUpdateTable;
        private Button btnAddTable;
        private DataGridView dgvCurrentBillDetails;
        private Panel panelCurrentBillBottom;
        private Label lblCurrentBillTotal;
        private Label lblCurrentBillInfo;
        private ContextMenuStrip cmsTable;
        private ToolStripMenuItem tsmDeleteTable;
        private ToolStripMenuItem tsmViewTableBills;
        private ToolStripMenuItem tsmViewTableHistory;
    }
}
