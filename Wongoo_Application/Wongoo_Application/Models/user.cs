using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Wongoo_Application.Models
{

    public partial class UserData
    {
        [JsonProperty("user")]
        public Users Users { get; set; }
    }

    public partial class Users
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("date_added")]
        public string DateAdded { get; set; }

        [JsonProperty("products")]
        public List<string> Products { get; set; }
        [JsonProperty("search_history")]
        public List<string> History { get; set; }
    }

}
