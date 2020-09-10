using Acr.UserDialogs;
using Newtonsoft.Json;
using Plugin.Connectivity;
using Plugin.Toast;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Wongoo_Application.Models;
using Wongoo_Application.Shared;
using Wongoo_Application.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Wongoo_Application.ViewModels
{
    class RegistrationViewModel : BaseViewModel
    {
        public string ServerURL = ServerIP.IP+"/api/application/users/register";
        private bool _IsRunning;

        public bool IsRunning
        {
            get { return _IsRunning; }
            set
            {
                _IsRunning = value;
                SetProperty(ref _IsRunning, value);
                OnPropertyChanged();
            }
        }
        private string _Name;

        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                OnPropertyChanged();
                SetProperty(ref _Name, value);
            }
        }
        private string _Email;

        public string Email
        {
            get { return _Email; }
            set
            {
                _Email = value;
                OnPropertyChanged();
                SetProperty(ref _Email, value);
            }
        }
        private string _Password;

        public string Password
        {
            get { return _Password; }
            set
            {
                _Password = value;
                OnPropertyChanged();
                SetProperty(ref _Password, value);
            }
        }
        private string _ConfirmPassword;

        public string ConfirmPassword
        {
            get { return _ConfirmPassword; }
            set
            {
                _ConfirmPassword = value;
                OnPropertyChanged();
                SetProperty(ref _ConfirmPassword, value);
            }
        }
        public RegistrationViewModel()
        {
            IsRunning = false;
        }
        public ICommand Register => new Command(RegisterUser);

        public async void RegisterUser()
        {
            if (Email==null||Name==null||Password==null)
            {
                CrossToastPopUp.Current.ShowToastMessage("Field can not be empty.");
                return;
            }
            if (ConfirmPassword != Password)
            {
                CrossToastPopUp.Current.ShowToastMessage("Password does not match", Plugin.Toast.Abstractions.ToastLength.Long);
                return;
            }
            if (!CrossConnectivity.Current.IsConnected)
            {
                CrossToastPopUp.Current.ShowToastMessage("You're offline,please check your internet connection.");
                UserDialogs.Instance.HideLoading();
                return;
            }
            IsRunning = true;
            var model = new Models.Registration();
            model.name = Name;
            model.email = Email;
            model.password = Password;
            try
            {
                using (var http = new HttpClient())
                {

                    var jsonData = JsonConvert.SerializeObject(model);
                    var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    var response = http.PostAsync(ServerURL, stringContent);
                    var content = response.Result.Content.ReadAsStringAsync().Result;
                    if (response.Result.StatusCode.ToString()=="Created"|| response.Result.StatusCode.ToString() == "OK")
                    {
                        CrossToastPopUp.Current.ShowToastSuccess("Your account has been registered successfully");
                     await   Application.Current.MainPage.DisplayAlert(content,"Your account has been registered successfully","OK");

                        await Application.Current.MainPage.Navigation.PopModalAsync();
                        IsRunning = false;
                    }
                    else
                    {
                        CrossToastPopUp.Current.ShowToastWarning(content);
                        IsRunning = false;
                        return;
                    }
                }
            }
            catch (Exception e)
            {
                        CrossToastPopUp.Current.ShowToastWarning("Failed to register please try again later, Error: " + e.Message);
                IsRunning = false;
            }

        }


        public ICommand GoToLogin => new Command(NavigateToLogin);
        public async void NavigateToLogin()
        {
            IsRunning = true;
            await  Application.Current.MainPage.Navigation.PopModalAsync();
            IsRunning = false;
        }
        public ICommand FacebookLogin => new Command(Facebook_Login);

        public  void Facebook_Login()
        {
            //IsRunning = true;
            //await Application.Current.MainPage.Navigation.PushModalAsync(new Views.FacebookLogin());
            //IsRunning = false;
        }
        public ICommand GoogleLogin => new Command(Google_Login);

        public  void Google_Login()
        {
            //IsRunning = true;
            //await Application.Current.MainPage.Navigation.PushModalAsync(new Views.GoogleLogin());
            //IsRunning = false;
        }
    }
}
