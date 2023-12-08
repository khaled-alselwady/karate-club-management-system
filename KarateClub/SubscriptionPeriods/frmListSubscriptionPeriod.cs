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
using static KarateClub_Business.clsPerson;

namespace KarateClub.SubscriptionPeriods
{
    public partial class frmListSubscriptionPeriod : Form
    {
        private DataTable _dtAllSubscriptionPeriod;

        public frmListSubscriptionPeriod()
        {
            InitializeComponent();
        }

        private string _GetRealColumnNameInDB()
        {
            switch (cbFilter.Text)
            {
                case "Period ID":
                    return "PeriodID";

                case "Member Name":
                    return "MemberName";

                case "Fees":
                    return "Fees";

                case "Is Paid":
                    return "IsPaid";

                case "Payment ID":
                    return "PaymentID";

                case "Is Active":
                    return "IsActive";

                default:
                    return "None";
            }
        }

        private void _RefreshSubscriptionPeriodsList()
        {
            _dtAllSubscriptionPeriod = clsSubscriptionPeriod.GetAllSubscriptionPeriods();
            dgvSubscriptionPeriodsList.DataSource = _dtAllSubscriptionPeriod;
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
            }
        }

        private int _GetPeriodIDFromDGV()
        {
            return (int)dgvSubscriptionPeriodsList.CurrentRow.Cells["PeriodID"].Value;
        }

        private void frmListSubscriptionPeriod_Load(object sender, EventArgs e)
        {
            _RefreshSubscriptionPeriodsList();

            cbFilter.SelectedIndex = 0;
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Visible = (cbFilter.Text != "None") && (cbFilter.Text != "Is Paid") && (cbFilter.Text != "Is Active") && (cbFilter.Text != "Is Expired");

            cbIsPaid.Visible = (cbFilter.Text == "Is Paid");

            cbIsActive.Visible = (cbFilter.Text == "Is Active");

            cbIsExpired.Visible = (cbFilter.Text == "Is Expired");

            if (txtSearch.Visible)
            {
                txtSearch.Text = "";
                txtSearch.Focus();
            }

            if (cbIsPaid.Visible)
            {
                cbIsPaid.SelectedIndex = 0;
            }

            if (cbIsActive.Visible)
            {
                cbIsActive.SelectedIndex = 0;
            }

            if (cbIsExpired.Visible)
            {
                cbIsExpired.SelectedIndex = 0;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (_dtAllSubscriptionPeriod.Rows.Count == 0)
            {
                return;
            }

            string ColumnName = _GetRealColumnNameInDB();

            if (string.IsNullOrWhiteSpace(txtSearch.Text.Trim()) || cbFilter.Text == "None")
            {
                _dtAllSubscriptionPeriod.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvSubscriptionPeriodsList.Rows.Count.ToString();

                return;
            }

            if (cbFilter.Text == "Period ID" || cbFilter.Text == "Payment ID")
            {
                // search with numbers
                _dtAllSubscriptionPeriod.DefaultView.RowFilter =
                    string.Format("[{0}] = {1}", ColumnName, txtSearch.Text.Trim());
            }
            else
            {
                // search with string
                _dtAllSubscriptionPeriod.DefaultView.RowFilter =
                    string.Format("[{0}] like '{1}%'", ColumnName, txtSearch.Text.Trim());
            }

            lblNumberOfRecords.Text = dgvSubscriptionPeriodsList.Rows.Count.ToString();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "Period ID" || cbFilter.Text == "Payment ID")
            {
                // make sure that the user can only enter the numbers
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void cbIsPaid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtAllSubscriptionPeriod.Rows.Count == 0)
            {
                return;
            }

            if (cbIsPaid.Text == "All")
            {
                _dtAllSubscriptionPeriod.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvSubscriptionPeriodsList.Rows.Count.ToString();

                return;
            }

            _dtAllSubscriptionPeriod.DefaultView.RowFilter =
                string.Format("[{0}] = {1}", "IsPaid", (cbIsPaid.Text == "Yes"));

            lblNumberOfRecords.Text = dgvSubscriptionPeriodsList.Rows.Count.ToString();
        }

        private void btnAddNewSubscriptionPeriodID_Click(object sender, EventArgs e)
        {
            frmAddEditSubscriptionPeriod AddNewSubscriptionPeriod = new frmAddEditSubscriptionPeriod();
            AddNewSubscriptionPeriod.ShowDialog();

            _RefreshSubscriptionPeriodsList();
        }

        private void cmsEditProfile_Opening(object sender, CancelEventArgs e)
        {
            if (dgvSubscriptionPeriodsList.Rows.Count > 0)
            {
                payToolStripMenuItem.Enabled = !(bool)dgvSubscriptionPeriodsList.CurrentRow.Cells["IsPaid"].Value;
                editToolStripMenuItem.Enabled = payToolStripMenuItem.Enabled;

                DateTime EndDate = (DateTime)dgvSubscriptionPeriodsList.CurrentRow.Cells["EndDate"].Value;

                RenewtoolStripMenuItem1.Enabled = (EndDate < DateTime.Now) && (bool)dgvSubscriptionPeriodsList.CurrentRow.Cells["IsActive"].Value;

                deleteToolStripMenuItem.Enabled = !(bool)dgvSubscriptionPeriodsList.CurrentRow.Cells["IsPaid"].Value &&
                                                   (bool)dgvSubscriptionPeriodsList.CurrentRow.Cells["IsActive"].Value;

            }
        }

        private void addNewMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditSubscriptionPeriod AddNewSubscriptionPeriod = new frmAddEditSubscriptionPeriod();
            AddNewSubscriptionPeriod.ShowDialog();

            _RefreshSubscriptionPeriodsList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditSubscriptionPeriod AddNewSubscriptionPeriod = new frmAddEditSubscriptionPeriod(_GetPeriodIDFromDGV());
            AddNewSubscriptionPeriod.ShowDialog();

            _RefreshSubscriptionPeriodsList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this period?", "Confirm", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (clsSubscriptionPeriod.DeletePeriod(_GetPeriodIDFromDGV()))
                {
                    MessageBox.Show("Deleted Done Successfully", "Deleted",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _RefreshSubscriptionPeriodsList();
                }
                else
                {
                    MessageBox.Show("Deleted Failed", "Failed",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void payToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to pay for this period?", "Confirm", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

                clsSubscriptionPeriod Period = clsSubscriptionPeriod.Find(_GetPeriodIDFromDGV());

                if (Period == null)
                {
                    MessageBox.Show("Pay Failed", "Failed",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                int? PaymentID = Period.Pay((decimal)dgvSubscriptionPeriodsList.CurrentRow.Cells["Fees"].Value);

                if (PaymentID.HasValue)
                {
                    Period.PaymentID = PaymentID;
                    Period.IsPaid = (PaymentID.HasValue);

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

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtAllSubscriptionPeriod.Rows.Count == 0)
            {
                return;
            }

            if (cbIsActive.Text == "All")
            {
                _dtAllSubscriptionPeriod.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvSubscriptionPeriodsList.Rows.Count.ToString();

                return;
            }

            _dtAllSubscriptionPeriod.DefaultView.RowFilter =
                string.Format("[{0}] = {1}", "IsActive", (cbIsActive.Text == "Yes"));

            lblNumberOfRecords.Text = dgvSubscriptionPeriodsList.Rows.Count.ToString();
        }

        private void showPeriodHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsSubscriptionPeriod Period = clsSubscriptionPeriod.Find(_GetPeriodIDFromDGV());
            frmShowSubscriptionPeriodsHistory ShowHistory = new frmShowSubscriptionPeriodsHistory(Period.MemberID);
            ShowHistory.ShowDialog();

            _RefreshSubscriptionPeriodsList();
        }

        private void ShowPeriodDetailstoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmShowSubscriptionPeriodDetails ShowSubscriptionPeriodDetails = new frmShowSubscriptionPeriodDetails(_GetPeriodIDFromDGV());
            ShowSubscriptionPeriodDetails.ShowDialog();
        }

        private void RenewtoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmRenewSubscriptionPeriod RenewSubscriptionPeriod = new frmRenewSubscriptionPeriod(_GetPeriodIDFromDGV());
            RenewSubscriptionPeriod.ShowDialog();

            _RefreshSubscriptionPeriodsList();
        }

        private void btnRenewPeriod_Click(object sender, EventArgs e)
        {
            frmRenewSubscriptionPeriod RenewSubscriptionPeriod = new frmRenewSubscriptionPeriod();
            RenewSubscriptionPeriod.ShowDialog();

            _RefreshSubscriptionPeriodsList();
        }

        private void btnRenewPeriod_MouseEnter(object sender, EventArgs e)
        {
            btnRenewPeriod.BackColor = Color.Gainsboro;
        }

        private void btnRenewPeriod_MouseLeave(object sender, EventArgs e)
        {
            btnRenewPeriod.BackColor = Color.White;
        }

        private void cbIsExpired_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtAllSubscriptionPeriod.Rows.Count == 0)
            {
                return;
            }

            if (cbIsExpired.Text == "All")
            {
                _dtAllSubscriptionPeriod.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvSubscriptionPeriodsList.Rows.Count.ToString();

                return;
            }

            if (cbIsExpired.Text == "Yes")
            {
                _dtAllSubscriptionPeriod.DefaultView.RowFilter =
                string.Format("[{0}] < '{1}'", "EndDate", DateTime.Now);
            }
            else
            {
                _dtAllSubscriptionPeriod.DefaultView.RowFilter =
                string.Format("[{0}] >= '{1}'", "EndDate", DateTime.Now);
            }
            

            lblNumberOfRecords.Text = dgvSubscriptionPeriodsList.Rows.Count.ToString();
        }

        private void dgvSubscriptionPeriodsList_DoubleClick(object sender, EventArgs e)
        {
            frmShowSubscriptionPeriodDetails ShowSubscriptionPeriodDetails = new frmShowSubscriptionPeriodDetails(_GetPeriodIDFromDGV());
            ShowSubscriptionPeriodDetails.ShowDialog();
        }
    }
}
