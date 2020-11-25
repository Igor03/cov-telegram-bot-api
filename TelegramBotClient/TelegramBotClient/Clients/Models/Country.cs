using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBotTelegram.Models
{
    public class Country
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "countryName")]
        public string CountryName { get; set; }
        [JsonProperty(PropertyName = "countryNameSearch")]
        public string CountryNameSearch { get; set; }
        [JsonProperty(PropertyName = "region")]
        public string Region { get; set; }
        [JsonProperty(PropertyName = "subregion")]
        public string Subregion { get; set; }
        [JsonProperty(PropertyName = "population")]
        public int Population { get; set; }
        [JsonProperty(PropertyName = "lastSearch")]
        public DateTime LastSearch { get; set; }
    }
}
