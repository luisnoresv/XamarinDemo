using Acr.UserDialogs;
using System.Threading.Tasks;
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

        public UsersListPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            // TODO: Check for a better way to use the loading dialog
            UserDialogs.Instance.ShowLoading("Loading", MaskType.Black);

            base.OnAppearing();

            BindingContext = await new UserViewModel(new UserRepository()).Initialize();

            UserDialogs.Instance.HideLoading();
        }

        private void UsersListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            UserDetail.Children.Clear();
            var user = e.Item as User;
            //DisplayAlert("Tapped", user.Id.ToString(),"OK");

            var userImage = new Image();
            userImage.Source = user.AvatarUrl;

            var layout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.StartAndExpand
            };
            layout.Children.Add(new Label { Text = user.FirstName });
            layout.Children.Add(new Label { Text = user.LastName });

            UserDetail.Children.Add(userImage);
            UserDetail.Children.Add(layout);
        }
    }
}