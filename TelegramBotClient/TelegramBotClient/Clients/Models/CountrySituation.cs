using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBotTelegram.Models
{
    public class CountrySituation
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "country")]
        public Country Country { get; set; }
        [JsonProperty(PropertyName = "activeCases")]
        public int ActiveCases { get; set; }
        [JsonProperty(PropertyName = "recoveredCases")]
        public int RecoveredCases { get; set; }
        [JsonProperty(PropertyName = "fatalCases")]
        public int FatalCases { get; set; }
        [JsonProperty(PropertyName = "searchDate")]
        public DateTime SearchDate { get; set; }
}
}
