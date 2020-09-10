﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wongoo_Application.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wongoo_Application.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountSetting : ContentPage
    {
        public AccountSetting()
        {
            InitializeComponent();
            BindingContext = new UserPageViewModel();
        }
    }
}