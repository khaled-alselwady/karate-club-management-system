using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KarateClub.Payment
{
    public partial class frmShowMemberPaymentsHistory : Form
    {
        public frmShowMemberPaymentsHistory(int? MemberID)
        {
            InitializeComponent();

            ucMemberCard1.LoadMemberInfo(MemberID);
            ucMemberPayments1.LoadMemberPaymentsInfo(MemberID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
