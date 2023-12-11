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

namespace KarateClub.Payment
{
    public partial class frmListPayments : Form
    {
        private DataTable _dtAllPayments;

        public frmListPayments()
        {
            InitializeComponent();
        }

        private string _GetRealColumnNameInDB()
        {
            switch (cbFilter.Text)
            {
                case "Payment ID":
                    return "PaymentID";

                case "Member Name":
                    return "MemberName";

                case "Date":
                    return "Date";

                case "Payment Amount":
                    return "Amount";

                default:
                    return "None";
            }
        }

        private void _RefreshPaymentsList()
        {
            _dtAllPayments = clsPayment.GetAllPayments();
            dgvPaymentsList.DataSource = _dtAllPayments;
            lblNumberOfRecords.Text = dgvPaymentsList.Rows.Count.ToString();

            if (dgvPaymentsList.Rows.Count > 0)
            {
                if (dgvPaymentsList.Rows.Count > 0)
                {
                    dgvPaymentsList.Columns[0].HeaderText = "Payment ID";
                    dgvPaymentsList.Columns[0].Width = 130;

                    dgvPaymentsList.Columns[1].HeaderText = "Member Name";
                    dgvPaymentsList.Columns[1].Width = 200;

                    dgvPaymentsList.Columns[2].HeaderText = "Payment Date";
                    dgvPaymentsList.Columns[2].Width = 150;

                    dgvPaymentsList.Columns[3].HeaderText = "Payment Amount";
                    dgvPaymentsList.Columns[3].Width = 160;
                }
            }
        }

        private int _GetPaymentIDFromDGV()
        {
            return (int)dgvPaymentsList.CurrentRow.Cells["PaymentID"].Value;
        }

        private void frmListPayments_Load(object sender, EventArgs e)
        {
            _RefreshPaymentsList();

            cbFilter.SelectedIndex = 0;
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Visible = (cbFilter.Text != "None");

            if (txtSearch.Visible)
            {
                txtSearch.Text = "";
                txtSearch.Focus();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (_dtAllPayments.Rows.Count == 0)
            {
                return;
            }

            string ColumnName = _GetRealColumnNameInDB();

            if (string.IsNullOrWhiteSpace(txtSearch.Text.Trim()) || cbFilter.Text == "None")
            {
                _dtAllPayments.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvPaymentsList.Rows.Count.ToString();

                return;
            }

            if (cbFilter.Text == "Payment ID" || cbFilter.Text == "Payment Amount")
            {
                // search with numbers
                _dtAllPayments.DefaultView.RowFilter =
                    string.Format("[{0}] = {1}", ColumnName, txtSearch.Text.Trim());
            }
            else
            {
                // search with string
                _dtAllPayments.DefaultView.RowFilter =
                    string.Format("[{0}] like '{1}%'", ColumnName, txtSearch.Text.Trim());
            }

            lblNumberOfRecords.Text = dgvPaymentsList.Rows.Count.ToString();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "Payment ID" || cbFilter.Text == "Payment Amount")
            {
                // make sure that the user can only enter the numbers
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void ShowPaymentDetailstoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmShowPaymentDetails ShowPaymentDetails = new frmShowPaymentDetails(_GetPaymentIDFromDGV());
            ShowPaymentDetails.ShowDialog();

            _RefreshPaymentsList();
        }

        private void showPaymentsHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int? MemberID = clsPayment.Find(_GetPaymentIDFromDGV()).MemberID;

            frmShowMemberPaymentsHistory ShowMemberPaymentsHistory = new frmShowMemberPaymentsHistory(MemberID);
            ShowMemberPaymentsHistory.ShowDialog();
        }

        private void dgvPaymentsList_DoubleClick(object sender, EventArgs e)
        {
            frmShowPaymentDetails ShowPaymentDetails = new frmShowPaymentDetails(_GetPaymentIDFromDGV());
            ShowPaymentDetails.ShowDialog();
        }
    }
}
