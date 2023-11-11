using KarateClub.BeltTests;
using KarateClub.Global_Classes;
using KarateClub.Members;
using KarateClub.Properties;
using KarateClub.SubscriptionPeriods;
using KarateClub_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KarateClub.Payment.UserControls
{
    public partial class ucPaymentDetails : UserControl
    {

        private int _PaymentID = -1;
        private clsPayment _Payment;

        public int PaymentID => _PaymentID;
        public clsPayment Payment => _Payment;

        private int _TempID = -1; // to store the id of the TestID or the PeriodID depends on the paymentID

        public ucPaymentDetails()
        {
            InitializeComponent();
        }

        private void _LoadMemberImage()
        {
            if (_Payment.MemberInfo.ImagePath != "")
            {
                if (File.Exists(_Payment.MemberInfo.ImagePath))
                    pbMemberImage.ImageLocation = _Payment.MemberInfo.ImagePath;
                else
                    MessageBox.Show("Could not find this image: = " + _Payment.MemberInfo.ImagePath,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (_Payment.MemberInfo.Gender == (byte)clsPerson.enGender.Male)
                    pbMemberImage.Image = Resources.DefaultMale;
                else
                    pbMemberImage.Image = Resources.DefaultFemale;
            }
        }

        private void _HandlePaymentFor()
        {
            _TempID = _Payment.PaymentForID;

            switch (_Payment.PaymentFor)
            {
                case clsPayment.enPaymentFor.SubscriptionPeriod:
                    lblPaymentFor.Text = "Subscription Period";
                    lblPaymentForLabel.Text = "Period ID:";
                    lblPaymentForIDValue.Text = _TempID.ToString();
                    lblPaymentForLabel.Location = new Point(422, 145);
                    llShowPeriodInfo.Visible = true;
                    break;

                case clsPayment.enPaymentFor.BeltTest:
                    lblPaymentFor.Text = "Belt Test";
                   lblPaymentForLabel.Text = "Belt Test ID:";
                    lblPaymentForIDValue.Text = _TempID.ToString();
                    lblPaymentForLabel.Location = new Point(401, 145);
                    llShowTestInfo.Visible = true;
                    break;
            }
        }

        private void _FillPaymentInfo()
        {
            llShowMemberInfo.Enabled = true;

            lblPaymentID.Text = _Payment.PaymentID.ToString();
            lblFullName.Text = _Payment.MemberInfo.Name;
            lblMemberID.Text = _Payment.MemberID.ToString();
            lblGender.Text = _Payment.MemberInfo.GenderName;
            lblPaymentDate.Text = clsFormat.DateToShort(_Payment.Date);           
            lblPaymentAmount.Text = _Payment.Amount.ToString("F0");

            _HandlePaymentFor();
            _LoadMemberImage();
        }

        public void Reset()
        {
            this._PaymentID = -1;
            this._Payment = null;

            lblPaymentID.Text = "[????]";
            lblFullName.Text = "[????]";
            lblMemberID.Text = "[????]";
            lblGender.Text = "[????]";
            lblPaymentDate.Text = "[????]";
            lblPaymentFor.Text = "[????]";
            lblPaymentForIDValue.Text = "[????]";
            lblPaymentAmount.Text = "[????]";

            pbMemberImage.Image = Resources.DefaultMale;
        }

        public void LoadPaymentInfo(int PaymentID)
        {
            this._PaymentID = PaymentID;

            if (this._PaymentID == -1)
            {
                MessageBox.Show("There is no payment with id = -1", "Missing Payment",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                Reset();

                return;
            }

            this._Payment = clsPayment.Find(this._PaymentID);

            if (this._Payment == null)
            {
                MessageBox.Show($"There is no payment with id = {PaymentID}", "Missing Payment",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                Reset();

                return;
            }

            _FillPaymentInfo();
        }

        private void llShowMemberInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowMemberDetails ShowMemberDetails = new frmShowMemberDetails(_Payment.MemberID);
            ShowMemberDetails.ShowDialog();
        }

        private void llShowTestInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowBeltTestDetails ShowBeltTestDetails = new frmShowBeltTestDetails(_TempID);
            ShowBeltTestDetails.ShowDialog();
        }

        private void llShowPeriodInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowSubscriptionPeriodDetails ShowSubscriptionPeriodDetails = new frmShowSubscriptionPeriodDetails(_TempID);
            ShowSubscriptionPeriodDetails.ShowDialog();
        }
    }
}
