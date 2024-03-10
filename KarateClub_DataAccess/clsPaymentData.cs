using System;
using System.Data;
using System.Data.SqlClient;
using DataAccessToolkit;

namespace KarateClub_DataAccess
{
    public class clsPaymentData
    {
        public static bool GetPaymentInfoByID(int? PaymentID, ref decimal Amount,
            ref DateTime Date, ref int? MemberID)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetPaymentInfoByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PaymentID", (object)PaymentID ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // The record was found
                                IsFound = true;

                                Amount = (decimal)reader["Amount"];
                                Date = (DateTime)reader["Date"];
                                MemberID = (reader["MemberID"] != DBNull.Value) ? (int?)reader["MemberID"] : null;
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

                clsErrorLogger.LogError("KarateClub", "Database Exception", ex);
            }
            catch (Exception ex)
            {
                IsFound = false;

                clsErrorLogger.LogError("KarateClub", "General Exception", ex);
            }

            return IsFound;
        }

        public static int? AddNewPayment(decimal Amount, int? MemberID)
        {
            // This function will return the new person id if succeeded and null if not
            int? PaymentID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_AddNewPayment", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Amount", Amount);
                        command.Parameters.AddWithValue("@MemberID", (object)MemberID ?? DBNull.Value);

                        SqlParameter outputIdParam = new SqlParameter("@NewPaymentID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        command.ExecuteNonQuery();

                        PaymentID = (int?)outputIdParam.Value;
                    }
                }
            }
            catch (SqlException ex)
            {
                clsErrorLogger.LogError("KarateClub", "Database Exception", ex);
            }
            catch (Exception ex)
            {
                clsErrorLogger.LogError("KarateClub", "General Exception", ex);
            }

            return PaymentID;
        }

        public static bool UpdatePayment(int? PaymentID, decimal Amount,
            DateTime Date, int? MemberID)
        {
            int RowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_UpdatePayment", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PaymentID", (object)PaymentID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Amount", Amount);
                        command.Parameters.AddWithValue("@Date", Date);
                        command.Parameters.AddWithValue("@MemberID", (object)MemberID ?? DBNull.Value);

                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                clsErrorLogger.LogError("KarateClub", "Database Exception", ex);
            }
            catch (Exception ex)
            {
                clsErrorLogger.LogError("KarateClub", "General Exception", ex);
            }

            return (RowAffected > 0);
        }

        public static bool DeletePayment(int? PaymentID)
        {
            int RowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_DeletePayment", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PaymentID", (object)PaymentID ?? DBNull.Value);

                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                clsErrorLogger.LogError("KarateClub", "Database Exception", ex);
            }
            catch (Exception ex)
            {
                clsErrorLogger.LogError("KarateClub", "General Exception", ex);
            }

            return (RowAffected > 0);
        }

        public static bool DoesPaymentExist(int? PaymentID)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_DoesPaymentExist", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PaymentID", (object)PaymentID ?? DBNull.Value);

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

                clsErrorLogger.LogError("KarateClub", "Database Exception", ex);
            }
            catch (Exception ex)
            {
                IsFound = false;

                clsErrorLogger.LogError("KarateClub", "General Exception", ex);
            }

            return IsFound;
        }

        public static DataTable GetAllPayments()
        {
            return clsDataAccessHelper.GetAll("SP_GetAllPayments", "KarateClub");
        }

        public static short CountPayments()
        {
            return (short)clsDataAccessHelper.Count("SP_GetPaymentsCount", "KarateClub");
        }

        public static DataTable GetAllPaymentsForMember(int? MemberID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetAllPaymentsForMember", connection))
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
                clsErrorLogger.LogError("KarateClub", "Database Exception", ex);
            }
            catch (Exception ex)
            {
                clsErrorLogger.LogError("KarateClub", "General Exception", ex);
            }

            return dt;
        }
    }
}
