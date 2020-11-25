using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TelegramBotClient.Models
{
    public class ResultUpdate
    {
        [JsonProperty(PropertyName = "update_id")]
        public int UpdateId { get; set; }
        [JsonProperty(PropertyName = "message")]
        public Message Message { get; set; }
        [JsonProperty(PropertyName = "edited_message")]
        public Message EditedMessage { get; set; }


    }
}
