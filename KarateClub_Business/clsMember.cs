using KarateClub_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarateClub_Business
{
    public class clsMember
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int MemberID { get; set; }
        public int PersonID { get; set; }
        public string EmergencyContactInfo { get; set; }
        public int LastBeltRankID { get; set; }
        public bool IsActive { get; set; }

        public clsMember()
        {
            this.MemberID = -1;
            this.PersonID = -1;
            this.EmergencyContactInfo = string.Empty;
            this.LastBeltRankID = -1;
            this.IsActive = false;

            Mode = enMode.AddNew;
        }

        private clsMember(int MemberID, int PersonID, string EmergencyContactInfo,
            int LastBeltRankID, bool IsActive)
        {
            this.MemberID = MemberID;
            this.PersonID = PersonID;
            this.EmergencyContactInfo = EmergencyContactInfo;
            this.LastBeltRankID = LastBeltRankID;
            this.IsActive = IsActive;

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

        public static clsMember Find(int MemberID)
        {
            int PersonID = -1;
            string EmergencyContactInfo = string.Empty;
            int LastBeltRankID = -1;
            bool IsActive = false;

            bool IsFound = clsMemberData.GetMemberInfoByID(MemberID, ref PersonID, ref EmergencyContactInfo,
                ref LastBeltRankID, ref IsActive);

            if (IsFound)
            {
                return new clsMember(MemberID, PersonID, EmergencyContactInfo, LastBeltRankID, IsActive);
            }
            else
            {
                return null;
            }
        }

        public static bool DeleteMember(int MemberID)
        {
            return clsMemberData.DeleteMember(MemberID);
        }

        public static bool DoesMemberExist(int MemberID)
        {
            return clsMemberData.DoesMemberExist(MemberID);
        }

        public static DataTable GetAllMembers()
        {
            return clsMemberData.GetAllMembers();
        }

    }


}
