using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Wongoo_Application.ViewModels
{
    class AllergensViewModel:BaseViewModel
    {
		private ObservableCollection<string> _AllergensList;

		public ObservableCollection<string> AllergensList
		{
			get { return _AllergensList; }
			set { _AllergensList = value;
				SetProperty(ref _AllergensList, value);
				OnPropertyChanged();
			}
		}
		private string _AllergenSelected;

		public string AllergenSelected
		{
			get { return _AllergenSelected; }
			set {
				_AllergenSelected = value;
				SetProperty(ref _AllergenSelected, value);
				OnPropertyChanged();
				AllergenSelectedList.Add(AllergenSelected);
				AllergensList.Remove(AllergenSelected);
			}
		}
		private ObservableCollection<string> _AllergenSelectedList;

		public ObservableCollection<string> AllergenSelectedList
		{
			get { return _AllergenSelectedList; }
			set
			{
				_AllergenSelectedList = value;
				SetProperty(ref _AllergenSelectedList, value);
				OnPropertyChanged();
			}
		}
		
		public AllergensViewModel()
		{
			AllergensList = new ObservableCollection<string> { "Celery", "Crustaceans", "Eggs", "Fish", "Gluten", "Lupin", "Milk", "Molluscs", "Mustard", "Nuts", "Peanuts", "Sesame seeds", "Soyabeans", "Sulphur dioxide and sulphits" };
			AllergenSelectedList = new ObservableCollection<string>();
			AllergenSelected = "";
		}
	}
}
