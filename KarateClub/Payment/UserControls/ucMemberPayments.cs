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

namespace KarateClub.Payment.UserControls
{
    public partial class ucMemberPayments : UserControl
    {
        private DataTable _dtAllMemberPayments;

        private int _MemberID = -1;

        public ucMemberPayments()
        {
            InitializeComponent();
        }

        private void _RefreshMemberPaymentsList()
        {
            _dtAllMemberPayments = clsPayment.GetAllPaymentsForMember(this._MemberID);
            dgvMemberPaymentsList.DataSource = _dtAllMemberPayments;

            lblNumberOfRecords.Text = dgvMemberPaymentsList.Rows.Count.ToString();

            if (dgvMemberPaymentsList.Rows.Count > 0)
            {
                dgvMemberPaymentsList.Columns[0].HeaderText = "Payment ID";
                dgvMemberPaymentsList.Columns[0].Width = 130;

                dgvMemberPaymentsList.Columns[1].HeaderText = "Member Name";
                dgvMemberPaymentsList.Columns[1].Width = 200;

                dgvMemberPaymentsList.Columns[2].HeaderText = "Payment Date";
                dgvMemberPaymentsList.Columns[2].Width = 150;

                dgvMemberPaymentsList.Columns[3].HeaderText = "Payment Amount";
                dgvMemberPaymentsList.Columns[3].Width = 160;
            }
        }

        private int _GetPaymentIDFromDGV()
        {
            return (int)dgvMemberPaymentsList.CurrentRow.Cells["PaymentID"].Value;
        }

        public void LoadMemberPaymentsInfo(int MemberID)
        {
            this._MemberID = MemberID;
            _RefreshMemberPaymentsList();
        }

        public void Clear()
        {
            _dtAllMemberPayments.Clear();
        }

        private void ShowPaymentDetailstoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmShowPaymentDetails ShowPaymentDetails = new frmShowPaymentDetails(_GetPaymentIDFromDGV());
            ShowPaymentDetails.ShowDialog();
        }

        private void dgvMemberPaymentsList_DoubleClick(object sender, EventArgs e)
        {
            frmShowPaymentDetails ShowPaymentDetails = new frmShowPaymentDetails(_GetPaymentIDFromDGV());
            ShowPaymentDetails.ShowDialog();
        }
    }
}
