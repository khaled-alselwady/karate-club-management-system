using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KarateClub.BeltTests
{
    public partial class frmShowMemberTestsHistory : Form
    {
        public frmShowMemberTestsHistory(int? MemberID)
        {
            InitializeComponent();

            ucMemberCard1.LoadMemberInfo(MemberID);
            ucMemberTests1.LoadMemberTestsInfo(MemberID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
