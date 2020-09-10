using Acr.UserDialogs;
using Plugin.Connectivity;
using Plugin.Toast;
using System;
using System.Collections.Generic;
using System.Linq;
using Wongoo_Application.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace WongooNavigation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<Object>(this, "home", (obj) =>
            {
             BindingContext = new HomePageViewModels();
                // DisplayAlert("Home Page", "Hello", "OK");
            });
        }
        private void AddButton_Clicked(object sender, EventArgs e)
        {
            AddButton.IsEnabled = false;
            searchButton.IsEnabled = false;
            Device.StartTimer(TimeSpan.FromSeconds(5), () =>
            {
                AddButton.IsEnabled = true;
                searchButton.IsEnabled = true;
                return false;
            });

        }

        private void searchButton_Clicked(object sender, EventArgs e)
        {
            AddButton.IsEnabled = false;
            searchButton.IsEnabled = false; 
            Device.StartTimer(TimeSpan.FromSeconds(5), () =>
            {
                AddButton.IsEnabled = true;
                searchButton.IsEnabled = true;
                return false;
            });
        }



        // DataService DataService = new DataService();
        //private async void ScanProduct_Clicked(object sender, EventArgs e)
        //{
        //    await ScanProduct.ScaleTo(2, 100);
        //    await ScanProduct.ScaleTo(1, 100, Easing.SpringOut);
        //    var scanPage = new ZXingScannerPage();
        //   await Navigation.PushModalAsync(scanPage);
        //    scanPage.OnScanResult += (result) =>
        //    {

        //        UserDialogs.Instance.ShowLoading("Loading Please Wait...");
        //        Device.BeginInvokeOnMainThread(async () =>
        //        {
        //            if (!CrossConnectivity.Current.IsConnected)
        //            {
        //                CrossToastPopUp.Current.ShowToastMessage("You're offline,please check your internet connection.");
        //                UserDialogs.Instance.HideLoading();
        //                await Navigation.PopModalAsync();
        //                return;
        //            }
        //            await Navigation.PopModalAsync();
        //            CheckProductFields message = await DataService.CheckProductAsync(result.Text);
        //            if (message.message.Contains("not approved"))
        //            {

        //                string msg = "Product against this barcode: " + result.Text + " is not approved by the admin.";
        //                CrossToastPopUp.Current.ShowToastMessage(msg);
        //                UserDialogs.Instance.HideLoading();
        //                return;
        //            }
        //            else if (message.message.Contains("not found"))
        //            {
        //                string msg = "Product against this barcode: " + result.Text + " is not found.";
        //                CrossToastPopUp.Current.ShowToastMessage(msg);
        //            }
        //            else
        //            {

        //                string msg = message.message;
        //                CrossToastPopUp.Current.ShowToastMessage(msg);

        //            }
        //            await Navigation.PushModalAsync(new ViewProduct(result.Text));
        //         UserDialogs.Instance.HideLoading();

        //        });
        //    };
        //}


    }
}