using System;
using Wongoo_Application.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WongooNavigation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPage : ContentPage
    {
        public UserPage()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<Object>(this, "menu", (obj) =>
            {
            BindingContext = new UserPageViewModel();
               // DisplayAlert("User Page", "user", "OK");
            });
        }
    }
}