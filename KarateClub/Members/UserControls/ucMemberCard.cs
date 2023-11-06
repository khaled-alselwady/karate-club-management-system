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

        private void _Reset()
        {
            this._MemberID = -1;
            this._Member = null;

            lblMemberID.Text = "[????]";
            lblFullName.Text = "[????]";
            lblDateOfBirth.Text = "[????]";
            lblGender.Text = "[????]";
            lblAddress.Text = "[????]";
            lblEmail.Text = "[????]";
            lblPhone.Text = "[????]";
            lblLastBeltRank.Text = "[????]";
            lblIsActive.Text = "[????]";
            lblEmergencyContact.Text = "[????]";
            pbMemberImage.Image = Resources.DefaultMale;

            llEditMemberInfo.Enabled = false;
        }

        private void _LoadMemberImage()
        {
            if (_Member.ImagePath != "")
            {
                if (File.Exists(_Member.ImagePath))
                    pbMemberImage.ImageLocation = _Member.ImagePath;
                else
                    MessageBox.Show("Could not find this image: = " + _Member.ImagePath,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (_Member.Gender == (byte)clsPerson.enGender.Male)
                    pbMemberImage.Image = Resources.DefaultMale;
                else
                    pbMemberImage.Image = Resources.DefaultFemale;
            }
        }

        private void _FillMemberInfo()
        {
            llEditMemberInfo.Enabled = true;
            lblMemberID.Text = _Member.MemberID.ToString();
            lblFullName.Text = _Member.Name;
            lblDateOfBirth.Text = clsFormat.DateToShort(_Member.DateOfBirth);
            lblGender.Text = _Member.GenderName;
            lblAddress.Text = _Member.Address;
            lblEmail.Text = _Member.Email;
            lblPhone.Text = _Member.Phone;
            lblLastBeltRank.Text = _Member.LastBeltRankInfo.RankName;
            lblIsActive.Text = (_Member.IsActive) ? "Yes" : "No";
            lblEmergencyContact.Text = _Member.EmergencyContactInfo;

            _LoadMemberImage();
        }

        public void LoadMemberInfo(int MemberID)
        {
            this._MemberID = MemberID;

            if (MemberID == -1)
            {
                MessageBox.Show("There is no member with id = -1", "Missing Member",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                _Reset();

                return;
            }

            _Member = clsMember.Find(this._MemberID);

            if (_Member == null)
            {
                MessageBox.Show($"There is no member with id = {MemberID}", "Missing Member",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                _Reset();

                return;
            }

            _FillMemberInfo();
        }

        private void llEditMemberInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditMember EditMember = new frmAddEditMember(_MemberID);
            EditMember.Show();

            LoadMemberInfo(_MemberID);
        }
    }
}
