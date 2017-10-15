using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UlasimApp.Model;

namespace UlasimApp.Services
{
    public class LocationService
    {
        private const string SERVICE_URL = "http://localhost:49560";


        private LocationService() { }

        private static LocationService _instance;

        public static LocationService Instance
        {
            get
            {
                return _instance ?? new LocationService();
            }
        }

        public IList<Stop> GetNearbyStops(int distance)
        {
            return null;
        }

       


    }
}
