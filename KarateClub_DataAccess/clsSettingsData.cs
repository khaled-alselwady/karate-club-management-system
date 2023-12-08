using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    string query = @"select DefaultSubscriptionPeriod from settings";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();

                        if (result != null && byte.TryParse(result.ToString(), out byte Value))
                        {
                            DefaultPeriod = Value;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsLogError.LogError("General Exception", ex);
            }
           
            return DefaultPeriod;
        }
    }
}
