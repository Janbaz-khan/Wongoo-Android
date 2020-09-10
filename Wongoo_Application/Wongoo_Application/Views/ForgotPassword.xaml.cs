using Acr.UserDialogs;
using Newtonsoft.Json;
using Plugin.Connectivity;
using Plugin.Toast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Wongoo_Application.Shared;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wongoo_Application.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForgotPassword : ContentPage
    {
        public ForgotPassword()
        {
            InitializeComponent();

        }

        private async void SendEmail_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                CrossToastPopUp.Current.ShowToastMessage("You're offline,please check your internet connection.");
                UserDialogs.Instance.HideLoading();
                return;
            }
            string url = ServerIP.IP+"/api/application/users/forgetpassword";
            if (EmailTextBox.Text == null ||EmailTextBox.Text=="")
            {
                CrossToastPopUp.Current.ShowToastMessage("Please Enter Email Address");
                return;
            }
            using (HttpClient http = new HttpClient())
            {
                forgotPassEmail forgotPassEmail = new forgotPassEmail();
                forgotPassEmail.email = EmailTextBox.Text;
                var json = JsonConvert.SerializeObject(forgotPassEmail);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var res =await http.PostAsync(url,stringContent);
                string msg = res.Content.ReadAsStringAsync().Result;
                await DisplayAlert(res.StatusCode.ToString(), msg, "OK");
                await Navigation.PopModalAsync();
            }
        }
    }
    public class forgotPassEmail
    {
        public string email { get; set; }
    }
}