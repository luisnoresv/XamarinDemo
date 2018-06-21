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
        private ObservableCollection<User> UsersList;

		public UsersListPage ()
		{
            BindingContext = new UserViewModel(new UserRepository());

			InitializeComponent();
		}
        
        protected override async void OnAppearing()
        {
            var users = await (BindingContext as UserViewModel).LoadUsersList();

            UsersList = new ObservableCollection<User>(users);
            usersListView.ItemsSource = UsersList;

            base.OnAppearing();
        }
        
    }
}