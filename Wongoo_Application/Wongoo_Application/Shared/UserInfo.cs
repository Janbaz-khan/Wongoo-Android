using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Wongoo_Application.ViewModels;
using Xamarin.Essentials;

namespace Wongoo_Application.Shared
{
    public class UserInfo : BaseViewModel
    {
        public static async Task<UserStoredInfo> GetUserNameAsync(string Token)
        {
            
            using (var http = new HttpClient())
            {
                http.DefaultRequestHeaders.Add("auth-token", Token);
                string response = await http.GetStringAsync(ServerIP.IP+"/api/application/users/");
                var json = JsonConvert.DeserializeObject<Models.UserData>(response);
                UserStoredInfo userStoringInfo = new UserStoredInfo();
                userStoringInfo.Name = json.Users.Name;
                userStoringInfo.Email = json.Users.Email;
                userStoringInfo.Token = Token;
                userStoringInfo.Status = json.Users.Status;
                userStoringInfo.Products = json.Users.Products;
                userStoringInfo.History = json.Users.History;
                return userStoringInfo;
            }
        }
        public async static Task<List<string>> GetUserFavouratesAsync(string Token)
        {
            //if (!CrossConnectivity.Current.IsConnected)
            //{
            //    await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Error", "You're disconnected! please check your internet connection and try again", "OK");
            //    //  await Navigation.PushAsync(new UserPage());
            //    System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();

            //}
            using (var http = new HttpClient())
            {
                http.DefaultRequestHeaders.Add("auth-token", Token);
                string response = await http.GetStringAsync(ServerIP.IP+"/api/application/users/");
                var json = JsonConvert.DeserializeObject<Models.UserData>(response);
                return json.Users.Products;
            }
        }
           
        public async static Task<UserListProducts> GetUserListProducts(List<string> products)
        {
            //if (!CrossConnectivity.Current.IsConnected)
            //{
            //    await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Error", "You're disconnected! please check your internet connection and try again", "OK");
            //  //  await Navigation.PushAsync(new UserPage());
            //    System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();

            //}
            listOfProducts listOfProducts = new listOfProducts();
            listOfProducts.products = products;
            using (var http = new HttpClient())
            {
                var Token = await GetToken();
                http.DefaultRequestHeaders.Add("auth-token", Token);
                var jsondata = JsonConvert.SerializeObject(listOfProducts);
                var content = new StringContent(jsondata, Encoding.UTF8, "application/json");
                var response = await http.PostAsync(ServerIP.IP+"/api/application/products/search/",content);
                var jsonRes =await response.Content.ReadAsStringAsync();
                var DesSerialized = JsonConvert.DeserializeObject<UserListProducts>(jsonRes);
                return DesSerialized;
            }
        }
        public async static Task<List<string>> GetUserFavourateLocal()
        {
            var StringProduct =await SecureStorage.GetAsync("Products");
            var p = StringProduct.Split(',').ToList();
            return p;
        }
        public static async Task<string> GetToken()
        {
            string token=await SecureStorage.GetAsync("Token");
            return token;
        }
        public static  bool IsAccountVerified()
        {
           string boolean =  SecureStorage.GetAsync("Status").Result;
           return Convert.ToBoolean(boolean);
        }
        public static string GetEmail()
        {
            string email = SecureStorage.GetAsync("Email").Result;
            return email;
        }
      
    }
   
   public   class UserStoredInfo
    {
        public  string Token { get; set; }
        public  string Name { get; set; }
        public  string Email { get; set; }
        public bool Status { get; set; }
        public List<string> Products { get; set; }
        public List<string> History { get; set; }
    }
    public class Result
    {
        public string _id { get; set; }
        public string product_name { get; set; }
    }
    public class UserListProducts
    {
        public int total_documents { get; set; }
        public List<Result> result { get; set; }
    }

   public class listOfProducts
    {
        public List<string> products { get; set; }
    }
}
