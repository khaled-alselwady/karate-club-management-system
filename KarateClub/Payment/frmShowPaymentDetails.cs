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
    public partial class frmShowPaymentDetails : Form
    {
        public frmShowPaymentDetails(int PaymentID)
        {
            InitializeComponent();

            ucPaymentDetails1.LoadPaymentInfo(PaymentID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
