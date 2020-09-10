using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wongoo_Application.Models
{
    public class ProductImages
    {
        [JsonProperty("image_nutrition_url")]
        public string ImageNutritionUrl { get; set; }

        [JsonProperty("image_ingredients_url")]
        public string ImageIngredientsUrl { get; set; }

        [JsonProperty("image_front_url")]
        public string ImageFrontUrl { get; set; }

    }
}
