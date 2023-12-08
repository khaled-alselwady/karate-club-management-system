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

namespace KarateClub.Instructors.UserControls
{
    public partial class ucInstructorCardWithFilter : UserControl
    {
        #region Declare Event
        public class InstructorSelectedEventArgs : EventArgs
        {
            public int? InstructorID { get; }

            public InstructorSelectedEventArgs(int? InstructorID)
            {
                this.InstructorID = InstructorID;
            }
        }

        public event EventHandler<InstructorSelectedEventArgs> OnInstructorSelected;

        public void RaiseOnInstructorSelected(int? InstructorID)
        {
            RaiseOnInstructorSelected(new InstructorSelectedEventArgs(InstructorID));
        }

        protected virtual void RaiseOnInstructorSelected(InstructorSelectedEventArgs e)
        {
            OnInstructorSelected?.Invoke(this, e);
        }
        #endregion

        private bool _ShowAddInstructorButton = true;
        public bool ShowAddInstructorButton
        {
            get => _ShowAddInstructorButton;

            set
            {
                _ShowAddInstructorButton = value;
                btnAddNewInstructor.Visible = _ShowAddInstructorButton;
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

        public int? InstructorID => ucInstructorCard1.InstructorID;
        public clsInstructor SelectedInstructorInfo => ucInstructorCard1.SelectedInstructorInfo;

        public ucInstructorCardWithFilter()
        {
            InitializeComponent();
        }

        private void _FindNow()
        {
            ucInstructorCard1.LoadInstructorInfo(int.Parse(txtFilterValue.Text.Trim()));

            if (OnInstructorSelected != null && FilterEnabled)
            {
                // Raise the event with a parameter
                RaiseOnInstructorSelected(ucInstructorCard1.InstructorID);
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

        private void ucInstructorCardWithFilter_Load(object sender, EventArgs e)
        {
            txtFilterValue.Focus();
        }

        private void btnAddNewInstructor_Click(object sender, EventArgs e)
        {
            frmAddEditInstructor AddNewInstructor = new frmAddEditInstructor();
            AddNewInstructor.GetInstructorID += AddNewInstructor_InstructorIDBack;
            AddNewInstructor.ShowDialog();
        }

        private void AddNewInstructor_InstructorIDBack(int? InstructorID)
        {
            txtFilterValue.Text = InstructorID.ToString();
            ucInstructorCard1.LoadInstructorInfo(InstructorID);
        }

        public void LoadInstructorInfo(int? InstructorID)
        {
            txtFilterValue.Text = InstructorID.ToString();
            ucInstructorCard1.LoadInstructorInfo(InstructorID);
        }
    }
}
