using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UserDemo.Xamarin.Models;

namespace UserDemo.Xamarin.ViewModels
{

    public class UserViewModel
    {
        private const string Url = "https://reqres.in/api/users?page=2";
        private HttpClient _client = new HttpClient();
        public List<Data> UsersList { get; private set; } = new List<Data>();

        public async Task<List<Data>> LoadUsersList()
        {
            var content = await _client.GetStringAsync(Url);

            var users = JsonConvert.DeserializeObject<RootObject>(content);
            UsersList = new List<Data>(users.data);

            return UsersList;
        }

        // TODO: Move the Database logic to this Class
    }
}
