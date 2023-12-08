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
using static KarateClub.Instructors.UserControls.ucInstructorCardWithFilter;
using static KarateClub.Members.UserControls.ucMemberCardWithFilter;

namespace KarateClub.MembersInstructors.UserControls
{
    public partial class ucMemberInstructorCardWithFilter : UserControl
    {
        public Action<int?> SendMemberID;
        public Action<int?> SendInstructorID;

        private int? _SelectedMemberID = null;
        private int? _SelectedInstructorID = null;

        public int? SelectedMemberID => ucMemberCardWithFilter1.MemberID;
        public int? SelectedInstructorID => ucInstructorCardWithFilter1.InstructorID;

        public clsMember SelectedMemberInfo => ucMemberCardWithFilter1.SelectedMemberInfo;
        public clsInstructor SelectedInstructorInfo => ucInstructorCardWithFilter1.SelectedInstructorInfo;

        private bool _FilterEnableMember = false;
        public bool FilterEnableMember
        {
            get => _FilterEnableMember;

            set
            {
                _FilterEnableMember = value;
                ucMemberCardWithFilter1.FilterEnabled = value;
            }
        }

        private bool _FilterEnableInstructor = false;
        public bool FilterEnableInstructor
        {
            get => _FilterEnableInstructor;

            set
            {
                _FilterEnableInstructor = value;
                ucInstructorCardWithFilter1.FilterEnabled = value;
            }
        }

        public ucMemberInstructorCardWithFilter()
        {
            InitializeComponent();
        }

        private bool _IsMemberCorrect()
        {
            if (!_SelectedMemberID.HasValue)
            {
                tcMembersInstructors.SelectedTab = tpMember;

                MessageBox.Show("You have to select a member first!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            if (!ucMemberCardWithFilter1.SelectedMemberInfo.IsActive)
            {
                tcMembersInstructors.SelectedTab = tpMember;

                MessageBox.Show("Selected Member is Not Active, choose an active member."
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            return true;
        }

        public void FilterFocus()
        {
            ucMemberCardWithFilter1.FilterFocus();
        }

        public void LoadMemberInfo(int? MemberID)
        {
            ucMemberCardWithFilter1.LoadMemberInfo(MemberID);
        }

        public void LoadInstructorInfo(int? InstructorID)
        {
            ucInstructorCardWithFilter1.LoadInstructorInfo(InstructorID);
        }

        private void btnMemberInfoNext_Click(object sender, EventArgs e)
        {
            if (_IsMemberCorrect())
            {
                tcMembersInstructors.SelectedTab = tpInstructor;
                ucInstructorCardWithFilter1.FilterFocus();
            }
        }

        private void tcMembersInstructors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ucMemberCardWithFilter1.SelectedMemberInfo != null &&
                ucMemberCardWithFilter1.SelectedMemberInfo.IsActive)
                return;


            TabPage SelectedTabPage = tcMembersInstructors.SelectedTab;

            if (SelectedTabPage == tpInstructor)
            {
                tcMembersInstructors.SelectedTab = tpMember;

                if (_IsMemberCorrect())
                {
                    ucInstructorCardWithFilter1.FilterFocus();
                    tcMembersInstructors.SelectedTab = tpInstructor;
                }

            }
        }

        private void ucMemberCardWithFilter1_OnMemberSelected(object sender, MemberSelectedEventArgs e)
        {
            _SelectedMemberID = e.MemberID;

            if (!_SelectedMemberID.HasValue)
            {
                btnMemberInfoNext.Enabled = false;

                SendMemberID?.Invoke(null);
                return;
            }

            if (!ucMemberCardWithFilter1.SelectedMemberInfo.IsActive)
            {
                MessageBox.Show("Selected Member is Not Active, choose an active member.",
                     "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnMemberInfoNext.Enabled = false;

                return;
            }

            btnMemberInfoNext.Enabled = true;

            SendMemberID?.Invoke(ucMemberCardWithFilter1.MemberID);
        }

        private void ucInstructorCardWithFilter1_OnInstructorSelected(object sender, InstructorSelectedEventArgs e)
        {
            _SelectedInstructorID = e.InstructorID;

            if (!_SelectedInstructorID.HasValue)
            {
                SendInstructorID?.Invoke(null); // to disable btnSave in the frmAddNewBeltTest
                return;
            }

            SendInstructorID?.Invoke(ucInstructorCardWithFilter1.InstructorID);
        }
    }
}
