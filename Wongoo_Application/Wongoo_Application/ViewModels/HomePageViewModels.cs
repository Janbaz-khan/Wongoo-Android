using Acr.UserDialogs;
using Java.Sql;
using Plugin.Connectivity;
using Plugin.Toast;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Wongoo_Application.Models.Favourites;
using Wongoo_Application.Service;
using Wongoo_Application.Shared.Persistence;
using WongooNavigation;
using Xamarin.Forms;

namespace Wongoo_Application.ViewModels
{
    class HomePageViewModels : BaseViewModel
    {
        DataService DataService = new DataService();
        private SQLiteAsyncConnection _connection;
        private bool _EnabledControl;

        public bool EnabledControl
        {
            get { return _EnabledControl; }
            set
            {
                _EnabledControl = value;
                SetProperty(ref _EnabledControl, value);
                OnPropertyChanged();
            }
        }

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
        public ICommand GoToProductPage => new Command(NavigateToProduct);
        public HomePageViewModels()
        {
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            InitSqlite();
            EnabledControl = true;
            IsRunning = false;
        }
        public async void InitSqlite()
        {
            await _connection.CreateTableAsync<FavouriteList>();
            await _connection.CreateTableAsync<FavouriteProduct>();
        }
        private string _barcode;

        public string barcode
        {
            get { return _barcode; }
            set
            {
                _barcode = value;
                SetProperty(ref _barcode, value);
                OnPropertyChanged();
            }
        }
        
        async public void NavigateToProduct()
        {
            try
            {
                EnabledControl = false;
                UserDialogs.Instance.ShowLoading("Please Wait...");

                IsRunning = true;
                if (barcode == null || barcode == "")
                {
                    CrossToastPopUp.Current.ShowToastMessage("Barcode empty! please enter barcode and try again");
                    IsRunning = false;
                    UserDialogs.Instance.HideLoading();
                    EnabledControl = true;
                    return;
                }
                if (!CrossConnectivity.Current.IsConnected)
                {
                    CrossToastPopUp.Current.ShowToastMessage("You're offline,please check your internet connection.");
                    UserDialogs.Instance.HideLoading();
                    IsRunning = false;
                    EnabledControl = true;
                    return;
                }
                CheckProductFields message = await DataService.CheckProductAsync(barcode);
                if (message.message.Contains("not approved"))
                {

                    string msg = "Product Exists! This barcode: " + barcode + " is not yet approved by the admin.";
                    CrossToastPopUp.Current.ShowToastMessage(msg, Plugin.Toast.Abstractions.ToastLength.Long);
                    UserDialogs.Instance.HideLoading();
                    IsRunning = false;
                    EnabledControl = true;
                    return;
                }
                else if (message.message.Contains("product found"))
                {

                    string msg = "Product Exists!";
                    CrossToastPopUp.Current.ShowToastMessage(msg, Plugin.Toast.Abstractions.ToastLength.Long);
                    await Application.Current.MainPage.Navigation.PushModalAsync(new ViewProduct(barcode));
                    UserDialogs.Instance.HideLoading();
                    IsRunning = false;
                    EnabledControl = true;
                    return;
                }
                else if (message.message.Contains("not found"))
                {
                    string msg = "Product not found!";
                    CrossToastPopUp.Current.ShowToastMessage(msg);
                    await Application.Current.MainPage.Navigation.PushModalAsync(new AddProduct(barcode));
                    IsRunning = false;
                    EnabledControl = true;
                    UserDialogs.Instance.HideLoading();
                }
                else
                {
                    string msg = message.message;
                    CrossToastPopUp.Current.ShowToastMessage(msg, Plugin.Toast.Abstractions.ToastLength.Long);
                    IsRunning = false;
                    UserDialogs.Instance.HideLoading();
                    return;
                }
                EnabledControl = true;
                barcode = "";
            }
            catch (Exception e)
            {

                CrossToastPopUp.Current.ShowToastMessage(e.Message);
                EnabledControl = true;
                barcode = "";
            }
         
        }

        public ICommand GoToSearch => new Command(Search);
        public async void Search()
        {

            if (!CrossConnectivity.Current.IsConnected)
            {
                CrossToastPopUp.Current.ShowToastMessage("You're offline,please check your internet connection.");
                UserDialogs.Instance.HideLoading();
                return;
            }
            try
            {
                EnabledControl = false;
                UserDialogs.Instance.ShowLoading("Please wait...");
                IsRunning = true;
                if (barcode == null || barcode == "")
                {
                    CrossToastPopUp.Current.ShowToastMessage("Barcode empty! Please enter barcode and try again");
                    IsRunning = false;
                    UserDialogs.Instance.HideLoading();
                    EnabledControl = true;
                    return;
                }
                CheckProductFields message = await DataService.CheckProductAsync(barcode);
                if (message.message.Contains("not approved"))
                {

                    string msg = "Product against this barcode: " + barcode + " is not approved by the admin.";
                    CrossToastPopUp.Current.ShowToastMessage(msg, Plugin.Toast.Abstractions.ToastLength.Long);
                    UserDialogs.Instance.HideLoading();
                    IsRunning = false;
                    EnabledControl = true;
                    return;
                }
                else if (message.message.Contains("not found"))
                {
                    string msg = "Product against this barcode: " + barcode + " is not found.";
                    CrossToastPopUp.Current.ShowToastMessage(msg, Plugin.Toast.Abstractions.ToastLength.Long);
                }
                else
                {

                    //string msg = message.message;
                    //CrossToastPopUp.Current.ShowToastMessage(msg);

                }
                await Application.Current.MainPage.Navigation.PushModalAsync(new ViewProduct(barcode));
                UserDialogs.Instance.HideLoading();
                IsRunning = false;

                EnabledControl = true;
                barcode = "";
            }
            catch (Exception e)
            {

                CrossToastPopUp.Current.ShowToastMessage(e.Message);
                EnabledControl = true;
                barcode = "";
            }

        }



    }
}
