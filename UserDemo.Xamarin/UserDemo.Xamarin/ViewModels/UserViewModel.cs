using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UserDemo.Xamarin.Models;
using UserDemo.Xamarin.Persistence;

namespace UserDemo.Xamarin.ViewModels
{

    public class UserViewModel
    {
        private readonly IUserRepository _repository;

        public List<User> UsersList { get; private set; } = new List<User>();

        public UserViewModel(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<User>> LoadUsersList()
        {
            return await _repository.GetUsersList();
        }
    }
}
