using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserDemo.Xamarin.Models;
using UserDemo.Xamarin.Persistence;
using Xamarin.Forms;

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

        public async Task<UserViewModel> Initialize()
        {
            try
            {
                UsersList = await _repository.GetUsersList();

                return this;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        
    }
}
