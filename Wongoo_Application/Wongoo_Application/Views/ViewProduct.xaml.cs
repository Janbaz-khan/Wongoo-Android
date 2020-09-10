using Acr.UserDialogs;
using Android.Graphics;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wongoo_Application.Models;
using Wongoo_Application.Models.Favourites;
using Wongoo_Application.Shared.Persistence;
using Wongoo_Application.ViewModels;
using Wongoo_Application.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WongooNavigation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewProduct : TabbedPage
    {
        private SQLiteAsyncConnection _connection;
        string barcode = "";
        public ViewProduct(string result)
        {
            InitializeComponent();
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            barcode = result;
            BindingContext = new ProductViewModel(result);
        }
        protected async override void OnAppearing()
        {
             int count = await _connection.Table<FavouriteProduct>().Where(a => a.Barcode == barcode).CountAsync();
                try
                {
                    if (count <= 0)
                    {
                        Buttonfavourite.Source = "heart1.png";
                    }
                    else
                    {
                        Buttonfavourite.Source = "heart2.png";
                    }
                }
                catch (Exception e)
                {

                    await Application.Current.MainPage.DisplayAlert(e.Message.ToString(), "", "OK");
                }

            base.OnAppearing();
        }

        private void CatView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //DisplayAlert("Result", e.Item.ToString(), "OK");
            Navigation.PushModalAsync(new SearchBy("categories",e.Item.ToString()));
        }

        private void brands_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushModalAsync(new SearchBy("brands", e.Item.ToString()));
            //  DisplayAlert("Result", e.Item.ToString(), "OK");
        }

        private void labels_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushModalAsync(new SearchBy("labels_tags", e.Item.ToString()));
        }

        private void packaging_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushModalAsync(new SearchBy("packaging", e.Item.ToString()));
            //  DisplayAlert("Result", e.Item.ToString(), "OK");
        }

        private void additives_ItemTapped(object sender, ItemTappedEventArgs e)   
        {
            Navigation.PushModalAsync(new SearchBy("additives", e.Item.ToString()));
            // DisplayAlert("Result", e.Item.ToString(), "OK");
        }

        private async void EditButton_Clicked(object sender, EventArgs e)
        {
            
           await Navigation.PushModalAsync(new EditProduct(barcode));

        }

        
    }
}