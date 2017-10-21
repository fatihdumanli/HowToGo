using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UlasimApp.Model;

namespace UlasimApp.Services
{
    public class LocationService
    {
        private const string SERVICE_URL = "http://localhost:49560";


        private LocationService() { client.BaseAddress = new Uri(SERVICE_URL); }

        private static LocationService _instance;
        private HttpClient client = new HttpClient();

        public static LocationService Instance
        {
            get
            {
                return _instance ?? new LocationService();
            }
        }

        public async Task<IList<Stop>> GetNearbyStops(double latitude, double longitude, double distance)
        {
            using(client)
            {
                var res = await client.GetStringAsync(String.Format("/Stops/GetNearbyStops?lat={0}&longitude={1}&distance={2}", latitude, longitude, distance));
                if(res != "[]")
                {
                    return JsonConvert.DeserializeObject<List<Stop>>(res);
                }
            }

            return null;
            
        }


        public async Task<Line> GetLineDetails(int lineId)
        {
            using (client)
            {
                var res = await client.GetStringAsync(String.Format("/Lines/Details/{0}", lineId));
                if (res != "[]")
                {
                    return JsonConvert.DeserializeObject<Line>(res);
                }
            }

            return null;

        }


        public async Task<List<Stop>> GetLineStops(int lineId)
        {
            using (client)
            {
                var res = await client.GetStringAsync(String.Format("/Lines/GetLineStops/{0}", lineId));
                if (res != "[]")
                {
                    return JsonConvert.DeserializeObject<List<Stop>>(res);
                }
            }

            return null;

        }

    }
}
