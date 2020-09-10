using Acr.UserDialogs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Plugin.Toast;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Wongoo_Application.Models;
using Wongoo_Application.Models.Favourites;
using Wongoo_Application.Shared;
using Wongoo_Application.Shared.Persistence;
using Wongoo_Application.Views;
using Wongoo_Application.Views.PopUp;
using WongooNavigation;
using Xamarin.Essentials;
using Xamarin.Forms;
using XF.Material.Forms.UI.Dialogs;

namespace Wongoo_Application.ViewModels
{

    public class ProductViewModel : BaseViewModel
    {
        public string ServerURL = ServerIP.IP;
        //Commands
        public string barcode_string;
        public ObservableCollection<Allegens> allergensDbList;
        private SQLiteAsyncConnection _connection;
        //Properties
        #region Properties

        private string _ExpirationDate;

        public string ExpirationDate
        {
            get { return _ExpirationDate; }
            set
            {
                _ExpirationDate = value;
                OnPropertyChanged();
                SetProperty(ref _ExpirationDate, value);
            }
        }
        private bool _novaEmpty=false;

        public bool novaEmpty
        {
            get { return _novaEmpty; }
            set { _novaEmpty = value;
                OnPropertyChanged();
                SetProperty(ref _novaEmpty, value);
            }
        }
        private bool _novaNotEmpty = false;

        public bool novaNotEmpty
        {
            get { return _novaNotEmpty; }
            set
            {
                _novaNotEmpty = value;
                OnPropertyChanged();
                SetProperty(ref _novaNotEmpty, value);
            }
        }
        private string _Quantity;

        public string Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value;
                SetProperty(ref _Quantity, value);
                OnPropertyChanged();
            }
        }


        private bool _IsRefresh;

        public bool IsRefresh
        {
            get { return _IsRefresh; }
            set
            {
                _IsRefresh = value;
                SetProperty(ref _IsRefresh, value);
                OnPropertyChanged();
            }
        }

        private bool _AllergenAllertVisible;

        public bool AllergenAllertVisible
        {
            get { return _AllergenAllertVisible; }
            set
            {
                _AllergenAllertVisible = value;
                SetProperty(ref _AllergenAllertVisible, value);
                OnPropertyChanged();
            }
        }
        private string _AllergenAllertText;

        public string AllergenAllertText
        {
            get { return _AllergenAllertText; }
            set
            {
                _AllergenAllertText = value;
                SetProperty(ref _AllergenAllertText, value);
                OnPropertyChanged();
            }
        }
        private bool _HaramAlert;

        public bool HaramAlert
        {
            get { return _HaramAlert; }
            set
            {
                _HaramAlert = value;
                SetProperty(ref _HaramAlert, value);
                OnPropertyChanged();
            }
        }

        private string _CatListHeight;

        public string CatListHeight
        {
            get { return _CatListHeight; }
            set
            {
                _CatListHeight = value;
                SetProperty(ref _CatListHeight, value);
                OnPropertyChanged();
            }
        }
        private List<string> _Category;

        public List<string> Category
        {
            get { return _Category; }
            set
            {
                _Category = value;
                SetProperty(ref _Category, value);
                OnPropertyChanged();
            }
        }
        private List<string> _Brands;

        public List<string> Brands
        {
            get { return _Brands; }
            set
            {
                _Brands = value;
                SetProperty(ref _Brands, value);
                OnPropertyChanged();
            }
        }

        private string _BrandsListHeight;

        public string BrandsListHeight
        {
            get { return _BrandsListHeight; }
            set
            {
                _BrandsListHeight = value;
                SetProperty(ref _BrandsListHeight, value);
                OnPropertyChanged();
            }
        }
        private string _LabelHeight;

        public string LabelHeight
        {
            get { return _LabelHeight; }
            set
            {
                _LabelHeight = value;
                SetProperty(ref _LabelHeight, value);
                OnPropertyChanged();
            }
        }
        private List<string> _Labels;

        public List<string> Labels
        {
            get { return _Labels; }
            set
            {
                _Labels = value;
                SetProperty(ref _Labels, value);
                OnPropertyChanged();
            }
        }

        private string _PackHeight;

        public string PackHeight
        {
            get { return _PackHeight; }
            set
            {
                _PackHeight = value;
                SetProperty(ref _PackHeight, value);
                OnPropertyChanged();
            }
        }
        private List<string> _Packages;

        public List<string> Packages
        {
            get { return _Packages; }
            set
            {
                _Packages = value;
                SetProperty(ref _Packages, value);
                OnPropertyChanged();
            }
        }
        private string _AdditiveHeight;

        public string AdditiveHeight
        {
            get { return _AdditiveHeight; }
            set
            {
                _AdditiveHeight = value;
                SetProperty(ref _AdditiveHeight, value);
                OnPropertyChanged();
            }
        }
        private List<string> _Additives;

        public List<string> Additives
        {
            get { return _Additives; }
            set
            {
                _Additives = value;
                SetProperty(ref _Additives, value);
                OnPropertyChanged();
            }
        }

        private List<string> _Traces;

        public List<string> Traces
        {
            get { return _Traces; }
            set
            {
                _Traces = value;
                SetProperty(ref _Traces, value);
                OnPropertyChanged();
            }
        }
        private List<string> _Allergens;

        public List<string> Allergens
        {
            get { return _Allergens; }
            set
            {
                _Allergens = value;
                SetProperty(ref _Allergens, value);
                OnPropertyChanged();
            }
        }



        private bool _ShowPopup;
        public bool ShowPopup
        {
            get { return _ShowPopup; }
            set
            {
                _ShowPopup = value;
                SetProperty(ref _ShowPopup, value);
                OnPropertyChanged();
            }
        }
        private bool _EnableTab;
        public bool EnableTab
        {
            get { return _EnableTab; }
            set
            {
                _EnableTab = value;
                SetProperty(ref _EnableTab, value);
                OnPropertyChanged();
            }
        }

        private bool _IsRunning;
        public bool IsRunning
        {
            get { return _IsRunning; }
            set
            {
                _IsRunning = value;
                SetProperty(ref _IsRunning, value);
                OnPropertyChanged();
            }
        }
        private string _favImage;

        public string favImage
        {
            get { return _favImage; }
            set
            {
                _favImage = value;
                SetProperty(ref _favImage, value);
                OnPropertyChanged();
            }
        }
        private bool _FavStatus;

        public bool FavStatus
        {
            get { return _FavStatus; }
            set { _FavStatus = value; }
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
        private string _NutriScoreImage;

        public string NutriScoreImage
        {
            get { return _NutriScoreImage; }
            set
            {
                _NutriScoreImage = value;
                SetProperty(ref _NutriScoreImage, value);
                OnPropertyChanged();
            }
        }
        private string _NovaGroup;

        public string NovaGroup
        {
            get { return _NovaGroup; }
            set
            {
                _NovaGroup = value;
                SetProperty(ref _NovaGroup, value);
                OnPropertyChanged();
            }
        }

        private ObservableCollection<MainProduct> _MainProducts;

        public ObservableCollection<MainProduct> MainProducts
        {
            get { return _MainProducts; }
            set
            {
                _MainProducts = value;
                SetProperty(ref _MainProducts, value);
                OnPropertyChanged();
            }
        }
        private MainProduct _MainProduct;
        public MainProduct MainProduct
        {
            get { return _MainProduct; }
            set
            {
                _MainProduct = value;
                SetProperty(ref _MainProduct, value);
                OnPropertyChanged();
            }
        }

        #endregion
        public ProductViewModel(string barcode)
        {
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            AllergenAllertVisible = false;
            HaramAlert = false;
            barcode_string = barcode;
            EnableTab = true;
            ShowPopup = false;
            MainProducts = new ObservableCollection<MainProduct>();
            MainProduct = new MainProduct();
            productImages = new ProductImages();
            IsRunning = true;
            viewMainProductByBarcode(barcode);
        }
        public async Task<string> CheckAllergen()
        {
            await _connection.CreateTableAsync<Allegens>();
            var getList = await _connection.Table<Allegens>().ToListAsync();
            if (getList.Count > 0)
            {
                allergensDbList = new ObservableCollection<Allegens>(getList);
                var foundAllergen = new List<string>();
                foreach (var item in allergensDbList)
                {
                    int count = Allergens.Where(a => a.Contains(item.AllergenAlert.ToLower())).Count();
                    if (count > 0)
                    {
                        foundAllergen.Add(item.AllergenAlert);
                    }
                }
                string allergenFinal = string.Join(",", foundAllergen);
                if (allergenFinal != "")
                {
                    return "Allergen Alert! This product contains: " + allergenFinal;
                }
                return "";
            }
            return "";
        }
        public bool CheckFoodForHaram(string searchtype = "category")
        {
            if (searchtype == "category")
            {
                foreach (var item in Category)
                {
                    if (item.ToLower().Contains("pork"))
                    {
                        return true;
                    }
                }
            }
            else
            {
                foreach (var item in Labels)
                {
                    if (item.ToLower().Contains("pork"))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        //Methods
        #region Methods



        public async void viewMainProductByBarcode(string barcode)
        {
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
                    if (jProduct.Contains("Product is not approved"))
                    {
                        CrossToastPopUp.Current.ShowToastError("Product is not approved by administrator");
                        await Xamarin.Forms.Application.Current.MainPage.Navigation.PopModalAsync();
                        UserDialogs.Instance.HideLoading();
                        IsRunning = false;
                        return;

                    }
                    if (jProduct.Contains("Product is not found"))
                    {
                        ShowPopup = true;
                        EnableTab = false;
                        CrossToastPopUp.Current.ShowToastError("Product not found against this barcode.");
                        UserDialogs.Instance.HideLoading();
                        IsRunning = false;
                        return;
                        // await Xamarin.Forms.Application.Current.MainPage.Navigation.PopModalAsync();

                    }
                    var ConvertMainProduct = JsonConvert.DeserializeObject<MainProduct>(MainProductInJson);
                    MainProduct = ConvertMainProduct;
                    Quantity = MainProduct.Product.Quantity == "" ? "0" : MainProduct.Product.Quantity;
                    ExpirationDate = (MainProduct.Product.ExpirationDate == "" || MainProduct.Product.ExpirationDate == null) ? "00/00/0000" : MainProduct.Product.ExpirationDate;
                    Traces = CleanList.Clean(MainProduct.Product.Traces);
                    var Catrows = MainProduct.Product.categories_tags.Count();
                    CatListHeight = (40 * Catrows).ToString();
                    var labelRow = MainProduct.Product.Labels.Count();
                    var BrandRows = MainProduct.Product.Brands.Count();
                    BrandsListHeight = (40 * BrandRows).ToString();
                    var brandslist = MainProduct.Product.Brands;
                    Brands = CleanList.Clean(brandslist);
                    var catList = MainProduct.Product.categories_tags;
                    Category = CleanList.Clean(catList);
                    HaramAlert = CheckFoodForHaram();
                    LabelHeight = (40 * labelRow).ToString();
                    var lblList = MainProduct.Product.Labels;
                    Labels = CleanList.Clean(lblList);
                    if (!HaramAlert)
                    {
                        HaramAlert = CheckFoodForHaram("label");
                    }
                    var PackRow = MainProduct.Product.Packaging.Count();
                    PackHeight = (40 * PackRow).ToString();
                    var packagesList = MainProduct.Product.Packaging;
                    Packages = CleanList.Clean(packagesList);
                    var additiveRow = MainProduct.Product.AdditivesTags.Count();
                    var AdditiveList = MainProduct.Product.AdditivesTags;
                    Additives = CleanList.Clean(AdditiveList);
                    var allergenslist = MainProduct.Product.Allergens;
                    Allergens = CleanList.Clean(allergenslist);
                    AdditiveHeight = (40 * additiveRow).ToString();
                    NovaGroup = (MainProduct.Product.NovaGroup == "" || MainProduct.Product.NovaGroup == null || MainProduct.Product.NovaGroup.Contains("0")) ? "Not calculated": "N" + MainProduct.Product.NovaGroup + ".png";
                    if (NovaGroup == "Not calculated")
                    {
                        novaEmpty = true;
                        novaNotEmpty = false;
                    }
                    else
                    {
                        novaEmpty = false;
                        novaNotEmpty = true;
                    }
                    NutriScoreImage = MainProduct.Product.NutriscoreData.Grade.ToUpper() + ".png";
                    AllergenAllertText = await CheckAllergen();
                    if (AllergenAllertText != "")
                    {
                        AllergenAllertVisible = true;
                    }
                    if (MainProduct.Product.NutriscoreData.Grade == "")
                    {
                        NutriScoreImage = "nonutriscore.png";
                    }
                    if (MainProduct.Product.AddedFromWongoo)
                    {
                        ProductImages productimages = new ProductImages();
                        productimages.ImageFrontUrl = ServerURL + MainProduct.Product.ImageFrontUrl;
                        productimages.ImageIngredientsUrl = ServerURL + MainProduct.Product.ImageIngredientsUrl;
                        productimages.ImageNutritionUrl = ServerURL + MainProduct.Product.ImageNutritionUrl;
                        productImages = productimages;
                    }
                    else
                    {
                        GetImages(barcode); // method used to get images from openfoodfacts server
                    }
                    UserDialogs.Instance.HideLoading();
                    IsRunning = false;
                }
                catch (Exception e)
                {
                    if (e.Message.Contains("Product is not Approved"))
                    {
                        CrossToastPopUp.Current.ShowToastError("Product not found or may not Approved");
                        await Xamarin.Forms.Application.Current.MainPage.Navigation.PopModalAsync();
                    }
                    //else if (e.Message.Contains("404")) {  CrossToastPopUp.Current.ShowToastError("Invalid Barcode! Product not Found.");}
                    //else { CrossToastPopUp.Current.ShowToastError(e.Message.ToString()); }
                    UserDialogs.Instance.HideLoading();
                    //await Xamarin.Forms.Application.Current.MainPage.Navigation.PopModalAsync();
                }
            }
            //await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("title", MainProduct.Product.ProductName, "ok");
            UserDialogs.Instance.HideLoading();
            IsRunning = false;
        }
        public async void GetImages(string barcode)
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
                if (convertFromJson!=null)
                {
                productImages = convertFromJson;
                }
                else
                {
                    productImages.ImageFrontUrl = ServerURL + MainProduct.Product.ImageFrontUrl;
                    productImages.ImageIngredientsUrl = ServerURL + MainProduct.Product.ImageIngredientsUrl;
                    productImages.ImageNutritionUrl = ServerURL + MainProduct.Product.ImageNutritionUrl;
                }
                UserDialogs.Instance.HideLoading();
                // await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("title", productImages.ImageFrontUrl, "ok");
            }
            catch (Exception e)
            {
                await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Failed to load", e.Message, "ok");
            }
        }
        public ICommand ViewProductImage => new Command(ViewProduct_Image);
        public async void ViewProduct_Image()
        {
            try
            {
                string image = "";
                if (MainProduct.Product.AddedFromWongoo)
                {
                      //await Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new ImageViewer(productImages.ImageFrontUrl));

                    image = productImages.ImageFrontUrl;
                }
                else
                {
                    var imagefront = productImages.ImageFrontUrl.Replace(".400.jpg", ".full.jpg");

                    image = imagefront;

                }
                await Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new ImageViewer(image));
               
            }
            catch (Exception e)
            {
            }
        }
        public ICommand RefreshData => new Command(RefreshingData);
        public void RefreshingData()
        {
            IsRefresh = true;
            viewMainProductByBarcode(barcode_string);
            IsRefresh = false;
        }
        public ICommand ViewIngredientImage => new Command(ViewIngredient_Image);
        public async void ViewIngredient_Image()
        {
            try
            {
                string image = "";
                if (MainProduct.Product.AddedFromWongoo)
                {
                    image = productImages.ImageIngredientsUrl;
                }
                else
                {
                    var imageIngredients = productImages.ImageIngredientsUrl.Replace(".400.jpg", ".full.jpg");
                    image = imageIngredients;
                }
                await Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new ImageViewer(image));
            }
            catch (Exception e)
            {
            }
        }
        public ICommand ViewNutritionImage => new Command(ViewNutrition_Image);
        public async void ViewNutrition_Image()
        {
            try
            {
                string image = "";
                if (MainProduct.Product.AddedFromWongoo)
                {
                    image = productImages.ImageNutritionUrl;
                }
                else
                {
                    var imageNutriton = productImages.ImageNutritionUrl.Replace(".400.jpg", ".full.jpg");
                    image = imageNutriton;
                }
                await Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new ImageViewer(image));
               }
            catch (Exception e)
            {
            }
        }
        public ICommand AddToFavourites => new Command(AddToFav);
        public async void AddToFav()
        {
            var favProduct = new FavouriteProduct();
            favProduct.Barcode = barcode_string;
            favProduct.ProductName = MainProduct.Product.ProductName;
            await Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new UserList2(favProduct));
        }
        public ICommand Cancel => new Command(GoBack);
        public async void GoBack()
        {

            await Xamarin.Forms.Application.Current.MainPage.Navigation.PopModalAsync();
        }
        public ICommand GotoAddProduct => new Command(AddProductPage);
        public async void AddProductPage()
        {
            UserDialogs.Instance.ShowLoading("Wait a second...");
            await Xamarin.Forms.Application.Current.MainPage.Navigation.PopModalAsync();
            await Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new WongooNavigation.AddProduct(barcode_string));
            UserDialogs.Instance.HideLoading();
        }
        #endregion
    }
    public class userFavourate
    {
        public string product_id { get; set; }
    }
}
