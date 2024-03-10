using DataAccessToolkit;
using System;
using System.Data;
using System.Data.SqlClient;

namespace KarateClub_DataAccess
{
    public class clsBeltTestData
    {
        public static bool GetTestInfoByID(int? TestID, ref int? MemberID,
            ref int? RankID, ref bool Result, ref DateTime Date,
            ref int? TestedByInstructorID, ref int? PaymentID)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetTestInfoByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@TestID", (object)TestID ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // The record was found
                                IsFound = true;

                                MemberID = (reader["MemberID"] != DBNull.Value) ? (int?)reader["MemberID"] : null;
                                RankID = (reader["RankID"] != DBNull.Value) ? (int?)reader["RankID"] : null;
                                Result = (bool)reader["Result"];
                                Date = (DateTime)reader["Date"];
                                TestedByInstructorID = (reader["TestedByInstructorID"] != DBNull.Value) ? (int?)reader["TestedByInstructorID"] : null;
                                PaymentID = (reader["PaymentID"] != DBNull.Value) ? (int?)reader["PaymentID"] : null;
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

        public static int? AddNewTest(int? MemberID, int? RankID, bool Result,
            DateTime Date, int? TestedByInstructorID, int? PaymentID)
        {
            // This function will return the new person id if succeeded and null if not
            int? TestID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_AddNewTest", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@MemberID", (object)MemberID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@RankID", (object)RankID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Result", Result);
                        command.Parameters.AddWithValue("@Date", Date);
                        command.Parameters.AddWithValue("@TestedByInstructorID", (object)TestedByInstructorID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@PaymentID", (object)PaymentID ?? DBNull.Value);

                        SqlParameter outputIdParam = new SqlParameter("@NewTestID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        command.ExecuteNonQuery();

                        TestID = (int?)outputIdParam.Value;
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

            return TestID;
        }

        public static bool UpdateTest(int? TestID, int? MemberID, int? RankID,
            bool Result, DateTime Date, int? TestedByInstructorID, int? PaymentID)
        {
            int RowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_UpdateTest", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@TestID", (object)TestID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@MemberID", (object)MemberID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@RankID", (object)RankID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Result", Result);
                        command.Parameters.AddWithValue("@Date", Date);
                        command.Parameters.AddWithValue("@TestedByInstructorID", (object)TestedByInstructorID ?? DBNull.Value);
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

        public static bool DeleteTest(int? TestID)
        {
            int RowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_DeleteTest", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@TestID", (object)TestID ?? DBNull.Value);

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

        public static bool DoesTestExist(int? TestID)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_DoesTestExist", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@TestID", (object)TestID ?? DBNull.Value);

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

        public static DataTable GetAllBeltTests()
        {
            return clsDataAccessHelper.GetAll("SP_GetAllBeltTests", "KarateClub");
        }

        public static short CountBeltTests()
        {
            return (short)clsDataAccessHelper.Count("SP_GetTestsCount", "KarateClub");
        }

        public static DataTable GetAllBeltTestsForMember(int? MemberID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetAllBeltTestsForMember", connection))
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

        public static int? GetTestIDByPaymentID(int? PaymentID)
        {
            int? TestID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetTestIDByPaymentID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PaymentID", (object)PaymentID ?? DBNull.Value);

                        SqlParameter outputIdParam = new SqlParameter("@TestID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        command.ExecuteNonQuery();

                        TestID = (int?)outputIdParam.Value;
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

            return TestID;
        }
    }
}
