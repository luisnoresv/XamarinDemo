using SQLite;
using System;
using System.Collections.Generic;
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
            try
            {
                return await Connection.CreateTableAsync<User>();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private async Task<User> GetUser(int userCode)
        {
            try
            {
                return await Connection.Table<User>().Where(i => i.UserCode == userCode).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private async Task<List<User>> GetUsers()
        {
            try
            {
                return await Connection.Table<User>().ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private async void SaveUser(User user)
        {
            try
            {
                await Connection.InsertAsync(user);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private async void SaveUsers(List<User> userList)
        {
            try
            {
                await Connection.InsertAllAsync(userList);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<User>> GetUsersList()
        {
            try
            {
                // await Connection.DropTableAsync<User>();
                await CreateUserTable();

                var userListForStorage = await GetNewUsersListFromService();

                SaveUsers(userListForStorage);

                var usersFromStorage = await GetUsers();

                return usersFromStorage;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private async Task<List<User>> GetNewUsersListFromService()
        {
            try
            {
                var userService = new UserService();
                var usersFromService = await userService.GetUsersFromService();

                var usersList = MapDataToUserList(usersFromService);

                var userListForStorage = new List<User>();
                foreach (var user in usersList)
                {
                    var userFromStorage = await GetUser(user.UserCode);
                    if (userFromStorage == null)
                    {
                        userListForStorage.Add(user);
                    }
                }

                return userListForStorage;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private List<User> MapDataToUserList(List<Data> usersFromService)
        {
            var usersList = new List<User>();
            foreach (var user in usersFromService)
            {
                var userForStore = new User();
                userForStore.UserCode = user.Id;
                userForStore.FirstName = user.FirstName;
                userForStore.LastName = user.LastName;
                userForStore.AvatarUrl = user.AvatarUrl;
                usersList.Add(userForStore);
            }
            return usersList;
        }
    }
}
