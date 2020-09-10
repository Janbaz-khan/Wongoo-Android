using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using System.Text;
using System.Transactions;
using Wongoo_Application.Shared;
using Xamarin.Forms.Extended;

namespace Wongoo_Application.ViewModels
{
    class SearchByViewModel:BaseViewModel
    {
		public string CatParam = "";
		private bool _IsBusy;
        private string _CatName;

        public string CatName
		{
            get { return _CatName; }
            set { _CatName = value;
				SetProperty(ref _CatName, value);
				OnPropertyChanged();
			}
        }

        public bool IsBusy
		{
			get { return _IsBusy; }
			set
			{
				_IsBusy = value;
				SetProperty(ref _IsBusy, value);
				OnPropertyChanged();
			}
		}
		private UserListProducts _FavList;
		public UserListProducts FavList
		{
			get { return _FavList; }
			set { _FavList = value;
				SetProperty(ref _FavList, value);
				OnPropertyChanged();
			}
		}
		public InfiniteScrollCollection<Result> Items { get; set; }
		public Service.DataService dataService = new Service.DataService();
		private const int pageSize = 10;
		int pagenumber=1;
		public async void DownloadDataAsync(string Property,string PropertyName)
		{
			var item = await dataService.GetItemAsync(pageIndex: 0, pageSize: pageSize,Property,PropertyName);
			Items.AddRange(item);
		}
		public SearchByViewModel(string Property,string PropertyName)
		{
			CatName = PropertyName;
            Items = new InfiniteScrollCollection<Result>
            {
                OnLoadMore = async () =>
                 {
                     IsBusy = true;
					 var page = Items.Count / pageSize;
                     var items = await dataService.GetItemAsync(page, pageSize,Property,PropertyName);
                     IsBusy = false;
					 pagenumber++;
                     return items;
                 },
                OnCanLoadMore = () =>
                {
					var s=dataService.getTotalDocument();
					return Items.Count < s;
                }
            };
            DownloadDataAsync(Property,PropertyName);
        }
		
		
	}
}
