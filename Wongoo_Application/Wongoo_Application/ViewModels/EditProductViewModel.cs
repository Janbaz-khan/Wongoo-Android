using Acr.UserDialogs;
using Java.Util;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Plugin.Connectivity;
using Plugin.Toast;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Wongoo_Application.Models;
using Wongoo_Application.Shared;
using Xamarin.Forms;

namespace Wongoo_Application.ViewModels
{
    public class EditProductViewModel : BaseViewModel
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

      
        private MainProduct _GetProduct;
        public MainProduct GetProduct
        {
            get { return _GetProduct; }
            set
            {
                _GetProduct = value;
                SetProperty(ref _GetProduct, value);
                OnPropertyChanged();
            }
        }
        private ProductImages _productImages;

        public ProductImages productImages
        {
            get { return _productImages; }
            set
            {
                _productImages = value;
                SetProperty(ref _productImages, value);
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
        private string _ExpirryDate;

        public string ExpirryDate
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

        private string _ServingSize;

        public string ServingSize
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

        public EditProductViewModel(string barcode)
        {
            barcode_string = barcode;
            NutritionFlag = false;
            LockNutrition = true;
            //GetProduct = new AddProduct();
            GetProductByBarcode(barcode);
          
        }


        public async void GetProductByBarcode(string barcode)
        {
            barcode_string = barcode;
            UserDialogs.Instance.ShowLoading("Loading product...");
            var url = ServerURL + "/api/application/products/" + barcode;       //Sample Barcode 4000417217004
            using (var http = new HttpClient())
            {
                try
                {
                    var token = await UserInfo.GetToken();
                    http.DefaultRequestHeaders.Add("auth-token", token);
                    var MainProductInJson = await http.GetStringAsync(url);
                    JObject jObject = JObject.Parse(MainProductInJson);
                    string jProduct = jObject["product"].ToString();
                    var ConvertMainProduct = JsonConvert.DeserializeObject<MainProduct>(MainProductInJson);
                    GetProduct = ConvertMainProduct;
                    var traces = CleanList.Clean(GetProduct.Product.Traces);
                    Traces = string.Join(",", traces)??"";
                    var brandslist = CleanList.Clean(GetProduct.Product.Brands);
                    Brands = string.Join(",", brandslist);
                    var catList = CleanList.Clean(GetProduct.Product.categories_tags);
                    Categories = string.Join(",",catList);
                    var lblList = CleanList.Clean(GetProduct.Product.Labels);
                    Labels =string.Join(",",lblList) ;
                    var packagesList = CleanList.Clean(GetProduct.Product.Packaging);
                    Packaging =string.Join(",",packagesList);
                    var AdditiveList = CleanList.Clean(GetProduct.Product.AdditivesTags);
                    AdditivesTags = string.Join(",",AdditiveList);
                    var allergenslist = CleanList.Clean(GetProduct.Product.Allergens);
                    Allergens = string.Join(",",allergenslist);
                    nutriments = new Nutriments();
                    nutriments = GetProduct.Product.Nutriments;
                    ServingSize =GetProduct.Product.ServingSize;
                    //Energy = nutriments.Energy ?? 0;
                    //EnergyKcal = nutriments.Energy ?? 0;
                    //Fiber = nutriments.Fiber100G ?? 0;
                    //FiberUnit = nutriments.FiberUnit ?? "";
                    //SaturatedFat = nutriments.SaturatedFat ?? 0;
                    //SaturatedFatUnit = nutriments.SaturatedFatUnit ?? "";
                    //Sugars = nutriments.Sugars ?? 0;
                    //SugarsUnit = nutriments.SugarsUnit ?? "";
                    //FruitsVegetables = nutriments.FruitsVegetablesNutsColzaWalnutOliveOils100G ?? 0;
                    //FruitsVegetablesUnit = nutriments.FruitsVegetablesNutsColzaWalnutOliveOilsUnit ?? "";
                    //Proteins = nutriments.Proteins ?? 0;
                    //ProteinsUnit = nutriments.ProteinsUnit ?? "";
                    //Sodium = nutriments.Sodium ?? 0;
                    //SodiumUnit = nutriments.SodiumUnit ?? "";
                    //Carbohydrates = nutriments.Carbohydrates ?? 0;
                    //CarbohydratesUnit = nutriments.CarbohydratesUnit ?? "";
                    //Alcohol = nutriments.Alcohol ?? 0;
                    //AlcoholUnit = nutriments.AlcoholUnit ?? "";
                    ExpirryDate = GetProduct.Product.ExpirationDate;
                    ProductName = GetProduct.Product.ProductName;
                    GenericName = GetProduct.Product.GenericName;
                    Quantity = GetProduct.Product.Quantity;
                    ProducerWebSite = GetProduct.Product.Link;
                    IngredientsList = GetProduct.Product.IngredientsText;
                    Country = string.Join(",",GetProduct.Product.Countries);
                    Stores = string.Join(",",GetProduct.Product.Stores);
                    EmbCodes = string.Join(",",GetProduct.Product.EmbCodes);
                    PurchasePlaces = string.Join(",",GetProduct.Product.PurchasePlaces);
                    ManufacturingPlaces = string.Join(",",GetProduct.Product.ManufacturingPlaces);
                    Origins = string.Join(",",GetProduct.Product.Origins);
                    Units = new List<string> { "g", "mg", "μg" };
                    RadioChoices = new List<string> { "Per 100g", "Per Serving" };
                    NutrimentsPer =GetProduct.Product.NutritionDataPer;
                    if (GetProduct.Product.AddedFromWongoo)
                    {
                        ImageFront = GetProduct.Product.ImageFrontUrl;
                        ImageIngredient = GetProduct.Product.ImageIngredientsUrl;
                        ImageNutrition = GetProduct.Product.ImageNutritionUrl;
                    }
                    else
                    {
                       ProductImages productImages=await GetImages(barcode); // method used to get images from openfoodfacts server
                        if (productImages.ImageFrontUrl != null&&productImages.ImageIngredientsUrl!=null&&productImages.ImageNutritionUrl!=null)
                        {
                       ImageFront = productImages.ImageFrontUrl;
                        ImageIngredient = productImages.ImageIngredientsUrl;
                        ImageNutrition = productImages.ImageNutritionUrl;
                        }
                        else
                        {
                            ImageFront = GetProduct.Product.ImageFrontUrl;
                            ImageIngredient = GetProduct.Product.ImageIngredientsUrl;
                            ImageNutrition = GetProduct.Product.ImageNutritionUrl;
                        }

                    }

                
                    UserDialogs.Instance.HideLoading();
                }
                catch (Exception e)
                {
                        CrossToastPopUp.Current.ShowToastError("Failed to load please try again.");
                        await Xamarin.Forms.Application.Current.MainPage.Navigation.PopModalAsync();
                    //else if (e.Message.Contains("404")) {  CrossToastPopUp.Current.ShowToastError("Invalid Barcode! Product not Found.");}
                    //else { CrossToastPopUp.Current.ShowToastError(e.Message.ToString()); }
                    UserDialogs.Instance.HideLoading();
                    //await Xamarin.Forms.Application.Current.MainPage.Navigation.PopModalAsync();
                }
            }
            //await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("title", MainProduct.Product.ProductName, "ok");
            UserDialogs.Instance.HideLoading();
        }
        public async Task<ProductImages> GetImages(string barcode)
        {
            try
            {
                UserDialogs.Instance.ShowLoading("Loading Images...");
                var image_url = ServerURL + "/api/application/products/getimage/" + barcode;
                var http = new HttpClient();
                var token = await UserInfo.GetToken();
                http.DefaultRequestHeaders.Add("auth-token", token);
                var imageInJson = await http.GetStringAsync(image_url);
                var convertFromJson = JsonConvert.DeserializeObject<ProductImages>(imageInJson);
                productImages = convertFromJson;
                return productImages;
                // await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("title", productImages.ImageFrontUrl, "ok");
            }
            catch (Exception e)
            {
                var productImages = new ProductImages();
                return productImages;
            }

        }

        public ICommand EditProductCommand => new Command(EditProduct_Command);
        // public void EditProduct_Command() { Application.Current.MainPage.DisplayAlert(nutriments.SaturatedFatUnit,nutriments.ProteinsUnit,"OK"); }
        public async void EditProduct_Command()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                CrossToastPopUp.Current.ShowToastMessage("You're offline,please check your internet connection.", Plugin.Toast.Abstractions.ToastLength.Long);
                UserDialogs.Instance.HideLoading();
                return;
            }
            var product = new AddProduct();
            product.Id = barcode_string;
            product.ProductName = ProductName;
            product.GenericName = GenericName;
            product.ExpirationDate = ExpirryDate;
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
            ServingSize = GetProduct.Product.ServingSize;
            if (NutritionFlag)
            {

                product.ServingSize = "0";
                nutriments = new Nutriments();
            }
            else { product.ServingSize = ServingSize; }
            //else
            //{
            //    nutriments = nutriments;
            //if (NutrimentsPer == "Per Serving")
            //{
            //    var nutriment = new Nutriments();
            //    product.ServingSize = ServingSize.ToString();
            //    nutriment.energy_100g = (GetProduct.Product.Nutriments.Energy / ServingSize) * 100;
            //    nutriment.Energy = (GetProduct.Product.Nutriments.Energy / ServingSize) * 100; ;
            //    nutriment.Fiber100G = GetProduct.Product.Nutriments.FiberUnit == "g" ? (GetProduct.Product.Nutriments.Fiber100G / ServingSize) * 100 : FiberUnit == "mg" ? (GetProduct.Product.Nutriments.Fiber100G / ServingSize) / 100 : (GetProduct.Product.Nutriments.Fiber100G / ServingSize) / 10000; //ternary operator to check selected unit and convert it accordingly
            //    nutriment.SaturatedFat = GetProduct.Product.Nutriments.SaturatedFatUnit == "g" ? (GetProduct.Product.Nutriments.SaturatedFat / ServingSize) * 100 : GetProduct.Product.Nutriments.SaturatedFatUnit == "mg" ? (GetProduct.Product.Nutriments.SaturatedFat / ServingSize) / 100 : (GetProduct.Product.Nutriments.SaturatedFat / ServingSize) / 10000;
            //    nutriment.SaturatedFat100G = GetProduct.Product.Nutriments.SaturatedFatUnit == "g" ? (GetProduct.Product.Nutriments.SaturatedFat / ServingSize) * 100 : GetProduct.Product.Nutriments.SaturatedFatUnit == "mg" ? (GetProduct.Product.Nutriments.SaturatedFat / ServingSize) / 100 : (GetProduct.Product.Nutriments.SaturatedFat / ServingSize) / 10000;
            //    nutriment.SaturatedFatUnit = GetProduct.Product.Nutriments.SaturatedFatUnit;
            //    nutriment.Alcohol = GetProduct.Product.Nutriments.Alcohol;
            //    nutriment.Alcohol100G = GetProduct.Product.Nutriments.Alcohol100G;
            //    nutriment.AlcoholServing = GetProduct.Product.Nutriments.AlcoholServing;
            //    nutriment.AlcoholUnit = "%vol";
            //    nutriment.AlcoholValue = GetProduct.Product.Nutriments.Alcohol;
            //    nutriment.Sugars = GetProduct.Product.Nutriments.SugarsUnit == "g" ? (GetProduct.Product.Nutriments.Sugars / ServingSize) * 100 : GetProduct.Product.Nutriments.SugarsUnit == "mg" ? (GetProduct.Product.Nutriments.Sugars / ServingSize) / 100 : (GetProduct.Product.Nutriments.Sugars / ServingSize) / 10000;
            //    nutriment.Sugars100G = GetProduct.Product.Nutriments.SugarsUnit == "g" ? (GetProduct.Product.Nutriments.Sugars / ServingSize) * 100 : GetProduct.Product.Nutriments.SugarsUnit == "mg" ? (GetProduct.Product.Nutriments.Sugars / ServingSize) / 100 : (GetProduct.Product.Nutriments.Sugars / ServingSize) / 10000;
            //    nutriment.SugarsUnit = GetProduct.Product.Nutriments.SugarsUnit;
            //    nutriment.Salt = GetProduct.Product.Nutriments.SaltUnit == "g" ? (GetProduct.Product.Nutriments.Salt / ServingSize) * 100 : GetProduct.Product.Nutriments.SaltUnit == "mg" ? (GetProduct.Product.Nutriments.Salt / ServingSize) / 100 : (GetProduct.Product.Nutriments.Salt / ServingSize) / 10000;
            //    nutriment.Salt100G = GetProduct.Product.Nutriments.SaltUnit == "g" ? (GetProduct.Product.Nutriments.Salt / ServingSize) * 100 : GetProduct.Product.Nutriments.SaltUnit == "mg" ? (GetProduct.Product.Nutriments.Salt / ServingSize) / 100 : (GetProduct.Product.Nutriments.Salt / ServingSize) / 10000;
            //    nutriment.SaltUnit = GetProduct.Product.Nutriments.SaltUnit;
            //    nutriment.Sodium = GetProduct.Product.Nutriments.SodiumUnit == "g" ? (GetProduct.Product.Nutriments.Sodium / ServingSize) * 100 : GetProduct.Product.Nutriments.SodiumUnit == "mg" ? (GetProduct.Product.Nutriments.Sodium / ServingSize) / 100 : (GetProduct.Product.Nutriments.Sodium / ServingSize) / 10000;
            //    nutriment.Sodium100G = GetProduct.Product.Nutriments.SodiumUnit == "g" ? (GetProduct.Product.Nutriments.Sodium / ServingSize) * 100 : GetProduct.Product.Nutriments.SodiumUnit == "mg" ? (GetProduct.Product.Nutriments.Sodium / ServingSize) / 100 : (GetProduct.Product.Nutriments.Sodium / ServingSize) / 10000;
            //    nutriment.SodiumUnit = GetProduct.Product.Nutriments.SodiumUnit;
            //    nutriment.Proteins = GetProduct.Product.Nutriments.ProteinsUnit == "g" ? (GetProduct.Product.Nutriments.Proteins / ServingSize) * 100 : GetProduct.Product.Nutriments.ProteinsUnit == "mg" ? (GetProduct.Product.Nutriments.Proteins / ServingSize) / 100 : (GetProduct.Product.Nutriments.Proteins / ServingSize) / 10000;
            //    nutriment.Proteins100G = GetProduct.Product.Nutriments.ProteinsUnit == "g" ? (GetProduct.Product.Nutriments.Proteins / ServingSize) * 100 : GetProduct.Product.Nutriments.ProteinsUnit == "mg" ? (GetProduct.Product.Nutriments.Proteins / ServingSize) / 100 : (GetProduct.Product.Nutriments.Proteins / ServingSize) / 10000; ;
            //    nutriment.ProteinsUnit = GetProduct.Product.Nutriments.ProteinsUnit;
            //    nutriment.NutrimentsSaturatedFat100G = GetProduct.Product.Nutriments.SaturatedFatUnit == "g" ? (GetProduct.Product.Nutriments.SaturatedFat / ServingSize) * 100 : GetProduct.Product.Nutriments.SaturatedFatUnit == "mg" ? (GetProduct.Product.Nutriments.SaturatedFat / ServingSize) / 100 : (GetProduct.Product.Nutriments.SaturatedFat / ServingSize) / 10000;
            //    nutriment.FruitsVegetablesNutsColzaWalnutOliveOils100G = GetProduct.Product.Nutriments.FruitsVegetablesNutsColzaWalnutOliveOils100G;
            //    nutriment.FruitsVegetablesNutsColzaWalnutOliveOilsUnit = GetProduct.Product.Nutriments.FruitsVegetablesNutsColzaWalnutOliveOilsUnit;
            //    nutriment.Carbohydrates = GetProduct.Product.Nutriments.Carbohydrates;
            //    nutriment.CarbohydratesUnit = GetProduct.Product.Nutriments.CarbohydratesUnit;
            //}
            //else
            //{
            //    product.ServingSize = ServingSize.ToString();
            //    nutriments.energy_100g = Energy;
            //    nutriments.Energy = Energy;
            //    nutriments.Fiber100G = Fiber;
            //    nutriments.SaturatedFat = SaturatedFat;
            //    nutriments.SaturatedFat100G = SaturatedFat;
            //    nutriments.SaturatedFatUnit = SaturatedFatUnit;
            //    nutriments.Alcohol = Alcohol;
            //    nutriments.Alcohol100G = Alcohol;
            //    nutriments.AlcoholServing = Alcohol;
            //    nutriments.AlcoholUnit = "%vol";
            //    nutriments.AlcoholValue = Alcohol;
            //    nutriments.Sugars = Sugars;
            //    nutriments.Sugars100G = Sugars;
            //    nutriments.SugarsUnit = SugarsUnit;
            //    nutriments.Salt = Salt;
            //    nutriments.Salt100G = Salt;
            //    nutriments.SaltUnit = SaltUnit;
            //    nutriments.Sodium = Sodium;
            //    nutriments.Sodium100G = Sodium;
            //    nutriments.SodiumUnit = SodiumUnit;
            //    nutriments.Proteins = Proteins;
            //    nutriments.Proteins100G = Proteins;
            //    nutriments.ProteinsUnit = ProteinsUnit;
            //    nutriments.NutrimentsSaturatedFat100G = SaturatedFat;
            //    nutriments.Carbohydrates = Carbohydrates;
            //    nutriments.CarbohydratesUnit = CarbohydratesUnit;
            //    nutriments.FruitsVegetablesNutsColzaWalnutOliveOils100G = FruitsVegetables;
            //}
            // }
            //product.Nutriments.Fiber100G = nutriments.Fiber100G;
            product.Nutriments = nutriments;
           // var s = product;
            var url = ServerURL + "/api/application/products/"+barcode_string+"/edit/";
            using (var http = new HttpClient())
            {
                try
                {
                    var jsondata = JsonConvert.SerializeObject(product);
                    var content = new StringContent(jsondata, Encoding.UTF8, "application/json");
                    var Token = await UserInfo.GetToken();
                    http.DefaultRequestHeaders.Add("auth-token", Token);
                    var message = await http.PutAsync(url, content);
                    var msg = message.Content.ReadAsStringAsync().Result;
                    if (message.IsSuccessStatusCode)
                    {
                        CrossToastPopUp.Current.ShowToastSuccess("Congrats! You updated this product successfully... waiting for admin to approve this product", Plugin.Toast.Abstractions.ToastLength.Long);
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
                return;
            }
            UserDialogs.Instance.HideLoading();
            CrossToastPopUp.Current.ShowToastWarning(res.Message);

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
                CrossToastPopUp.Current.ShowToastSuccess("Image uploaded successfully.");
                UserDialogs.Instance.HideLoading();

                return;
            }
            UserDialogs.Instance.HideLoading();
            CrossToastPopUp.Current.ShowToastWarning(res.Message);
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
                CrossToastPopUp.Current.ShowToastSuccess("Image uploaded successfully.");
                UserDialogs.Instance.HideLoading();
                return;
            }
            UserDialogs.Instance.HideLoading();
            CrossToastPopUp.Current.ShowToastWarning(res.Message);

        }

        
    }
}
