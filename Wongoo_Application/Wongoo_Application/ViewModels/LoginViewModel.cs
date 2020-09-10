using Acr.UserDialogs;
using Android.Media;
using Android.Widget;
using Newtonsoft.Json;
using Plugin.Connectivity;
using Plugin.Toast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Wongoo_Application.Models;
using Wongoo_Application.Shared;
using Wongoo_Application.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Wongoo_Application.ViewModels
{
    class LoginViewModel:BaseViewModel
    {

		public string ServerURL = ServerIP.IP+"/api/application/users/login";

		
		private bool _EnableControl;

		public bool EnableControl
		{
			get { return _EnableControl; }
			set {
				_EnableControl = value;
				SetProperty(ref _EnableControl, value);
				OnPropertyChanged();
			}
		}


		private string _Email;

		public string Email
		{
			get { return _Email; }
			set { _Email = value;
				SetProperty(ref _Email, value);
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

		public LoginViewModel()
		{
			_EnableControl = true;
		}

		public ICommand Login => new Command(LoginCommand);

		public async void LoginCommand()
		{
			_EnableControl = false;
			UserDialogs.Instance.ShowLoading("Wait a Second...");
			if (Email==null||Password==null)
			{
				CrossToastPopUp.Current.ShowToastMessage("Email/Password are Empty.(Both Fields are Required)");
				_EnableControl = true;
				UserDialogs.Instance.HideLoading();
				return;
			}
			if (!CrossConnectivity.Current.IsConnected)
			{
				CrossToastPopUp.Current.ShowToastMessage("You're offline,please check your internet connection.");
				UserDialogs.Instance.HideLoading();
				return;
			}
			var login = new Models.Login();
			login.email = Email;
			login.password = Password;

			using (var http = new HttpClient())
			{
				
				var json = JsonConvert.SerializeObject(login);
				var stringContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
				try
				{
					var response = http.PostAsync(ServerURL, stringContent);
					string content = response.Result.Content.ReadAsStringAsync().Result.ToString();
					if (response.Result.StatusCode.ToString() == "OK")
					{
						HttpHeaders headers = response.Result.Headers;
						UserStoredInfo userStoredInfo = await UserInfo.GetUserNameAsync(headers.GetValues("auth-token").First());
						await SecureStorage.SetAsync("Token", userStoredInfo.Token);
						await SecureStorage.SetAsync("Name", userStoredInfo.Name);
						await SecureStorage.SetAsync("Email", userStoredInfo.Email);
						await SecureStorage.SetAsync("Status", userStoredInfo.Status.ToString());
						await SecureStorage.SetAsync("Products", userStoredInfo.Products.ToString());
						var name = SecureStorage.GetAsync("Name").Result;

						CrossToastPopUp.Current.ShowToastSuccess("Successfully logged in");
						await Application.Current.MainPage.Navigation.PopAsync();
						await Application.Current.MainPage.Navigation.PushAsync(new Navigation());
						_EnableControl = true;
						UserDialogs.Instance.HideLoading();

						return;
					}
					CrossToastPopUp.Current.ShowToastError(content);
					_EnableControl = true;
					UserDialogs.Instance.HideLoading();

				}
				catch (Exception e)
				{
						CrossToastPopUp.Current.ShowToastError("Failed to login,please try again later. error: " + e.Message);
					_EnableControl = true;
					UserDialogs.Instance.HideLoading();

				}
			}

		}

		public ICommand GoToRegistration => new Command(NavigateToRegistration);
		public async void NavigateToRegistration()
		{
			_EnableControl = false;
			await Application.Current.MainPage.Navigation.PushModalAsync(new Views.Registration());
			_EnableControl = true;
		}
		public ICommand ForgotPassword => new Command(ShowForgotPassword);
		public async  void ShowForgotPassword()
		{
			if (!CrossConnectivity.Current.IsConnected)
			{
				CrossToastPopUp.Current.ShowToastMessage("You're offline,please check your internet connection.");
				UserDialogs.Instance.HideLoading();
				return;
			}
			await Application.Current.MainPage.Navigation.PushModalAsync(new Views.ForgotPassword());
		}
		public ICommand FacebookLogin => new Command(Facebook_Login);

		public  void Facebook_Login()
		{
			//await Application.Current.MainPage.Navigation.PushModalAsync(new Views.FacebookLogin());
		}
		public ICommand GoogleLogin => new Command(Google_Login);

		public  void Google_Login()
		{
			//UserDialogs.Instance.ShowLoading("Loading...");

			//_EnableControl = false;
			//await Application.Current.MainPage.Navigation.PushModalAsync(new Views.GoogleLogin());
			//_EnableControl = true;
			//UserDialogs.Instance.HideLoading();

		}
	}
}
