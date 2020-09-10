using System;
using System.Collections.Generic;
using System.Text;
using WongooNavigation;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace Wongoo_Application.Shared
{

    class CustomTabbar : Xamarin.Forms.TabbedPage
    {
        public CustomTabbar()
        {
           // On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            //this.On<Android>().SetIsSwipePagingEnabled(false);
            var navigation1 = new NavigationPage(new ScanPage());
            var navigation2 = new NavigationPage(new UserList());
            var navigation3 = new NavigationPage(new HomePage());
            var navigation4 = new NavigationPage(new UserPage());
            var navigation5 = new NavigationPage(new HistoryPage());


            navigation1.IconImageSource = "barcode.png";
            navigation1.Title = "Scan";

            // navigation1.BarBackgroundColor = Color.FromHex(ChooseColor.DefaultColor());
            navigation2.IconImageSource = "checklist.png";
            navigation2.Title = "lists";
            //navigation2.BarBackgroundColor = Color.FromHex(ChooseColor.DefaultColor());

            navigation3.IconImageSource = "homepage.png";
            navigation3.Title = "Home";

            //navigation3.BarBackgroundColor = Color.FromHex(ChooseColor.DefaultColor());

            navigation4.IconImageSource = "user.png";
            navigation4.Title = "User";

            navigation5.IconImageSource = "history.png";
            navigation5.Title = "History";
            //SelectedTabColor =Color.FromHex(ChooseColor.DefaultColor());
            // UnselectedTabColor = Color.FromHex(ChooseColor.UnselectedColor());
            Children.Add(navigation1);
            Children.Add(navigation2);
            Children.Add(navigation3);
            Children.Add(navigation4);
            Children.Add(navigation5);
            CurrentPage = Children[2];
            // BarBackgroundColor = Color.FromHex("#f5f6fa");




        }
    }
}
