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

namespace KarateClub.BeltTests.UserControls
{
    public partial class ucMemberTests : UserControl
    {
        private DataTable _dtAllMemberBeltTests;

        private int _MemberID = -1;

        public ucMemberTests()
        {
            InitializeComponent();
        }

        private void _RefreshBeltTestsList()
        {
            _dtAllMemberBeltTests = clsBeltTest.GetAllBeltTestsForMember(this._MemberID);
            dgvMemberBeltTestsList.DataSource = _dtAllMemberBeltTests;

            lblNumberOfRecords.Text = dgvMemberBeltTestsList.Rows.Count.ToString();

            if (dgvMemberBeltTestsList.Rows.Count > 0)
            {
                dgvMemberBeltTestsList.Columns[0].HeaderText = "Test ID";
                dgvMemberBeltTestsList.Columns[0].Width = 115;

                dgvMemberBeltTestsList.Columns[1].HeaderText = "Member ID";
                dgvMemberBeltTestsList.Columns[1].Width = 115;

                dgvMemberBeltTestsList.Columns[2].HeaderText = "Member Name";
                dgvMemberBeltTestsList.Columns[2].Width = 190;

                dgvMemberBeltTestsList.Columns[3].HeaderText = "Rank Name";
                dgvMemberBeltTestsList.Columns[3].Width = 190;

                dgvMemberBeltTestsList.Columns[4].HeaderText = "Test Date";
                dgvMemberBeltTestsList.Columns[4].Width = 130;

                dgvMemberBeltTestsList.Columns[5].HeaderText = "Instructor Name";
                dgvMemberBeltTestsList.Columns[5].Width = 190;

                dgvMemberBeltTestsList.Columns[6].HeaderText = "Payment ID";
                dgvMemberBeltTestsList.Columns[6].Width = 115;

                dgvMemberBeltTestsList.Columns[7].HeaderText = "Result";
                dgvMemberBeltTestsList.Columns[7].Width = 80;
            }
        }

        private int _GetBeltTestsIDFromDGV()
        {
            return (int)dgvMemberBeltTestsList.CurrentRow.Cells["TestID"].Value;
        }

        public void LoadMemberTestsInfo(int MemberID)
        {
            this._MemberID = MemberID;
            _RefreshBeltTestsList();
        }

        public void Clear()
        {
            _dtAllMemberBeltTests.Clear();
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
    }
}
