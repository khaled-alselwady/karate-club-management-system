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
    public partial class frmShowInstructorDetails : Form
    {
        // Declare a delegate
        public delegate void DataBackEventHandler(object sender, int InstructorID);
        // Declare an event using the delegate
        public event DataBackEventHandler RefreshList;

        public frmShowInstructorDetails(int InstructorID)
        {
            InitializeComponent();
            ucInstructorCard1.LoadInstructorInfo(InstructorID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            RefreshList?.Invoke(this, ucInstructorCard1.InstructorID);

            this.Close();
        }
    }
}
