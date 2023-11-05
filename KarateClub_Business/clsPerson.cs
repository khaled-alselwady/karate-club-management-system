using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarateClub_DataAccess;

namespace KarateClub_Business
{
    public class clsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int PersonID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactInfo { get; set; }

        public clsPerson()
        {
            this.PersonID = -1;
            this.Name = string.Empty;
            this.Address = string.Empty;
            this.ContactInfo = string.Empty;

            Mode = enMode.AddNew;
        }

        private clsPerson(int PersonID, string Name, string Address, string ContactInfo)
        {
            this.PersonID = PersonID;
            this.Name = Name;
            this.Address = Address;
            this.ContactInfo = ContactInfo;

            Mode = enMode.Update;
        }

        private bool _AddNewPerson()
        {
            this.PersonID = clsPersonData.AddNewPerson(this.Name, this.Address, this.ContactInfo);

            return (this.PersonID != -1);
        }

        private bool _UpdatePerson()
        {
            return clsPersonData.UpdatePerson(this.PersonID, this.Name, this.Address, this.ContactInfo);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdatePerson();
            }

            return false;
        }

        public static clsPerson Find(int PersonID)
        {
            string Name = string.Empty;
            string Address = string.Empty;
            string ContactInfo = string.Empty;

            bool IsFound = clsPersonData.GetPersonInfoByPersonID
                (PersonID, ref Name, ref Address, ref ContactInfo);

            if (IsFound)
            {
                return new clsPerson(PersonID, Name, Address, ContactInfo);
            }
            else
            {
                return null;
            }
        }

        public static bool DeletePerson(int PersonID)
        {
            return clsPersonData.DeletePerson(PersonID);
        }

        public static bool DoesPersonExist(int PersonID)
        {
            return clsPersonData.DoesPersonExist(PersonID);
        }

        public static DataTable GetAllPeople()
        {
            return clsPersonData.GetAllPeople();
        }

    }


}
