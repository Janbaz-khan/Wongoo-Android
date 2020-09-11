using Acr.UserDialogs;
using Java.Security;
using Newtonsoft.Json;
using Plugin.Connectivity;
using Plugin.Toast;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Wongoo_Application.Shared;
using Wongoo_Application.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Wongoo_Application.ViewModels
{
    class UserPageViewModel:BaseViewModel
    {
        public string ServerURL =ServerIP.IP;
        private string _Name = SecureStorage.GetAsync("Name").Result;

        public string Name
        {
            get { return _Name; }
            set { _Name = value;
                SetProperty(ref _Name, value);
                OnPropertyChanged();
            }
        }
        private string _Email = SecureStorage.GetAsync("Email").Result;

        public string Email
        {
            get { return _Email; }
            set
            {
                _Email = value;
                SetProperty(ref _Email, value);
                OnPropertyChanged();
            }
        }
        private string _EmailStatus;

        public string EmailStatus
        {
            get { return _EmailStatus; }
            set
            {
                _EmailStatus = value;
                SetProperty(ref _EmailStatus, value);
                OnPropertyChanged();
            }
        }
        private string _Password;

        public string Password
        {
            get { return _Password; }
            set { _Password = value;
                SetProperty(ref _Password, value);
                OnPropertyChanged();
            }
        }

        private bool _ShowPopup;

        public bool ShowPopup 
        {
            get { return _ShowPopup; }
            set { _ShowPopup = value; }
        }

        
        public UserPageViewModel()
        {
            ShowPopup = UserInfo.IsAccountVerified() ? false:true;
            var accountStatus = UserInfo.IsAccountVerified();
            EmailStatus = accountStatus ? "shield.png" : "alert.png";

        }
        public ICommand SendToken => new Command(sendToken);
        public async void sendToken()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                CrossToastPopUp.Current.ShowToastMessage("You're offline,please check your internet connection.");
                UserDialogs.Instance.HideLoading();
                return;
            }
            var url = ServerURL + "/api/application/users/resend";
            resend resend = new resend();
            resend.email = UserInfo.GetEmail();
            using (HttpClient http=new HttpClient())
            {
                
                var json = JsonConvert.SerializeObject(resend);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var token = await UserInfo.GetToken();
                http.DefaultRequestHeaders.Add("auth-token", token);
                var res = await http.PostAsync(url, stringContent);
                var msg = res.Content.ReadAsStringAsync().Result;
                if (res.StatusCode.ToString() == "OK")
                {
                    CrossToastPopUp.Current.ShowToastMessage(msg);
                    await Application.Current.MainPage.DisplayAlert(res.StatusCode.ToString(), msg, "OK");
                    await Application.Current.MainPage.Navigation.PopModalAsync();
                    return;
                }
                CrossToastPopUp.Current.ShowToastError(msg);

            }
        }

        public ICommand Edit => new Command(EditProfile);
        public async void EditProfile()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                CrossToastPopUp.Current.ShowToastMessage("You're offline,please check your internet connection.");
                return;
            }
            var url = ServerURL + "/api/application/users/";
            if (Name==null||Password==null)
            {
                CrossToastPopUp.Current.ShowToastMessage("Fields Can't be Empty");
                UserDialogs.Instance.HideLoading();
                return;
            }
            using (HttpClient http=new HttpClient())
            {
                ChangePassword CH = new ChangePassword();
                CH.name = Name;
                CH.password = Password;
                var json = JsonConvert.SerializeObject(CH);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var token = await UserInfo.GetToken();
                http.DefaultRequestHeaders.Add("auth-token", token);
                var res =await http.PutAsync(url,stringContent);
                var msg = res.Content.ReadAsStringAsync().Result;
                if (res.StatusCode.ToString()=="OK")
                {
                    CrossToastPopUp.Current.ShowToastMessage("Account Changes Are Saved!");
                    SecureStorage.Remove("Name");
                    SecureStorage.Remove("Email");
                    SecureStorage.Remove("Status");
                    SecureStorage.Remove("Token");
                    await Application.Current.MainPage.Navigation.PopModalAsync();
                    await Application.Current.MainPage.Navigation.PopToRootAsync();
                    await Application.Current.MainPage.Navigation.PushAsync(new Login());
                }
            }

        }
        public ICommand LogOutCommand => new Command(Logout);
        public async void Logout()
        {

             bool removed=SecureStorage.Remove("Token");
            if (removed)
            {
                SecureStorage.Remove("Name");
                SecureStorage.Remove("Email");
                SecureStorage.Remove("Status");
                CrossToastPopUp.Current.ShowToastMessage("You are logged out!");
                await Application.Current.MainPage.Navigation.PopToRootAsync();
              await  Application.Current.MainPage.Navigation.PushAsync(new Login());
            }
            else
            {
                CrossToastPopUp.Current.ShowToastError("Fail to logout ,please try again later");

            }   
        }
        public ICommand AllergenAlert => new Command(AllergensAlerts);
        public async void AllergensAlerts()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new AllergensAlert());
        }
        public ICommand GoToAccount => new Command(Account);
        public async void Account()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                CrossToastPopUp.Current.ShowToastMessage("You're offline,please check your internet connection.");
                return;
            }
            await Application.Current.MainPage.Navigation.PushModalAsync(new AccountSetting());
        }
    }
        public class ChangePassword
        {
        public string name { get; set; }
        public string password { get; set; }
    }
    public class resend
    {
        public string email { get; set; }
    }
}
