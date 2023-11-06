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

namespace KarateClub.Dashboard
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            lblNumberOfInstructors.Text = clsInstructor.Count().ToString();
            lblNumberOfMembers.Text = clsMember.Count().ToString();
            lblNumberOfUsers.Text = clsUser.Count().ToString();
            lblNumberOfSubscriptions.Text = clsSubscriptionPeriod.Count().ToString();
            lblNumberOfBeltTests.Text = clsBeltTest.Count().ToString();
            lblNumberOfPayments.Text = clsPayment.Count().ToString();
        }
    }
}
