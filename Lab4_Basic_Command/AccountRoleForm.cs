using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab4_Basic_Command
{
    public partial class AccountRoleForm : Form
    {
        private string accountName;

        public AccountRoleForm(string account)
        {
            InitializeComponent();
            accountName = account;
        }

        private void AccountRoleForm_Load(object sender, EventArgs e)
        {
            lblAccount.Text = "  Danh sách vai trò của tài khoản: " + accountName;
            this.Text = "Vai trò của tài khoản: " + accountName;
            LoadRoles();
        }

        private void LoadRoles()
        {
            try
            {
                string query = @"
                    SELECT r.ID AS RoleID, 
                           r.RoleName, 
                           CAST(ISNULL(ra.Actived, 0) AS BIT) AS Actived,
                           ISNULL(ra.Notes, '') AS Notes
                    FROM Role r
                    LEFT JOIN RoleAccount ra ON r.ID = ra.RoleID AND ra.AccountName = @AccountName
                    ORDER BY r.ID";

                SqlParameter[] parameters = { new SqlParameter("@AccountName", accountName) };
                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

                dgvRoles.DataSource = dt;

                if (dgvRoles.Columns["RoleID"] != null)
                {
                    dgvRoles.Columns["RoleID"].HeaderText = "Mã vai trò";
                    dgvRoles.Columns["RoleID"].ReadOnly = true;
                    dgvRoles.Columns["RoleID"].Width = 90;
                }
                if (dgvRoles.Columns["RoleName"] != null)
                {
                    dgvRoles.Columns["RoleName"].HeaderText = "Tên vai trò";
                    dgvRoles.Columns["RoleName"].ReadOnly = true;
                    dgvRoles.Columns["RoleName"].Width = 180;
                }
                if (dgvRoles.Columns["Actived"] != null)
                {
                    dgvRoles.Columns["Actived"].HeaderText = "Kích hoạt";
                    dgvRoles.Columns["Actived"].Width = 80;
                }
                if (dgvRoles.Columns["Notes"] != null)
                {
                    dgvRoles.Columns["Notes"].HeaderText = "Ghi chú";
                    dgvRoles.Columns["Notes"].Width = 200;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải vai trò: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                dgvRoles.EndEdit();

                foreach (DataGridViewRow row in dgvRoles.Rows)
                {
                    int roleId = Convert.ToInt32(row.Cells["RoleID"].Value);
                    bool actived = Convert.ToBoolean(row.Cells["Actived"].Value);
                    string notes = row.Cells["Notes"].Value?.ToString() ?? "";

                    // Kiểm tra xem dòng này đã có trong RoleAccount chưa
                    string checkQuery = "SELECT COUNT(*) FROM RoleAccount WHERE RoleID = @RoleID AND AccountName = @AccountName";
                    SqlParameter[] checkParams = new SqlParameter[]
                    {
                        new SqlParameter("@RoleID", roleId),
                        new SqlParameter("@AccountName", accountName)
                    };
                    int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkQuery, checkParams));

                    if (count > 0)
                    {
                        string updateQuery = "UPDATE RoleAccount SET Actived = @Actived, Notes = @Notes WHERE RoleID = @RoleID AND AccountName = @AccountName";
                        SqlParameter[] updateParams = new SqlParameter[]
                        {
                            new SqlParameter("@Actived", actived),
                            new SqlParameter("@Notes", notes),
                            new SqlParameter("@RoleID", roleId),
                            new SqlParameter("@AccountName", accountName)
                        };
                        DatabaseHelper.ExecuteNonQuery(updateQuery, updateParams);
                    }
                    else if (actived)
                    {
                        string insertQuery = "INSERT INTO RoleAccount(RoleID, AccountName, Actived, Notes) VALUES (@RoleID, @AccountName, @Actived, @Notes)";
                        SqlParameter[] insertParams = new SqlParameter[]
                        {
                            new SqlParameter("@RoleID", roleId),
                            new SqlParameter("@AccountName", accountName),
                            new SqlParameter("@Actived", actived),
                            new SqlParameter("@Notes", notes)
                        };
                        DatabaseHelper.ExecuteNonQuery(insertQuery, insertParams);
                    }
                }

                MessageBox.Show("Cập nhật vai trò thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadRoles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu vai trò: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
