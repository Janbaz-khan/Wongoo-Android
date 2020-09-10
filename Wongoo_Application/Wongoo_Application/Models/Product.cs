using Newtonsoft.Json;
using System.Collections.Generic;

namespace Wongoo_Application.Models
{
    public partial class MainProduct
    {

        [JsonProperty("product")]
        public Product Product { get; set; }
    }
       public partial class Product
    {

        public Product()
        {
            this.GenericName = "";
            this.ProductName = "";
            this.Quantity = "";
            this.ServingSize = "";
            this.NutritionDataPer = "";
            this.NutritionDataPreparedPer = "";
            this.Link = "";
            this.IngredientsText = "";
            this.ImageFrontUrl = "";
            this.ImageIngredientsUrl = "";
            ImageNutritionUrl = "";
        }
       
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
        public string NutriscoreImage { get; set; }
        [JsonProperty("nutriscore_data")]
        public NutriscoreData NutriscoreData { get; set; }

        [JsonProperty("ingredients")]
        public List<object> Ingredients { get; set; }
        [JsonProperty("added_from_wongoo")]
        public bool AddedFromWongoo { get; set; }
        

        [JsonProperty("packaging_tags")]
        public List<string> Packaging { get; set; }

        [JsonProperty("additives_tags")]
        public List<string> AdditivesTags { get; set; }

        [JsonProperty("brands_tags")]
        public List<string> Brands { get; set; }

        [JsonProperty("categories")]
        public List<string> Categories { get; set; }
        public List<string> categories_tags { get; set; }

        [JsonProperty("labels_tags")]
        public List<string> Labels { get; set; }

        [JsonProperty("manufacturing_places")]
        public List<string> ManufacturingPlaces { get; set; }

        [JsonProperty("emb_codes")]
        public List<string> EmbCodes { get; set; }

        [JsonProperty("purchase_places")]
        public List<object> PurchasePlaces { get; set; }

        [JsonProperty("stores")]
        public List<string> Stores { get; set; }

        [JsonProperty("countries")]
        public List<string> Countries { get; set; }

        [JsonProperty("allergens")]
        public List<string> Allergens { get; set; }

        [JsonProperty("traces")]
        public List<string> Traces { get; set; }

        [JsonProperty("origins")]
        public List<string> Origins { get; set; }

        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("product_name")]
        public string ProductName { get; set; }

        [JsonProperty("generic_name")]
        public string GenericName { get; set; }

        [JsonProperty("product_name_es")]
        public string ProductNameEs { get; set; }

        [JsonProperty("generic_name_es")]
        public string GenericNameEs { get; set; }

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
        public List<string> ingredients_tags { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("expiration_date")]
        public string ExpirationDate { get; set; }

        [JsonProperty("ingredients_text")]
        public string IngredientsText { get; set; }

        [JsonProperty("serving_size")]
        public string ServingSize { get; set; }
        [JsonProperty("nova_group")]
        public string NovaGroup { get; set; }
        
        [JsonProperty("nutrition_data_per")]
        public string NutritionDataPer { get; set; }

        [JsonProperty("nutrition_data_prepared_per")]
        public string NutritionDataPreparedPer { get; set; }
    }

    public partial class Nutriments
    {
        public Nutriments()
        {
       
        }
        [JsonProperty("energy")]
        public decimal? Energy { get; set; }
        public decimal? energy_100g { get; set; }

        [JsonProperty("fiber_100g")]
        public decimal? Fiber100G { get; set; }

        [JsonProperty("fiber_unit")]
#nullable   enable
        public string? FiberUnit { get; set; }
#nullable disable


        [JsonProperty("fruits_vegetables_nuts_colza_walnut_olive_oils_100g")]
        public decimal? FruitsVegetablesNutsColzaWalnutOliveOils100G { get; set; }
        [JsonProperty("fruits_vegetables_nuts_colza_walnut_olive_oils_unit")]
        public string? FruitsVegetablesNutsColzaWalnutOliveOilsUnit { get; set; }

        [JsonProperty("proteins_100g")]
        public decimal? Proteins100G { get; set; }

        [JsonProperty("saturated_fat_100g")]
        public decimal? NutrimentsSaturatedFat100G { get; set; }

        [JsonProperty("sodium_100g")]
        public decimal? Sodium100G { get; set; }

        [JsonProperty("sugars_100g")]
        public decimal? Sugars100G { get; set; }

        [JsonProperty("saturated_fat")]
        public decimal? SaturatedFat { get; set; }

        [JsonProperty("saturated-fat_100g")]
        public decimal? SaturatedFat100G { get; set; }

        [JsonProperty("saturated-fat_unit")]
#nullable enable
        public string? SaturatedFatUnit { get; set; }
#nullable disable

        [JsonProperty("alcohol")]
        public decimal? Alcohol { get; set; }

        [JsonProperty("alcohol_100g")]
        public decimal? Alcohol100G { get; set; }

        [JsonProperty("alcohol_serving")]
        public decimal? AlcoholServing { get; set; }

        [JsonProperty("alcohol_unit")]
#nullable enable
        public string? AlcoholUnit { get; set; }
#nullable disable

        [JsonProperty("alcohol_value")]
        public decimal? AlcoholValue { get; set; }

        [JsonProperty("proteins")]
        public decimal? Proteins { get; set; }

        [JsonProperty("proteins_unit")]
#nullable enable
        public string? ProteinsUnit { get; set; }
#nullable disable

        [JsonProperty("salt")]
        public decimal? Salt { get; set; }

        [JsonProperty("salt_100g")]
        public decimal? Salt100G { get; set; }

        [JsonProperty("salt_unit")]
#nullable enable
        public string? SaltUnit { get; set; }
#nullable disable

        [JsonProperty("sodium")]
        public decimal? Sodium { get; set; }

        [JsonProperty("sodium_unit")]
#nullable enable
        public string? SodiumUnit { get; set; }
#nullable disable

        [JsonProperty("sugars")]
        public decimal? Sugars { get; set; }

        [JsonProperty("sugars_unit")]
#nullable enable
        public string? SugarsUnit { get; set; }
#nullable disable
        [JsonProperty("carbohydrates")]
        public decimal? Carbohydrates { get; set; }
        [JsonProperty("carbohydrates_unit")]
#nullable enable
        public string? CarbohydratesUnit { get; set; }
#nullable disable
    }

    public partial class NutriscoreData
    {
        public NutriscoreData()
        {
            Grade = "";
        }
        [JsonProperty("energy")]
        public decimal? Energy { get; set; }

        [JsonProperty("energy_points")]
        public decimal? EnergyPoints { get; set; } 

        [JsonProperty("energy_value")]
        public decimal? EnergyValue { get; set; }

        [JsonProperty("fiber")]
        public decimal? Fiber { get; set; }

        [JsonProperty("fiber_points")]
        public decimal? FiberPoints { get; set; }

        [JsonProperty("fiber_value")]
        public decimal? FiberValue { get; set; }

        [JsonProperty("fruits_vegetables_nuts_colza_walnut_olive_oils")]
        public decimal? FruitsVegetablesNutsColzaWalnutOliveOils { get; set; }

        [JsonProperty("fruits_vegetables_nuts_colza_walnut_olive_oils_points")]
        public decimal? FruitsVegetablesNutsColzaWalnutOliveOilsPoints { get; set; }

        [JsonProperty("fruits_vegetables_nuts_colza_walnut_olive_oils_value")]
        public decimal? FruitsVegetablesNutsColzaWalnutOliveOilsValue { get; set; }

        [JsonProperty("is_beverage")]
        public decimal? IsBeverage { get; set; }

        [JsonProperty("is_cheese")]
        public decimal? IsCheese { get; set; }

        [JsonProperty("is_fat")]
        public decimal? IsFat { get; set; }

        [JsonProperty("is_water")]
        public decimal? IsWater { get; set; }

        [JsonProperty("negative_points")]
        public decimal? NegativePoints { get; set; }

        [JsonProperty("positive_points")]
        public decimal? PositivePoints { get; set; }

        [JsonProperty("proteins")]
        public decimal? Proteins { get; set; }

        [JsonProperty("proteins_points")]
        public decimal? ProteinsPoints { get; set; }

        [JsonProperty("proteins_value")]
        public decimal? ProteinsValue { get; set; }

        [JsonProperty("saturated_fat")]
        public decimal? SaturatedFat { get; set; }

        [JsonProperty("saturated_fat_points")]
        public decimal? SaturatedFatPoints { get; set; }

        [JsonProperty("saturated_fat_ratio")]
        public decimal? SaturatedFatRatio { get; set; }

        [JsonProperty("saturated_fat_ratio_points")]
        public decimal? SaturatedFatRatioPoints { get; set; }

        [JsonProperty("saturated_fat_ratio_value")]
        public decimal? SaturatedFatRatioValue { get; set; }

        [JsonProperty("saturated_fat_value")]
        public decimal? SaturatedFatValue { get; set; }

        [JsonProperty("score")]
        public decimal? Score { get; set; }

        [JsonProperty("sodium")]
        public decimal? Sodium { get; set; }

        [JsonProperty("sodium_points")]
        public decimal? SodiumPoints { get; set; }

        [JsonProperty("sodium_value")]
        public decimal? SodiumValue { get; set; }

        [JsonProperty("sugars")]
        public decimal? Sugars { get; set; }

        [JsonProperty("sugars_points")]
        public decimal? SugarsPoints { get; set; }

        [JsonProperty("sugars_value")]
        public decimal? SugarsValue { get; set; }


        [JsonProperty("grade")]
#nullable enable
        public string? Grade { get; set; }
#nullable disable
    }
}
