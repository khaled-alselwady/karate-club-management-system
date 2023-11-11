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
    public partial class ucMemberInstructorCardWithFilter : UserControl
    {

        // Declare a delegate
        public delegate void DataBackEventHandler();
        public event DataBackEventHandler MemberDataBack;
        public event DataBackEventHandler InstructorDataBack;

        private int _SelectedMemberID = -1;
        private int _SelectedInstructorID = -1;

        public int SelectedMemberID => ucMemberCardWithFilter1.MemberID;
        public int SelectedInstructorID => ucInstructorCardWithFilter1.InstructorID;

        public clsMember SelectedMemberInfo => ucMemberCardWithFilter1.SelectedMemberInfo;
        public clsInstructor SelectedInstructorInfo => ucInstructorCardWithFilter1.SelectedInstructorInfo;

        private bool _FilterEnable = false;
        public bool FilterEnable
        {
            get => _FilterEnable;

            set
            {
                _FilterEnable = value;
                ucMemberCardWithFilter1.FilterEnabled = value;
                ucInstructorCardWithFilter1.FilterEnabled = value;
            }
        }

        public ucMemberInstructorCardWithFilter()
        {
            InitializeComponent();
        }

        private bool _IsMemberCorrect()
        {
            if (_SelectedMemberID == -1)
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

        public void LoadMemberInfo(int MemberID)
        {
            ucMemberCardWithFilter1.LoadMemberInfo(MemberID);
            ucMemberCardWithFilter1.FilterEnabled = false;
        }

        private void btnMemberInfoNext_Click(object sender, EventArgs e)
        {
            if (_IsMemberCorrect())
            {
                tcMembersInstructors.SelectedTab = tpInstructor;
                ucInstructorCardWithFilter1.FilterFocus();
            }
        }

        private void ucMemberCardWithFilter1_OnMemberSelected(int obj)
        {
            _SelectedMemberID = obj;

            if (_SelectedMemberID == -1)
            {
                btnMemberInfoNext.Enabled = false;
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

            MemberDataBack?.Invoke();
        }

        private void ucInstructorCardWithFilter1_OnInstructorSelected(int obj)
        {
            _SelectedInstructorID = obj;

            if (_SelectedInstructorID == -1)
            {
                return;
            }

            InstructorDataBack?.Invoke();
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
    }
}
