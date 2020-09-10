using Acr.UserDialogs;
using Android.OS;
using Newtonsoft.Json.Linq;
using Plugin.Connectivity;
using Plugin.Toast;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Wongoo_Application.Service;
using Wongoo_Application.Shared;
using Wongoo_Application.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Material.Forms.UI.Dialogs;
using ZXing;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace WongooNavigation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScanPage : ContentPage
    {

        public ScanPage()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<Object>(this, "scan", (obj) =>
            {
                StartScan();
            });
        }
        DataService DataService = new DataService();
        public async void StartScan()
        {
           
            try
            {
                var scanPage = new ZXingScannerPage();
                await Navigation.PushModalAsync(scanPage);
                scanPage.OnScanResult += (result) =>
                {

                    UserDialogs.Instance.ShowLoading("Loading Please Wait...");
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        if (!CrossConnectivity.Current.IsConnected)
                        {
                            CrossToastPopUp.Current.ShowToastMessage("You're offline,please check your internet connection.");
                            UserDialogs.Instance.HideLoading();
                            await Navigation.PopModalAsync();

                            return;
                        }
                        await Navigation.PopModalAsync();
                        CheckProductFields message = await DataService.CheckProductAsync(result.Text);
                        if (message.message.Contains("not approved"))
                        {

                            string msg = "Product against this barcode: " + result.Text + " is not approved by the admin.";
                            CrossToastPopUp.Current.ShowToastMessage(msg);
                            UserDialogs.Instance.HideLoading();
                            return;
                        }
                        else if (message.message.Contains("not found"))
                        {
                            string msg = "Product against this barcode: " + result.Text + " is not found.";
                            CrossToastPopUp.Current.ShowToastMessage(msg);
                        }
                        else
                        {

                            string msg = message.message;
                            CrossToastPopUp.Current.ShowToastMessage(msg);

                        }
                        await Navigation.PushModalAsync(new ViewProduct(result.Text));
                        UserDialogs.Instance.HideLoading();

                    });
                };
            }
            catch (Exception e)
            {

                CrossToastPopUp.Current.ShowToastMessage("Failed to scan product,restart the application and try again. Error: "+e.Message, Plugin.Toast.Abstractions.ToastLength.Long);
            }
         
        }

        private  void ScanProduct_Clicked(object sender, EventArgs e)
        {

            ScanProduct.IsEnabled = false;
            //await ScanProduct.ScaleTo(2, 100);
            //await ScanProduct.ScaleTo(1, 100, Easing.SpringOut);
            StartScan();
            Device.StartTimer(TimeSpan.FromSeconds(2), () =>
            {
                ScanProduct.IsEnabled = true;
                return false;
            });

           
        }
    }
}