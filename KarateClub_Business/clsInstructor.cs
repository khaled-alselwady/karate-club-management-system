using KarateClub_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarateClub_Business
{
    public class clsInstructor
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int InstructorID { get; set; }
        public int PersonID { get; set; }
        public string Qualification { get; set; }

        public clsInstructor()
        {
            this.InstructorID = -1;
            this.PersonID = -1;
            this.Qualification = string.Empty;

            Mode = enMode.AddNew;
        }

        private clsInstructor(int InstructorID, int PersonID, string Qualification)
        {
            this.InstructorID = InstructorID;
            this.PersonID = PersonID;
            this.Qualification = Qualification;

            Mode = enMode.Update;
        }

        private bool _AddNewInstructor()
        {
            this.InstructorID = clsInstructorData.AddNewInstructor(this.PersonID, this.Qualification);

            return (this.InstructorID != -1);
        }

        private bool _UpdateInstructor()
        {
            return clsInstructorData.UpdateInstructor(this.InstructorID, this.PersonID, this.Qualification);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewInstructor())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateInstructor();
            }

            return false;
        }

        public static clsInstructor Find(int InstructorID)
        {
            int PersonID = -1;
            string Qualification = string.Empty;

            bool IsFound = clsInstructorData.GetInstructorInfoByID(InstructorID, ref PersonID, ref Qualification);

            if (IsFound)
            {
                return new clsInstructor(InstructorID, PersonID, Qualification);
            }
            else
            {
                return null;
            }
        }

        public static bool DeleteInstructor(int InstructorID)
        {
            return clsInstructorData.DeleteInstructor(InstructorID);
        }

        public static bool DoesInstructorExist(int InstructorID)
        {
            return clsInstructorData.DoesInstructorExist(InstructorID);
        }

        public static DataTable GetAllInstructors()
        {
            return clsInstructorData.GetAllInstructors();
        }

    }


}
