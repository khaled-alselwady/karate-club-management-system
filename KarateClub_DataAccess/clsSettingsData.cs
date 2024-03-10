using System;
using System.Data;
using System.Data.SqlClient;
using DataAccessToolkit;

namespace KarateClub_DataAccess
{
    public class clsSettingsData
    {
        public static byte GetDefaultSubscriptionPeriod()
        {
            byte DefaultPeriod = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetDefaultSubscriptionPeriod", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        object result = command.ExecuteScalar();

                        if (result != null && byte.TryParse(result.ToString(), out byte Value))
                        {
                            DefaultPeriod = Value;
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

            return DefaultPeriod;
        }
    }
}
