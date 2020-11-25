using ApiBotTelegram.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TelegramBotClient.Models;

namespace TelegramBotClient.Clients
{
    public class TeleBotClient
    {


        public static string TOKEN = Environment.GetEnvironmentVariable("TELEGRAM-BOT-TOKEN");                
        public static HttpClient ApiClient;
        public static string BaseURL = $"https://api.telegram.org/";

        public static async Task<TelegramUpdate> GetUpdates(int offset)
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string _url = BaseURL + $"{TOKEN}/getUpdates";

            var content = new StringContent($"{{\"offset\": \"{offset.ToString()}\"}}",
                    Encoding.UTF8,
                    "application/json");

            using (HttpResponseMessage response = await ApiClient.PostAsync(_url, content))
            {
                if (response.IsSuccessStatusCode)
                {
                    TelegramUpdate result = await response.Content.ReadAsAsync<TelegramUpdate>();
                    return result;
                }
                else
                    throw new Exception(response.ReasonPhrase);
            }
        }       

        public static int GetLastUpdateId(TelegramUpdate telegramUpdate)
        {
            return telegramUpdate.Result.Count == 0 ? 0 : telegramUpdate.Result[telegramUpdate.Result.Count - 1].UpdateId;
        }

        // Offset da requisicao
        public static async Task<TelegramUpdate> GetLastUpdateOb()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string _url = BaseURL + $"{TOKEN}/getUpdates";

            using (HttpResponseMessage response = await ApiClient.GetAsync(_url))
            {
                if (response.IsSuccessStatusCode)
                {
                    TelegramUpdate result = await response.Content.ReadAsAsync<TelegramUpdate>();
                    return result;
                }
                else
                    throw new Exception(response.ReasonPhrase);
            }
        }

        public static int GetChatId(TelegramUpdate telegramUpdate)
        {
            int chatId;
            try
            {
                chatId = telegramUpdate.Result.Count == 0 ? 0 : telegramUpdate.Result[telegramUpdate.Result.Count - 1].Message.Chat.Id;                
            } 
            catch (NullReferenceException)
            {
                chatId = telegramUpdate.Result.Count == 0 ? 0 : telegramUpdate.Result[telegramUpdate.Result.Count - 1].EditedMessage.Chat.Id;                
            }
            catch (Exception e)
            {
                throw (e);
            }
            return chatId;


        }

        public static async Task<HttpResponseMessage> SendMessage(string ChatId, string Text)
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string _url = BaseURL + $"{TOKEN}/sendMessage";

            MessageTo _messageTo = new MessageTo
            {
                ChatId = ChatId,
                Text = Text
            };

            // Serializando objeto
            var content = new StringContent(JsonConvert.SerializeObject(_messageTo),
                    Encoding.UTF8,
                    "application/json");

            using (HttpResponseMessage response = await ApiClient.PostAsync(_url, content))
            {
                if (response.IsSuccessStatusCode)
                    return response;
                else
                    throw new Exception(response.ReasonPhrase);
            }
        }

        public static string BuildResponseString(int Active, int Recovered, int Fatal, string Date)
        {
            return $@"Ativos: {Active}
                    Recuperados: {Recovered}
                    Fatais: {Fatal}
                    Referente: {Date}";
        }

        public static string GetAllCommands()
        {
            throw new NotImplementedException();
        }

        public async void Inicializar()
        {
            // int _lastUpdate = await GetLastUpdate();
            
            
            TelegramUpdate _telegramUpdate = await GetLastUpdateOb();
            int lastUpdate = GetLastUpdateId(_telegramUpdate);
            int chatId = GetChatId(_telegramUpdate);
            
            List<CountrySituation> cs;
            TelegramUpdate newMessage;
            while (true)
            {
                if (GetLastUpdateId (await GetLastUpdateOb()) <= lastUpdate) continue;

                _telegramUpdate = await GetLastUpdateOb();
                lastUpdate = GetLastUpdateId(_telegramUpdate);
                newMessage = await GetUpdates(lastUpdate);
                chatId = GetChatId(_telegramUpdate);

                if (newMessage.Result[0].Message.Text == "/help")
                {
                    //await SendMessage("869476690", "Bot description");
                    await SendMessage(chatId.ToString(), "Bot description");
                }
                else if (newMessage.Result[0].Message.Text == "/commands")
                {
                    //await SendMessage("869476690", "Building...!");
                    await SendMessage(chatId.ToString(), "Building...!");
                }
                else
                {
                    cs = await CovidAPIClient.GetCountrySituation(newMessage.Result[0].Message.Text.Replace("/", ""));

                    if (cs.Count != 0)
                        await SendMessage(chatId.ToString(), BuildResponseString(cs[0].ActiveCases,
                            cs[0].RecoveredCases,
                            cs[0].FatalCases,
                            cs[0].SearchDate.ToShortDateString()));
                    else
                        await SendMessage(chatId.ToString(), "Invalid command!");
                    // await SendMessage("625072531", newMessage.Result[0].Message.Text);
                }
            }
        }
    }
}
