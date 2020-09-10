using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Wongoo_Application.Models
{
    public partial class AddProduct
    {

        public AddProduct()
        {
            // ExpirationDate = "6/10/2020";
            this.GenericName = "";
            this.ProductName = "";
            this.Quantity = "";
            this.ServingSize = "";
            this.NutritionDataPer = "";
            this.NutritionDataPreparedPer = "";
            this.Link = "";
          
        }

        //[JsonProperty("ingredients")]
        //public List<object> Ingredients { get; set; }

        [JsonProperty("packaging")]
        public  string Packaging { get; set; }
        [JsonProperty("additives_tags")]
        public string AdditivesTags { get; set; }
        

        [JsonProperty("brands")]
        public  string Brands { get; set; }

        [JsonProperty("categories")]
        public  string Categories { get; set; }

        [JsonProperty("labels")]
        public  string Labels { get; set; }

        [JsonProperty("manufacturing_places")]
        public  string ManufacturingPlaces { get; set; }

        [JsonProperty("emb_codes")]
        public  string EmbCodes { get; set; }

        [JsonProperty("purchase_places")]
        public  string PurchasePlaces { get; set; }

        [JsonProperty("stores")]
        public  string Stores { get; set; }

        [JsonProperty("countries")]
        public string Countries { get; set; }

        [JsonProperty("allergens")]
        public  string Allergens { get; set; }

        [JsonProperty("traces")]
        public  string Traces { get; set; }

        [JsonProperty("origins")]
        public  string Origins { get; set; }

        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("product_name")]
        public string ProductName { get; set; }

        [JsonProperty("generic_name")]
        public string GenericName { get; set; }

        [JsonProperty("quantity")]
        public string Quantity { get; set; }

        [JsonProperty("nutriments")]
#nullable enable
        public Nutriments? Nutriments { get; set; }
#nullable disable

        [JsonProperty("image_nutrition_url")]
        public string ImageNutritionUrl { get; set; }

        [JsonProperty("image_front_url")]
        public string ImageFrontUrl { get; set; }

        [JsonProperty("image_ingredients_url")]
        public string ImageIngredientsUrl { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("expiration_date")]
        public string ExpirationDate { get; set; }

        [JsonProperty("ingredients_text")]
        public string IngredientsText { get; set; }

        [JsonProperty("serving_size")]
        public string ServingSize { get; set; }

        [JsonProperty("nutrition_data_per")]
        public string NutritionDataPer { get; set; }

        [JsonProperty("nutrition_data_prepared_per")]
        public string NutritionDataPreparedPer { get; set; }
    }

}
