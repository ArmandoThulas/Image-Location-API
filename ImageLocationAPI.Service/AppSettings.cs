using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageLocationAPI.Service
{
    public static class AppSettings
    {
        public static string apiBaseUrl => "https://api.foursquare.com/";
        public static string clientId => "TO2QJKQEYBNPCLFL14OJC4GXT3MLWXYAFJMQVV1EZWGNQNVJ"; //Limited to 50 premium calls /day
        public static string clientSecret => "0DAU0T1R12R2LAYUKWZ3MP43HV0NBHNJMXWNYS1SKJWH2H2G";
        public static string apiVersion => "20180323";
        public const int responseLimit = 10;
        public static string connectionString => "Server=localhost;Database=ImageLocation;Trusted_Connection=True;MultipleActiveResultSets=true";
        public static int maximumRequestLimit => 30;
    }
}
