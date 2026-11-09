namespace Lab4_Basic_Command
{
    partial class AccountManager
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
            panelFilter = new Panel();
            btnFilter = new Button();
            cboActiveFilter = new ComboBox();
            label2 = new Label();
            cboRoleFilter = new ComboBox();
            label1 = new Label();
            dgvAccounts = new DataGridView();
            cmsAccount = new ContextMenuStrip(components);
            tsmDeleteAccount = new ToolStripMenuItem();
            tsmViewRoles = new ToolStripMenuItem();
            panelInputs = new Panel();
            btnResetPassword = new Button();
            btnClear = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            cboDefaultRole = new ComboBox();
            label8 = new Label();
            txtTell = new TextBox();
            label7 = new Label();
            txtEmail = new TextBox();
            label6 = new Label();
            txtFullName = new TextBox();
            label5 = new Label();
            txtPassword = new TextBox();
            label4 = new Label();
            txtAccountName = new TextBox();
            label3 = new Label();
            panelFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAccounts).BeginInit();
            cmsAccount.SuspendLayout();
            panelInputs.SuspendLayout();
            SuspendLayout();
            // 
            // panelFilter
            // 
            panelFilter.Controls.Add(btnFilter);
            panelFilter.Controls.Add(cboActiveFilter);
            panelFilter.Controls.Add(label2);
            panelFilter.Controls.Add(cboRoleFilter);
            panelFilter.Controls.Add(label1);
            panelFilter.Dock = DockStyle.Top;
            panelFilter.Location = new Point(0, 0);
            panelFilter.Name = "panelFilter";
            panelFilter.Size = new Size(950, 48);
            panelFilter.TabIndex = 0;
            // 
            // btnFilter
            // 
            btnFilter.Location = new Point(690, 10);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(110, 28);
            btnFilter.TabIndex = 4;
            btnFilter.Text = "Lọc dữ liệu";
            btnFilter.UseVisualStyleBackColor = true;
            btnFilter.Click += btnFilter_Click;
            // 
            // cboActiveFilter
            // 
            cboActiveFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cboActiveFilter.FormattingEnabled = true;
            cboActiveFilter.Items.AddRange(new object[] { "Tất cả trạng thái", "Đang kích hoạt", "Ngưng kích hoạt" });
            cboActiveFilter.Location = new Point(480, 13);
            cboActiveFilter.Name = "cboActiveFilter";
            cboActiveFilter.Size = new Size(180, 23);
            cboActiveFilter.TabIndex = 3;
            cboActiveFilter.SelectedIndexChanged += cboFilter_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(405, 17);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 2;
            label2.Text = "Trạng thái:";
            // 
            // cboRoleFilter
            // 
            cboRoleFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRoleFilter.FormattingEnabled = true;
            cboRoleFilter.Location = new Point(110, 13);
            cboRoleFilter.Name = "cboRoleFilter";
            cboRoleFilter.Size = new Size(240, 23);
            cboRoleFilter.TabIndex = 1;
            cboRoleFilter.SelectedIndexChanged += cboFilter_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 17);
            label1.Name = "label1";
            label1.Size = new Size(77, 15);
            label1.TabIndex = 0;
            label1.Text = "Nhóm vai trò:";
            // 
            // dgvAccounts
            // 
            dgvAccounts.AllowUserToAddRows = false;
            dgvAccounts.AllowUserToDeleteRows = false;
            dgvAccounts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAccounts.ContextMenuStrip = cmsAccount;
            dgvAccounts.Dock = DockStyle.Fill;
            dgvAccounts.Location = new Point(0, 48);
            dgvAccounts.MultiSelect = false;
            dgvAccounts.Name = "dgvAccounts";
            dgvAccounts.ReadOnly = true;
            dgvAccounts.RowHeadersWidth = 50;
            dgvAccounts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAccounts.Size = new Size(950, 312);
            dgvAccounts.TabIndex = 1;
            dgvAccounts.CellClick += dgvAccounts_CellClick;
            // 
            // cmsAccount
            // 
            cmsAccount.Items.AddRange(new ToolStripItem[] { tsmDeleteAccount, tsmViewRoles });
            cmsAccount.Name = "cmsAccount";
            cmsAccount.Size = new Size(189, 48);
            // 
            // tsmDeleteAccount
            // 
            tsmDeleteAccount.Name = "tsmDeleteAccount";
            tsmDeleteAccount.Size = new Size(188, 22);
            tsmDeleteAccount.Text = "Xóa tài khoản";
            tsmDeleteAccount.Click += tsmDeleteAccount_Click;
            // 
            // tsmViewRoles
            // 
            tsmViewRoles.Name = "tsmViewRoles";
            tsmViewRoles.Size = new Size(188, 22);
            tsmViewRoles.Text = "Xem danh sách vai trò";
            tsmViewRoles.Click += tsmViewRoles_Click;
            // 
            // panelInputs
            // 
            panelInputs.Controls.Add(btnResetPassword);
            panelInputs.Controls.Add(btnClear);
            panelInputs.Controls.Add(btnUpdate);
            panelInputs.Controls.Add(btnAdd);
            panelInputs.Controls.Add(cboDefaultRole);
            panelInputs.Controls.Add(label8);
            panelInputs.Controls.Add(txtTell);
            panelInputs.Controls.Add(label7);
            panelInputs.Controls.Add(txtEmail);
            panelInputs.Controls.Add(label6);
            panelInputs.Controls.Add(txtFullName);
            panelInputs.Controls.Add(label5);
            panelInputs.Controls.Add(txtPassword);
            panelInputs.Controls.Add(label4);
            panelInputs.Controls.Add(txtAccountName);
            panelInputs.Controls.Add(label3);
            panelInputs.Dock = DockStyle.Bottom;
            panelInputs.Location = new Point(0, 360);
            panelInputs.Name = "panelInputs";
            panelInputs.Size = new Size(950, 190);
            panelInputs.TabIndex = 2;
            // 
            // btnResetPassword
            // 
            btnResetPassword.Location = new Point(530, 140);
            btnResetPassword.Name = "btnResetPassword";
            btnResetPassword.Size = new Size(130, 34);
            btnResetPassword.TabIndex = 14;
            btnResetPassword.Text = "Reset mật khẩu";
            btnResetPassword.UseVisualStyleBackColor = true;
            btnResetPassword.Click += btnResetPassword_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(680, 140);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(110, 34);
            btnClear.TabIndex = 15;
            btnClear.Text = "Làm mới";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(390, 140);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(120, 34);
            btnUpdate.TabIndex = 13;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(240, 140);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(130, 34);
            btnAdd.TabIndex = 12;
            btnAdd.Text = "Thêm tài khoản";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // cboDefaultRole
            // 
            cboDefaultRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDefaultRole.FormattingEnabled = true;
            cboDefaultRole.Location = new Point(670, 95);
            cboDefaultRole.Name = "cboDefaultRole";
            cboDefaultRole.Size = new Size(240, 23);
            cboDefaultRole.TabIndex = 11;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(560, 99);
            label8.Name = "label8";
            label8.Size = new Size(88, 15);
            label8.TabIndex = 10;
            label8.Text = "Gán vai trò đầu:";
            // 
            // txtTell
            // 
            txtTell.Location = new Point(670, 57);
            txtTell.Name = "txtTell";
            txtTell.Size = new Size(240, 23);
            txtTell.TabIndex = 9;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(560, 61);
            label7.Name = "label7";
            label7.Size = new Size(79, 15);
            label7.TabIndex = 8;
            label7.Text = "Số điện thoại:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(670, 17);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(240, 23);
            txtEmail.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(560, 21);
            label6.Name = "label6";
            label6.Size = new Size(39, 15);
            label6.TabIndex = 6;
            label6.Text = "Email:";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(140, 95);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(340, 23);
            txtFullName.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(20, 99);
            label5.Name = "label5";
            label5.Size = new Size(61, 15);
            label5.TabIndex = 4;
            label5.Text = "Họ và tên:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(140, 57);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(340, 23);
            txtPassword.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 61);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 2;
            label4.Text = "Mật khẩu:";
            // 
            // txtAccountName
            // 
            txtAccountName.Location = new Point(140, 17);
            txtAccountName.Name = "txtAccountName";
            txtAccountName.Size = new Size(340, 23);
            txtAccountName.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 21);
            label3.Name = "label3";
            label3.Size = new Size(80, 15);
            label3.TabIndex = 0;
            label3.Text = "Tên tài khoản:";
            // 
            // AccountManager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(950, 550);
            Controls.Add(dgvAccounts);
            Controls.Add(panelInputs);
            Controls.Add(panelFilter);
            Name = "AccountManager";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý tài khoản";
            Load += AccountManager_Load;
            panelFilter.ResumeLayout(false);
            panelFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAccounts).EndInit();
            cmsAccount.ResumeLayout(false);
            panelInputs.ResumeLayout(false);
            panelInputs.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelFilter;
        private Label label1;
        private ComboBox cboRoleFilter;
        private ComboBox cboActiveFilter;
        private Label label2;
        private Button btnFilter;
        private DataGridView dgvAccounts;
        private Panel panelInputs;
        private TextBox txtFullName;
        private Label label5;
        private TextBox txtPassword;
        private Label label4;
        private TextBox txtAccountName;
        private Label label3;
        private TextBox txtTell;
        private Label label7;
        private TextBox txtEmail;
        private Label label6;
        private ComboBox cboDefaultRole;
        private Label label8;
        private Button btnClear;
        private Button btnUpdate;
        private Button btnAdd;
        private Button btnResetPassword;
        private ContextMenuStrip cmsAccount;
        private ToolStripMenuItem tsmDeleteAccount;
        private ToolStripMenuItem tsmViewRoles;
    }
}
