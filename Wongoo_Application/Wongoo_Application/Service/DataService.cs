using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Wongoo_Application.Shared;
using Xamarin.Forms;

namespace Wongoo_Application.Service
{
    public class DataService
    {

        public string ServerURL = ServerIP.IP + "/api/application/products/";
        public string Searchby = ServerIP.IP + "/api/application/products/all";
        public decimal totalDoc = 0;
        private readonly List<Result> _data = new List<Result>();
         
        public async Task<List<Result>> getProductsByCat(string Property,string PropertyName, int pagenumber)
        {
            var catUrl = Searchby + "/" + pagenumber + "/"+Property+"/" + PropertyName;
            var token = await UserInfo.GetToken();
            using (HttpClient http = new HttpClient())
            {
                http.DefaultRequestHeaders.Add("auth-token", token);
                var ItemInJson = await http.GetStringAsync(catUrl);
                var convertFromJson = JsonConvert.DeserializeObject<UserListProducts>(ItemInJson);
                totalDoc = convertFromJson.total_documents;
                //return convertFromJson;
                _data.AddRange(convertFromJson.result);
                return convertFromJson.result;
            }
        }
        public async Task<List<Result>> GetItemAsync(int pageIndex, int pageSize, string Property,string PropertyName)
        {
            //var data = await getProductsByCat(catName, pageIndex);
            //return data.result.Skip(pageIndex * pageSize).Take(pageSize).Select(a => a.product_name).ToList();
            //await Task.Delay(2000);
               var s=await getProductsByCat(Property,PropertyName, pageIndex);
            return _data.Skip(pageIndex * pageSize).Take(pageSize).ToList();
        }
        public decimal getTotalDocument()
        {
            return totalDoc;
        }
       

         
        public DataService()
        {
           
        }
        public async Task<CheckProductFields> CheckProductAsync(string barcode)
        {
            CheckProductFields checkProductFields = new CheckProductFields();
            if (!CrossConnectivity.Current.IsConnected)
            {
                checkProductFields.message = "You are offline,check your internet connection and try again";
                checkProductFields.ProductName = "";
                checkProductFields.GenericName = "";
                return checkProductFields;


            }
            using (var http = new HttpClient())
            {
                try
                {
                    var token = await UserInfo.GetToken();
                    http.DefaultRequestHeaders.Add("auth-token", token);
                    var MainProductInJson = await http.GetStringAsync(ServerURL + barcode);

                    JObject jObject = JObject.Parse(MainProductInJson);
                    string jProduct = jObject["product"].ToString();
                    if (jProduct.Contains("Product is not approved"))
                    {
                        checkProductFields.message = "not approved";
                        checkProductFields.ProductName = "";
                        checkProductFields.GenericName = "";
                        return checkProductFields;

                    }
                    else if (jProduct.Contains("Product is not found"))
                    {
                        checkProductFields.message = "not found";
                        checkProductFields.ProductName = "";
                        checkProductFields.GenericName = "";
                        return checkProductFields;
                    }
                    else
                    {
                        checkProductFields.message = "product found";
                        checkProductFields.ProductName = "Product name will shown here";
                        checkProductFields.GenericName = "Generic name will shown here";
                        return checkProductFields;
                    }
                }
                catch (Exception e)
                {
                    checkProductFields.message = e.Message;
                    checkProductFields.ProductName = "";
                    checkProductFields.GenericName = "";
                    return checkProductFields;
                }
            }

        }
    }
    public class CheckProductFields
    {
        public string message { get; set; }
        public string ProductName { get; set; }
        public string GenericName { get; set; }
    }
}
