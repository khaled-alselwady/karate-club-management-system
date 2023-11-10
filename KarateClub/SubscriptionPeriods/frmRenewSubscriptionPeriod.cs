using KarateClub.Global_Classes;
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

namespace KarateClub.SubscriptionPeriods
{
    public partial class frmRenewSubscriptionPeriod : Form
    {
        public delegate void DataBackEventHandler();
        public event DataBackEventHandler DataBack;

        private int _NewPeriodID = -1;

        public frmRenewSubscriptionPeriod()
        {
            InitializeComponent();
        }

        public frmRenewSubscriptionPeriod(int OldPeriodID)
        {
            InitializeComponent();

            ucSubscriptionPeriodInfoWithFilter1.LoadSubscriptionPeriodInfo(OldPeriodID);
            ucSubscriptionPeriodInfoWithFilter1.FilterEnabled = false;
        }

        private void _LoadData()
        {
            dtpStartDate.MinDate = DateTime.Now;

            dtpEndDate.MinDate = dtpStartDate.Value.AddMonths(clsSettings.DefaultSubscriptionPeriod());

            rbNo.Checked = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRenewSubscriptionPeriod_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void ucSubscriptionPeriodInfoWithFilter1_OnPeriodSelected(int obj)
        {
            if (obj == -1)
            {
                btnRenew.Enabled = false;

                return;
            }

            if (!ucSubscriptionPeriodInfoWithFilter1.SelectedPeriodInfo.DidPeriodExpire())
            {
                DateTime ExpiredDate = ucSubscriptionPeriodInfoWithFilter1.SelectedPeriodInfo.EndDate;

                MessageBox.Show($"This period has not expired yet!, it expires at" +
                    $" [{clsFormat.DateToShort(ExpiredDate)}]", "Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnRenew.Enabled = false;

                return;
            }

            if (!ucSubscriptionPeriodInfoWithFilter1.SelectedPeriodInfo.IsActive)
            {
                MessageBox.Show($"This period is not active!, Choose another one.", "Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnRenew.Enabled = false;

                return;
            }

            lblMemberID.Text = ucSubscriptionPeriodInfoWithFilter1.SelectedPeriodInfo.MemberID.ToString();
            lblPreviousPeriodID.Text = ucSubscriptionPeriodInfoWithFilter1.SelectedPeriodInfo.PeriodID.ToString();

            btnRenew.Enabled = true;
            llShowPeriodsHistory.Enabled = true;
        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "Fees cannot be empty!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtFees, null);

            };


            if (!clsValidation.IsNumber(txtFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "Invalid Number.");
            }
            else
            {
                errorProvider1.SetError(txtFees, null);
            };
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the error",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sure you want to Renew the license?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            int PaymentID = -1;

            int RenewPeriodID = ucSubscriptionPeriodInfoWithFilter1.SelectedPeriodInfo.
                Renew(Convert.ToDecimal(txtFees.Text.Trim()), dtpStartDate.Value,
                dtpEndDate.Value, rbYes.Checked, ref PaymentID);

            if (RenewPeriodID == -1)
            {
                MessageBox.Show("Failed to Renew the Period", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _NewPeriodID = RenewPeriodID;
            lblRenewPeriodID.Text = RenewPeriodID.ToString();
            lblPaymentID.Text = (PaymentID != -1) ? PaymentID.ToString() : "[????]";

            MessageBox.Show("Period Renewed Successfully with ID = " + RenewPeriodID.ToString(),
                "Period Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnRenew.Enabled = false;
            ucSubscriptionPeriodInfoWithFilter1.FilterEnabled = false;
            llShowNewPeriodInfo.Enabled = true;

            DataBack?.Invoke();
        }

        private void llShowNewPeriodInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowSubscriptionPeriodDetails ShowSubscriptionPeriodDetails = new frmShowSubscriptionPeriodDetails(_NewPeriodID);
            ShowSubscriptionPeriodDetails.ShowDialog();
        }

        private void llShowPeriodsHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowSubscriptionPeriodsHistory ShowPeriodsHistory = new frmShowSubscriptionPeriodsHistory(ucSubscriptionPeriodInfoWithFilter1.SelectedPeriodInfo.MemberID);
            ShowPeriodsHistory.ShowDialog();
        }
    }
}
