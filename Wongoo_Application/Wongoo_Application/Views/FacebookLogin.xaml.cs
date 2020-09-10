using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Wongoo_Application.Models;
using Wongoo_Application.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wongoo_Application.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FacebookLogin : ContentPage
    {
        public FacebookLogin()
        {
            InitializeComponent();
            BindingContext =new FbViewModel();
         
        }

        private async  void WebView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            loading.IsRunning = true;
            loading.IsVisible = true;
            var accessurl = e.Url;
            if (accessurl.Contains("access_token"))
            {
              accessurl=  accessurl.Replace("https://www.facebook.com/connect/login_success.html#access_token=", string.Empty);
                var accesstoken = accessurl.Split('&')[0];
                using (HttpClient http=new HttpClient())
                {
                    var response =await http.GetStringAsync("https://graph.facebook.com/me?fields=name,email&access_token=" + accesstoken);
                    var Data = JsonConvert.DeserializeObject<Users>(response);
                    await DisplayAlert(Data.Name, Data.Email,"OK");
                }
            }
            loading.IsRunning = false;
            loading.IsVisible = false;
        }
    }
}