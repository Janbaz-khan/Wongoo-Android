using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wongoo_Application.Shared.Persistence;
using Wongoo_Application.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wongoo_Application.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllergensAlert : ContentPage
    {
        ObservableCollection<Allegens> list;
        ObservableCollection<string> AllergensList = new ObservableCollection<string>();
        private SQLiteAsyncConnection _connection;


        public AllergensAlert()
        {
            InitializeComponent();
            //BindingContext = new AllergensViewModel();
            AllergensList = new ObservableCollection<string> { "Celery", "Crustaceans", "Eggs", "Fish", "Gluten", "Lupin", "Milk", "Molluscs", "Mustard", "Nuts", "Peanuts", "Sesame seeds", "Soyabeans", "Sulphur dioxide and sulphits" };
            AllergenList.ItemsSource = AllergensList;
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }
        protected async override void OnAppearing()
        {
            await _connection.CreateTableAsync<Allegens>();
            list = await GetList();
            SelectedList.ItemsSource = list;
            base.OnAppearing();
        }
        private async void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                string name = (string)picker.ItemsSource[selectedIndex];

                 GetSelectedList(name);
                SelectedList.ItemsSource =await GetList();
            }
        }
        public async void GetSelectedList(string name)
        {
            // AllergensList.Remove(name);

            if (list.Where(a => a.AllergenAlert.Contains(name)).Count() == 0)
            {
                var allergen = new Allegens();
                allergen.AllergenAlert = name;
                await _connection.InsertAsync(allergen);
            }
            AllergenList.SelectedIndex = -1;
        }
        private async void delete_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var AllergenAllert = button.CommandParameter as Allegens;
            await _connection.DeleteAsync(AllergenAllert);
            SelectedList.ItemsSource =await GetList();
        }
        public async Task<ObservableCollection<Allegens>> GetList()
        {
            var getList = await _connection.Table<Allegens>().ToListAsync();
            var List = new ObservableCollection<Allegens>(getList);
            return List;
        }
        private async void SelectedList_Refreshing(object sender, EventArgs e)
        {
            SelectedList.IsRefreshing = true;
            SelectedList.ItemsSource =await GetList();
            SelectedList.IsRefreshing = false;
        }
    }
    public class Allegens
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string AllergenAlert { get; set; }
    }
}