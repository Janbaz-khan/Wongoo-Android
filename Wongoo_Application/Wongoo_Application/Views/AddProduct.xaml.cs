using Plugin.Toast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wongoo_Application.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WongooNavigation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddProduct :TabbedPage
    {
        public AddProduct(string barcode)
        {
            InitializeComponent();
            BindingContext = new AddProductViewModel(barcode);
        }
        private void NextToInredients_Clicked(object sender, EventArgs e)
        {
            if (ProductName.Text==null)
            {
                CrossToastPopUp.Current.ShowToastMessage("Fields can not be empty");
                return;
            }
            CurrentPage = Children[1];
        }

        private void GoToNutrition_Clicked(object sender, EventArgs e)
        {
            
            CurrentPage = Children[2];
        }
   private void Submit_Clicked(object sender, EventArgs e)
        {
            if (ProductName.Text == null )
            {
                CrossToastPopUp.Current.ShowToastMessage("Fields can not be empty",Plugin.Toast.Abstractions.ToastLength.Long);
                CurrentPage = Children[0];
            }
        }

       
        protected override bool OnBackButtonPressed()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                var exit = await this.DisplayAlert("Leave Page", "Are you sure you want to leave this page?", "Yes", "No").ConfigureAwait(false);

                if (exit)
                    //System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
                    await Navigation.PopModalAsync();
            });
            return true;
        }
    }
}