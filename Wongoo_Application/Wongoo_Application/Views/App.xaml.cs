using Android.Content.PM;
using Wongoo_Application.ViewModels;
using WongooNavigation;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.OneD;

namespace Wongoo_Application.Views
{
    public partial class App : Xamarin.Forms.Application
    {
        public App()
        {
            InitializeComponent();
            XF.Material.Forms.Material.Init(this);
            start();
            //MainPage = new ViewProduct("8901262150989");
        }
        public async void start()
        {
           
            var token = await SecureStorage.GetAsync("Token");
            if (token != null)
            {
                MainPage = new NavigationPage(new Navigation());
            }
            else
            {
                MainPage = new NavigationPage(new Login());
            }
        }
        
        protected override void OnSleep()
        {

        }

        protected override void OnResume()
        {
        }
    }
}
