using KarateClub.SubscriptionPeriods;
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

namespace KarateClub.Members
{
    public partial class frmListMembers : Form
    {

        private DataTable _dtAllMembers;

        public frmListMembers()
        {
            InitializeComponent();
        }

        private string _GetRealColumnNameInDB()
        {
            switch (cbFilter.Text)
            {
                case "Member ID":
                    return "MemberID";

                case "Name":
                    return "Name";

                case "Rank Name":
                    return "RankName";

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

        private void _FillBeltRanksInComboBox()
        {
            // add `All` as the first item in the combo box
            cbBeltRank.Items.Add("All");

            DataTable _dtBeltRanks = clsBeltRank.GetAllBeltRanksName();

            foreach (DataRow drBeltRank in _dtBeltRanks.Rows)
            {
                cbBeltRank.Items.Add(drBeltRank["RankName"].ToString());
            }
        }

        private void _RefreshMemberList()
        {
            _dtAllMembers = clsMember.GetAllMembers();
            dgvMembersList.DataSource = _dtAllMembers;
            lblNumberOfRecords.Text = dgvMembersList.Rows.Count.ToString();

            if (dgvMembersList.Rows.Count > 0)
            {
                dgvMembersList.Columns[0].HeaderText = "Member ID";
                dgvMembersList.Columns[0].Width = 115;

                dgvMembersList.Columns[1].HeaderText = "Name";
                dgvMembersList.Columns[1].Width = 190;

                dgvMembersList.Columns[2].HeaderText = "Rank Name";
                dgvMembersList.Columns[2].Width = 180;

                dgvMembersList.Columns[3].HeaderText = "Gender";
                dgvMembersList.Columns[3].Width = 100;

                dgvMembersList.Columns[4].HeaderText = "Date Of Birth";
                dgvMembersList.Columns[4].Width = 130;

                dgvMembersList.Columns[5].HeaderText = "Phone";
                dgvMembersList.Columns[5].Width = 110;

                dgvMembersList.Columns[6].HeaderText = "Is Active";
                dgvMembersList.Columns[6].Width = 80;
            }
        }

        private int _GetMemberIDFromDGV()
        {
            return (int)dgvMembersList.CurrentRow.Cells["MemberID"].Value;
        }

        private void frmListMembers_Load(object sender, EventArgs e)
        {
            _RefreshMemberList();
            _FillBeltRanksInComboBox();

            cbFilter.SelectedIndex = 0;
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Visible = (cbFilter.Text != "None") && (cbFilter.Text != "Gender") && (cbFilter.Text != "Is Active") && (cbFilter.Text != "Rank Name");

            cbBeltRank.Visible = (cbFilter.Text == "Rank Name");

            cbGender.Visible = (cbFilter.Text == "Gender");

            cbIsActive.Visible = (cbFilter.Text == "Is Active");

            if (txtSearch.Visible)
            {
                txtSearch.Text = "";
                txtSearch.Focus();
            }

            if (cbBeltRank.Visible)
            {
                cbBeltRank.SelectedIndex = 0;
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
            if (_dtAllMembers.Rows.Count == 0)
            {
                return;
            }

            string ColumnName = _GetRealColumnNameInDB();

            if (string.IsNullOrWhiteSpace(txtSearch.Text.Trim()) || cbFilter.Text == "None")
            {
                _dtAllMembers.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvMembersList.Rows.Count.ToString();

                return;
            }

            if (cbFilter.Text == "Member ID")
            {
                // search with numbers
                _dtAllMembers.DefaultView.RowFilter = string.Format("[{0}] = {1}", ColumnName, txtSearch.Text.Trim());
            }
            else
            {
                // search with string
                _dtAllMembers.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", ColumnName, txtSearch.Text.Trim());
            }

            lblNumberOfRecords.Text = dgvMembersList.Rows.Count.ToString();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "Member ID" || cbFilter.Text == "Phone")
            {
                // make sure that the user can only enter the numbers
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void cbBeltRank_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtAllMembers.Rows.Count == 0)
            {
                return;
            }

            if (cbBeltRank.Text == "All")
            {
                _dtAllMembers.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvMembersList.Rows.Count.ToString();

                return;
            }

            _dtAllMembers.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", "RankName", cbBeltRank.Text);
            lblNumberOfRecords.Text = dgvMembersList.Rows.Count.ToString();
        }

        private void cbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtAllMembers.Rows.Count == 0)
            {
                return;
            }

            if (cbGender.Text == "All")
            {
                _dtAllMembers.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvMembersList.Rows.Count.ToString();

                return;
            }

            _dtAllMembers.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", "Gender", cbGender.Text);
            lblNumberOfRecords.Text = dgvMembersList.Rows.Count.ToString();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmShowMemberDetails ShowMemberDetails = new frmShowMemberDetails(_GetMemberIDFromDGV());
            ShowMemberDetails.Show();

            _RefreshMemberList();
        }

        private void addNewMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditMember AddNewMember = new frmAddEditMember();
            AddNewMember.MemberIDBack += RefreshList;
            AddNewMember.Show();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditMember AddNewMember = new frmAddEditMember(_GetMemberIDFromDGV());
            AddNewMember.MemberIDBack += RefreshList;
            AddNewMember.Show();           
        }

        private void RefreshList(object sender, int MemberID)
        {
            _RefreshMemberList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this member?", "Confirm", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (clsMember.DeleteMember(_GetMemberIDFromDGV()))
                {
                    MessageBox.Show("Deleted Done Successfully", "Deleted",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _RefreshMemberList();
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
            if (_dtAllMembers.Rows.Count == 0)
            {
                return;
            }

            if (cbIsActive.Text == "All")
            {
                _dtAllMembers.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvMembersList.Rows.Count.ToString();

                return;
            }

            _dtAllMembers.DefaultView.RowFilter = string.Format("[{0}] = {1}", "IsActive", (cbIsActive.Text == "Yes"));
            lblNumberOfRecords.Text = dgvMembersList.Rows.Count.ToString();
        }

        private void dgvMembersList_DoubleClick(object sender, EventArgs e)
        {
            frmShowMemberDetails ShowMemberDetails = new frmShowMemberDetails(_GetMemberIDFromDGV());
            ShowMemberDetails.ShowDialog();

            _RefreshMemberList();
        }

        private void btnAddNewMember_Click(object sender, EventArgs e)
        {
            frmAddEditMember AddNewMember = new frmAddEditMember();
            AddNewMember.MemberIDBack += RefreshList;
            AddNewMember.Show();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowSubscriptionPeriodsHistory ShowHistory = new frmShowSubscriptionPeriodsHistory(_GetMemberIDFromDGV());
            ShowHistory.ShowDialog();

            _RefreshMemberList();
        }
    }
}
