using DataAccessToolkit;
using System;
using System.Data;
using System.Data.SqlClient;

namespace KarateClub_DataAccess
{
    public class clsSubscriptionPeriodData
    {
        public static bool GetPeriodInfoByID(int? PeriodID, ref DateTime StartDate,
            ref DateTime EndDate, ref decimal Fees, ref bool IsPaid, ref int? MemberID,
            ref int? PaymentID, ref byte IssueReason, ref bool IsActive)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetPeriodInfoByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PeriodID", (object)PeriodID ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // The record was found
                                IsFound = true;

                                StartDate = (DateTime)reader["StartDate"];
                                EndDate = (DateTime)reader["EndDate"];
                                Fees = (decimal)reader["Fees"];
                                IsPaid = (bool)reader["IsPaid"];
                                MemberID = (reader["MemberID"] != DBNull.Value) ? (int?)reader["MemberID"] : null;
                                PaymentID = (reader["PaymentID"] != DBNull.Value) ? (int?)reader["PaymentID"] : null;
                                IssueReason = (byte)reader["IssueReason"];
                                IsActive = (bool)reader["IsActive"];
                            }
                            else
                            {
                                // The record was not found
                                IsFound = false;
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                IsFound = false;

                clsErrorLogger loggerToEventViewer = new clsErrorLogger(clsLogHandler.LogToEventViewer);
                loggerToEventViewer.LogError("Database Exception", ex);
            }
            catch (Exception ex)
            {
                IsFound = false;

                clsErrorLogger loggerToEventViewer = new clsErrorLogger(clsLogHandler.LogToEventViewer);
                loggerToEventViewer.LogError("General Exception", ex);
            }

            return IsFound;
        }

        public static int? AddNewPeriod(DateTime StartDate, DateTime EndDate,
            decimal Fees, bool IsPaid, int? MemberID, int? PaymentID,
            byte IssueReason, bool IsActive)
        {
            // This function will return the new person id if succeeded and null if not
            int? PeriodID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_AddNewPeriod", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@StartDate", StartDate);
                        command.Parameters.AddWithValue("@EndDate", EndDate);
                        command.Parameters.AddWithValue("@Fees", Fees);
                        command.Parameters.AddWithValue("@IsPaid", IsPaid);
                        command.Parameters.AddWithValue("@MemberID", (object)MemberID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@PaymentID", (object)PaymentID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@IssueReason", IssueReason);
                        command.Parameters.AddWithValue("@IsActive", IsActive);

                        SqlParameter outputIdParam = new SqlParameter("@NewPeriodID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        command.ExecuteNonQuery();

                        PeriodID = (int?)outputIdParam.Value;
                    }
                }
            }
            catch (SqlException ex)
            {
                clsErrorLogger loggerToEventViewer = new clsErrorLogger(clsLogHandler.LogToEventViewer);
                loggerToEventViewer.LogError("Database Exception", ex);
            }
            catch (Exception ex)
            {
                clsErrorLogger loggerToEventViewer = new clsErrorLogger(clsLogHandler.LogToEventViewer);
                loggerToEventViewer.LogError("General Exception", ex);
            }

            return PeriodID;
        }

        public static bool UpdatePeriod(int? PeriodID, DateTime StartDate,
            DateTime EndDate, decimal Fees, bool IsPaid, int? MemberID,
            int? PaymentID, byte IssueReason, bool IsActive)
        {
            int RowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_UpdatePeriod", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PeriodID", (object)PeriodID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@StartDate", StartDate);
                        command.Parameters.AddWithValue("@EndDate", EndDate);
                        command.Parameters.AddWithValue("@Fees", Fees);
                        command.Parameters.AddWithValue("@IsPaid", IsPaid);
                        command.Parameters.AddWithValue("@MemberID", (object)MemberID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@PaymentID", (object)PaymentID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@IssueReason", IssueReason);
                        command.Parameters.AddWithValue("@IsActive", IsActive);

                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                clsErrorLogger loggerToEventViewer = new clsErrorLogger(clsLogHandler.LogToEventViewer);
                loggerToEventViewer.LogError("Database Exception", ex);
            }
            catch (Exception ex)
            {
                clsErrorLogger loggerToEventViewer = new clsErrorLogger(clsLogHandler.LogToEventViewer);
                loggerToEventViewer.LogError("General Exception", ex);
            }

            return (RowAffected > 0);
        }

        public static bool DeletePeriod(int? PeriodID)
        {
            int RowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_DeletePeriod", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PeriodID", (object)PeriodID ?? DBNull.Value);

                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                clsErrorLogger loggerToEventViewer = new clsErrorLogger(clsLogHandler.LogToEventViewer);
                loggerToEventViewer.LogError("Database Exception", ex);
            }
            catch (Exception ex)
            {
                clsErrorLogger loggerToEventViewer = new clsErrorLogger(clsLogHandler.LogToEventViewer);
                loggerToEventViewer.LogError("General Exception", ex);
            }

            return (RowAffected > 0);
        }

        public static bool DoesPeriodExist(int? PeriodID)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_DoesPeriodExist", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PeriodID", (object)PeriodID ?? DBNull.Value);

                        // @ReturnVal could be any name, and we don't need to add it to the SP, just use it here in the code.
                        SqlParameter returnParameter = new SqlParameter("@ReturnVal", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };
                        command.Parameters.Add(returnParameter);

                        command.ExecuteNonQuery();

                        IsFound = (int)returnParameter.Value == 1;
                    }
                }
            }
            catch (SqlException ex)
            {
                IsFound = false;

                clsErrorLogger loggerToEventViewer = new clsErrorLogger(clsLogHandler.LogToEventViewer);
                loggerToEventViewer.LogError("Database Exception", ex);
            }
            catch (Exception ex)
            {
                IsFound = false;

                clsErrorLogger loggerToEventViewer = new clsErrorLogger(clsLogHandler.LogToEventViewer);
                loggerToEventViewer.LogError("General Exception", ex);
            }

            return IsFound;
        }

        public static DataTable GetAllSubscriptionPeriods()
        {
            return clsDataAccessHelper.GetAll("SP_GetAllSubscriptionPeriods");
        }

        public static short CountSubscriptionPeriods()
        {
            return (short)clsDataAccessHelper.Count("SP_GetSubscriptionPeriodsCount");
        }

        public static int? GetLastActivePeriodIDForMember(int? MemberID)
        {
            int? LastActivePeriodID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetLastActivePeriodIDForMember", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@MemberID", (object)MemberID ?? DBNull.Value);

                        SqlParameter outputIdParam = new SqlParameter("@LastActivePeriodID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        command.ExecuteNonQuery();

                        LastActivePeriodID = (int?)outputIdParam.Value;
                    }
                }
            }
            catch (SqlException ex)
            {
                clsErrorLogger loggerToEventViewer = new clsErrorLogger(clsLogHandler.LogToEventViewer);
                loggerToEventViewer.LogError("Database Exception", ex);
            }
            catch (Exception ex)
            {
                clsErrorLogger loggerToEventViewer = new clsErrorLogger(clsLogHandler.LogToEventViewer);
                loggerToEventViewer.LogError("General Exception", ex);
            }

            return LastActivePeriodID;
        }

        public static DataTable GetAllPeriodsForMember(int? MemberID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetAllPeriodsForMember", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@MemberID", (object)MemberID ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                clsErrorLogger loggerToEventViewer = new clsErrorLogger(clsLogHandler.LogToEventViewer);
                loggerToEventViewer.LogError("Database Exception", ex);
            }
            catch (Exception ex)
            {
                clsErrorLogger loggerToEventViewer = new clsErrorLogger(clsLogHandler.LogToEventViewer);
                loggerToEventViewer.LogError("General Exception", ex);
            }

            return dt;
        }

        public static bool UpdateActivityAndIsPaid(int? PeriodID, bool IsPaid, bool IsActive)
        {
            int RowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_UpdateActivityAndIsPaid", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PeriodID", (object)PeriodID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@IsPaid", IsPaid);
                        command.Parameters.AddWithValue("@IsActive", IsActive);

                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                clsErrorLogger loggerToEventViewer = new clsErrorLogger(clsLogHandler.LogToEventViewer);
                loggerToEventViewer.LogError("Database Exception", ex);
            }
            catch (Exception ex)
            {
                clsErrorLogger loggerToEventViewer = new clsErrorLogger(clsLogHandler.LogToEventViewer);
                loggerToEventViewer.LogError("General Exception", ex);
            }

            return (RowAffected > 0);
        }

        public static int? GetPeriodIDByPaymentID(int? PaymentID)
        {
            int? PeriodID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetPeriodIDByPaymentID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PaymentID", (object)PaymentID ?? DBNull.Value);

                        SqlParameter outputIdParam = new SqlParameter("@PeriodID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        command.ExecuteNonQuery();

                        PeriodID = (int?)outputIdParam.Value;
                    }
                }
            }
            catch (SqlException ex)
            {
                clsErrorLogger loggerToEventViewer = new clsErrorLogger(clsLogHandler.LogToEventViewer);
                loggerToEventViewer.LogError("Database Exception", ex);
            }
            catch (Exception ex)
            {
                clsErrorLogger loggerToEventViewer = new clsErrorLogger(clsLogHandler.LogToEventViewer);
                loggerToEventViewer.LogError("General Exception", ex);
            }

            return PeriodID;
        }
    }
}
