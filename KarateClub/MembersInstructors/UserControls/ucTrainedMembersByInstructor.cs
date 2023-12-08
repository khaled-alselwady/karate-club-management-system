using KarateClub.BeltTests;
using KarateClub.Members;
using KarateClub.Payment;
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

namespace KarateClub.MembersInstructors.UserControls
{
    public partial class ucTrainedMembersByInstructor : UserControl
    {
        private DataTable _dtAllTrainedMembers;

        private int? _InstructorID = null;

        public ucTrainedMembersByInstructor()
        {
            InitializeComponent();
        }

        private void _RefreshTrainedMembersList()
        {
            _dtAllTrainedMembers = clsMemberInstructor.GetTrainedMembersByInstructor(_InstructorID);
            dgvTrainedMembersList.DataSource = _dtAllTrainedMembers;

            lblNumberOfRecords.Text = dgvTrainedMembersList.Rows.Count.ToString();

            if (dgvTrainedMembersList.Rows.Count > 0)
            {
                dgvTrainedMembersList.Columns[0].HeaderText = "Member ID";
                dgvTrainedMembersList.Columns[0].Width = 115;

                dgvTrainedMembersList.Columns[1].HeaderText = "Member Name";
                dgvTrainedMembersList.Columns[1].Width = 170;

                dgvTrainedMembersList.Columns[2].HeaderText = "Rank Name";
                dgvTrainedMembersList.Columns[2].Width = 170;

                dgvTrainedMembersList.Columns[3].HeaderText = "Gender";
                dgvTrainedMembersList.Columns[3].Width = 100;

                dgvTrainedMembersList.Columns[4].HeaderText = "Date Of Birth";
                dgvTrainedMembersList.Columns[4].Width = 160;

                dgvTrainedMembersList.Columns[5].HeaderText = "Phone";
                dgvTrainedMembersList.Columns[5].Width = 120;

                dgvTrainedMembersList.Columns[6].HeaderText = "Is Active";
                dgvTrainedMembersList.Columns[6].Width = 115;
            }
        }

        private int _GetMemberIDFromDGV()
        {
            return (int)dgvTrainedMembersList.CurrentRow.Cells["MemberID"].Value;
        }

        public void LoadTrainedMembersInfo(int? InstructorID)
        {
            this._InstructorID = InstructorID;
            _RefreshTrainedMembersList();
        }

        public void Clear()
        {
            _dtAllTrainedMembers.Clear();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmShowMemberDetails ShowMemberDetails = new frmShowMemberDetails(_GetMemberIDFromDGV());
            ShowMemberDetails.ShowDialog();

            _RefreshTrainedMembersList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditMember AddNewMember = new frmAddEditMember(_GetMemberIDFromDGV());
            AddNewMember.ShowDialog();

            _RefreshTrainedMembersList();
        }

        private void TakeNextBeltTesttoolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmAddNewBeltTest AddNewBeltTest = new frmAddNewBeltTest(_GetMemberIDFromDGV());
            AddNewBeltTest.ShowDialog();

            _RefreshTrainedMembersList();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowSubscriptionPeriodsHistory ShowHistory = new frmShowSubscriptionPeriodsHistory(_GetMemberIDFromDGV());
            ShowHistory.ShowDialog();

            _RefreshTrainedMembersList();
        }

        private void ShowTestsHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowMemberTestsHistory ShowMemberTestsHistory = new frmShowMemberTestsHistory(_GetMemberIDFromDGV());
            ShowMemberTestsHistory.ShowDialog();
        }

        private void showPaymentsHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowMemberPaymentsHistory ShowMemberPaymentsHistory = new frmShowMemberPaymentsHistory(_GetMemberIDFromDGV());
            ShowMemberPaymentsHistory.ShowDialog();
        }

        private void cmsEditProfile_Opening(object sender, CancelEventArgs e)
        {
            TakeNextBeltTesttoolStripMenuItem2.Enabled = (bool)dgvTrainedMembersList.CurrentRow.Cells["IsActive"].Value;
        }

        private void dgvTrainedMembersList_DoubleClick(object sender, EventArgs e)
        {
            frmShowMemberDetails ShowMemberDetails = new frmShowMemberDetails(_GetMemberIDFromDGV());
            ShowMemberDetails.ShowDialog();

            _RefreshTrainedMembersList();
        }
    }
}
