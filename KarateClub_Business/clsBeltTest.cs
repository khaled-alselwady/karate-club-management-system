using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarateClub_DataAccess;

namespace KarateClub_Business
{
    public class clsBeltTest
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int TestID { get; set; }
        public int MemberID { get; set; }
        public int RankID { get; set; }
        public bool Result { get; set; }
        public DateTime Date { get; set; }
        public int TestedByInstructorID { get; set; }
        public int PaymentID { get; set; }

        public clsMember MemberInfo { get; set; }
        public clsInstructor InstructorInfo { get; set; }
        public clsBeltRank BeltRankInfo { get; set; }
        public clsPayment PaymentInfo { get; set; }

        public clsBeltTest()
        {
            this.TestID = -1;
            this.MemberID = -1;
            this.RankID = -1;
            this.Result = true;
            this.Date = DateTime.Now;
            this.TestedByInstructorID = -1;
            this.PaymentID = -1;

            Mode = enMode.AddNew;
        }

        private clsBeltTest(int TestID, int MemberID, int RankID, bool Result,
            DateTime Date, int TestedByInstructorID, int PaymentID)
        {
            this.TestID = TestID;
            this.MemberID = MemberID;
            this.RankID = RankID;
            this.Result = Result;
            this.Date = Date;
            this.TestedByInstructorID = TestedByInstructorID;
            this.PaymentID = PaymentID;

            this.MemberInfo = clsMember.Find(MemberID);
            this.InstructorInfo = clsInstructor.Find(TestedByInstructorID);
            this.BeltRankInfo = clsBeltRank.Find(RankID);
            this.PaymentInfo = clsPayment.Find(PaymentID);

            Mode = enMode.Update;
        }

        private bool _AddNewTest()
        {
            this.TestID = clsBeltTestData.AddNewTest(this.MemberID, this.RankID, this.Result,
                this.Date, this.TestedByInstructorID, this.PaymentID);

            return (this.TestID != -1);
        }

        private bool _UpdateTest()
        {
            return clsBeltTestData.UpdateTest(this.TestID, this.MemberID, this.RankID,
                this.Result, this.Date, this.TestedByInstructorID, this.PaymentID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTest())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateTest();
            }

            return false;
        }

        public static clsBeltTest Find(int TestID)
        {
            int MemberID = -1;
            int RankID = -1;
            bool Result = true;
            DateTime Date = DateTime.Now;
            int TestedByInstructorID = -1;
            int PaymentID = -1;

            bool IsFound = clsBeltTestData.GetTestInfoByID(TestID, ref MemberID, ref RankID,
                ref Result, ref Date, ref TestedByInstructorID, ref PaymentID);

            if (IsFound)
            {
                return new clsBeltTest(TestID, MemberID, RankID, Result, Date,
                    TestedByInstructorID, PaymentID);
            }
            else
            {
                return null;
            }
        }

        public static bool DeleteTest(int TestID)
        {
            return clsBeltTestData.DeleteTest(TestID);
        }

        public static bool DoesTestExist(int TestID)
        {
            return clsBeltTestData.DoesTestExist(TestID);
        }

        public static DataTable GetAllBeltTests()
        {
            return clsBeltTestData.GetAllBeltTests();
        }

        public static short Count()
        {
            return clsBeltTestData.CountBeltTests();
        }

        public int Pay(decimal Amount)
        {
            clsPayment Payment = new clsPayment();

            Payment.MemberID = this.MemberID;
            Payment.Amount = Amount;

            if (!Payment.Save())
            {
                return -1;
            }

            return Payment.PaymentID;
        }

        public static DataTable GetAllBeltTestsForMember(int MemberID)
        {
            return clsBeltTestData.GetAllBeltTestsForMember(MemberID);
        }

    }


}
