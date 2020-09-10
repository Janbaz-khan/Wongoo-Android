using Acr.UserDialogs;
using Plugin.Toast;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Wongoo_Application.Models.Favourites;
using Wongoo_Application.Shared;
using Wongoo_Application.Shared.Persistence;
using Wongoo_Application.ViewModels;
using Wongoo_Application.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Material.Forms.UI.Dialogs;

namespace WongooNavigation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserList : ContentPage
    {
        private SQLiteAsyncConnection _connection;
        public UserList()
        {
              InitializeComponent();
              _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            MessagingCenter.Subscribe<Object>(this, "userlist", (obj) =>
            {
                // BindingContext = new UserListViewModel();
                //  DisplayAlert("User List", "Hello", "OK");
            });
        }
        protected async override void OnAppearing()
        {
            //await _connection.DropTableAsync<FavouriteList>();
            //await _connection.DropTableAsync<FavouriteProduct>();
            await _connection.CreateTableAsync<FavouriteList>();
            await _connection.CreateTableAsync<FavouriteProduct>();
            int count =await _connection.Table<FavouriteList>().CountAsync();
            if (count<=0)
            {
                var obj1 = new FavouriteList();
                obj1.ListName = "Eaten Products";
                obj1.TotalProducts = 0;
                obj1.PrintProduct = "Total Products: 0";
                var obj2 = new FavouriteList();
                obj2.ListName = "Products to buy";
                obj2.TotalProducts = 0;
                obj2.PrintProduct = "Total Products: 0";
                await _connection.InsertAsync(obj1);
                await _connection.InsertAsync(obj2);
            }
            RefreshData();
            base.OnAppearing();
        }
        private async void ProductList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var result = e.Item as FavouriteList;
            try
            {
                RefreshData();
                await Navigation.PushModalAsync(new UserCreatedList(result.FavId));
            }
            catch (Exception a)
            {
               await DisplayAlert("Failed", a.ToString(), "OK");
            }
          
        }
        private async void AddList_Clicked(object sender, EventArgs e)
        {
            var input = await MaterialDialog.Instance.InputAsync("Create List","",null,"eg: eaten products","OK","Cancel");
            if (input!=""&&input.Length<30)
            {
                var list =  _connection.Table<FavouriteList>().ToListAsync().Result.Select(a=>a.ListName);
                if (!list.Contains(input))
                {
                    var Newlist = new FavouriteList();
                    Newlist.ListName = input;
                    Newlist.TotalProducts = 0;
                    Newlist.PrintProduct = "Total Products: 0";
                  await  _connection.InsertAsync(Newlist);
                    RefreshData();
                }
                else { await DisplayAlert("Already Exists", "List with this name already created", "OK"); }
            }
            else { await DisplayAlert("List Not Created", "List name must be not empty and less than 30 characters","OK"); }
        }

        private  void ProductList_Refreshing(object sender, EventArgs e)
        {
            ProductList.IsRefreshing = true;
            RefreshData();
            ProductList.IsRefreshing = false;
        }

        private async void Delete_Clicked(object sender, EventArgs e)
        {
            var menu = sender as MenuItem;
            var product = menu.CommandParameter as FavouriteList;
            var delete = await DisplayAlert(product.ListName, "Do you really want to delete the list?", "Yes", "No");
            if (delete)
            {
             var listProduct= await _connection.Table<FavouriteProduct>().Where(a => a.FavListId == product.FavId).ToListAsync();
            foreach (var item in listProduct)
            {
                await _connection.DeleteAsync(item);
            }
            await _connection.DeleteAsync(product);
            RefreshData();
            CrossToastPopUp.Current.ShowToastMessage("Deleted successfully");
            }
        }
        public async void RefreshData()
        {
            ProductList.ItemsSource = await _connection.Table<FavouriteList>().ToListAsync();
        }
    }
}