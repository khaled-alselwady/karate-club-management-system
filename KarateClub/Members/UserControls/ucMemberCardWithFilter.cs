using KarateClub_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KarateClub.Members.UserControls
{
    public partial class ucMemberCardWithFilter : UserControl
    {

        // Define a custom event handler delegate with parameters
        public event Action<int> OnMemberSelected;
        // Create a protected method to raise the event with a parameter
        protected virtual void MemberSelected(int MemberID)
        {
            Action<int> handler = OnMemberSelected;
            if (handler != null)
            {
                handler(MemberID); // Raise the event with the parameter
            }
        }


        private bool _ShowAddMemberButton = true;
        public bool ShowAddMemberButton
        {
            get => _ShowAddMemberButton;

            set
            {
                _ShowAddMemberButton = value;
                btnAddNewMember.Visible = _ShowAddMemberButton;
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

        public int MemberID => ucMemberCard1.MemberID;
        public clsMember SelectedMemberInfo => ucMemberCard1.SelectedMemberInfo;

        public ucMemberCardWithFilter()
        {
            InitializeComponent();
        }

        private void _FindNow()
        {
            ucMemberCard1.LoadMemberInfo(int.Parse(txtFilterValue.Text.Trim()));

            if (OnMemberSelected != null && FilterEnabled)
            {
                // Raise the event with a parameter
                OnMemberSelected(ucMemberCard1.MemberID);
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

        private void btnAddNewMember_Click(object sender, EventArgs e)
        {
            frmAddEditMember AddNewMember = new frmAddEditMember();
            AddNewMember.MemberIDBack += AddNewMember_MemberIDBack;
            AddNewMember.Show();
        }

        private void AddNewMember_MemberIDBack(object sender, int MemberID)
        {
            txtFilterValue.Text = MemberID.ToString();
            ucMemberCard1.LoadMemberInfo(MemberID);
        }

        private void ucMemberCardWithFilter_Load(object sender, EventArgs e)
        {
            txtFilterValue.Focus();
        }

        public void LoadMemberInfo(int MemberID)
        {
            txtFilterValue.Text = MemberID.ToString();
            ucMemberCard1.LoadMemberInfo(MemberID);
        }

    }
}
