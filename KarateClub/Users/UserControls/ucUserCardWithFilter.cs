using KarateClub.Members;
using KarateClub.Members.UserControls;
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
    public partial class ucUserCardWithFilter : UserControl
    {

        // Define a custom event handler delegate with parameters
        public event Action<int> OnUserSelected;
        // Create a protected method to raise the event with a parameter
        protected virtual void UserSelected(int UserID)
        {
            Action<int> handler = OnUserSelected;
            if (handler != null)
            {
                handler(UserID); // Raise the event with the parameter
            }
        }

        private bool _ShowAddUserButton = true;
        public bool ShowAddUserButton
        {
            get => _ShowAddUserButton;

            set
            {
                _ShowAddUserButton = value;
                btnAddNewUser.Visible = _ShowAddUserButton;
            }
        }

        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get => _FilterEnabled;

            set
            {
                _FilterEnabled = value;
                gbFilters.Enabled = _FilterEnabled;
            }
        }

        public int UserID => ucUserCard1.UserID;
        public clsUser SelectedUserInfo => ucUserCard1.SelectedUserInfo;

        public ucUserCardWithFilter()
        {
            InitializeComponent();
        }

        private void _FindNow()
        {
            ucUserCard1.LoadUserInfo(int.Parse(txtFilterValue.Text.Trim()));

            if (OnUserSelected != null && FilterEnabled)
            {
                // Raise the event with a parameter
                OnUserSelected(ucUserCard1.UserID);
            }
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is Enter (character code 13)
            if (e.KeyChar == (char)13)
            {

                btnFind.PerformClick();
            }

            // to make sure that the user can enter only numbers
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we don't continue because the form is not valid
                MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the Error",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            _FindNow();
        }

        private void txtFilterValue_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFilterValue.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFilterValue, "This field is required!");
            }
            else
            {
                errorProvider1.SetError(txtFilterValue, null);
            }
        }

        public void FilterFocus()
        {
            txtFilterValue.Focus();
        }

        private void ucUserCardWithFilter_Load(object sender, EventArgs e)
        {
            txtFilterValue.Focus();
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            frmAddEditUser AddNewUser = new frmAddEditUser();
            AddNewUser.GetUserID += AddNewUser_UserIDBack;
            AddNewUser.ShowDialog();
        }

        private void AddNewUser_UserIDBack(int UserID)
        {
            txtFilterValue.Text = UserID.ToString();
            ucUserCard1.LoadUserInfo(UserID);
        }
    }
}
