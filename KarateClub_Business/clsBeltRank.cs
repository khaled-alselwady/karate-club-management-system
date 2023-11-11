using KarateClub_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarateClub_Business
{
    public class clsBeltRank
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int RankID { get; set; }
        public string RankName { get; set; }
        public decimal TestFees { get; set; }

        public clsBeltRank()
        {
            this.RankID = -1;
            this.RankName = string.Empty;
            this.TestFees = -1M;

            Mode = enMode.AddNew;
        }

        private clsBeltRank(int RankID, string RankName, decimal TestFees)
        {
            this.RankID = RankID;
            this.RankName = RankName;
            this.TestFees = TestFees;

            Mode = enMode.Update;
        }

        private bool _AddNewRank()
        {
            this.RankID = clsBeltRankData.AddNewRank(this.RankName, this.TestFees);

            return (this.RankID != -1);
        }

        private bool _UpdateRank()
        {
            return clsBeltRankData.UpdateRank(this.RankID, this.RankName, this.TestFees);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewRank())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateRank();
            }

            return false;
        }

        public static clsBeltRank Find(int RankID)
        {
            string RankName = string.Empty;
            decimal TestFees = -1M;

            bool IsFound = clsBeltRankData.GetRankInfoByID(RankID, ref RankName, ref TestFees);

            if (IsFound)
            {
                return new clsBeltRank(RankID, RankName, TestFees);
            }
            else
            {
                return null;
            }
        }

        public static clsBeltRank Find(string RankName)
        {
            int RankID = -1;
            decimal TestFees = -1M;

            bool IsFound = clsBeltRankData.GetRankInfoByName(RankName, ref RankID, ref TestFees);

            if (IsFound)
            {
                return new clsBeltRank(RankID, RankName, TestFees);
            }
            else
            {
                return null;
            }
        }

        public static bool DeleteRank(int RankID)
        {
            return clsBeltRankData.DeleteRank(RankID);
        }

        public static bool DoesRankExist(int RankID)
        {
            return clsBeltRankData.DoesRankExist(RankID);
        }

        public static bool DoesRankExist(string RankName)
        {
            return clsBeltRankData.DoesRankExist(RankName);
        }

        public static DataTable GetAllBeltRanks()
        {
            return clsBeltRankData.GetAllBeltRanks();
        }

        public static DataTable GetAllBeltRanksName()
        {
            return clsBeltRankData.GetAllBeltRanksName();
        }

        public static int GetNextBeltRankID(int CurrentBeltRankID)
        {
            return clsBeltRankData.GetNextBeltRankID(CurrentBeltRankID);
        }
    }


}
