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

        public clsBeltTest()
        {
            this.TestID = -1;
            this.MemberID = -1;
            this.RankID = -1;
            this.Result = false;
            this.Date = DateTime.Now;
            this.TestedByInstructorID = -1;
            this.PaymentID = -1;

            Mode = enMode.AddNew;
        }

        private clsBeltTest(int TestID, int MemberID, int RankID, bool Result, DateTime Date, int TestedByInstructorID, int PaymentID)
        {
            this.TestID = TestID;
            this.MemberID = MemberID;
            this.RankID = RankID;
            this.Result = Result;
            this.Date = Date;
            this.TestedByInstructorID = TestedByInstructorID;
            this.PaymentID = PaymentID;

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
            bool Result = false;
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

    }


}
