using KarateClub_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarateClub_Business
{
    public class clsSettings
    {
        public static byte DefaultSubscriptionPeriod()
        {
            return clsSettingsData.GetDefaultSubscriptionPeriod();
        }
    }
}
