using KarateClub.Properties;
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

namespace KarateClub.BeltTests
{
    public partial class frmAddNewBeltTest : Form
    {
        private int? _NewBeltTestID = null;

        public frmAddNewBeltTest()
        {
            InitializeComponent();
        }

        public frmAddNewBeltTest(int? MemberID)
        {
            InitializeComponent();

            ucMemberInstructorCardWithFilter1.SendMemberID += LoadNextBeltInfoUsingDelegate;
            ucMemberInstructorCardWithFilter1.LoadMemberInfo(MemberID);
            ucMemberInstructorCardWithFilter1.FilterEnableMember = false;
        }

        private void _LoadData()
        {
            dtpTestDate.MinDate = DateTime.Now;
            rbPassed.Checked = true;
        }

        private void frmAddNewBeltTest_Load(object sender, EventArgs e)
        {
            _LoadData();

            ucMemberInstructorCardWithFilter1.SendMemberID += LoadNextBeltInfoUsingDelegate;
            // subscribe with the delegate, and it will enter in the `EnableBtnSave` method when the Instructor is selected because I put the invoke there
            ucMemberInstructorCardWithFilter1.SendInstructorID += EnableBtnSaveWhenSelectInstructor;
        }

        private void LoadNextBeltInfoUsingDelegate(int? MemberID)
        {
            if (ucMemberInstructorCardWithFilter1.SelectedMemberInfo == null)
            {
                llShowTestsHistory.Enabled = false;
                btnSave.Enabled = false;
                return;
            }

            lblBeltRankID.Text = ucMemberInstructorCardWithFilter1.SelectedMemberInfo.NextBeltRankInfo.RankID.ToString();
            lblBeltRankName.Text = ucMemberInstructorCardWithFilter1.SelectedMemberInfo.NextBeltRankInfo.RankName;
            lblFees.Text = ucMemberInstructorCardWithFilter1.SelectedMemberInfo.NextBeltRankInfo.TestFees.ToString("F0");
            llShowTestsHistory.Enabled = true;  
            
            if (ucMemberInstructorCardWithFilter1.SelectedInstructorID.HasValue)
            {
                // here I already choose the instructor, so I enable the btnSave
                btnSave.Enabled = true;
            }

        }

        private void EnableBtnSaveWhenSelectInstructor(int? InstructorID)
        {
            btnSave.Enabled = (InstructorID.HasValue);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddNewBeltTest_Activated(object sender, EventArgs e)
        {
            ucMemberInstructorCardWithFilter1.FilterFocus();
        }

        private void rbPassed_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPassed.Checked)
            {
                pbResultTest.Image = Resources.passed;
            }
        }

        private void rbFailed_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFailed.Checked)
            {
                pbResultTest.Image = Resources.failed;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ucMemberInstructorCardWithFilter1.SelectedMemberID.HasValue ||
                !ucMemberInstructorCardWithFilter1.SelectedInstructorID.HasValue)
            {
                MessageBox.Show("You have to select member and instructor first!", "Missing Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnSave.Enabled = false;

                return;
            }

            clsBeltTest BeltTest = new clsBeltTest();

            BeltTest.MemberID = ucMemberInstructorCardWithFilter1.SelectedMemberID;
            BeltTest.TestedByInstructorID = ucMemberInstructorCardWithFilter1.SelectedInstructorID;
            BeltTest.RankID = ucMemberInstructorCardWithFilter1.SelectedMemberInfo.NextBeltRankInfo.RankID;
            BeltTest.Result = (rbPassed.Checked);
            BeltTest.Date = dtpTestDate.Value;

            BeltTest.PaymentID = BeltTest.Pay(ucMemberInstructorCardWithFilter1.SelectedMemberInfo.NextBeltRankInfo.TestFees);

            lblPaymentID.Text = (BeltTest.PaymentID.HasValue) ? BeltTest.PaymentID.ToString() : "[????]";

            if (BeltTest.Save())
            {
                MessageBox.Show("Data Saved Successfully", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                _NewBeltTestID = BeltTest.TestID;
                lblTestID.Text = _NewBeltTestID.ToString();

                btnSave.Enabled = false;
                llShowNewBeltTestDetails.Enabled = true;
                ucMemberInstructorCardWithFilter1.FilterEnableMember = false;
                ucMemberInstructorCardWithFilter1.FilterEnableInstructor = false;
            }
            else
            {
                MessageBox.Show("Failed to save data", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void llShowNewBeltTestDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowBeltTestDetails ShowBeltTestDetails = new frmShowBeltTestDetails(_NewBeltTestID);
            ShowBeltTestDetails.ShowDialog();
        }

        private void llShowTestsHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowMemberTestsHistory ShowMemberTestsHistory = new frmShowMemberTestsHistory(ucMemberInstructorCardWithFilter1.SelectedMemberID);
            ShowMemberTestsHistory.ShowDialog();
        }
    }
}
