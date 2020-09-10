using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wongoo_Application.Shared;
using Wongoo_Application.ViewModels;
using WongooNavigation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wongoo_Application.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchBy : ContentPage
    {
        public SearchBy(string Property,string PropertyName)
        {
            InitializeComponent();

            BindingContext = new SearchByViewModel(Property,PropertyName);
        }

        private async void itemView_ItemTapped(object sender, ItemTappedEventArgs e)
        {

            var item = e.Item as Result;
            await Navigation.PushModalAsync(new ViewProduct(item._id));
        }
    }
}