using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarateClub_DataAccess
{
    public class clsInstructorData
    {
        public static bool GetInstructorInfoByID(int InstructorID, ref int PersonID,
            ref string Qualification)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from Instructors where InstructorID = @InstructorID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@InstructorID", InstructorID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    IsFound = true;

                    PersonID = (int)reader["PersonID"];
                    Qualification = (reader["Qualification"] != DBNull.Value) ? (string)reader["Qualification"] : string.Empty;
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


        public static int AddNewInstructor(int PersonID, string Qualification)
        {
            // This function will return the new person id if succeeded and -1 if not
            int InstructorID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"insert into Instructors (PersonID, Qualification)
values (@PersonID, @Qualification)
select scope_identity()";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            if (string.IsNullOrWhiteSpace(Qualification))
            {
                command.Parameters.AddWithValue("@Qualification", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Qualification", Qualification);
            }

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertID))
                {
                    InstructorID = InsertID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return InstructorID;
        }


        public static bool UpdateInstructor(int InstructorID, int PersonID, string Qualification)
        {
            int RowAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update Instructors
set PersonID = @PersonID,
Qualification = @Qualification
where InstructorID = @InstructorID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@InstructorID", InstructorID);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            if (string.IsNullOrWhiteSpace(Qualification))
            {
                command.Parameters.AddWithValue("@Qualification", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Qualification", Qualification);
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


        public static bool DeleteInstructor(int InstructorID)
        {
            int RowAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"delete Instructors where InstructorID = @InstructorID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@InstructorID", InstructorID);

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


        public static bool DoesInstructorExist(int InstructorID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select found = 1 from Instructors where InstructorID = @InstructorID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@InstructorID", InstructorID);

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


        public static DataTable GetAllInstructors()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from InstructorsDetails_view";

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


        public static short CountInstructors()
        {
            short Count = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select count(*) from Instructors";

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
            catch(Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return Count;
        }


        public static int GetPersonIDByInstructorID(int InstructorID)
        {
            int PersonID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select PersonID from Instructors where InstructorID = @InstructorID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@InstructorID", InstructorID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int Value))
                {
                    PersonID = Value;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return PersonID;
        }

    }
}
