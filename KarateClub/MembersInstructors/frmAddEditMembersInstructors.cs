using KarateClub_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace KarateClub.MembersInstructors
{
    public partial class frmAddEditMembersInstructors : Form
    {
        public Action<int> GetMembersInstructorsID;

        private enum enMode { AddNew, Update };
        private enMode _Mode = enMode.AddNew;

        private int _SelectedMemberID = -1;
        private int _SelectedInstructorID = -1;
        private int _MembersInstructorID = -1;

        private clsMemberInstructor _MembersInstructor;

        public frmAddEditMembersInstructors()
        {
            InitializeComponent();

            this._Mode = enMode.AddNew;
        }
        public frmAddEditMembersInstructors(int MembersInstructorID)
        {
            InitializeComponent();

            this._MembersInstructorID = MembersInstructorID;
            this._Mode = enMode.Update;
        }

        private void _ResetDefaultValues()
        {
            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Members-Instructors";
                this.Text = "Add New Members-Instructors";
                _MembersInstructor = new clsMemberInstructor();
            }
            else
            {
                lblTitle.Text = "Update Members-Instructors";
                this.Text = "Update Members-Instructors";
            }
        }

        private void _LoadData()
        {
            _MembersInstructor = clsMemberInstructor.Find(_MembersInstructorID);

            if (_MembersInstructor == null)
            {
                MessageBox.Show("No Members-Instructor with ID = " + _MembersInstructorID,
                    "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                this.Close();
                return;
            }

            lblMembersInstructorsID.Text = _MembersInstructor.MemberInstructorID.ToString();

            ucMemberCardWithFilter1.LoadMemberInfo(_MembersInstructor.MemberID);
            ucInstructorCardWithFilter1.LoadInstructorInfo(_MembersInstructor.InstructorID);

            if (_MembersInstructor.AssignDate < DateTime.Now)
                dtpAssignDate.Value = DateTime.Now;
            else
                dtpAssignDate.Value = _MembersInstructor.AssignDate;

            btnSave.Enabled = true;
            btnMemberInfoNext.Enabled = true;

            _SelectedMemberID = ucMemberCardWithFilter1.MemberID;
            _SelectedInstructorID = ucInstructorCardWithFilter1.InstructorID;
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

            if (_IsInstructorTrainingThisMember())
            {
                // the instructor is already training this member!
                MessageBox.Show("this instructor is already training that member!," +
                    " Choose another one", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnSave.Enabled = false;

                return false;
            }

            return true;
        }

        private bool _IsInstructorTrainingThisMember()
        {
            if (ucInstructorCardWithFilter1.SelectedInstructorInfo == null)
                return false;

            // if I am in the `AddNew` Mode, then I have to check is the instructor already training the member or not,
            // but if I am in the `Update` Mode, I have to check before that if the InstructorID is changed or not, if it is not changed, so I don't have to check
            if ((_Mode == enMode.AddNew && ucInstructorCardWithFilter1.SelectedInstructorInfo.
                IsTrainingThisMember(_SelectedMemberID)) ||
                (_Mode == enMode.Update && _MembersInstructor != null &&
                (_MembersInstructor.MemberID != ucMemberCardWithFilter1.MemberID ||
                _MembersInstructor.InstructorID != ucInstructorCardWithFilter1.InstructorID) &&
                 ucInstructorCardWithFilter1.SelectedInstructorInfo.IsTrainingThisMember(_SelectedMemberID)))
            {
                return true;
            }

            return false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tcMembersInstructors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_IsInstructorTrainingThisMember())
            {
                // the instructor is already training this member!
                MessageBox.Show("this instructor is already training that member!," +
                    " Choose another one", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnSave.Enabled = false;

                return;
            }

            if (ucMemberCardWithFilter1.SelectedMemberInfo != null &&
                ucMemberCardWithFilter1.SelectedMemberInfo.IsActive)
                return;


            TabPage SelectedTabPage = tcMembersInstructors.SelectedTab;

            if (SelectedTabPage == tpMember)
            {
                btnSave.Enabled = false;
            }

            if (SelectedTabPage == tpInstructor)
            {
                tcMembersInstructors.SelectedTab = tpMember;

                if (_IsMemberCorrect())
                {
                    tcMembersInstructors.SelectedTab = tpInstructor;

                    //btnSave.Enabled = true;
                }

            }
        }

        private void ucMemberCardWithFilter1_OnMemberSelected(int obj)
        {
            _SelectedMemberID = obj;

            if (_SelectedMemberID == -1)
            {
                btnMemberInfoNext.Enabled = false;
                btnSave.Enabled = false;

                return;
            }

            if (!ucMemberCardWithFilter1.SelectedMemberInfo.IsActive)
            {
                MessageBox.Show("Selected Member is Not Active, choose an active member.",
                     "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnMemberInfoNext.Enabled = false;
                btnSave.Enabled = false;

                return;
            }


            btnMemberInfoNext.Enabled = true;
            ucMemberCardWithFilter1.FilterEnabled = false;
        }

        private void frmAddEditMembersInstructors_Activated(object sender, EventArgs e)
        {
            ucMemberCardWithFilter1.FilterFocus();
        }

        private void btnMemberInfoNext_Click(object sender, EventArgs e)
        {
            if (_IsMemberCorrect())
            {
                tcMembersInstructors.SelectedTab = tpInstructor;
            }
        }

        private void ucInstructorCardWithFilter1_OnInstructorSelected(int obj)
        {
            _SelectedInstructorID = obj;

            if (_SelectedInstructorID == -1)
            {
                btnSave.Enabled = false;

                return;
            }

            if (_IsInstructorTrainingThisMember())
            {
                // the instructor is already training this member!
                MessageBox.Show("this instructor is already training that member!," +
                    " Choose another one", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnSave.Enabled = false;

                return;
            }

            btnSave.Enabled = true;
        }

        private void frmAddEditMembersInstructors_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.Update)
                _LoadData();

            dtpAssignDate.MinDate = DateTime.Now;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_SelectedMemberID == -1 || _SelectedInstructorID == -1)
            {
                return;
            }

            _MembersInstructor.MemberID = _SelectedMemberID;
            _MembersInstructor.InstructorID = _SelectedInstructorID;
            _MembersInstructor.AssignDate = dtpAssignDate.Value;

            if (_MembersInstructor.Save())
            {
                MessageBox.Show($"Instructor with ID: [{_MembersInstructor.InstructorID}] " +
                    $"is assigned to Member with ID: [{_MembersInstructor.MemberID}] at:" +
                    $" [{_MembersInstructor.AssignDate.ToShortDateString()}]",
                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                lblMembersInstructorsID.Text = _MembersInstructor.MemberInstructorID.ToString();

                this._Mode = enMode.Update;

                lblTitle.Text = "Update Members-Instructors";
                this.Text = "Update Members-Instructors";

                btnSave.Enabled = false;
                ucInstructorCardWithFilter1.FilterEnabled = false;

                GetMembersInstructorsID?.Invoke(_MembersInstructor.MemberInstructorID);
            }

            else
                MessageBox.Show("Data Saved Failed", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
