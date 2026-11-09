using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab4_Basic_Command
{
    public partial class AccountManager : Form
    {
        public AccountManager()
        {
            InitializeComponent();
        }

        private void AccountManager_Load(object sender, EventArgs e)
        {
            LoadRolesCombobox();
            cboActiveFilter.SelectedIndex = 0;
            LoadAccounts();
        }

        private void LoadRolesCombobox()
        {
            try
            {
                string query = "SELECT ID, RoleName FROM Role ORDER BY ID";
                DataTable dtFilter = DatabaseHelper.ExecuteQuery(query);

                DataRow allRow = dtFilter.NewRow();
                allRow["ID"] = 0;
                allRow["RoleName"] = "Tất cả vai trò";
                dtFilter.Rows.InsertAt(allRow, 0);

                cboRoleFilter.DataSource = dtFilter;
                cboRoleFilter.DisplayMember = "RoleName";
                cboRoleFilter.ValueMember = "ID";
                cboRoleFilter.SelectedIndex = 0;

                // Combobox gán vai trò ban đầu khi tạo mới
                DataTable dtAssign = dtFilter.Copy();
                dtAssign.Rows.RemoveAt(0); // Bỏ dòng "Tất cả"
                cboDefaultRole.DataSource = dtAssign;
                cboDefaultRole.DisplayMember = "RoleName";
                cboDefaultRole.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục vai trò: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAccounts()
        {
            try
            {
                int selectedRoleId = 0;
                if (cboRoleFilter.SelectedValue != null && int.TryParse(cboRoleFilter.SelectedValue.ToString(), out int rId))
                {
                    selectedRoleId = rId;
                }

                int activeFilter = cboActiveFilter.SelectedIndex; // 0: Tất cả, 1: Active, 2: Inactive

                string query = @"
                    SELECT a.AccountName, 
                           a.FullName, 
                           ISNULL(a.Email, '') AS Email, 
                           ISNULL(a.Tell, '') AS Tell, 
                           a.DateCreated,
                           STRING_AGG(CASE WHEN ra.Actived = 1 THEN r.RoleName ELSE r.RoleName + ' (Tắt)' END, ', ') AS Roles,
                           CASE 
                               WHEN SUM(CASE WHEN ra.Actived = 1 THEN 1 ELSE 0 END) > 0 THEN N'Đang kích hoạt'
                               ELSE N'Ngưng kích hoạt'
                           END AS StatusText
                    FROM Account a
                    LEFT JOIN RoleAccount ra ON a.AccountName = ra.AccountName
                    LEFT JOIN Role r ON ra.RoleID = r.ID
                    WHERE (@RoleID = 0 OR ra.RoleID = @RoleID)
                    GROUP BY a.AccountName, a.FullName, a.Email, a.Tell, a.DateCreated
                    HAVING (@ActiveFilter = 0)
                        OR (@ActiveFilter = 1 AND SUM(CASE WHEN ra.Actived = 1 THEN 1 ELSE 0 END) > 0)
                        OR (@ActiveFilter = 2 AND (SUM(CASE WHEN ra.Actived = 1 THEN 1 ELSE 0 END) = 0 OR COUNT(ra.RoleID) = 0))
                    ORDER BY a.AccountName";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@RoleID", selectedRoleId),
                    new SqlParameter("@ActiveFilter", activeFilter)
                };

                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
                dgvAccounts.DataSource = dt;
                ConfigureColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureColumns()
        {
            if (dgvAccounts.Columns["AccountName"] != null)
            {
                dgvAccounts.Columns["AccountName"].HeaderText = "Tên tài khoản";
                dgvAccounts.Columns["AccountName"].Width = 120;
            }
            if (dgvAccounts.Columns["FullName"] != null)
            {
                dgvAccounts.Columns["FullName"].HeaderText = "Họ và tên";
                dgvAccounts.Columns["FullName"].Width = 170;
            }
            if (dgvAccounts.Columns["Email"] != null)
            {
                dgvAccounts.Columns["Email"].HeaderText = "Email";
                dgvAccounts.Columns["Email"].Width = 150;
            }
            if (dgvAccounts.Columns["Tell"] != null)
            {
                dgvAccounts.Columns["Tell"].HeaderText = "Số điện thoại";
                dgvAccounts.Columns["Tell"].Width = 110;
            }
            if (dgvAccounts.Columns["DateCreated"] != null)
            {
                dgvAccounts.Columns["DateCreated"].HeaderText = "Ngày tạo";
                dgvAccounts.Columns["DateCreated"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                dgvAccounts.Columns["DateCreated"].Width = 130;
            }
            if (dgvAccounts.Columns["Roles"] != null)
            {
                dgvAccounts.Columns["Roles"].HeaderText = "Các vai trò";
                dgvAccounts.Columns["Roles"].Width = 180;
            }
            if (dgvAccounts.Columns["StatusText"] != null)
            {
                dgvAccounts.Columns["StatusText"].HeaderText = "Trạng thái";
                dgvAccounts.Columns["StatusText"].Width = 120;
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadAccounts();
        }

        private void cboFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAccounts();
        }

        private void dgvAccounts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvAccounts.Rows[e.RowIndex];
            txtAccountName.Text = row.Cells["AccountName"].Value?.ToString() ?? "";
            txtAccountName.ReadOnly = true;
            txtFullName.Text = row.Cells["FullName"].Value?.ToString() ?? "";
            txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";
            txtTell.Text = row.Cells["Tell"].Value?.ToString() ?? "";
            txtPassword.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtAccountName.Clear();
            txtAccountName.ReadOnly = false;
            txtPassword.Clear();
            txtFullName.Clear();
            txtEmail.Clear();
            txtTell.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string accountName = txtAccountName.Text.Trim();
            string password = txtPassword.Text;
            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string tell = txtTell.Text.Trim();

            if (string.IsNullOrWhiteSpace(accountName) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(fullName))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ: Tên tài khoản, Mật khẩu và Họ tên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Kiểm tra tài khoản đã tồn tại chưa
                string checkQuery = "SELECT COUNT(*) FROM Account WHERE AccountName = @AccountName";
                SqlParameter[] checkParams = { new SqlParameter("@AccountName", accountName) };
                int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkQuery, checkParams));

                if (count > 0)
                {
                    MessageBox.Show("Tên tài khoản này đã tồn tại trong hệ thống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Thêm vào bảng Account
                string insertAccount = @"INSERT INTO Account(AccountName, Password, FullName, Email, Tell, DateCreated) 
                                         VALUES (@AccountName, @Password, @FullName, @Email, @Tell, GETDATE())";
                SqlParameter[] insertParams = new SqlParameter[]
                {
                    new SqlParameter("@AccountName", accountName),
                    new SqlParameter("@Password", password),
                    new SqlParameter("@FullName", fullName),
                    new SqlParameter("@Email", string.IsNullOrEmpty(email) ? (object)DBNull.Value : email),
                    new SqlParameter("@Tell", string.IsNullOrEmpty(tell) ? (object)DBNull.Value : tell)
                };
                DatabaseHelper.ExecuteNonQuery(insertAccount, insertParams);

                // Gán vai trò mặc định ban đầu
                if (cboDefaultRole.SelectedValue != null && int.TryParse(cboDefaultRole.SelectedValue.ToString(), out int defaultRoleId))
                {
                    string insertRole = "INSERT INTO RoleAccount(RoleID, AccountName, Actived) VALUES (@RoleID, @AccountName, 1)";
                    SqlParameter[] roleParams = new SqlParameter[]
                    {
                        new SqlParameter("@RoleID", defaultRoleId),
                        new SqlParameter("@AccountName", accountName)
                    };
                    DatabaseHelper.ExecuteNonQuery(insertRole, roleParams);
                }

                MessageBox.Show("Thêm tài khoản mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnClear_Click(null, null);
                LoadAccounts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string accountName = txtAccountName.Text.Trim();
            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string tell = txtTell.Text.Trim();

            if (string.IsNullOrWhiteSpace(accountName) || string.IsNullOrWhiteSpace(fullName))
            {
                MessageBox.Show("Vui lòng chọn tài khoản và nhập họ tên hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = @"UPDATE Account 
                                 SET FullName = @FullName, Email = @Email, Tell = @Tell 
                                 WHERE AccountName = @AccountName";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@FullName", fullName),
                    new SqlParameter("@Email", string.IsNullOrEmpty(email) ? (object)DBNull.Value : email),
                    new SqlParameter("@Tell", string.IsNullOrEmpty(tell) ? (object)DBNull.Value : tell),
                    new SqlParameter("@AccountName", accountName)
                };

                int rows = DatabaseHelper.ExecuteNonQuery(query, parameters);
                if (rows > 0)
                {
                    MessageBox.Show("Cập nhật thông tin tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAccounts();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            string accountName = txtAccountName.Text.Trim();
            if (string.IsNullOrWhiteSpace(accountName))
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần reset mật khẩu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show(
                $"Bạn có chắc chắn muốn đặt lại mật khẩu cho tài khoản '{accountName}' về mặc định là '123456' không?",
                "Xác nhận reset mật khẩu",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dr != DialogResult.Yes) return;

            try
            {
                string query = "UPDATE Account SET Password = @Password WHERE AccountName = @AccountName";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Password", "123456"),
                    new SqlParameter("@AccountName", accountName)
                };

                int rows = DatabaseHelper.ExecuteNonQuery(query, parameters);
                if (rows > 0)
                {
                    MessageBox.Show($"Reset mật khẩu thành công!\nMật khẩu mới của tài khoản '{accountName}' là: 123456", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi reset mật khẩu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsmDeleteAccount_Click(object sender, EventArgs e)
        {
            if (dgvAccounts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string accountName = dgvAccounts.SelectedRows[0].Cells["AccountName"].Value.ToString();

            DialogResult dr = MessageBox.Show(
                $"Theo quy định bài tập, thao tác Xóa tài khoản sẽ đánh dấu toàn bộ vai trò của tài khoản '{accountName}' là không kích hoạt (0).\n\nBạn có chắc chắn muốn thực hiện không?",
                "Xác nhận vô hiệu hóa tài khoản",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dr != DialogResult.Yes) return;

            try
            {
                string query = "UPDATE RoleAccount SET Actived = 0 WHERE AccountName = @AccountName";
                SqlParameter[] parameters = { new SqlParameter("@AccountName", accountName) };

                int rows = DatabaseHelper.ExecuteNonQuery(query, parameters);
                MessageBox.Show($"Đã vô hiệu hóa thành công {rows} vai trò của tài khoản '{accountName}'!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAccounts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsmViewRoles_Click(object sender, EventArgs e)
        {
            if (dgvAccounts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn tài khoản để xem vai trò!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string accountName = dgvAccounts.SelectedRows[0].Cells["AccountName"].Value.ToString();
            AccountRoleForm frm = new AccountRoleForm(accountName);
            frm.ShowDialog();
            LoadAccounts();
        }
    }
}
