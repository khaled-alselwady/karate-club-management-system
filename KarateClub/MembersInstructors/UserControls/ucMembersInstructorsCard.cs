using KarateClub.Global_Classes;
using KarateClub.Instructors;
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
    public partial class ucMembersInstructorsCard : UserControl
    {

        private int _MembersInstructorsID = -1;
        private clsMemberInstructor _MembersInstructors;

        public ucMembersInstructorsCard()
        {
            InitializeComponent();
        }

        private void _Reset()
        {
            _MembersInstructorsID = -1;
            _MembersInstructors = null;

            lblAssignDate.Text = "[????]";
            lblMembersInstructorsID.Text = "[????]";

            ucMemberCard1.Reset();
            ucInstructorCard1.Reset();
        }

        public void LoadMembersInstructorsInfo(int MembersInstructorsID)
        {
            this._MembersInstructorsID = MembersInstructorsID;

            if (this._MembersInstructorsID == -1)
            {
                MessageBox.Show("There is no Members-Instructors with id = -1", "Missing Member",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                _Reset();

                return;
            }

            _MembersInstructors = clsMemberInstructor.Find(this._MembersInstructorsID);

            if (_MembersInstructors == null)
            {
                MessageBox.Show($"There is no Members-Instructors with id = {this._MembersInstructorsID}", "Missing Member",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                _Reset();

                return;
            }


            llEditInfo.Enabled = true;
            llShowTrainedMembers.Enabled = true;
            ucMemberCard1.LoadMemberInfo(_MembersInstructors.MemberID);
            ucInstructorCard1.LoadInstructorInfo(_MembersInstructors.InstructorID);

            lblMembersInstructorsID.Text = _MembersInstructors.MemberInstructorID.ToString();
            lblAssignDate.Text = clsFormat.DateToShort(_MembersInstructors.AssignDate);
        }

        private void llEditInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditMembersInstructors EditMembersInstructors = new frmAddEditMembersInstructors(_MembersInstructorsID);
            EditMembersInstructors.ShowDialog();

            LoadMembersInstructorsInfo(_MembersInstructorsID);
        }

        private void llShowTrainedMembers_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowTrainedMembersByInstructor ShowTrainedMembersByInstructor = new frmShowTrainedMembersByInstructor(ucInstructorCard1.InstructorID);
            ShowTrainedMembersByInstructor.ShowDialog();
        }
    }
}
