using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TelegramBotClient.Models
{
    public class MessageTo
    {
        [JsonProperty(PropertyName = "chat_id")]
        public string ChatId { get; set; }
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }                               
    }
}
