using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarateClub_DataAccess
{
    public class clsSubscriptionPeriodData
    {
        public static bool GetPeriodInfoByID(int PeriodID, ref DateTime StartDate, ref DateTime EndDate, 
            ref decimal Fees, ref bool Paid, ref int MemberID, ref int PaymentID)
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
                    Paid = (bool)reader["Paid"];
                    MemberID = (int)reader["MemberID"];
                    PaymentID = (int)reader["PaymentID"];
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


        public static int AddNewPeriod(DateTime StartDate, DateTime EndDate, decimal Fees, bool Paid,
            int MemberID, int PaymentID)
        {
            // This function will return the new person id if succeeded and -1 if not
            int PeriodID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"insert into SubscriptionPeriods (StartDate, EndDate, Fees, Paid, MemberID, PaymentID)
values (@StartDate, @EndDate, @Fees, @Paid, @MemberID, @PaymentID)
select scope_identity()";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@StartDate", StartDate);
            command.Parameters.AddWithValue("@EndDate", EndDate);
            command.Parameters.AddWithValue("@Fees", Fees);
            command.Parameters.AddWithValue("@Paid", Paid);
            command.Parameters.AddWithValue("@MemberID", MemberID);
            command.Parameters.AddWithValue("@PaymentID", PaymentID);

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
            decimal Fees, bool Paid, int MemberID, int PaymentID)
        {
            int RowAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update SubscriptionPeriods
set StartDate = @StartDate,
EndDate = @EndDate,
Fees = @Fees,
Paid = @Paid,
MemberID = @MemberID,
PaymentID = @PaymentID
where PeriodID = @PeriodID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PeriodID", PeriodID);
            command.Parameters.AddWithValue("@StartDate", StartDate);
            command.Parameters.AddWithValue("@EndDate", EndDate);
            command.Parameters.AddWithValue("@Fees", Fees);
            command.Parameters.AddWithValue("@Paid", Paid);
            command.Parameters.AddWithValue("@MemberID", MemberID);
            command.Parameters.AddWithValue("@PaymentID", PaymentID);

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

            string query = @"select * from SubscriptionPeriods";

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

    }
}
