using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wongoo_Application.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wongoo_Application.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
        }
        protected override bool OnBackButtonPressed()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                try
                {
                    var exit = await this.DisplayAlert("Confirm Exit", "Do you really want to exit the application?", "Yes", "No").ConfigureAwait(false);

                    if (exit)
                        System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
                }
                catch (Exception e)
                {

                    await DisplayAlert("Error", e.Message.ToString(), "OK");
                }
            });
            return true;
        }
    }
}