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
        private const string url = "https://reqres.in/api/users?page=2";
        private HttpClient _Client = new HttpClient();
        public ObservableCollection<Data> UsersList { get; private set; } = new ObservableCollection<Data>();

        public async Task<ObservableCollection<Data>> LoadUsersList()
        {
            var content = await _Client.GetStringAsync(url);
            var users = JsonConvert.DeserializeObject<RootObject>(content);
            UsersList = new ObservableCollection<Data>(users.data);
            return UsersList;
        }
    }
}
