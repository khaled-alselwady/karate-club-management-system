using KarateClub.Global_Classes;
using KarateClub.Members;
using KarateClub.Properties;
using KarateClub_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KarateClub.SubscriptionPeriods.UserControls
{
    public partial class ucSubscriptionPeriodInfo : UserControl
    {
        private int _PeriodID = -1;
        private clsSubscriptionPeriod _Period;

        public int PeriodID => _PeriodID;
        public clsSubscriptionPeriod Period => _Period;

        public ucSubscriptionPeriodInfo()
        {
            InitializeComponent();
        }

        private void _LoadMemberImage()
        {
            if (_Period.MemberInfo.ImagePath != "")
            {
                if (File.Exists(_Period.MemberInfo.ImagePath))
                    pbMemberImage.ImageLocation = _Period.MemberInfo.ImagePath;
                else
                    MessageBox.Show("Could not find this image: = " + _Period.MemberInfo.ImagePath,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (_Period.MemberInfo.Gender == (byte)clsPerson.enGender.Male)
                    pbMemberImage.Image = Resources.DefaultMale;
                else
                    pbMemberImage.Image = Resources.DefaultFemale;
            }
        }

        private void _FillSubscriptionPeriod()
        {
            llEditMemberInfo.Enabled = true;

            lblPeriodID.Text = _Period.PeriodID.ToString();
            lblMemberID.Text = _Period.MemberID.ToString();
            lblFullName.Text = _Period.MemberInfo.Name;
            lblGender.Text = _Period.MemberInfo.GenderName;
            lblIssueReason.Text = _Period.IssueReasonText;
            lblLastBeltRank.Text = _Period.MemberInfo.LastBeltRankInfo.RankName;
            lblStartDate.Text = clsFormat.DateToShort(_Period.StartDate);
            lblEndDate.Text = clsFormat.DateToShort(_Period.EndDate);
            lblIsPaid.Text = (_Period.IsPaid) ? "Yes" : "No";
            lblIsActive.Text = (_Period.IsActive) ? "Yes" : "No";
            lblPaymentID.Text = (_Period.PaymentID != -1) ? _Period.PaymentID.ToString() : "Not paid yet";
            lblFees.Text = _Period.Fees.ToString("F0");

            _LoadMemberImage();
        }

        public void Reset()
        {
            _PeriodID = -1;
            _Period = null;

            lblPeriodID.Text = "[????]";
            lblMemberID.Text = "[????]";
            lblFullName.Text = "[????]";
            lblGender.Text = "[????]";
            lblIssueReason.Text = "[????]";
            lblLastBeltRank.Text = "[????]";
            lblStartDate.Text = "[????]";
            lblEndDate.Text = "[????]";
            lblIsPaid.Text = "[????]";
            lblIsActive.Text = "[????]";
            lblPaymentID.Text = "[????]";
            lblFees.Text = "[????]";

            pbMemberImage.Image = Resources.DefaultMale;

            llEditMemberInfo.Enabled = false;
        }

        public void LoadSubscriptionPeriodInfo(int PeriodID)
        {
            this._PeriodID = PeriodID;

            if (this._PeriodID == -1)
            {
                MessageBox.Show("There is no subscription period with id = -1", "Missing Subscription Period",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                Reset();

                return;
            }

            _Period = clsSubscriptionPeriod.Find(this._PeriodID);

            if (_Period == null)
            {
                MessageBox.Show("There is no subscription period with id = -1", "Missing Subscription Period",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                Reset();

                return;
            }

            _FillSubscriptionPeriod();
        }

        private void llEditMemberInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditMember EditMember = new frmAddEditMember(_Period.MemberID);
            EditMember.GetMemberID += Refresh;
            EditMember.ShowDialog();
        }

        private void Refresh(int MemberID)
        {
            clsMember Member = clsMember.Find(MemberID);

            if (Member == null)
            {
                return;
            }

            lblMemberID.Text = Member.MemberID.ToString();
            lblFullName.Text = Member.Name;
            lblGender.Text = Member.GenderName;
            lblLastBeltRank.Text = Member.LastBeltRankInfo.RankName;

            if (Member.ImagePath != "")
            {
                if (File.Exists(Member.ImagePath))
                    pbMemberImage.ImageLocation = Member.ImagePath;
                else
                    MessageBox.Show("Could not find this image: = " + Member.ImagePath,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (Member.Gender == (byte)clsPerson.enGender.Male)
                    pbMemberImage.Image = Resources.DefaultMale;
                else
                    pbMemberImage.Image = Resources.DefaultFemale;
            }
        }
    }
}
