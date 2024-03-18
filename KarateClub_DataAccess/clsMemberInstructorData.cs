using DataAccessToolkit;
using System;
using System.Data;
using System.Data.SqlClient;

namespace KarateClub_DataAccess
{
    public class clsMemberInstructorData
    {
        public static bool GetMemberInstructorInfoByID(int? MemberInstructorID,
            ref int? MemberID, ref int? InstructorID, ref DateTime AssignDate)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetMemberInstructorInfoByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@MemberInstructorID", (object)MemberInstructorID ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // The record was found
                                IsFound = true;

                                MemberID = (reader["MemberID"] != DBNull.Value) ? (int?)reader["MemberID"] : null;
                                InstructorID = (reader["InstructorID"] != DBNull.Value) ? (int?)reader["InstructorID"] : null;
                                AssignDate = (DateTime)reader["AssignDate"];
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

        public static int? AddNewMemberInstructor(int? MemberID, int? InstructorID,
            DateTime AssignDate)
        {
            // This function will return the new person id if succeeded and null if not
            int? MemberInstructorID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_AddNewMemberInstructor", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@MemberID", (object)MemberID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@InstructorID", (object)InstructorID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@AssignDate", AssignDate);

                        SqlParameter outputIdParam = new SqlParameter("@NewMemberInstructorID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        command.ExecuteNonQuery();

                        MemberInstructorID = (int?)outputIdParam.Value;
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

            return MemberInstructorID;
        }

        public static bool UpdateMemberInstructor(int? MemberInstructorID, int? MemberID,
            int? InstructorID, DateTime AssignDate)
        {
            int RowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_UpdateMemberInstructor", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@MemberInstructorID", (object)MemberInstructorID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@MemberID", (object)MemberID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@InstructorID", (object)InstructorID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@AssignDate", AssignDate);

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

        public static bool DeleteMemberInstructor(int? MemberInstructorID)
        {
            int RowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_DeleteMemberInstructor", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@MemberInstructorID", (object)MemberInstructorID ?? DBNull.Value);

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

        public static bool DoesMemberInstructorExist(int? MemberInstructorID)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_DoesMemberInstructorExist", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@MemberInstructorID", (object)MemberInstructorID ?? DBNull.Value);

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

        public static DataTable GetAllMemberInstructors()
        {
            return clsDataAccessHelper.GetAll("SP_GetAllMemberInstructors");
        }

        public static bool IsInstructorTrainingMember(int? InstructorID, int? MemberID)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_IsInstructorTrainingMember", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@InstructorID", (object)InstructorID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@MemberID", (object)MemberID ?? DBNull.Value);

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

        public static DataTable GetTrainedMembersByInstructor(int? InstructorID)
        {
            DataTable dtTrainedMembers = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetTrainedMembersByInstructor", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@InstructorID", (object)InstructorID ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dtTrainedMembers.Load(reader);
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

            return dtTrainedMembers;
        }
    }
}
