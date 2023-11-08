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

namespace KarateClub.Instructors.UserControls
{
    public partial class ucInstructorCard : UserControl
    {

        private int _InstructorID = -1;
        private clsInstructor _Instructor;

        public int InstructorID => _InstructorID;
        public clsInstructor SelectedInstructorInfo => _Instructor;

        public ucInstructorCard()
        {
            InitializeComponent();
        }

        public void Reset()
        {
            this._InstructorID = -1;
            this._Instructor = null;

            lblInstructorID.Text = "[????]";
            lblQualifications.Text = "[????]";

            llEditInstructorInfo.Enabled = false;
        }

        private void _FillInstructorInfo()
        {
            llEditInstructorInfo.Enabled = true;

            ucPersonCard1.LoadPersonInfo(_Instructor.PersonID);

            lblInstructorID.Text = _Instructor.InstructorID.ToString();
            lblQualifications.Text = _Instructor.Qualification;
        }

        public void LoadInstructorInfo(int InstructorID)
        {
            this._InstructorID = InstructorID;

            if (InstructorID == -1)
            {
                MessageBox.Show("There is no instructor with id = -1", "Missing Member",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                Reset();

                return;
            }

            _Instructor = clsInstructor.Find(this._InstructorID);

            if (_Instructor == null)
            {
                MessageBox.Show($"There is no instructor with id = {InstructorID}",
                    "Missing Member", MessageBoxButtons.OK, MessageBoxIcon.Error);


                Reset();

                return;
            }

            _FillInstructorInfo();
        }

        private void llEditInstructorInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditInstructor EditInstructor = new frmAddEditInstructor(_InstructorID);
            EditInstructor.InstructorIDBack += Refresh;
            EditInstructor.Show();           
        }

        private void Refresh(object sender, int InstructorID)
        {
            LoadInstructorInfo(_InstructorID);
        }
    }
}
