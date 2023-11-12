using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarateClub_DataAccess
{
    public class clsMemberInstructorData
    {
        public static bool GetMemberInstructorInfoByID(int MemberInstructorID,
            ref int MemberID, ref int InstructorID, ref DateTime AssignDate)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from MemberInstructors where MemberInstructorID = @MemberInstructorID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@MemberInstructorID", MemberInstructorID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    IsFound = true;

                    MemberID = (int)reader["MemberID"];
                    InstructorID = (int)reader["InstructorID"];
                    AssignDate = (DateTime)reader["AssignDate"];
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

        public static int AddNewMemberInstructor(int MemberID, int InstructorID, DateTime AssignDate)
        {
            // This function will return the new person id if succeeded and -1 if not
            int MemberInstructorID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"insert into MemberInstructors (MemberID, InstructorID, AssignDate)
values (@MemberID, @InstructorID, @AssignDate)
select scope_identity()";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@MemberID", MemberID);
            command.Parameters.AddWithValue("@InstructorID", InstructorID);
            command.Parameters.AddWithValue("@AssignDate", AssignDate);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertID))
                {
                    MemberInstructorID = InsertID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return MemberInstructorID;
        }

        public static bool UpdateMemberInstructor(int MemberInstructorID, int MemberID,
            int InstructorID, DateTime AssignDate)
        {
            int RowAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update MemberInstructors
set MemberID = @MemberID,
InstructorID = @InstructorID,
AssignDate = @AssignDate
where MemberInstructorID = @MemberInstructorID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@MemberInstructorID", MemberInstructorID);
            command.Parameters.AddWithValue("@MemberID", MemberID);
            command.Parameters.AddWithValue("@InstructorID", InstructorID);
            command.Parameters.AddWithValue("@AssignDate", AssignDate);

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

        public static bool DeleteMemberInstructor(int MemberInstructorID)
        {
            int RowAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"delete MemberInstructors where MemberInstructorID = @MemberInstructorID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@MemberInstructorID", MemberInstructorID);

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

        public static bool DoesMemberInstructorExist(int MemberInstructorID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select found = 1 from MemberInstructors where MemberInstructorID = @MemberInstructorID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@MemberInstructorID", MemberInstructorID);

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

        public static DataTable GetAllMemberInstructors()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from MembersInstructorsDetails_view order by MemberInstructorID desc";

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

        public static bool IsInstructorTrainingMember(int InstructorID, int MemberID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select top 1 Found = 1 from MemberInstructors where InstructorID = @InstructorID and MemberID = @MemberID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@InstructorID", InstructorID);
            command.Parameters.AddWithValue("@MemberID", MemberID);

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

        public static DataTable GetTrainedMembersByInstructor(int InstructorID)
        {
            DataTable dtTrainedMembers = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select MembersDetails_view.*
                             from MemberInstructors
                             inner join MembersDetails_view
                             on MembersDetails_view.MemberID = MemberInstructors.MemberID
                             where MemberInstructors.InstructorID = @InstructorID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@InstructorID", InstructorID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dtTrainedMembers.Load(reader);
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

            return dtTrainedMembers;
        }
    }
}
