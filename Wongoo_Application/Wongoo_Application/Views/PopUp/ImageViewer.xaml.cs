using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wongoo_Application.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wongoo_Application.Views.PopUp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImageViewer : ContentPage
    {
        public ImageViewer(string source)
        {
            InitializeComponent();
            ShowImage(source);
            //DisplayAlert("Result", source, "OK");
        }

        public void ShowImage(string imagepath)
        {
            try
            {
            ImageSource.Source = imagepath;
            }
            catch (Exception)
            {

                DisplayAlert("Error", "Loading failed", "OK");
            }

        }
    }
}