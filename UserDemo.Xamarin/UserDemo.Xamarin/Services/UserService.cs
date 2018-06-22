using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UserDemo.Xamarin.Models;

namespace UserDemo.Xamarin.Services
{
    public class UserService
    {
        private const string Url = "https://reqres.in/api/users?page=4";

        private HttpClient _client = new HttpClient();

        public async Task<List<Data>> GetUsersFromService()
        {
            try
            {
                var content = await _client.GetStringAsync(Url);

                var users = JsonConvert.DeserializeObject<RootObject>(content);

                var usersList = new List<Data>(users.data);
                return usersList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
