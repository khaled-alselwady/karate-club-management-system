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
    public partial class frmShowSubscriptionPeriodsHistory : Form
    {
        private DataTable _dtAllSubscriptionPeriodForMember;

        private int _MemberID = -1;

        public frmShowSubscriptionPeriodsHistory(int MemberID)
        {
            InitializeComponent();

            this._MemberID = MemberID;
            ucMemberCard1.LoadMemberInfo(this._MemberID);
        }

        private void _RefreshSubscriptionPeriodsList()
        {
            _dtAllSubscriptionPeriodForMember = clsSubscriptionPeriod.GetAllPeriodsForMember(_MemberID);
            dgvSubscriptionPeriodsList.DataSource = _dtAllSubscriptionPeriodForMember;
            lblNumberOfRecords.Text = dgvSubscriptionPeriodsList.Rows.Count.ToString();

            if (dgvSubscriptionPeriodsList.Rows.Count > 0)
            {
                dgvSubscriptionPeriodsList.Columns[0].HeaderText = "Period ID";
                dgvSubscriptionPeriodsList.Columns[0].Width = 100;

                dgvSubscriptionPeriodsList.Columns[1].HeaderText = "Member Name";
                dgvSubscriptionPeriodsList.Columns[1].Width = 150;

                dgvSubscriptionPeriodsList.Columns[2].HeaderText = "Fees";
                dgvSubscriptionPeriodsList.Columns[2].Width = 110;

                dgvSubscriptionPeriodsList.Columns[3].HeaderText = "Is Paid";
                dgvSubscriptionPeriodsList.Columns[3].Width = 100;

                dgvSubscriptionPeriodsList.Columns[4].HeaderText = "Start Date";
                dgvSubscriptionPeriodsList.Columns[4].Width = 106;

                dgvSubscriptionPeriodsList.Columns[5].HeaderText = "End Date";
                dgvSubscriptionPeriodsList.Columns[5].Width = 105;

                dgvSubscriptionPeriodsList.Columns[6].HeaderText = "Subscription Days";
                dgvSubscriptionPeriodsList.Columns[6].Width = 160;

                dgvSubscriptionPeriodsList.Columns[7].HeaderText = "Payment ID";
                dgvSubscriptionPeriodsList.Columns[7].Width = 115;

                dgvSubscriptionPeriodsList.Columns[8].HeaderText = "Is Active";
                dgvSubscriptionPeriodsList.Columns[8].Width = 100;

                DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
                checkBoxColumn.HeaderText = "Is Active";
                checkBoxColumn.Name = "IsActive";
                checkBoxColumn.DataPropertyName = "IsActive";
                dgvSubscriptionPeriodsList.Columns.Remove("IsActive"); // Remove the original IsActive column
                dgvSubscriptionPeriodsList.Columns.Insert(8, checkBoxColumn);
            }



        }

        private void frmShowSubscriptionPeriodsHistory_Load(object sender, EventArgs e)
        {
            _RefreshSubscriptionPeriodsList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowPeriodDetailstoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmShowSubscriptionPeriodDetails ShowSubscriptionPeriodDetails =
                new frmShowSubscriptionPeriodDetails
                ((int)dgvSubscriptionPeriodsList.CurrentRow.Cells["PeriodID"].Value);

            ShowSubscriptionPeriodDetails.ShowDialog();
        }

        private void payToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to pay for this period?", "Confirm", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

                clsSubscriptionPeriod Period = clsSubscriptionPeriod.
                    Find((int)dgvSubscriptionPeriodsList.CurrentRow.Cells["PeriodID"].Value);

                if (Period == null)
                {
                    MessageBox.Show("Pay Failed", "Failed",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                int PaymentID = Period.Pay((decimal)dgvSubscriptionPeriodsList.CurrentRow.Cells["Fees"].Value);

                if (PaymentID != -1)
                {
                    Period.PaymentID = PaymentID;
                    Period.IsPaid = (PaymentID != -1);

                    if (Period.Save())
                    {
                        MessageBox.Show("Pay Done Successfully", "Deleted",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                        _RefreshSubscriptionPeriodsList();
                    }
                }
                else
                {
                    MessageBox.Show("Deleted Failed", "Failed",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmsEditProfile_Opening(object sender, CancelEventArgs e)
        {
            payToolStripMenuItem.Enabled = !(bool)dgvSubscriptionPeriodsList.CurrentRow.Cells["IsPaid"].Value;
        }
    }
}
