using KarateClub_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarateClub_Business
{
    public class clsMemberInstructor
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int MemberInstructorID { get; set; }
        public int MemberID { get; set; }
        public int InstructorID { get; set; }
        public DateTime AssignDate { get; set; }

        public clsMember MemberInfo { get; set; }
        public clsInstructor InstructorInfo { get; set; }

        public clsMemberInstructor()
        {
            this.MemberInstructorID = -1;
            this.MemberID = -1;
            this.InstructorID = -1;
            this.AssignDate = DateTime.Now;

            this.Mode = enMode.AddNew;
        }

        private clsMemberInstructor(int MemberInstructorID, int MemberID,
            int InstructorID, DateTime AssignDate)
        {
            this.MemberInstructorID = MemberInstructorID;
            this.MemberID = MemberID;
            this.InstructorID = InstructorID;
            this.AssignDate = AssignDate;

            this.MemberInfo = clsMember.Find(MemberID);
            this.InstructorInfo = clsInstructor.Find(InstructorID);

            this.Mode = enMode.Update;
        }

        private bool _AddNewMemberInstructor()
        {
            this.MemberInstructorID = clsMemberInstructorData.AddNewMemberInstructor
                (this.MemberID, this.InstructorID, this.AssignDate);

            return (this.MemberInstructorID != -1);
        }

        private bool _UpdateMemberInstructor()
        {
            return clsMemberInstructorData.UpdateMemberInstructor
                (this.MemberInstructorID, this.MemberID, this.InstructorID, this.AssignDate);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewMemberInstructor())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateMemberInstructor();
            }

            return false;
        }

        public static clsMemberInstructor Find(int MemberInstructorID)
        {
            int MemberID = -1;
            int InstructorID = -1;
            DateTime AssignDate = DateTime.Now;

            bool IsFound = clsMemberInstructorData.GetMemberInstructorInfoByID
                (MemberInstructorID, ref MemberID, ref InstructorID, ref AssignDate);

            if (IsFound)
            {
                return new clsMemberInstructor(MemberInstructorID, MemberID, InstructorID, AssignDate);
            }
            else
            {
                return null;
            }
        }

        public static bool DeleteMemberInstructor(int MemberInstructorID)
        {
            return clsMemberInstructorData.DeleteMemberInstructor(MemberInstructorID);
        }

        public static bool DoesMemberInstructorExist(int MemberInstructorID)
        {
            return clsMemberInstructorData.DoesMemberInstructorExist(MemberInstructorID);
        }

        public static DataTable GetAllMemberInstructors()
        {
            return clsMemberInstructorData.GetAllMemberInstructors();
        }

        public static bool IsInstructorTrainingMember(int InstructorID, int MemberID)
        {
            return clsMemberInstructorData.IsInstructorTrainingMember(InstructorID, MemberID);
        }

        public static DataTable GetTrainedMembersByInstructor(int InstructorID)
        {
            return clsMemberInstructorData.GetTrainedMembersByInstructor(InstructorID);
        }
    }


}
