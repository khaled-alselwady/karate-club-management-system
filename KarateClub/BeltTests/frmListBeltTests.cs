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

namespace KarateClub.BeltTests
{
    public partial class frmListBeltTests : Form
    {

        private DataTable _dtAllBeltTests;

        public frmListBeltTests()
        {
            InitializeComponent();
        }

        private string _GetRealColumnNameInDB()
        {
            switch (cbFilter.Text)
            {
                case "Test ID":
                    return "TestID";

                case "Member Name":
                    return "MemberName";

                case "Instructor Name":
                    return "InstructorName";

                case "Rank Name":
                    return "RankName";

                case "Payment ID":
                    return "PaymentID";

                case "Result":
                    return "Result";

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

        private void _RefreshBeltTestsList()
        {
            _dtAllBeltTests = clsBeltTest.GetAllBeltTests();
            dgvBeltTestsList.DataSource = _dtAllBeltTests;
            lblNumberOfRecords.Text = dgvBeltTestsList.Rows.Count.ToString();

            if (dgvBeltTestsList.Rows.Count > 0)
            {
                dgvBeltTestsList.Columns[0].HeaderText = "Test ID";
                dgvBeltTestsList.Columns[0].Width = 115;

                dgvBeltTestsList.Columns[1].HeaderText = "Member Name";
                dgvBeltTestsList.Columns[1].Width = 190;

                dgvBeltTestsList.Columns[2].HeaderText = "Rank Name";
                dgvBeltTestsList.Columns[2].Width = 190;

                dgvBeltTestsList.Columns[3].HeaderText = "Test Date";
                dgvBeltTestsList.Columns[3].Width = 130;

                dgvBeltTestsList.Columns[4].HeaderText = "Instructor Name";
                dgvBeltTestsList.Columns[4].Width = 190;

                dgvBeltTestsList.Columns[5].HeaderText = "Payment ID";
                dgvBeltTestsList.Columns[5].Width = 115;

                dgvBeltTestsList.Columns[6].HeaderText = "Result";
                dgvBeltTestsList.Columns[6].Width = 80;
            }
        }

        private int _GetBeltTestsIDFromDGV()
        {
            return (int)dgvBeltTestsList.CurrentRow.Cells["TestID"].Value;
        }

        private void frmListBeltTests_Load(object sender, EventArgs e)
        {
            _RefreshBeltTestsList();
            _FillBeltRanksInComboBox();

            cbFilter.SelectedIndex = 0;
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Visible = (cbFilter.Text != "None") && (cbFilter.Text != "Result") && (cbFilter.Text != "Rank Name");

            cbBeltRank.Visible = (cbFilter.Text == "Rank Name");

            cbResult.Visible = (cbFilter.Text == "Result");

            if (txtSearch.Visible)
            {
                txtSearch.Text = "";
                txtSearch.Focus();
            }

            if (cbBeltRank.Visible)
            {
                cbBeltRank.SelectedIndex = 0;
            }

            if (cbResult.Visible)
            {
                cbResult.SelectedIndex = 0;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (_dtAllBeltTests.Rows.Count == 0)
            {
                return;
            }

            string ColumnName = _GetRealColumnNameInDB();

            if (string.IsNullOrWhiteSpace(txtSearch.Text.Trim()) || cbFilter.Text == "None")
            {
                _dtAllBeltTests.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvBeltTestsList.Rows.Count.ToString();

                return;
            }

            if (cbFilter.Text == "Test ID" || cbFilter.Text == "Payment ID")
            {
                // search with numbers
                _dtAllBeltTests.DefaultView.RowFilter =
                    string.Format("[{0}] = {1}", ColumnName, txtSearch.Text.Trim());
            }
            else
            {
                // search with string
                _dtAllBeltTests.DefaultView.RowFilter =
                    string.Format("[{0}] like '{1}%'", ColumnName, txtSearch.Text.Trim());
            }

            lblNumberOfRecords.Text = dgvBeltTestsList.Rows.Count.ToString();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "Test ID" || cbFilter.Text == "Payment ID")
            {
                // make sure that the user can only enter the numbers
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void cbBeltRank_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtAllBeltTests.Rows.Count == 0)
            {
                return;
            }

            if (cbBeltRank.Text == "All")
            {
                _dtAllBeltTests.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvBeltTestsList.Rows.Count.ToString();

                return;
            }

            _dtAllBeltTests.DefaultView.RowFilter =
                string.Format("[{0}] like '{1}%'", "RankName", cbBeltRank.Text);

            lblNumberOfRecords.Text = dgvBeltTestsList.Rows.Count.ToString();
        }

        private void cbResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtAllBeltTests.Rows.Count == 0)
            {
                return;
            }

            if (cbResult.Text == "All")
            {
                _dtAllBeltTests.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvBeltTestsList.Rows.Count.ToString();

                return;
            }

            _dtAllBeltTests.DefaultView.RowFilter =
                string.Format("[{0}] = {1}", "Result", (cbResult.Text == "Pass"));

            lblNumberOfRecords.Text = dgvBeltTestsList.Rows.Count.ToString();
        }

        private void ShowTestDetailstoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmShowBeltTestDetails ShowBeltTestDetails = new frmShowBeltTestDetails(_GetBeltTestsIDFromDGV());
            ShowBeltTestDetails.ShowDialog();
        }

        private void addNewTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int MemberID = clsBeltTest.Find(_GetBeltTestsIDFromDGV()).MemberID;

            frmAddNewBeltTest AddNewBeltTest = new frmAddNewBeltTest(MemberID);
            AddNewBeltTest.RefreshDataBack += _RefreshBeltTestsList;
            AddNewBeltTest.Show();
        }

        private void btnAddNewBeltTest_Click(object sender, EventArgs e)
        {
            frmAddNewBeltTest AddNewBeltTest = new frmAddNewBeltTest();
            AddNewBeltTest.RefreshDataBack += _RefreshBeltTestsList;
            AddNewBeltTest.Show();
        }

        private void dgvBeltTestsList_DoubleClick(object sender, EventArgs e)
        {
            frmShowBeltTestDetails ShowBeltTestDetails = new frmShowBeltTestDetails(_GetBeltTestsIDFromDGV());
            ShowBeltTestDetails.ShowDialog();
        }

        private void showTestsHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int MemberID = clsBeltTest.Find(_GetBeltTestsIDFromDGV()).MemberID;

            frmShowMemberTestsHistory ShowMemberTestsHistory = new frmShowMemberTestsHistory(MemberID);
            ShowMemberTestsHistory.ShowDialog();
        }
    }
}
