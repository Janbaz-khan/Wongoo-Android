using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.SymbolStore;
using System.Text;
using System.Windows.Input;
using WongooNavigation;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace Wongoo_Application.ViewModels
{
    class ScanViewModel:BaseViewModel
    {
        public ZXing.Result Result { get; set; }

        string old_result = "";
        private bool isAnalyzing = true;
        public bool IsAnalyzing
        {
            get { return this.isAnalyzing; }
            set
            {
                isAnalyzing = value;
                SetProperty(ref isAnalyzing, value);
                OnPropertyChanged();
            }
        }
        private bool _IsBusy= false;
        public bool IsBusy
        {
            get { return _IsBusy; }
            set
            {
                _IsBusy = value;
                SetProperty(ref _IsBusy, value);
                OnPropertyChanged();
            }
        }

        private bool isScanning = true;
        public bool IsScanning
        {
            get { return this.isScanning; }
            set
            {
                isAnalyzing = value;
                SetProperty(ref isScanning, value);
                OnPropertyChanged();
            }
        }
        public ScanViewModel()
        {
            IsBusy = false;
            isScanning = true;
            isAnalyzing = true;
        }


        //public Command QRScanResultCommand
        //{
        //    get
        //    {
        //        return new Command(() =>
        //        {

        //            if (old_result == Result.ToString())
        //            {
        //                return;
        //            }
        //            Device.BeginInvokeOnMainThread(async () =>
        //            {
        //                if (Result.Text != null)
        //                {
        //                    old_result = Result.ToString();
        //                    // productVM = new ProductViewModel(Result.Text);
        //                    UserDialogs.Instance.ShowLoading("Loading...");
        //                    await Application.Current.MainPage.Navigation.PushModalAsync(new ViewProduct(Result.Text));
        //                    old_result = "";
        //                }
        //                else
        //                {
        //                    await Application.Current.MainPage.DisplayAlert("Failed", "No barcode found,please try again", "Okay");
        //                    IsBusy = false;
        //                }

        //            });
        //            UserDialogs.Instance.HideLoading(); 
        //            IsBusy = true;
        //            isScanning = false;
        //            isAnalyzing = false;
                    
        //        });

        //    }
        //}
    }



}