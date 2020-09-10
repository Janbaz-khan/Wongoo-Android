using Acr.UserDialogs;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using Wongoo_Application.Shared;
using Wongoo_Application.ViewModels;
using WongooNavigation;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace Wongoo_Application.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Navigation : Xamarin.Forms.TabbedPage
    {
        public Navigation()
        {
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            this.On<Xamarin.Forms.PlatformConfiguration.Android>().SetIsSwipePagingEnabled(false);
            InitializeComponent();

            CheckToken();
        }

        public async void CheckToken()
        {
            try
            {
                var IsConnected = CrossConnectivity.Current.IsConnected;

                if (IsConnected)
                {
                    string url = ServerIP.IP + "/api/application/users/";
                    var token = await SecureStorage.GetAsync("Token");
                    Acr.UserDialogs.UserDialogs.Instance.ShowLoading("Loading...");

                    var http = new HttpClient();
                    http.DefaultRequestHeaders.Add("auth-token", token);
                    var message = await http.GetAsync(url);
                    var res = message.StatusCode;
                    if (res.ToString() == "OK")
                    {
                        Acr.UserDialogs.UserDialogs.Instance.HideLoading();
                    }
                    else
                    {
                        await Navigation.PushAsync(new Login());
                    }
                    Acr.UserDialogs.UserDialogs.Instance.HideLoading();
                }
                else
                {
                    // await DisplayAlert("Error", "You're not connected to the internet! please check your connection and try again", "OK");
                    await Navigation.PushModalAsync(new Connectivity());
                    // System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
                }
            }
            catch (Exception e)
            {

               await DisplayAlert("Error", "Something went wrong! Please check internet connection and try again ", "OK");
                System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
            }

        }
        protected Stack<Page> TabStack { get; private set; } = new Stack<Page>();
        protected override void OnCurrentPageChanged()
        {
            // Get the current page
            var page = CurrentPage;
            int index = Children.IndexOf(CurrentPage);
            if (page != null)
            {
                // Push the page onto the stack
                if (!TabStack.Contains(page))
                {
                    TabStack.Push(page);
                }
                if (index == 0)
                {
                    MessagingCenter.Send<Object>(this, "home");
                }
                else if (index == 1)
                {
                    MessagingCenter.Send<Object>(this, "scan");
                }
                else if (index == 2)
                {
                    MessagingCenter.Send<Object>(this, "userlist");
                }
                else if (index == 3)
                {
                    MessagingCenter.Send<Object>(this, "history");
                }
                else
                {
                    MessagingCenter.Send<Object>(this, "menu");
                }
            }
            base.OnCurrentPageChanged();
        }
        protected override bool OnBackButtonPressed()
        {

            // Go to previous page in the stack. First, pop off the top page since this represents the
            // current page we are on.
            if (TabStack.Any())
            {
                TabStack.Pop();
            }
            // See if we have any pages left
            if (TabStack.Any())
            {
                // Pop off the next page and show it
                CurrentPage = TabStack.Last();
                return true;
            }
            if (CurrentPage.Title == "Home")
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var exit = await DisplayAlert("Confirm exit", "Do you really want to exit the application?", "Yes", "No");
                    if (exit)
                        System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
                });
                return true;
            }
            // We don't have any more pages in the stack so do default
            return base.OnBackButtonPressed();
        }
    }
}