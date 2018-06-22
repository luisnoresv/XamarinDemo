using Acr.UserDialogs;
using System.Threading.Tasks;
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
    }
}