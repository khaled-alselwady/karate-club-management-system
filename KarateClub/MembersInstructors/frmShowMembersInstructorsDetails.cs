using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KarateClub.MembersInstructors
{
    public partial class frmShowMembersInstructorsDetails : Form
    {
        public frmShowMembersInstructorsDetails(int MembersInstructorsID)
        {
            InitializeComponent();

            ucMembersInstructorsCard1.LoadMembersInstructorsInfo(MembersInstructorsID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
