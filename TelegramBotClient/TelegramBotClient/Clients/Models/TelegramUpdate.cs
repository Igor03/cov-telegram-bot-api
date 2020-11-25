using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TelegramBotClient.Models
{
    public class TelegramUpdate
    {
        [JsonProperty(PropertyName = "ok")]
        public string Status { get; set; }
        [JsonProperty(PropertyName = "result")]
        public List<ResultUpdate> Result;
  
    }
}
