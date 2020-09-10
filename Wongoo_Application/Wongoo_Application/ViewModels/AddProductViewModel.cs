using Acr.UserDialogs;
using Newtonsoft.Json;
using Plugin.Connectivity;
using Plugin.Toast;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Wongoo_Application.Models;
using Wongoo_Application.Shared;
using Xamarin.Forms;

namespace Wongoo_Application.ViewModels
{
    class AddProductViewModel : BaseViewModel
    {
        MobileCamera camera = new MobileCamera();
        public string ServerURL = ServerIP.IP;
        public string barcode_string;
        //private ImageSource _ImageProduct;

        #region Properties
        private string _image;

        public string image
        {
            get { return _image; }
            set
            {
                _image = value;
                SetProperty(ref _image, value);
                OnPropertyChanged();
            }
        }
        private string _ImageFrontPath;

        public string ImageFrontPath
        {
            get { return _ImageFrontPath; }
            set
            {
                _ImageFrontPath = value;
                SetProperty(ref _ImageFrontPath, value);
                OnPropertyChanged();
            }
        }
        private string _ImageIngredientPath;

        public string ImageIngredientPath
        {
            get { return _ImageIngredientPath; }
            set
            {
                _ImageIngredientPath = value;
                SetProperty(ref _ImageIngredientPath, value);
                OnPropertyChanged();
            }
        }
        private string _ImageNutritionPath;

        public string ImageNutritionPath
        {
            get { return _ImageNutritionPath; }
            set
            {
                _ImageNutritionPath = value;
                SetProperty(ref _ImageNutritionPath, value);
                OnPropertyChanged();
            }
        }



        private AddProduct _product;
        public AddProduct product
        {
            get { return _product; }
            set
            {
                _product = value;
                SetProperty(ref _product, value);
                OnPropertyChanged();
            }
        }
        private Nutriments _nutriments;
        public Nutriments nutriments
        {
            get { return _nutriments; }
            set
            {
                _nutriments = value;
                SetProperty(ref _nutriments, value);
                OnPropertyChanged();
            }
        }

        #region General


        private string _ProductName;

        public string ProductName
        {
            get { return _ProductName; }
            set
            {
                _ProductName = value;
                SetProperty(ref _ProductName, value);
                OnPropertyChanged();
            }
        }

        private string _GenericName;

        public string GenericName
        {
            get { return _GenericName; }
            set
            {
                _GenericName = value;
                SetProperty(ref _GenericName, value);
                OnPropertyChanged();
            }
        }
        private DateTime _ExpirryDate;

        public DateTime ExpirryDate
        {
            get { return _ExpirryDate; }
            set
            {
                _ExpirryDate = value;
                SetProperty(ref _ExpirryDate, value);
                OnPropertyChanged();
            }
        }
        private string _Quantity;

        public string Quantity
        {
            get { return _Quantity; }
            set
            {
                _Quantity = value;
                SetProperty(ref _Quantity, value);
                OnPropertyChanged();
            }
        }
        private string _ProducerWebSite;

        public string ProducerWebSite
        {
            get { return _ProducerWebSite; }
            set
            {
                _ProducerWebSite = value;
                SetProperty(ref _ProducerWebSite, value);
                OnPropertyChanged();
            }
        }

        private string _Country;

        public string Country
        {
            get { return _Country; }
            set
            {
                _Country = value;
                SetProperty(ref _Country, value);
                OnPropertyChanged();
            }
        }


        private string _Stores;

        public string Stores
        {
            get { return _Stores; }
            set
            {
                _Stores = value;
                SetProperty(ref _Stores, value);
                OnPropertyChanged();
            }
        }
        private string _AdditivesTags;

        public string AdditivesTags
        {
            get { return _AdditivesTags; }
            set
            {
                _AdditivesTags = value;
                SetProperty(ref _AdditivesTags, value);
                OnPropertyChanged();
            }
        }


        private string _Brands;

        public string Brands
        {
            get { return _Brands; }
            set
            {
                _Brands = value;
                SetProperty(ref _Brands, value);
                OnPropertyChanged();
            }
        }

        private string _Labels;

        public string Labels
        {
            get { return _Labels; }
            set
            {
                _Labels = value;
                SetProperty(ref _Labels, value);
                OnPropertyChanged();
            }
        }

        private string _Categories;

        public string Categories
        {
            get { return _Categories; }
            set
            {
                _Categories = value;
                SetProperty(ref _Categories, value);
                OnPropertyChanged();
            }
        }

        private string _EmbCodes;

        public string EmbCodes
        {
            get { return _EmbCodes; }
            set
            {
                _EmbCodes = value;
                SetProperty(ref _EmbCodes, value);
                OnPropertyChanged();
            }
        }

        private string _Origins;

        public string Origins
        {
            get { return _Origins; }
            set
            {
                _Origins = value;
                SetProperty(ref _Origins, value);
                OnPropertyChanged();
            }
        }


        private string _ImageFront;

        public string ImageFront
        {
            get { return _ImageFront; }
            set
            {
                _ImageFront = value;
                SetProperty(ref _ImageFront, value);
                OnPropertyChanged();
            }
        }
        private string _ImageIngredient;
        public string ImageIngredient
        {
            get { return _ImageIngredient; }
            set
            {
                _ImageIngredient = value;
                SetProperty(ref _ImageIngredient, value);
                OnPropertyChanged();
            }
        }
        private string _ImageNutrition;
        public string ImageNutrition
        {
            get { return _ImageNutrition; }
            set
            {
                _ImageNutrition = value;
                SetProperty(ref _ImageNutrition, value);
                OnPropertyChanged();
            }
        }

        private decimal _ServingSize;

        public decimal ServingSize
        {
            get { return _ServingSize; }
            set
            {
                _ServingSize = value;
                SetProperty(ref _ServingSize, value);
                OnPropertyChanged();
            }
        }
        private bool _NutritionFlag;

        public bool NutritionFlag
        {
            get { return _NutritionFlag; }
            set
            {
                _NutritionFlag = value;
                SetProperty(ref _NutritionFlag, value);
                OnPropertyChanged();
                LockNutrition = NutritionFlag ? false : true;
            }
        }
        private bool _LockNutrition;

        public bool LockNutrition
        {
            get { return _LockNutrition; }
            set
            {
                _LockNutrition = value;
                SetProperty(ref _LockNutrition, value);
                OnPropertyChanged();
            }
        }

        #endregion
        #region Ingredients
        private string _IngredientsList;

        public string IngredientsList
        {
            get { return _IngredientsList; }
            set
            {
                _IngredientsList = value;
                SetProperty(ref _IngredientsList, value);
                OnPropertyChanged();
            }
        }
        private string _Allergens;

        public string Allergens
        {
            get { return _Allergens; }
            set
            {
                _Allergens = value;
                SetProperty(ref _Allergens, value);
                OnPropertyChanged();
            }
        }

        private string _Traces;

        public string Traces
        {
            get { return _Traces; }
            set
            {
                _Traces = value;
                SetProperty(ref _Traces, value);
                OnPropertyChanged();
            }
        }

        public string _Packaging;
        public string Packaging
        {
            get { return _Packaging; }
            set
            {
                _Packaging = value;
                SetProperty(ref _Packaging, value);
                OnPropertyChanged();
            }
        }

        public string _ManufacturingPlaces;
        public string ManufacturingPlaces
        {
            get { return _ManufacturingPlaces; }
            set
            {
                _ManufacturingPlaces = value;
                SetProperty(ref _ManufacturingPlaces, value);
                OnPropertyChanged();
            }
        }

        public string _PurchasePlaces;
        public string PurchasePlaces
        {
            get { return _PurchasePlaces; }
            set
            {
                _PurchasePlaces = value;
                SetProperty(ref _PurchasePlaces, value);
                OnPropertyChanged();
            }
        }



        #endregion
        #region Nutriments
        private List<string> _Units;

        public List<string> Units
        {
            get { return _Units; }
            set
            {
                _Units = value;
                SetProperty(ref _Units, value);
                OnPropertyChanged();
            }
        }
        private List<string> _RadioChoices;

        public List<string> RadioChoices
        {
            get { return _RadioChoices; }
            set
            {
                _RadioChoices = value;
                SetProperty(ref _RadioChoices, value);
                OnPropertyChanged();
            }
        }

        private string _NutrimentsPer;

        public string NutrimentsPer
        {
            get { return _NutrimentsPer; }
            set
            {
                _NutrimentsPer = value;
                SetProperty(ref _NutrimentsPer, value);
                OnPropertyChanged();
            }
        }

        private decimal _Energy;

        public decimal Energy
        {
            get { return _Energy; }
            set
            {
                _Energy = value;
                SetProperty(ref _Energy, value);
                OnPropertyChanged();
            }
        }
        private decimal _EnergyKcal;

        public decimal EnergyKcal
        {
            get { return _EnergyKcal; }
            set
            {
                _EnergyKcal = value;
                SetProperty(ref _EnergyKcal, value);
                OnPropertyChanged();
            }
        }
        private decimal _Fiber;

        public decimal Fiber
        {
            get { return _Fiber; }
            set
            {
                _Fiber = value;
                SetProperty(ref _Fiber, value);
            }
        }
        private string _FiberUnit;

        public string FiberUnit
        {
            get { return _FiberUnit; }
            set
            {
                _FiberUnit = value;
                SetProperty(ref _FiberUnit, value);
            }
        }
        private decimal _SaturatedFat;

        public decimal SaturatedFat
        {
            get { return _SaturatedFat; }
            set
            {
                _SaturatedFat = value;
                SetProperty(ref _SaturatedFat, value);
            }
        }
        private string _SaturatedFatUnit;

        public string SaturatedFatUnit
        {
            get { return _SaturatedFatUnit; }
            set
            {
                _SaturatedFatUnit = value;
                SetProperty(ref _SaturatedFatUnit, value);
            }
        }
        private decimal _Alcohol;
        public decimal Alcohol
        {
            get { return _Alcohol; }
            set
            {
                _Alcohol = value;
                SetProperty(ref _Alcohol, value);
            }
        }
        private string _AlcoholUnit;
        public string AlcoholUnit
        {
            get { return _AlcoholUnit; }
            set
            {
                _AlcoholUnit = value;
                SetProperty(ref _AlcoholUnit, value);
            }
        }
        private decimal _Sugars;
        public decimal Sugars
        {
            get { return _Sugars; }
            set
            {
                _Sugars = value;
                SetProperty(ref _Sugars, value);
            }
        }
        private string _SugarsUnit;
        public string SugarsUnit
        {
            get { return _SugarsUnit; }
            set
            {
                _SugarsUnit = value;
                SetProperty(ref _SugarsUnit, value);
            }
        }
        private decimal _Salt;
        public decimal Salt
        {
            get { return _Salt; }
            set
            {
                _Salt = value;
                SetProperty(ref _Salt, value);
            }
        }
        private string _SaltUnit;
        public string SaltUnit
        {
            get { return _SaltUnit; }
            set
            {
                _SaltUnit = value;
                SetProperty(ref _SaltUnit, value);
            }
        }
        private decimal _FruitsVegetables;
        public decimal FruitsVegetables
        {
            get { return _FruitsVegetables; }
            set
            {
                _FruitsVegetables = value;
                SetProperty(ref _FruitsVegetables, value);
            }
        }
        private string _FruitsVegetablesUnit;
        public string FruitsVegetablesUnit
        {
            get { return _FruitsVegetablesUnit; }
            set
            {
                _FruitsVegetablesUnit = value;
                SetProperty(ref _FruitsVegetablesUnit, value);
            }
        }
        private decimal _Proteins;
        public decimal Proteins
        {
            get { return _Proteins; }
            set
            {
                _Proteins = value;
                SetProperty(ref _Proteins, value);
            }
        }
        private string _ProteinsUnit;
        public string ProteinsUnit
        {
            get { return _ProteinsUnit; }
            set
            {
                _ProteinsUnit = value;
                SetProperty(ref _ProteinsUnit, value);
            }
        }
        private decimal _Sodium;
        public decimal Sodium
        {
            get { return _Sodium; }
            set
            {
                _Sodium = value;
                SetProperty(ref _Sodium, value);
            }
        }
        private string _SodiumUnit;
        public string SodiumUnit
        {
            get { return _SodiumUnit; }
            set
            {
                _SodiumUnit = value;
                SetProperty(ref _SodiumUnit, value);
            }
        }
        private decimal _Carbohydrates;
        public decimal Carbohydrates
        {
            get { return _Carbohydrates; }
            set
            {
                _Carbohydrates = value;
                SetProperty(ref _Carbohydrates, value);
            }
        }
        private string _CarbohydratesUnit;
        public string CarbohydratesUnit
        {
            get { return _CarbohydratesUnit; }
            set
            {
                _CarbohydratesUnit = value;
                SetProperty(ref _CarbohydratesUnit, value);
            }
        }



        #endregion
        #endregion

        public AddProductViewModel(string barcode)
        {
            barcode_string = barcode;
            NutritionFlag = false;
            LockNutrition = true;
            product = new AddProduct();
            nutriments = new Nutriments();
            ExpirryDate = DateTime.Now.Date;
            ProductName = "";
            GenericName = "";
            Quantity = "";
            ProducerWebSite = "";
            IngredientsList = "";
            Packaging = "";
            Country = "";
            Labels = "";
            Brands = "";
            Stores = "";
            AdditivesTags = "";
            EmbCodes = "";
            Allergens = "";
            Categories = "";
            Traces = "";
            PurchasePlaces = "";
            ManufacturingPlaces = "";
            Origins = "";
            Units = new List<string> { "g", "mg", "μg" };
            RadioChoices = new List<string> { "Per 100g", "Per Serving" };
            NutrimentsPer = "Per 100g";
            ImageFront = "/assets/products.png";
            ImageIngredient = "/assets/ingredients.png";
            ImageNutrition = "/assets/nutrtions.png";
            ImageFrontPath = "picture.png";
            ImageIngredientPath = "picture.png";
            ImageNutritionPath = "picture.png";
        }


        public ICommand AddProductCommand => new Command(AddProduct_Command);
        public async void AddProduct_Command()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                CrossToastPopUp.Current.ShowToastMessage("You're offline,please check your internet connection.", Plugin.Toast.Abstractions.ToastLength.Long);
                UserDialogs.Instance.HideLoading();
                return;
            }

            if (barcode_string == null || barcode_string == "")
            {
                CrossToastPopUp.Current.ShowToastError("Failed to add! barcode is empty", Plugin.Toast.Abstractions.ToastLength.Long);
                await Application.Current.MainPage.Navigation.PopModalAsync();
                return;
            }

            product.Id = barcode_string;
            product.ProductName = ProductName;
            product.GenericName = GenericName;
            product.ExpirationDate = ExpirryDate.Date.ToString();
            product.Quantity = Quantity;
            product.Link = ProducerWebSite;
            product.Countries = Country;
            product.Categories = Categories;
            product.Labels = Labels;
            product.Brands = Brands;
            product.Stores = Stores;
            product.Allergens = Allergens;
            product.Traces = Traces;
            product.Packaging = Packaging;
            product.ManufacturingPlaces = ManufacturingPlaces;
            product.PurchasePlaces = PurchasePlaces;
            product.Origins = Origins;
            product.AdditivesTags = AdditivesTags;
            product.EmbCodes = EmbCodes;
            product.IngredientsText = IngredientsList;
            product.NutritionDataPer = "100g";
            product.NutritionDataPreparedPer = "100g";
            product.ImageFrontUrl = ImageFront;
            product.ImageIngredientsUrl = ImageIngredient;
            product.ImageNutritionUrl = ImageNutrition;
            if (NutritionFlag)
            {

                product.ServingSize = "0";
                nutriments = new Nutriments();
            }
            else
            {
                if (NutrimentsPer == "Per Serving")
                {
                    product.ServingSize = ServingSize.ToString();
                    nutriments.energy_100g = (Energy / ServingSize) * 100;
                    nutriments.Energy = (Energy / ServingSize) * 100; ;
                    nutriments.Fiber100G = FiberUnit == "g" ? (Fiber / ServingSize) * 100 : FiberUnit == "mg" ? (Fiber / ServingSize) / 100 : (Fiber / ServingSize) / 10000; //ternary operator to check selected unit and convert it accordingly
                    nutriments.SaturatedFat = SaturatedFatUnit == "g" ? (SaturatedFat / ServingSize) * 100 : SaturatedFatUnit == "mg" ? (SaturatedFat / ServingSize) / 100 : (SaturatedFat / ServingSize) / 10000;
                    nutriments.SaturatedFat100G = SaturatedFatUnit == "g" ? (SaturatedFat / ServingSize) * 100 : SaturatedFatUnit == "mg" ? (SaturatedFat / ServingSize) / 100 : (SaturatedFat / ServingSize) / 10000;
                    nutriments.SaturatedFatUnit = SaturatedFatUnit;
                    nutriments.Alcohol = Alcohol;
                    nutriments.Alcohol100G = Alcohol;
                    nutriments.AlcoholServing = Alcohol;
                    nutriments.AlcoholUnit = "%vol";
                    nutriments.AlcoholValue = Alcohol;
                    nutriments.Sugars = SugarsUnit == "g" ? (Sugars / ServingSize) * 100 : SugarsUnit == "mg" ? (Sugars / ServingSize) / 100 : (Sugars / ServingSize) / 10000;
                    nutriments.Sugars100G = SugarsUnit == "g" ? (Sugars / ServingSize) * 100 : SugarsUnit == "mg" ? (Sugars / ServingSize) / 100 : (Sugars / ServingSize) / 10000;
                    nutriments.SugarsUnit = SugarsUnit;
                    nutriments.Salt = SaltUnit == "g" ? (Salt / ServingSize) * 100 : SaltUnit == "mg" ? (Salt / ServingSize) / 100 : (Salt / ServingSize) / 10000;
                    nutriments.Salt100G = SaltUnit == "g" ? (Salt / ServingSize) * 100 : SaltUnit == "mg" ? (Salt / ServingSize) / 100 : (Salt / ServingSize) / 10000;
                    nutriments.SaltUnit = SaltUnit;
                    nutriments.Sodium = SodiumUnit == "g" ? (Sodium / ServingSize) * 100 : SodiumUnit == "mg" ? (Sodium / ServingSize) / 100 : (Sodium / ServingSize) / 10000;
                    nutriments.Sodium100G = SodiumUnit == "g" ? (Sodium / ServingSize) * 100 : SodiumUnit == "mg" ? (Sodium / ServingSize) / 100 : (Sodium / ServingSize) / 10000;
                    nutriments.SodiumUnit = SodiumUnit;
                    nutriments.Proteins = ProteinsUnit == "g" ? (Proteins / ServingSize) * 100 : ProteinsUnit == "mg" ? (Proteins / ServingSize) / 100 : (Proteins / ServingSize) / 10000;
                    nutriments.Proteins100G = ProteinsUnit == "g" ? (Proteins / ServingSize) * 100 : ProteinsUnit == "mg" ? (Proteins / ServingSize) / 100 : (Proteins / ServingSize) / 10000; ;
                    nutriments.ProteinsUnit = ProteinsUnit;
                    nutriments.NutrimentsSaturatedFat100G = SaturatedFatUnit == "g" ? (SaturatedFat / ServingSize) * 100 : SaturatedFatUnit == "mg" ? (SaturatedFat / ServingSize) / 100 : (SaturatedFat / ServingSize) / 10000;
                    nutriments.FruitsVegetablesNutsColzaWalnutOliveOils100G = FruitsVegetables;
                    nutriments.Carbohydrates = Carbohydrates;
                    nutriments.CarbohydratesUnit = CarbohydratesUnit;
                }
                else
                {
                    product.ServingSize = ServingSize.ToString();
                    nutriments.energy_100g = Energy;
                    nutriments.Energy = Energy;
                    nutriments.Fiber100G = Fiber;
                    nutriments.SaturatedFat = SaturatedFat;
                    nutriments.SaturatedFat100G = SaturatedFat;
                    nutriments.SaturatedFatUnit = SaturatedFatUnit;
                    nutriments.Alcohol = Alcohol;
                    nutriments.Alcohol100G = Alcohol;
                    nutriments.AlcoholServing = Alcohol;
                    nutriments.AlcoholUnit = "%vol";
                    nutriments.AlcoholValue = Alcohol;
                    nutriments.Sugars = Sugars;
                    nutriments.Sugars100G = Sugars;
                    nutriments.SugarsUnit = SugarsUnit;
                    nutriments.Salt = Salt;
                    nutriments.Salt100G = Salt;
                    nutriments.SaltUnit = SaltUnit;
                    nutriments.Sodium = Sodium;
                    nutriments.Sodium100G = Sodium;
                    nutriments.SodiumUnit = SodiumUnit;
                    nutriments.Proteins = Proteins;
                    nutriments.Proteins100G = Proteins;
                    nutriments.ProteinsUnit = ProteinsUnit;
                    nutriments.NutrimentsSaturatedFat100G = SaturatedFat;
                    nutriments.Carbohydrates = Carbohydrates;
                    nutriments.CarbohydratesUnit = CarbohydratesUnit;
                    nutriments.FruitsVegetablesNutsColzaWalnutOliveOils100G = FruitsVegetables;
                }
            }
            product.Nutriments = nutriments;

            var url = ServerURL + "/api/application/products";
            using (var http = new HttpClient())
            {
                try
                {
                    var jsondata = JsonConvert.SerializeObject(product);
                    var content = new StringContent(jsondata, Encoding.UTF8, "application/json");
                    var Token = await UserInfo.GetToken();
                    http.DefaultRequestHeaders.Add("auth-token", Token);
                    var message = await http.PostAsync(url, content);
                    var msg = message.Content.ReadAsStringAsync().Result;
                    if (message.IsSuccessStatusCode)
                    {
                        CrossToastPopUp.Current.ShowToastSuccess("Congrats! You added this product successfully... waiting for admin to approve this product", Plugin.Toast.Abstractions.ToastLength.Long);
                        await Application.Current.MainPage.Navigation.PopModalAsync();

                    }
                    else
                    {
                        CrossToastPopUp.Current.ShowToastError(message.StatusCode.ToString() + ", Message: " + msg);

                    }
                }
                catch (Exception e)
                {
                    CrossToastPopUp.Current.ShowToastError(e.Message.ToString());
                }
            }
        }
        public ICommand ProductPicture => new Command(TakeProductPicture_Command);

        public async void TakeProductPicture_Command()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                CrossToastPopUp.Current.ShowToastMessage("You're offline,please check your internet connection.");
                UserDialogs.Instance.HideLoading();
                return;
            }

                UserDialogs.Instance.ShowLoading("Wait a Second...");
                ResponseMessage res = await camera.TakePhoto("ProductImage", "image_front_url");
                image = res.Message;
                if (res.Status)
                {
                    ImageFront = res.Message;
                    CrossToastPopUp.Current.ShowToastSuccess("Image uploaded successfully.");
                    UserDialogs.Instance.HideLoading();
                    ImageFrontPath = ServerURL + ImageFront;
                    //await Application.Current.MainPage.DisplayAlert("Image Path", ServerURL + ImageFront, "OK");
                    return;
                }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Failed to upload",res.Message, "OK");

            }


            UserDialogs.Instance.HideLoading();

        }
        public ICommand IngredientPicture => new Command(TakeIngredientPicture_Command);
        public async void TakeIngredientPicture_Command()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                CrossToastPopUp.Current.ShowToastMessage("You're offline,please check your internet connection.");
                UserDialogs.Instance.HideLoading();
                return;
            }
              UserDialogs.Instance.ShowLoading("Wait a Second...");
                ResponseMessage res = await camera.TakePhoto("IngredientsImage", "image_ingredients_url");
                if (res.Status)
                {
                    ImageIngredient = res.Message;
                    ImageIngredientPath = ServerURL + ImageIngredient;
                    CrossToastPopUp.Current.ShowToastSuccess("Image uploaded successfully.");
                    UserDialogs.Instance.HideLoading();

                    return;
                }
           

            UserDialogs.Instance.HideLoading();
        }
        public ICommand NutritionPicture => new Command(TakeNutritionPicture_Command);

        public async void TakeNutritionPicture_Command()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                CrossToastPopUp.Current.ShowToastMessage("You're offline,please check your internet connection.");
                UserDialogs.Instance.HideLoading();
                return;
            }

                UserDialogs.Instance.ShowLoading("Wait a Second...");
                ResponseMessage res = await camera.TakePhoto("NutritionImage", "image_nutrition_url");
                if (res.Status)
                {
                    ImageNutrition = res.Message;
                    ImageNutritionPath = ServerURL + ImageNutrition;
                    CrossToastPopUp.Current.ShowToastSuccess("Image uploaded successfully.");
                    UserDialogs.Instance.HideLoading();
                    return;
                }
          
            UserDialogs.Instance.HideLoading();
        }
    }
}
