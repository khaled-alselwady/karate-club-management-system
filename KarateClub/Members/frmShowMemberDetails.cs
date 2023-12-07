using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KarateClub.Members
{
    public partial class frmShowMemberDetails : Form
    {     
        public frmShowMemberDetails(int memberID)
        {
            InitializeComponent();

            ucMemberCard1.LoadMemberInfo(memberID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
