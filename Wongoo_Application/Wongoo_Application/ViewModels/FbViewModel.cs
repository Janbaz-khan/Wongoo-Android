using Android.Hardware.Camera2.Params;
using Android.Webkit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Wongoo_Application.ViewModels
{
   public class FbViewModel:BaseViewModel
    {
		private Xamarin.Forms.WebViewSource _facebookWeb;

		public Xamarin.Forms.WebViewSource facebookWeb
		{
			get { return _facebookWeb; }
			set
			{
				_facebookWeb = value;
				SetProperty(ref _facebookWeb, value);
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



		public FbViewModel()
		{
			
			//facebookWeb = "https://www.facebook.com/v7.0/dialog/oauth?client_id=272406393998065&response_type=token&redirect_uri=https%3A%2F%2Fwww.facebook.com%2Fconnect%2Flogin_success.html";
		
		}

	}
}
