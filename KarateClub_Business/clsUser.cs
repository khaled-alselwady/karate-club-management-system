using KarateClub_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarateClub_Business
{
    public class clsUser : clsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public enum enPermissions
        {
            All = -1,
            ManageMembers = 1,
            ManageInstructors = 2,
            ManageUsers = 4,
            ManageMembersInstructors = 8,
            ManageBeltRanks = 16,
            ManageSubscriptionPeriods = 32,
            ManageBeltTests = 64,
            ManagePayments = 128
        }

        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Permissions { get; set; }
        public bool IsActive { get; set; }

        public clsUser()
        {
            this.UserID = -1;
            this.PersonID = -1;
            this.Username = string.Empty;
            this.Password = string.Empty;
            this.Permissions = -1;
            this.IsActive = false;

            Mode = enMode.AddNew;
        }

        private clsUser(int PersonID, string Name, string Address,
            string Phone, string Email, DateTime DateOfBirth, enGender Gender,
            string ImagePath, int UserID, string Username, string Password,
            int Permissions, bool IsActive)
        {
            base.PersonID = PersonID;
            base.Name = Name;
            base.Address = Address;
            base.Phone = Phone;
            base.Email = Email;
            base.DateOfBirth = DateOfBirth;
            base.Gender = Gender;
            base.ImagePath = ImagePath;

            this.UserID = UserID;
            this.Username = Username;
            this.Password = Password;
            this.Permissions = Permissions;
            this.IsActive = IsActive;

            Mode = enMode.Update;
        }

        private bool _AddNewUser()
        {
            this.UserID = clsUserData.AddNewUser(this.PersonID, this.Username,
                this.Password, this.Permissions, this.IsActive);

            return (this.UserID != -1);
        }

        private bool _UpdateUser()
        {
            return clsUserData.UpdateUser(this.UserID, this.PersonID, this.Username,
                this.Password, this.Permissions, this.IsActive);
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
                    if (_AddNewUser())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateUser();
            }

            return false;
        }

        private static int _GetPersonIDByUserID(int UserID)
        {
            return clsUserData.GetPersonIDByUserID(UserID);
        }

        public static clsUser Find(int UserID)
        {
            int PersonID = -1;
            string Username = string.Empty;
            string Password = string.Empty;
            int Permissions = -1;
            bool IsActive = false;

            bool IsFound = clsUserData.GetUserInfoByID
                (UserID, ref PersonID, ref Username, ref Password, ref Permissions, ref IsActive);

            if (IsFound)
            {
                clsPerson Person = clsPerson.Find(PersonID);

                if (Person == null)
                {
                    return null;
                }

                return new clsUser(Person.PersonID, Person.Name, Person.Address, Person.Phone,
                    Person.Email, Person.DateOfBirth, Person.Gender, Person.ImagePath,
                    UserID, Username, Password, Permissions, IsActive);
            }
            else
            {
                return null;
            }
        }

        public static clsUser Find(string Username)
        {
            int UserID = -1;
            int PersonID = -1;
            string Password = string.Empty;
            int Permissions = -1;
            bool IsActive = false;

            bool IsFound = clsUserData.GetUserInfoByUsername
                (ref UserID, ref PersonID, Username, ref Password, ref Permissions, ref IsActive);

            if (IsFound)
            {
                clsPerson Person = clsPerson.Find(PersonID);

                if (Person == null)
                {
                    return null;
                }

                return new clsUser(Person.PersonID, Person.Name, Person.Address, Person.Phone,
                    Person.Email, Person.DateOfBirth, Person.Gender, Person.ImagePath,
                    UserID, Username, Password, Permissions, IsActive);
            }
            else
            {
                return null;
            }
        }

        public static clsUser Find(string Username, string Password)
        {
            int UserID = -1;
            int PersonID = -1;
            int Permissions = -1;
            bool IsActive = false;

            bool IsFound = clsUserData.GetUserInfoByUsernameAndPassword
                (ref UserID, ref PersonID, Username, Password, ref Permissions, ref IsActive);

            if (IsFound)
            {
                clsPerson Person = clsPerson.Find(PersonID);

                if (Person == null)
                {
                    return null;
                }

                return new clsUser(Person.PersonID, Person.Name, Person.Address, Person.Phone,
                    Person.Email, Person.DateOfBirth, Person.Gender, Person.ImagePath,
                    UserID, Username, Password, Permissions, IsActive);
            }
            else
            {
                return null;
            }
        }

        public static bool DeleteUser(int UserID)
        {
            int PersonID = _GetPersonIDByUserID(UserID);

            if (PersonID == -1)
            {
                return false;
            }

            if (!clsUserData.DeleteUser(UserID))
            {
                return false;
            }

            return clsPerson.DeletePerson(PersonID);
        }

        public static bool DoesUserExist(int UserID)
        {
            return clsUserData.DoesUserExist(UserID);
        }

        public static bool DoesUserExist(string Username)
        {
            return clsUserData.DoesUserExist(Username);
        }

        public static bool DoesUserExist(string Username, string Password)
        {
            return clsUserData.DoesUserExist(Username, Password);
        }

        public static DataTable GetAllUsers()
        {
            return clsUserData.GetAllUsers();
        }

        public static short Count()
        {
            return clsUserData.CountUsers();
        }

    }


}
