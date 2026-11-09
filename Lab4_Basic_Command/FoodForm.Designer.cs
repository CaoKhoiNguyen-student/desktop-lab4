namespace Lab4_Basic_Command
{
    partial class FoodForm
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
            dgvFood = new DataGridView();
            btnSave = new Button();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvFood).BeginInit();
            SuspendLayout();
            // 
            // dgvFood
            // 
            dgvFood.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvFood.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFood.Location = new Point(12, 60);
            dgvFood.Name = "dgvFood";
            dgvFood.RowHeadersWidth = 50;
            dgvFood.Size = new Size(860, 480);
            dgvFood.TabIndex = 2;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(12, 12);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(160, 36);
            btnSave.TabIndex = 0;
            btnSave.Text = "Lưu (Thêm / Sửa)";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(185, 12);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(130, 36);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "Xóa món";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // FoodForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 552);
            Controls.Add(btnDelete);
            Controls.Add(btnSave);
            Controls.Add(dgvFood);
            Name = "FoodForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Danh sách món ăn";
            ((System.ComponentModel.ISupportInitialize)dgvFood).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvFood;
        private Button btnSave;
        private Button btnDelete;
    }
}
