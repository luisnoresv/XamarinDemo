using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserDemo.Xamarin.Models;
using UserDemo.Xamarin.Services;
using Xamarin.Forms;

namespace UserDemo.Xamarin.Persistence
{
    public class UserRepository : IUserRepository
    {
        private SQLiteAsyncConnection Connection { get; set; }

        public UserRepository()
        {
            Connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        private async Task<CreateTablesResult> CreateUserTable()
        {
            return await Connection.CreateTableAsync<User>();
        }

        private async Task<List<User>> GetUsersFromStorage()
        {
            return await Connection.Table<User>().ToListAsync();
        }

        private async void SaveUsersOnStorage(List<User> userList)
        {
            await Connection.InsertAllAsync(userList);
        }

        public async Task<List<User>> GetUsersList()
        {
            await CreateUserTable();
            var userService = new UserService();
            var usersFromService = await userService.GetUsersFromService();

            var usersList = MapDataToUserList(usersFromService);

            SaveUsersOnStorage(usersList);

            var usersFromStorage = await GetUsersFromStorage();

            return usersFromStorage;
            
        }

        private List<User> MapDataToUserList(List<Data> usersFromService)
        {
            var usersList = new List<User>();
            foreach (var user in usersFromService)
            {
                var userForStore = new User();
                userForStore.UserCode = user.id;
                userForStore.FirstName = user.first_name;
                userForStore.LastName = user.last_name;
                userForStore.AvatarUrl = user.avatar;
                usersList.Add(userForStore);
            }
            return usersList;
        }
    }
}
