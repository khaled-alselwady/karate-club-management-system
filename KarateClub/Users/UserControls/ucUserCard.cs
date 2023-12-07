using KarateClub.Members;
using KarateClub.Properties;
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

namespace KarateClub.Users.UserControls
{
    public partial class ucUserCard : UserControl
    {

        private int _UserID = -1;
        private clsUser _User;

        public int UserID => _UserID;
        public clsUser SelectedUserInfo => _User;

        private bool _ShowPermissions = true;

        public ucUserCard()
        {
            InitializeComponent();
        }

        private void _Reset()
        {
            this._UserID = -1;
            this._User = null;

            lblUserID.Text = "[????]";
            lblUsername.Text = "[????]";
            lblIsActive.Text = "[????]";

            llEditUserInfo.Enabled = false;
        }

        private void _FillUserInfo()
        {
            llEditUserInfo.Enabled = true;

            ucPersonCard1.LoadPersonInfo(_User.PersonID);

            lblUserID.Text = _User.UserID.ToString();
            lblUsername.Text = _User.Username;
            lblIsActive.Text = (_User.IsActive) ? "Yes" : "No";

            if (_User.IsActive)
                pbIsActive.Image = Resources.active_user;

            else
                pbIsActive.Image = Resources.inactive_user;
        }

        public void LoadUserInfo(int UserID, bool ShowPermissions = true)
        {
            this._UserID = UserID;

            if (UserID == -1)
            {
                MessageBox.Show("There is no User with id = -1", "Missing User",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                _Reset();

                return;
            }

            _User = clsUser.Find(this._UserID);

            if (_User == null)
            {
                MessageBox.Show($"There is no User with id = {UserID}", "Missing User",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                _Reset();

                return;
            }

            _FillUserInfo();

            _ShowPermissions = ShowPermissions;
        }

        private void llEditUserInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditUser EditUser = new frmAddEditUser(_UserID, _ShowPermissions);
            EditUser.ShowDialog();

            LoadUserInfo(_UserID);
        }


    }
}
