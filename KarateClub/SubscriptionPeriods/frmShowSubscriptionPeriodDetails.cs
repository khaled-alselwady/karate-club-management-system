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
    public partial class frmShowSubscriptionPeriodDetails : Form
    {
        public frmShowSubscriptionPeriodDetails(int PeriodID)
        {
            InitializeComponent();

            ucSubscriptionPeriodInfo1.LoadSubscriptionPeriodInfo(PeriodID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
