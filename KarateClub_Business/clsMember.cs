using KarateClub_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace KarateClub_Business
{
    public class clsMember : clsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int MemberID { get; set; }
        public string EmergencyContactInfo { get; set; }
        public int LastBeltRankID { get; set; }
        public bool IsActive { get; set; }

        public clsBeltRank LastBeltRankInfo { get; set; }

        public clsMember()
        {
            this.MemberID = -1;
            this.PersonID = -1;
            this.EmergencyContactInfo = string.Empty;
            this.LastBeltRankID = -1;
            this.IsActive = false;

            Mode = enMode.AddNew;
        }

        private clsMember(int PersonID, string Name, string Address,
            string Phone, string Email, DateTime DateOfBirth, enGender Gender,
            string ImagePath, int MemberID, string EmergencyContactInfo,
            int LastBeltRankID, bool IsActive)
        {
            base.PersonID = PersonID;
            base.Name = Name;
            base.Address = Address;
            base.Phone = Phone;
            base.Email = Email;
            base.DateOfBirth = DateOfBirth;
            base.Gender = Gender;
            base.ImagePath = ImagePath;

            this.MemberID = MemberID;
            this.EmergencyContactInfo = EmergencyContactInfo;
            this.LastBeltRankID = LastBeltRankID;
            this.IsActive = IsActive;

            this.LastBeltRankInfo = clsBeltRank.Find(LastBeltRankID);

            Mode = enMode.Update;
        }

        private bool _AddNewMember()
        {
            this.MemberID = clsMemberData.AddNewMember(this.PersonID, this.EmergencyContactInfo,
                this.LastBeltRankID, this.IsActive);

            return (this.MemberID != -1);
        }

        private bool _UpdateMember()
        {
            return clsMemberData.UpdateMember(this.MemberID, this.PersonID,
                this.EmergencyContactInfo, this.LastBeltRankID, this.IsActive);
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
                    if (_AddNewMember())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateMember();
            }

            return false;
        }

        public bool SetActivity(bool IsActive)
        {
            return SetActivity(this.MemberID, IsActive);
        }

        public static bool SetActivity(int MemberID, bool IsActive)
        {
            return clsMemberData.SetActivity(MemberID, IsActive);
        }

        public static clsMember Find(int MemberID)
        {
            int PersonID = -1;
            string EmergencyContactInfo = string.Empty;
            int LastBeltRankID = -1;
            bool IsActive = false;

            bool IsFound = clsMemberData.GetMemberInfoByID(MemberID, ref PersonID,
                ref EmergencyContactInfo, ref LastBeltRankID, ref IsActive);


            if (IsFound)
            {
                clsPerson Person = clsPerson.Find(PersonID);

                if (Person == null)
                {
                    return null;
                }

                return new clsMember(Person.PersonID, Person.Name, Person.Address, Person.Phone,
                    Person.Email, Person.DateOfBirth, Person.Gender, Person.ImagePath, MemberID,
                    EmergencyContactInfo, LastBeltRankID, IsActive);
            }
            else
            {
                return null;
            }
        }

        private static int _GetPersonIDByMemberID(int MemberID)
        {
            return clsMemberData.GetPersonIDByMemberID(MemberID);
        }

        public static bool DeleteMember(int MemberID)
        {
            int PersonID = _GetPersonIDByMemberID(MemberID);

            if (PersonID == -1)
            {
                return false;
            }

            if (!clsMemberData.DeleteMember(MemberID))
            {
                return false;
            }

            return clsPerson.DeletePerson(PersonID);
        }

        public static bool DoesMemberExist(int MemberID)
        {
            return clsMemberData.DoesMemberExist(MemberID);
        }

        public static DataTable GetAllMembers()
        {
            return clsMemberData.GetAllMembers();
        }

        public static short Count()
        {
            return clsMemberData.CountMembers();
        }

        public int GetLastActivePeriodID()
        {
            return clsSubscriptionPeriod.GetLastActivePeriodIDForMember(this.MemberID);
        }

        public bool DoesHaveAnActivePeriodID()
        {
            return (GetLastActivePeriodID() != -1);
        }

    }


}
