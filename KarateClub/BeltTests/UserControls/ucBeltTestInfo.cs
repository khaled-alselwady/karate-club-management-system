using KarateClub.Global_Classes;
using KarateClub.Instructors;
using KarateClub.Members;
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

namespace KarateClub.BeltTests.UserControls
{
    public partial class ucBeltTestInfo : UserControl
    {

        private int _TestID = -1;
        private clsBeltTest _Test;

        public ucBeltTestInfo()
        {
            InitializeComponent();
        }

        private void _FillTestInfo()
        {
            llShowMemberInfo.Enabled = true;
            llShowInstructorInfo.Enabled = true;

            lblTestID.Text = _Test.TestID.ToString();
            lblMemberName.Text = _Test.MemberInfo.Name;
            lblMemberID.Text = _Test.MemberID.ToString();
            lblGender.Text = _Test.MemberInfo.GenderName;
            lblBeltRankName.Text = _Test.BeltRankInfo.RankName;
            lblInstructorName.Text = _Test.InstructorInfo.Name;
            lblTestDate.Text = clsFormat.DateToShort(_Test.Date);
            lblResult.Text = (_Test.Result) ? "Passed" : "Failed";
            lblPaymentID.Text = (_Test.PaymentID != -1) ? _Test.PaymentID.ToString() : "Not paid yet";
            lblFees.Text = _Test.BeltRankInfo.TestFees.ToString("F0");

            pbResult.Image = (_Test.Result) ? Resources.passed : Resources.failed;
        }

        public void Reset()
        {
            _TestID = -1;
            _Test = null;

            llShowMemberInfo.Enabled = false;
            llShowInstructorInfo.Enabled = false;

            lblTestID.Text = "[????]";
            lblMemberName.Text = "[????]";
            lblMemberID.Text = "[????]";
            lblGender.Text = "[????]";
            lblBeltRankName.Text = "[????]";
            lblInstructorName.Text = "[????]";
            lblTestDate.Text = "[????]";
            lblResult.Text = "[????]";
            lblPaymentID.Text = "[????]";
            lblFees.Text = "[????]";
        }

        public void LoadBeltTestInfo(int TestID)
        {
            this._TestID = TestID;

            if (this._TestID == -1)
            {
                MessageBox.Show("There is no test with id = -1", "Missing Test",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                Reset();

                return;
            }

            _Test = clsBeltTest.Find(this._TestID);

            if (_Test == null)
            {
                MessageBox.Show($"There is no test with id = {TestID}", "Missing Test",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                Reset();

                return;
            }

            _FillTestInfo();
        }

        private void llShowMemberInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowMemberDetails ShowMemberDetails = new frmShowMemberDetails(_Test.MemberID);
            ShowMemberDetails.ShowDialog();
        }

        private void llShowInstructorInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowInstructorDetails ShowInstructorDetails = new frmShowInstructorDetails(_Test.TestedByInstructorID);
            ShowInstructorDetails.ShowDialog();
        }
    }
}
