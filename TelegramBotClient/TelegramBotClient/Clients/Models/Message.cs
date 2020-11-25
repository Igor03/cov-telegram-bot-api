using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TelegramBotClient.Models
{
    public class Message
    {
        [JsonProperty(PropertyName = "message_id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "from")]
        public MessageFrom From { get; set; }

        [JsonProperty(PropertyName = "chat")]
        public ChatInfo Chat { get; set; }
        [JsonProperty(PropertyName = "date")]
        public string Date { get; set; }
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

    }
}
