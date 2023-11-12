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
    public partial class frmShowTrainedMembersByInstructor : Form
    {
        public frmShowTrainedMembersByInstructor(int InstructorID)
        {
            InitializeComponent();

            ucInstructorCard1.LoadInstructorInfo(InstructorID);
            ucTrainedMembersByInstructor1.LoadTrainedMembersInfo(InstructorID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
