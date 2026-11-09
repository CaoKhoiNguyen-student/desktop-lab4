namespace Lab4_Basic_Command
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnLoad = new Button();
            lvCategory = new ListView();
            chID = new ColumnHeader();
            chName = new ColumnHeader();
            chType = new ColumnHeader();
            contextMenu = new ContextMenuStrip(components);
            tsmDelete = new ToolStripMenuItem();
            tsmViewFood = new ToolStripMenuItem();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnThem = new Button();
            btnCapNhat = new Button();
            btnXoa = new Button();
            txtID = new TextBox();
            cboType = new ComboBox();
            txtName = new TextBox();
            contextMenu.SuspendLayout();
            SuspendLayout();
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(20, 200);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(160, 45);
            btnLoad.TabIndex = 6;
            btnLoad.Text = "Lấy danh sách";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // lvCategory
            // 
            lvCategory.Columns.AddRange(new ColumnHeader[] { chID, chName, chType });
            lvCategory.ContextMenuStrip = contextMenu;
            lvCategory.Dock = DockStyle.Bottom;
            lvCategory.FullRowSelect = true;
            lvCategory.Location = new Point(0, 260);
            lvCategory.MultiSelect = false;
            lvCategory.Name = "lvCategory";
            lvCategory.Size = new Size(800, 340);
            lvCategory.TabIndex = 10;
            lvCategory.UseCompatibleStateImageBehavior = false;
            lvCategory.View = View.Details;
            lvCategory.Click += lvCategory_Click;
            // 
            // chID
            // 
            chID.Text = "Mã loại";
            chID.Width = 120;
            // 
            // chName
            // 
            chName.Text = "Tên loại món ăn";
            chName.Width = 350;
            // 
            // chType
            // 
            chType.Text = "Loại";
            chType.Width = 250;
            // 
            // contextMenu
            // 
            contextMenu.Items.AddRange(new ToolStripItem[] { tsmDelete, tsmViewFood });
            contextMenu.Name = "contextMenu";
            contextMenu.Size = new Size(205, 48);
            // 
            // tsmDelete
            // 
            tsmDelete.Name = "tsmDelete";
            tsmDelete.Size = new Size(204, 22);
            tsmDelete.Text = "Xóa nhóm sản phẩm";
            tsmDelete.Click += tsmDelete_Click;
            // 
            // tsmViewFood
            // 
            tsmViewFood.Name = "tsmViewFood";
            tsmViewFood.Size = new Size(204, 22);
            tsmViewFood.Text = "Xem danh sách món ăn";
            tsmViewFood.Click += tsmViewFood_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 30);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 0;
            label1.Text = "Mã nhóm:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 80);
            label2.Name = "label2";
            label2.Size = new Size(106, 15);
            label2.TabIndex = 2;
            label2.Text = "Tên nhóm thức ăn:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 130);
            label3.Name = "label3";
            label3.Size = new Size(32, 15);
            label3.TabIndex = 4;
            label3.Text = "Loại:";
            // 
            // btnThem
            // 
            btnThem.Location = new Point(330, 200);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(130, 45);
            btnThem.TabIndex = 7;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnCapNhat
            // 
            btnCapNhat.Enabled = false;
            btnCapNhat.Location = new Point(480, 200);
            btnCapNhat.Name = "btnCapNhat";
            btnCapNhat.Size = new Size(130, 45);
            btnCapNhat.TabIndex = 8;
            btnCapNhat.Text = "Cập nhật";
            btnCapNhat.UseVisualStyleBackColor = true;
            btnCapNhat.Click += btnCapNhat_Click;
            // 
            // btnXoa
            // 
            btnXoa.Enabled = false;
            btnXoa.Location = new Point(630, 200);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(130, 45);
            btnXoa.TabIndex = 9;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // txtID
            // 
            txtID.Location = new Point(160, 27);
            txtID.Name = "txtID";
            txtID.ReadOnly = true;
            txtID.Size = new Size(400, 23);
            txtID.TabIndex = 1;
            // 
            // cboType
            // 
            cboType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboType.FormattingEnabled = true;
            cboType.Items.AddRange(new object[] { "0 - Thức uống", "1 - Đồ ăn" });
            cboType.Location = new Point(160, 127);
            cboType.Name = "cboType";
            cboType.Size = new Size(400, 23);
            cboType.TabIndex = 5;
            // 
            // txtName
            // 
            txtName.Location = new Point(160, 77);
            txtName.Name = "txtName";
            txtName.Size = new Size(400, 23);
            txtName.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 600);
            Controls.Add(txtName);
            Controls.Add(cboType);
            Controls.Add(txtID);
            Controls.Add(btnXoa);
            Controls.Add(btnCapNhat);
            Controls.Add(btnThem);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lvCategory);
            Controls.Add(btnLoad);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý nhóm món ăn";
            contextMenu.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLoad;
        private ListView lvCategory;
        private ColumnHeader chID;
        private ColumnHeader chName;
        private ColumnHeader chType;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnThem;
        private Button btnCapNhat;
        private Button btnXoa;
        private TextBox txtID;
        private ComboBox cboType;
        private TextBox txtName;
        private ContextMenuStrip contextMenu;
        private ToolStripMenuItem tsmDelete;
        private ToolStripMenuItem tsmViewFood;
    }
}
