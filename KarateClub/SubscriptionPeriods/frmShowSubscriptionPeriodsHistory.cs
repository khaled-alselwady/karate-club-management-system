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

namespace KarateClub.SubscriptionPeriods
{
    public partial class frmShowSubscriptionPeriodsHistory : Form
    {
        public frmShowSubscriptionPeriodsHistory(int? MemberID)
        {
            InitializeComponent();

            ucMemberCard1.LoadMemberInfo(MemberID);
            ucMemberSubscriptionPeriods1.LoadSubscriptionPeriodsInfo(MemberID);
        }
      
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }      
    }
}
