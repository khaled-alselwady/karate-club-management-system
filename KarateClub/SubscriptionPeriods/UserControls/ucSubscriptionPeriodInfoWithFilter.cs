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

namespace KarateClub.SubscriptionPeriods.UserControls
{
    public partial class ucSubscriptionPeriodInfoWithFilter : UserControl
    {
        // Define a custom event handler delegate with parameters
        public event Action<int> OnPeriodSelected;
        // Create a protected method to raise the event with a parameter
        protected virtual void PeriodSelected(int PeriodID)
        {
            Action<int> handler = OnPeriodSelected;
            if (handler != null)
            {
                handler(PeriodID); // Raise the event with the parameter
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

        public int PeriodID => ucSubscriptionPeriodInfo1.PeriodID;
        public clsSubscriptionPeriod SelectedPeriodInfo => ucSubscriptionPeriodInfo1.Period;

        public ucSubscriptionPeriodInfoWithFilter()
        {
            InitializeComponent();
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

            LoadSubscriptionPeriodInfo(int.Parse(txtFilterValue.Text.Trim()));
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

        private void ucSubscriptionPeriodInfoWithFilter_Load(object sender, EventArgs e)
        {
            txtFilterValue.Focus();
        }

        public void LoadSubscriptionPeriodInfo(int PeriodID)
        {
            txtFilterValue.Text = PeriodID.ToString();
            ucSubscriptionPeriodInfo1.LoadSubscriptionPeriodInfo(PeriodID);

            if (OnPeriodSelected != null && FilterEnabled)
            {
                // Raise the event with a parameter
                OnPeriodSelected(ucSubscriptionPeriodInfo1.PeriodID);
            }
        }

        public void Clear()
        {
            ucSubscriptionPeriodInfo1.Reset();
        }
    }
}
