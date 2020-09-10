using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wongoo_Application.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GoogleLogin : ContentPage
    {
        public GoogleLogin()
        {
            InitializeComponent();
            google_view.Source = "https://accounts.google.com/o/oauth2/v2/auth?"+
             "scope=openid&"+
             "response_type=code&"+
             "redirect_uri=https://www.facebook.com/connect/login_success.html&"+
             "client_id=420054793748-ca0forltfdd3ghvvmvb18ludf8n7e242.apps.googleusercontent.com";
;
        }

        private void google_view_Navigated(object sender, WebNavigatedEventArgs e)
        {
            var accessUrl = e.Url;
        }
    }
}