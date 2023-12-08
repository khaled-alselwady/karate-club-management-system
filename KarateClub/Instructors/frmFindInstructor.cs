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
        public Action<int?> GetInstructorID;

        public frmFindInstructor()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            GetInstructorID?.Invoke(ucInstructorCardWithFilter1.InstructorID);

            this.Close();
        }

        private void frmFindInstructor_Activated(object sender, EventArgs e)
        {
            ucInstructorCardWithFilter1.FilterFocus();
        }
    }
}
