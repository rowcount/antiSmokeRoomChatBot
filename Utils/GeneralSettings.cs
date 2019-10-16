using System;
using System.Net;
using Telegram.Bot;
using ApiAiSDK;

namespace bot.Utils{
    public class GeneralSettings
    {
       private static WebProxy wp = new WebProxy("95.168.185.183:8080", true); //proxy for debug - need to delete
       public readonly TelegramBotClient botClient = new TelegramBotClient("958396719:AAG-g8xJVGlueJq1tczvi5fIjhaJdl4PckQ", wp);
       private static AIConfiguration config = new AIConfiguration("45a85b9166c046a8ba11c9e3ed09f581",SupportedLanguage.Russian);
       public readonly ApiAi apiAi = new ApiAi(config);
    }

   
}