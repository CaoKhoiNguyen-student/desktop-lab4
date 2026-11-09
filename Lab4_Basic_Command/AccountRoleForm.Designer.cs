namespace Lab4_Basic_Command
{
    partial class AccountRoleForm
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
            dgvRoles = new DataGridView();
            panelBottom = new Panel();
            btnClose = new Button();
            btnSave = new Button();
            lblAccount = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvRoles).BeginInit();
            panelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // dgvRoles
            // 
            dgvRoles.AllowUserToAddRows = false;
            dgvRoles.AllowUserToDeleteRows = false;
            dgvRoles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRoles.Dock = DockStyle.Fill;
            dgvRoles.Location = new Point(0, 40);
            dgvRoles.Name = "dgvRoles";
            dgvRoles.RowHeadersWidth = 50;
            dgvRoles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRoles.Size = new Size(620, 320);
            dgvRoles.TabIndex = 1;
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(btnClose);
            panelBottom.Controls.Add(btnSave);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 360);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(620, 50);
            panelBottom.TabIndex = 2;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(330, 10);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(110, 30);
            btnClose.TabIndex = 1;
            btnClose.Text = "Đóng";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(190, 10);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(120, 30);
            btnSave.TabIndex = 0;
            btnSave.Text = "Lưu thay đổi";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // lblAccount
            // 
            lblAccount.Dock = DockStyle.Top;
            lblAccount.Location = new Point(0, 0);
            lblAccount.Name = "lblAccount";
            lblAccount.Size = new Size(620, 40);
            lblAccount.TabIndex = 0;
            lblAccount.Text = "Danh sách vai trò tài khoản: ";
            lblAccount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // AccountRoleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(620, 410);
            Controls.Add(dgvRoles);
            Controls.Add(lblAccount);
            Controls.Add(panelBottom);
            Name = "AccountRoleForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Danh sách vai trò tài khoản";
            Load += AccountRoleForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRoles).EndInit();
            panelBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvRoles;
        private Panel panelBottom;
        private Button btnClose;
        private Button btnSave;
        private Label lblAccount;
    }
}
