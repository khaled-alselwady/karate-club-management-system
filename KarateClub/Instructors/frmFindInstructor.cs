using KarateClub.Members.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KarateClub.Instructors
{
    public partial class frmFindInstructor : Form
    {
        // Declare a Delegate
        public delegate void GetInstructorID(object sender, int InstructorID);
        // Declare an event
        public event GetInstructorID InstructorIDBack;

        public frmFindInstructor()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            InstructorIDBack?.Invoke(this, ucInstructorCardWithFilter1.InstructorID);

            this.Close();
        }

        private void frmFindInstructor_Activated(object sender, EventArgs e)
        {
            ucInstructorCardWithFilter1.FilterFocus();
        }
    }
}
