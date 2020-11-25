using ApiBotTelegram.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TelegramBotClient.Clients;
using TelegramBotClient.Models;

namespace TelegramBotClient
{
    class Program
    {      
        static void Main(string[] args)
        {
            TeleBotClient bot = new TeleBotClient();

            bot.Inicializar();

            Console.ReadLine();
        }
    }
}
