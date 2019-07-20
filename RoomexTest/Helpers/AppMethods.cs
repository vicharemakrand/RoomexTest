using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomexTest.Helpers
{
    public class AppMethods
    {
        public static double ConvertMeterToKm(double meter)
        {
            return (meter >0) ? meter / AppConstants.MeterToKmConvertor : 0;
        }

        public static double ConvertMeterToMile(double meter)
        {
            return (meter > 0) ? meter / AppConstants.MeterToMileConvertor : 0;
        }

        public static double ConvertKMToMile(double kmeter)
        {
            return (kmeter > 0) ? (kmeter * AppConstants.MeterToKmConvertor) / AppConstants.MeterToMileConvertor : 0;
        }
    }
}
