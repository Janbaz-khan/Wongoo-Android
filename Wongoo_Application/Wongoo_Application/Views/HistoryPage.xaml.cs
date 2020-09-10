using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wongoo_Application.Shared;
using Wongoo_Application.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WongooNavigation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryPage : ContentPage
    {
        public HistoryPage()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<Object>(this, "history", (obj) =>
            {
                BindingContext = new HistoryViewModel();
                // DisplayAlert("History", "History", "OK");
            });
        }

        private async void ProductList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Result result = e.Item as Result;
            await Navigation.PushModalAsync(new ViewProduct(result._id));
        }

        protected override bool OnBackButtonPressed()
        {
            UserDialogs.Instance.HideLoading();
            return base.OnBackButtonPressed();
        }
    }
}