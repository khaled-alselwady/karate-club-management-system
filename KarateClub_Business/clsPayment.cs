using KarateClub_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarateClub_Business
{
    public class clsPayment
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int PaymentID { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int MemberID { get; set; }

        public clsPayment()
        {
            this.PaymentID = -1;
            this.Amount = -1M;
            this.Date = DateTime.Now;
            this.MemberID = -1;

            Mode = enMode.AddNew;
        }

        private clsPayment(int PaymentID, decimal Amount, DateTime Date, int MemberID)
        {
            this.PaymentID = PaymentID;
            this.Amount = Amount;
            this.Date = Date;
            this.MemberID = MemberID;

            Mode = enMode.Update;
        }

        private bool _AddNewPayment()
        {
            this.PaymentID = clsPaymentData.AddNewPayment(this.Amount, this.Date, this.MemberID);

            return (this.PaymentID != -1);
        }

        private bool _UpdatePayment()
        {
            return clsPaymentData.UpdatePayment(this.PaymentID, this.Amount, this.Date, this.MemberID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPayment())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdatePayment();
            }

            return false;
        }

        public static clsPayment Find(int PaymentID)
        {
            decimal Amount = -1M;
            DateTime Date = DateTime.Now;
            int MemberID = -1;

            bool IsFound = clsPaymentData.GetPaymentInfoByID(PaymentID, ref Amount, ref Date, ref MemberID);

            if (IsFound)
            {
                return new clsPayment(PaymentID, Amount, Date, MemberID);
            }
            else
            {
                return null;
            }
        }

        public static bool DeletePayment(int PaymentID)
        {
            return clsPaymentData.DeletePayment(PaymentID);
        }

        public static bool DoesPaymentExist(int PaymentID)
        {
            return clsPaymentData.DoesPaymentExist(PaymentID);
        }

        public static DataTable GetAllPayments()
        {
            return clsPaymentData.GetAllPayments();
        }

        public static short Count()
        {
            return clsPaymentData.CountPayments();
        }

    }


}
