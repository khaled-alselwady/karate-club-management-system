using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices.ComTypes;

namespace KarateClub_DataAccess
{
    public class clsSubscriptionPeriodData
    {
        public static bool GetPeriodInfoByID(int PeriodID, ref DateTime StartDate,
            ref DateTime EndDate, ref decimal Fees, ref bool IsPaid, ref int MemberID,
            ref int PaymentID, ref byte IssueReason, ref bool IsActive)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from SubscriptionPeriods where PeriodID = @PeriodID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PeriodID", PeriodID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    IsFound = true;

                    StartDate = (DateTime)reader["StartDate"];
                    EndDate = (DateTime)reader["EndDate"];
                    Fees = (decimal)reader["Fees"];
                    IsPaid = (bool)reader["IsPaid"];
                    MemberID = (int)reader["MemberID"];
                    PaymentID = (reader["PaymentID"] != DBNull.Value) ? (int)reader["PaymentID"] : -1;
                    IssueReason = (byte)reader["IssueReason"];
                    IsActive = (bool)reader["IsActive"];
                }
                else
                {
                    // The record was not found
                    IsFound = false;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static int AddNewPeriod(DateTime StartDate, DateTime EndDate, decimal Fees,
            bool IsPaid, int MemberID, int PaymentID, byte IssueReason, bool IsActive)
        {
            // This function will return the new person id if succeeded and -1 if not
            int PeriodID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"update SubscriptionPeriods
                             set IsActive = 0
                             where MemberID = @MemberID;

                             insert into SubscriptionPeriods (StartDate, EndDate, Fees, IsPaid, MemberID, PaymentID, IssueReason, IsActive)
                             values (@StartDate, @EndDate, @Fees, @IsPaid, @MemberID, @PaymentID, @IssueReason, @IsActive)
                             select scope_identity()";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@StartDate", StartDate);
            command.Parameters.AddWithValue("@EndDate", EndDate);
            command.Parameters.AddWithValue("@Fees", Fees);
            command.Parameters.AddWithValue("@IsPaid", IsPaid);
            command.Parameters.AddWithValue("@MemberID", MemberID);
            command.Parameters.AddWithValue("@IssueReason", IssueReason);
            command.Parameters.AddWithValue("@IsActive", IsActive);

            if (PaymentID <= 0)
            {
                command.Parameters.AddWithValue("@PaymentID", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@PaymentID", PaymentID);
            }

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertID))
                {
                    PeriodID = InsertID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return PeriodID;
        }

        public static bool UpdatePeriod(int PeriodID, DateTime StartDate, DateTime EndDate,
            decimal Fees, bool IsPaid, int MemberID, int PaymentID, byte IssueReason, bool IsActive)
        {
            int RowAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update SubscriptionPeriods
set StartDate = @StartDate,
EndDate = @EndDate,
Fees = @Fees,
IsPaid = @IsPaid,
MemberID = @MemberID,
PaymentID = @PaymentID,
IssueReason = @IssueReason,
IsActive = @IsActive
where PeriodID = @PeriodID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PeriodID", PeriodID);
            command.Parameters.AddWithValue("@StartDate", StartDate);
            command.Parameters.AddWithValue("@EndDate", EndDate);
            command.Parameters.AddWithValue("@Fees", Fees);
            command.Parameters.AddWithValue("@IsPaid", IsPaid);
            command.Parameters.AddWithValue("@MemberID", MemberID);
            command.Parameters.AddWithValue("@IssueReason", IssueReason);
            command.Parameters.AddWithValue("@IsActive", IsActive);

            if (PaymentID <= 0)
            {
                command.Parameters.AddWithValue("@PaymentID", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@PaymentID", PaymentID);
            }

            try
            {
                connection.Open();

                RowAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return (RowAffected > 0);
        }

        public static bool DeletePeriod(int PeriodID)
        {
            int RowAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"delete SubscriptionPeriods where PeriodID = @PeriodID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PeriodID", PeriodID);

            try
            {
                connection.Open();

                RowAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return (RowAffected > 0);
        }

        public static bool DoesPeriodExist(int PeriodID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select found = 1 from SubscriptionPeriods where PeriodID = @PeriodID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PeriodID", PeriodID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                IsFound = (result != null);
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static DataTable GetAllSubscriptionPeriods()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from SubscriptionPeriodsDetails_view order by PeriodID desc";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static short CountSubscriptionPeriods()
        {
            short Count = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select count(*) from SubscriptionPeriods";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && short.TryParse(result.ToString(), out short Value))
                {
                    Count = Value;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return Count;
        }

        public static int GetLastActivePeriodForMember(int MemberID)
        {
            int LastActivePeriodID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select top 1 PeriodID from SubscriptionPeriods
                             where MemberID = @MemberID
                             and CONVERT(DATE, SubscriptionPeriods.EndDate) >= CONVERT(DATE, GETDATE())
                             order by StartDate desc";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@MemberID", MemberID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int Value))
                {
                    LastActivePeriodID = Value;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return LastActivePeriodID;
        }

        public static DataTable GetAllPeriodsForMember(int MemberID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT        dbo.SubscriptionPeriods.PeriodID,
                             (SELECT        Name
                               FROM            dbo.People
                               WHERE        (PersonID = dbo.Members.PersonID)) AS MemberName, dbo.SubscriptionPeriods.Fees, dbo.SubscriptionPeriods.IsPaid, dbo.SubscriptionPeriods.StartDate, dbo.SubscriptionPeriods.EndDate, DATEDIFF(day, 
                         dbo.SubscriptionPeriods.StartDate, dbo.SubscriptionPeriods.EndDate) AS SubscriptionDays, dbo.SubscriptionPeriods.PaymentID,dbo.SubscriptionPeriods.IsActive 
FROM            dbo.SubscriptionPeriods INNER JOIN
                         dbo.Members ON dbo.Members.MemberID = dbo.SubscriptionPeriods.MemberID
						 where SubscriptionPeriods.MemberID = @MemberID
						 order by SubscriptionPeriods.StartDate desc";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@MemberID", MemberID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static bool UpdateActivityAndIsPaid(int PeriodID, bool IsPaid, bool IsActive)
        {
            int RowAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"update SubscriptionPeriods
                             set   IsPaid = @IsPaid,
                                   IsActive = @IsActive
                             where PeriodID = @PeriodID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PeriodID", PeriodID);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@IsPaid", IsPaid);

            try
            {
                connection.Open();

                RowAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return (RowAffected > 0);
        }

    }
}
