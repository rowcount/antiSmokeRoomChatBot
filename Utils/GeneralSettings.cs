using System.Net;
using Telegram.Bot;
using ApiAiSDK;
using AntiSmokeRoomChatBot.Models;

namespace AntiSmokeRoomChatBot.Utils
{
    class GeneralSettings
    {
       private WebProxy _wp;
       private AIConfiguration _config;
       private Properties _props;
       public readonly ApiAi apiAi;
       public readonly TelegramBotClient botClient;
       
       public GeneralSettings(Properties props)
        {
            _props = props;
            _wp = new WebProxy(_props.proxy, true);
            _config = new AIConfiguration(_props.ai_token, SupportedLanguage.Russian);
            apiAi = new ApiAi(_config);
            botClient = new TelegramBotClient(_props.telegram_token, _wp);
        }
    }

   
}