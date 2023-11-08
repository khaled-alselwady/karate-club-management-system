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
using KarateClub.Global_Classes;
using KarateClub.Properties;
using System.IO;

namespace KarateClub.Members.UserControls
{
    public partial class ucMemberCard : UserControl
    {

        private int _MemberID = -1;
        private clsMember _Member;

        public int MemberID => _MemberID;
        public clsMember SelectedMemberInfo => _Member;

        public ucMemberCard()
        {
            InitializeComponent();
        }

        public void Reset()
        {
            this._MemberID = -1;
            this._Member = null;

            lblMemberID.Text = "[????]";
            lblLastBeltRank.Text = "[????]";
            lblIsActive.Text = "[????]";
            lblEmergencyContact.Text = "[????]";

            llEditMemberInfo.Enabled = false;
        }

        private void _FillMemberInfo()
        {
            llEditMemberInfo.Enabled = true;

            ucPersonCard1.LoadPersonInfo(_Member.PersonID);

            lblMemberID.Text = _Member.MemberID.ToString();
            lblLastBeltRank.Text = _Member.LastBeltRankInfo.RankName;
            lblIsActive.Text = (_Member.IsActive) ? "Yes" : "No";

            if (_Member.IsActive)
                pbIsActive.Image = Resources.active_user;

            else
                pbIsActive.Image = Resources.inactive_user;


            lblEmergencyContact.Text = _Member.EmergencyContactInfo;
        }

        public void LoadMemberInfo(int MemberID)
        {
            this._MemberID = MemberID;

            if (MemberID == -1)
            {
                MessageBox.Show("There is no member with id = -1", "Missing Member",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                Reset();

                return;
            }

            _Member = clsMember.Find(this._MemberID);

            if (_Member == null)
            {
                MessageBox.Show($"There is no member with id = {MemberID}", "Missing Member",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                Reset();

                return;
            }

            _FillMemberInfo();
        }

        private void llEditMemberInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditMember EditMember = new frmAddEditMember(_MemberID);
            EditMember.MemberIDBack += Refresh;
            EditMember.Show();
        }

        private void Refresh(object sender, int MemberID)
        {
            LoadMemberInfo(_MemberID);
        }
    }
}
