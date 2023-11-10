using KarateClub.Global_Classes;
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
    public partial class frmAddEditSubscriptionPeriod : Form
    {
        public delegate void DataBackEventHandler();
        public event DataBackEventHandler DataBack;

        private enum enMode { AddNew, Update };
        private enMode _Mode = enMode.AddNew;

        private int _SelectedMemberID = -1;

        private int _PeriodID = -1;
        private clsSubscriptionPeriod _Period;

        public frmAddEditSubscriptionPeriod()
        {
            InitializeComponent();

            this._Mode = enMode.AddNew;
        }

        public frmAddEditSubscriptionPeriod(int PeriodID)
        {
            InitializeComponent();

            this._PeriodID = PeriodID;
            this._Mode = enMode.Update;
        }

        private void _ResetDefaultValues()
        {
            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Subscription Period";
                this.Text = lblTitle.Text;

                _Period = new clsSubscriptionPeriod();
            }
            else
            {
                lblTitle.Text = "Update Subscription Period";
                this.Text = lblTitle.Text;
            }

            dtpStartDate.MinDate = DateTime.Now;

            dtpEndDate.MinDate = dtpStartDate.Value.AddMonths(clsSettings.DefaultSubscriptionPeriod());

            rbNo.Checked = true;
        }

        private void _LoadData()
        {
            _Period = clsSubscriptionPeriod.Find(_PeriodID);

            if (_Period == null)
            {
                MessageBox.Show($"There is no Period with ID = {_PeriodID}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnSave.Enabled = false;

                return;
            }

            ucMemberCardWithFilter1.FilterEnabled = false;
            ucMemberCardWithFilter1.LoadMemberInfo(_Period.MemberID);

            lblPeriodID.Text = _Period.PeriodID.ToString();
            lblMemberID.Text = _Period.MemberID.ToString();

            if (_Period.StartDate < DateTime.Now)
            {
                dtpStartDate.Value = DateTime.Now;
            }
            else
            {
                dtpStartDate.Value = _Period.StartDate;
            }

            if (_Period.EndDate < DateTime.Now.AddMonths(clsSettings.DefaultSubscriptionPeriod()))
            {
                dtpEndDate.Value = DateTime.Now.AddMonths(clsSettings.DefaultSubscriptionPeriod());
            }
            else
            {
                dtpEndDate.Value = _Period.EndDate;
            }

            txtFees.Text = _Period.Fees.ToString("F0");

            if (_Period.IsPaid)
            {
                rbYes.Checked = true;

                rbYes.Enabled = false;
                rbNo.Enabled = false;

                lblPaymentID.Text = _Period.PaymentID.ToString();

                btnSave.Enabled = false;
                llShowPeriodsHistory.Enabled = true;
                return;
            }
            else
            {
                rbNo.Checked = true;
            }

            btnSave.Enabled = true;
            llShowPeriodsHistory.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void ucMemberCardWithFilter1_OnMemberSelected(int obj)
        {
            _SelectedMemberID = obj;

            if (_SelectedMemberID == -1)
            {
                btnSave.Enabled = false;
                ucMemberCardWithFilter1.Clear();
                lblMemberID.Text = "[????]";

                return;
            }

            int PeriodID = ucMemberCardWithFilter1.SelectedMemberInfo.GetLastActivePeriodID();

            if (PeriodID != -1)
            {
                clsSubscriptionPeriod LastPeriod = clsSubscriptionPeriod.Find(PeriodID);

                if (LastPeriod == null)
                {
                    btnSave.Enabled = false;

                    return;
                }

                MessageBox.Show($"This member already has an active subscription period!," +
                    $" his subscription period will expire at [{clsFormat.DateToShort(LastPeriod.EndDate)}]", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnSave.Enabled = false;
                llShowPeriodsHistory.Enabled = true;

                return;
            }

            lblMemberID.Text = _SelectedMemberID.ToString();
            btnSave.Enabled = true;
            llShowPeriodsHistory.Enabled = true;
            txtFees.Focus();
        }

        private void frmAddEditSubscriptionPeriod_Activated(object sender, EventArgs e)
        {
            ucMemberCardWithFilter1.FilterFocus();
        }

        private void frmAddEditSubscriptionPeriod_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the error",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Period.StartDate = dtpStartDate.Value;
            _Period.EndDate = dtpEndDate.Value;
            _Period.MemberID = ucMemberCardWithFilter1.MemberID;
            _Period.Fees = Convert.ToDecimal(txtFees.Text.Trim());
            _Period.IsActive = true;

            if (_Mode == enMode.AddNew)
            {
                _Period.IssueReason = clsSubscriptionPeriod.enIssueReason.FirstTime;
            }

            int PaymentID = -1;

            if (rbYes.Enabled && rbYes.Checked)
            {
                // create record in the payment table

                PaymentID = _Period.Pay(Convert.ToDecimal(txtFees.Text.Trim()));

                lblPaymentID.Text = PaymentID.ToString();
            }

            _Period.PaymentID = PaymentID;
            _Period.IsPaid = (PaymentID != -1);

            clsMember.SetActivity(_Period.MemberID, _Period.IsPaid);

            if (_Period.Save())
            {
                MessageBox.Show("Successfully Registered", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                ucMemberCardWithFilter1.FilterEnabled = false;
                btnSave.Enabled = false;
                txtFees.Enabled = false;

                DataBack?.Invoke();
            }
            else
            {
                MessageBox.Show("Failed Registered", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void llShowPeriodsHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowSubscriptionPeriodsHistory ShowPeriodsHistory = new frmShowSubscriptionPeriodsHistory(ucMemberCardWithFilter1.MemberID);
            ShowPeriodsHistory.ShowDialog();
        }
    }
}
