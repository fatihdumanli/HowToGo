using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UlasimApp.Model;

namespace UlasimApp.Services
{
    public class AccountService
    {
        private const string SERVICE_URL = "http://localhost:49560";
        private HttpClient client = new HttpClient();


        private AccountService() { client.BaseAddress = new Uri(SERVICE_URL); }

        private static AccountService _instance;

        public static AccountService Instance
        {
            get
            {
                return _instance ?? new AccountService();
            }
        }

        public bool IsLoggedIn { get; set; } = true;

        public static string Email { get; set; } = "fatih";

        public User User
        {
            get
            {
                return Task.Run(async () => await AccountService.Instance.GetUserDetails(Email)).Result;
            }
        }

        public async Task<bool> Login(string email, string password)
        {
            using(client)
            {
                JObject jo = new JObject();
                jo.Add("email", email);
                jo.Add("password", password);


                var stringContent = new StringContent(jo.ToString());
                stringContent.Headers.Remove("content-type");
                stringContent.Headers.Add("content-type", "application/json");
                var res = await client.PostAsync("/Users/Login", stringContent);
                var result = Convert.ToBoolean(await res.Content.ReadAsStringAsync());
                return result;
            }

        }

        public async Task<bool> Register(string email, string name, string username, string password)
        {
            using (client)
            {
                JObject jo = new JObject();
                jo.Add("email", email);
                jo.Add("name", name);
                jo.Add("username", username);
                jo.Add("password", password);

                var stringContent = new StringContent(jo.ToString());
                stringContent.Headers.Remove("content-type");
                stringContent.Headers.Add("content-type", "application/json");
                var res = await client.PostAsync("/Users/Register", stringContent);

            }

            return true;
        }


        public async Task<User> GetUserDetails(string email)
        {
            using (client)
            {
                var res = await client.GetStringAsync(String.Format("/Users/GetUserDetails?email={0}", email));
                return JsonConvert.DeserializeObject<User>(res);
            }
        }


        public async Task<bool> PostStopSub(int stopId)
        {
            using (client)
            {
                JObject jo = new JObject();
                jo.Add("userid", AccountService.Instance.User.Email);
                jo.Add("stopid", stopId);
          

                var stringContent = new StringContent(jo.ToString());
                stringContent.Headers.Remove("content-type");
                stringContent.Headers.Add("content-type", "application/json");
                var res = await client.PostAsync("/Stops/PostStopSubscription", stringContent);

            }

            return true;
        }
    }
}
