using Plugin.Toast;
using SQLite;
using System;
using Wongoo_Application.Models.Favourites;
using Wongoo_Application.Shared.Persistence;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wongoo_Application.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserCreatedList : ContentPage
    {
        private SQLiteAsyncConnection _connection;
        private int _id;
        public UserCreatedList(int id)
        {
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            _id = id;
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            GetData();  
            base.OnAppearing();
        }

        private async void Delete_Clicked(object sender, EventArgs e)
        {
            var menu = sender as MenuItem;
            var product = menu.CommandParameter as FavouriteProduct;
            var delete = await DisplayAlert(product.ProductName, "Do you really want to remove this product from this list?", "Yes", "No");
            if (delete)
            {
                var list = await _connection.Table<FavouriteList>().Where(a => a.FavId == product.FavListId).FirstOrDefaultAsync();
                list.TotalProducts -= 1;
                list.PrintProduct = "Total Products: " + list.TotalProducts;
                await _connection.UpdateAsync(list);
                await _connection.DeleteAsync(product);
            CrossToastPopUp.Current.ShowToastMessage("Deleted successfully");
            }
            GetData();
        }
        
        public async void GetData()
        {
            var productList = await _connection.Table<FavouriteProduct>().Where(a => a.FavListId == _id).ToListAsync();
            SelectedList.ItemsSource = productList;
        }

        private async void SelectedList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var product = e.Item as FavouriteProduct;
            await Navigation.PushModalAsync(new WongooNavigation.ViewProduct(product.Barcode));
        }
    }
}