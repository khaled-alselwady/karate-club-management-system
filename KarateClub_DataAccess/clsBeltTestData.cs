using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarateClub_DataAccess
{
    public class clsBeltTestData
    {
        public static bool GetTestInfoByID(int TestID, ref int MemberID, ref int RankID,
            ref bool Result, ref DateTime Date, ref int TestedByInstructorID, ref int PaymentID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from BeltTests where TestID = @TestID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestID", TestID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    IsFound = true;

                    MemberID = (int)reader["MemberID"];
                    RankID = (int)reader["RankID"];
                    Result = (bool)reader["Result"];
                    Date = (DateTime)reader["Date"];
                    TestedByInstructorID = (int)reader["TestedByInstructorID"];
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


        public static int AddNewTest(int MemberID, int RankID, bool Result, DateTime Date,
            int TestedByInstructorID, int PaymentID)
        {
            // This function will return the new person id if succeeded and -1 if not
            int TestID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO BeltTests (MemberID, RankID, Result, Date, TestedByInstructorID, PaymentID)
                             VALUES (@MemberID, @RankID, @Result, @Date, @TestedByInstructorID, @PaymentID);
                             
                             IF (@Result = 1)
                             BEGIN
                                 UPDATE Members
                                 SET LastBeltRankID = @RankID
                                 WHERE MemberID = @MemberID;
                             END
                             
                             SELECT SCOPE_IDENTITY();";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@MemberID", MemberID);
            command.Parameters.AddWithValue("@RankID", RankID);
            command.Parameters.AddWithValue("@Result", Result);
            command.Parameters.AddWithValue("@Date", Date);
            command.Parameters.AddWithValue("@TestedByInstructorID", TestedByInstructorID);
            command.Parameters.AddWithValue("@PaymentID", PaymentID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertID))
                {
                    TestID = InsertID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return TestID;
        }


        public static bool UpdateTest(int TestID, int MemberID, int RankID, bool Result,
            DateTime Date, int TestedByInstructorID, int PaymentID)
        {
            int RowAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update BeltTests
set MemberID = @MemberID,
RankID = @RankID,
Result = @Result,
Date = @Date,
TestedByInstructorID = @TestedByInstructorID,
PaymentID = @PaymentID
where TestID = @TestID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestID", TestID);
            command.Parameters.AddWithValue("@MemberID", MemberID);
            command.Parameters.AddWithValue("@RankID", RankID);
            command.Parameters.AddWithValue("@Result", Result);
            command.Parameters.AddWithValue("@Date", Date);
            command.Parameters.AddWithValue("@TestedByInstructorID", TestedByInstructorID);
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


        public static bool DeleteTest(int TestID)
        {
            int RowAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"delete BeltTests where TestID = @TestID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestID", TestID);

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


        public static bool DoesTestExist(int TestID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select found = 1 from BeltTests where TestID = @TestID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestID", TestID);

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


        public static DataTable GetAllBeltTests()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from TestsDetails_view order by TestID desc";

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


        public static short CountBeltTests()
        {
            short Count = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select count(*) from BeltTests";

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


        public static DataTable GetAllBeltTestsForMember(int MemberID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT        dbo.BeltTests.TestID,Members.MemberID,
                             (SELECT        Name
                               FROM            dbo.People
                               WHERE        (dbo.Members.PersonID = PersonID)) AS MemberName, dbo.BeltRanks.RankName, dbo.BeltTests.Date,
                             (SELECT        Name
                               FROM            dbo.People
                               WHERE        (dbo.Instructors.PersonID = PersonID)) AS InstructorName, dbo.BeltTests.PaymentID, dbo.BeltTests.Result
FROM            dbo.BeltTests INNER JOIN
                         dbo.Members ON dbo.Members.MemberID = dbo.BeltTests.MemberID INNER JOIN
                         dbo.Instructors ON dbo.Instructors.InstructorID = dbo.BeltTests.TestedByInstructorID INNER JOIN
                         dbo.BeltRanks ON dbo.BeltRanks.RankID = dbo.BeltTests.RankID
						 where Members.MemberID = @MemberID
                         order by TestID desc";

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
    }
}
