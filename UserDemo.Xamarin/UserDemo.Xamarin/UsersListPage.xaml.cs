using SQLite;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UserDemo.Xamarin.Models;
using UserDemo.Xamarin.Persistence;
using UserDemo.Xamarin.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UserDemo.Xamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UsersListPage : ContentPage
	{
        private SQLiteAsyncConnection _connection;
        private ObservableCollection<User> _users;

		public UsersListPage ()
		{
            BindingContext = new UserViewModel();
			InitializeComponent();

            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            
		}



        protected override async void OnAppearing()
        {
            await _connection.CreateTableAsync<User>();
            //SaveUsersOnStorage();

            var users = await _connection.Table<User>().ToListAsync();
            _users = new ObservableCollection<User>(users);

            usersListView.ItemsSource = _users;
            base.OnAppearing();
        }

        private async void SaveUsersOnStorage()
        {
            List<User> usersForStore = new List<User>();
            var usersList = await (BindingContext as UserViewModel).LoadUsersList();
            foreach (var user in usersList)
            {
                var userForStore = new User();
                userForStore.FirstName = user.first_name;
                userForStore.LastName = user.last_name;
                userForStore.AvatarUrl = user.avatar;
                usersForStore.Add(userForStore);
            }
            await _connection.InsertAllAsync(usersForStore);
        }
    }
}