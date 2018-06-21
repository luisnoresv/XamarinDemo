using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserDemo.Xamarin.Models;

namespace UserDemo.Xamarin.Persistence
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsersList();
    }
}
