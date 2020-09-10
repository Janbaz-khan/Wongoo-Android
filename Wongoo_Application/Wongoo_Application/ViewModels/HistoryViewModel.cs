using Acr.UserDialogs;
using Plugin.Connectivity;
using Plugin.Toast;
using System.Net.Http;
using System.Windows.Input;
using Wongoo_Application.Shared;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Wongoo_Application.ViewModels
{
	class HistoryViewModel:BaseViewModel
    {
	string url =ServerIP.IP+"/api/application/users/history/";
		private UserListProducts _FavList;

		public UserListProducts FavList
		{
			get { return _FavList; }
			set
			{
				_FavList = value;
				SetProperty(ref _FavList, value);
				OnPropertyChanged();
			}
		}

		private bool _NotFound;

		public bool NotFound
		{
			get { return _NotFound; }
			set
			{
				_NotFound = value;
				SetProperty(ref _NotFound, value);
				OnPropertyChanged();
			}
		}
		private bool _IsRefresh;

		public bool IsRefresh
		{
			get { return _IsRefresh; }
			set
			{
				_IsRefresh = value;
				SetProperty(ref _IsRefresh, value);
				OnPropertyChanged();
			}
		}
		public HistoryViewModel()
		{
			IsRefresh = false;
			NotFound = false;
			if (!CrossConnectivity.Current.IsConnected)
			{
				CrossToastPopUp.Current.ShowToastMessage("You're offline,please check your internet connection.");
			}
			else
			{
			OnStart_UserHistory();
			}
		}
		public ICommand RefreshData => new Command(RefreshingData);

		private void RefreshingData()
		{
			IsRefresh = true;
			OnStart_UserHistory();
			IsRefresh = false;
		}
		public async void OnStart_UserHistory()
		{
			UserDialogs.Instance.ShowLoading("Loading...");
			var token = await UserInfo.GetToken();
			var productList = await UserInfo.GetUserNameAsync(token);
			if (productList.History.Count >0)
			{
				FavList = await UserInfo.GetUserListProducts(productList.History);
			}
			else
			{
				NotFound = true;
			}
			UserDialogs.Instance.HideLoading();
		}

		public ICommand Delete => new Command<Result>(DeleteItem);

		public async void DeleteItem(Result Product)
		{

			//Application.Current.MainPage.DisplayAlert("Product id: " + Product._id, "Product name: " + Product.product_name + ". Delete will work soon", "OK");
			UserDialogs.Instance.ShowLoading("Loading please wait...");
			//Application.Current.MainPage.DisplayAlert("Product id: " + Product._id, "Product name: " + Product.product_name + ". Delete will work soon", "OK");
			using (var http = new HttpClient())
			{
				var Token = SecureStorage.GetAsync("Token").Result;
				http.DefaultRequestHeaders.Add("auth-token", Token);
				var res = http.DeleteAsync(url + Product._id);
				string responeMsg = res.Result.Content.ReadAsStringAsync().Result;
				if (responeMsg.Contains("access denied"))
				{
					await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Failed", "Please Login to do the task", "OK");

					UserDialogs.Instance.HideLoading();
					return;
				}
				OnStart_UserHistory();

			}
		}
	}
}
