using KarateClub_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarateClub_Business
{
    public class clsInstructor : clsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int? InstructorID { get; set; }
        public string Qualification { get; set; }

        public clsInstructor()
        {
            this.InstructorID = null;
            this.PersonID = null;
            this.Qualification = string.Empty;

            Mode = enMode.AddNew;
        }

        private clsInstructor(int? PersonID, string Name, string Address,
            string Phone, string Email, DateTime DateOfBirth,
            enGender Gender, string ImagePath, int? InstructorID,
            string Qualification)
        {
            base.PersonID = PersonID;
            base.Name = Name;
            base.Address = Address;
            base.Phone = Phone;
            base.Email = Email;
            base.DateOfBirth = DateOfBirth;
            base.Gender = Gender;
            base.ImagePath = ImagePath;

            this.InstructorID = InstructorID;
            this.Qualification = Qualification;

            Mode = enMode.Update;
        }

        private static int? _GetPersonIDByInstructorID(int? InstructorID)
        {
            return clsInstructorData.GetPersonIDByInstructorID(InstructorID);
        }

        private bool _AddNewInstructor()
        {
            this.InstructorID = clsInstructorData.AddNewInstructor(this.PersonID,
                this.Qualification);

            return (this.InstructorID.HasValue);
        }

        private bool _UpdateInstructor()
        {
            return clsInstructorData.UpdateInstructor(this.InstructorID,
                this.PersonID, this.Qualification);
        }

        public bool Save()
        {
            base.Mode = (clsPerson.enMode)Mode;
            if (!base.Save())
            {
                return false;
            }

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

        public static clsInstructor Find(int? InstructorID)
        {
            int? PersonID = null;
            string Qualification = null;

            bool IsFound = clsInstructorData.GetInstructorInfoByID(InstructorID,
                ref PersonID, ref Qualification);

            if (IsFound)
            {
                clsPerson Person = clsPerson.Find(PersonID);

                if (Person == null)
                {
                    return null;
                }

                return new clsInstructor(Person.PersonID, Person.Name, Person.Address,
                    Person.Phone, Person.Email, Person.DateOfBirth, Person.Gender,
                     Person.ImagePath, InstructorID, Qualification);

            }
            else
            {
                return null;
            }
        }

        public static bool DeleteInstructor(int? InstructorID)
        {
            int? PersonID = _GetPersonIDByInstructorID(InstructorID);

            if (!PersonID.HasValue)
            {
                return false;
            }

            if (!clsInstructorData.DeleteInstructor(InstructorID))
            {
                return false;
            }

            return clsPerson.DeletePerson(PersonID);
        }

        public static bool DoesInstructorExist(int? InstructorID)
        {
            return clsInstructorData.DoesInstructorExist(InstructorID);
        }

        public static DataTable GetAllInstructors()
        {
            return clsInstructorData.GetAllInstructors();
        }

        public static short Count()
        {
            return clsInstructorData.CountInstructors();
        }

        public bool IsTrainingThisMember(int? MemberID)
        {
            return clsMemberInstructor.IsInstructorTrainingMember(this.InstructorID, MemberID);
        }
    }


}
