using KarateClub.Global_Classes;
using KarateClub.Members;
using KarateClub_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KarateClub.Users
{
    public partial class frmListUsers : Form
    {

        private DataTable _dtAllUsers;

        public frmListUsers()
        {
            InitializeComponent();
        }

        private string _GetRealColumnNameInDB()
        {
            switch (cbFilter.Text)
            {
                case "User ID":
                    return "UserID";

                case "Name":
                    return "Name";

                case "Username":
                    return "Username";

                case "Gender":
                    return "Gender";

                case "Phone":
                    return "Phone";

                case "Is Active":
                    return "IsActive";

                default:
                    return "None";
            }
        }

        private void _RefreshUserList()
        {
            _dtAllUsers = clsUser.GetAllUsers();
            dgvUsersList.DataSource = _dtAllUsers;
            lblNumberOfRecords.Text = dgvUsersList.Rows.Count.ToString();

            if (dgvUsersList.Rows.Count > 0)
            {
                dgvUsersList.Columns[0].HeaderText = "User ID";
                dgvUsersList.Columns[0].Width = 115;

                dgvUsersList.Columns[1].HeaderText = "Name";
                dgvUsersList.Columns[1].Width = 190;

                dgvUsersList.Columns[2].HeaderText = "Username";
                dgvUsersList.Columns[2].Width = 180;

                dgvUsersList.Columns[3].HeaderText = "Gender";
                dgvUsersList.Columns[3].Width = 100;

                dgvUsersList.Columns[4].HeaderText = "Date Of Birth";
                dgvUsersList.Columns[4].Width = 130;

                dgvUsersList.Columns[5].HeaderText = "Phone";
                dgvUsersList.Columns[5].Width = 110;

                dgvUsersList.Columns[6].HeaderText = "Is Active";
                dgvUsersList.Columns[6].Width = 80;
            }
        }

        private int _GetUserIDFromDGV()
        {
            return (int)dgvUsersList.CurrentRow.Cells["UserID"].Value;
        }

        private void frmListUsers_Load(object sender, EventArgs e)
        {
            _RefreshUserList();

            cbFilter.SelectedIndex = 0;
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Visible = (cbFilter.Text != "None") && (cbFilter.Text != "Gender") && (cbFilter.Text != "Is Active");

            cbGender.Visible = (cbFilter.Text == "Gender");

            cbIsActive.Visible = (cbFilter.Text == "Is Active");

            if (txtSearch.Visible)
            {
                txtSearch.Text = "";
                txtSearch.Focus();
            }

            if (cbGender.Visible)
            {
                cbGender.SelectedIndex = 0;
            }

            if (cbIsActive.Visible)
            {
                cbIsActive.SelectedIndex = 0;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (_dtAllUsers.Rows.Count == 0)
            {
                return;
            }

            string ColumnName = _GetRealColumnNameInDB();

            if (string.IsNullOrWhiteSpace(txtSearch.Text.Trim()) || cbFilter.Text == "None")
            {
                _dtAllUsers.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvUsersList.Rows.Count.ToString();

                return;
            }

            if (cbFilter.Text == "User ID")
            {
                // search with numbers
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", ColumnName, txtSearch.Text.Trim());
            }
            else
            {
                // search with string
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", ColumnName, txtSearch.Text.Trim());
            }

            lblNumberOfRecords.Text = dgvUsersList.Rows.Count.ToString();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "User ID" || cbFilter.Text == "Phone")
            {
                // make sure that the user can only enter the numbers
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void cbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtAllUsers.Rows.Count == 0)
            {
                return;
            }

            if (cbGender.Text == "All")
            {
                _dtAllUsers.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvUsersList.Rows.Count.ToString();

                return;
            }

            _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", "Gender", cbGender.Text);
            lblNumberOfRecords.Text = dgvUsersList.Rows.Count.ToString();
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtAllUsers.Rows.Count == 0)
            {
                return;
            }

            if (cbIsActive.Text == "All")
            {
                _dtAllUsers.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvUsersList.Rows.Count.ToString();

                return;
            }

            _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", "IsActive", (cbIsActive.Text == "Yes"));
            lblNumberOfRecords.Text = dgvUsersList.Rows.Count.ToString();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmShowUserDetails ShowUserDetails = new frmShowUserDetails(_GetUserIDFromDGV());
            ShowUserDetails.ShowDialog();

            _RefreshUserList();
        }

        private void addNewMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditUser AddNewUser = new frmAddEditUser();
            AddNewUser.ShowDialog();

            _RefreshUserList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditUser AddNewUser = new frmAddEditUser(_GetUserIDFromDGV());
            AddNewUser.ShowDialog();

            _RefreshUserList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this user?", "Confirm", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (clsUser.DeleteUser(_GetUserIDFromDGV()))
                {
                    MessageBox.Show("Deleted Done Successfully", "Deleted",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _RefreshUserList();
                }
                else
                {
                    MessageBox.Show("Deleted Failed", "Failed",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvUsersList_DoubleClick(object sender, EventArgs e)
        {
            frmShowUserDetails ShowUserDetails = new frmShowUserDetails(_GetUserIDFromDGV());
            ShowUserDetails.ShowDialog();

            _RefreshUserList();
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            frmAddEditUser AddNewUser = new frmAddEditUser();
            AddNewUser.ShowDialog();

            _RefreshUserList();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword ChangePasswordToCurrentUser = new frmChangePassword(_GetUserIDFromDGV());
            ChangePasswordToCurrentUser.ShowDialog();

            _RefreshUserList();
        }

        private void cmsEditProfile_Opening(object sender, CancelEventArgs e)
        {
            deleteToolStripMenuItem.Enabled = ((int)dgvUsersList.CurrentRow.Cells["UserID"].Value != clsGlobal.CurrentUser.UserID);
        }
    }
}
