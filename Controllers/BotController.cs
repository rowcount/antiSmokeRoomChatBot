using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using ApiAiSDK;
using AntiSmokeRoomChatBot.Factories;
using AntiSmokeRoomChatBot.Handlers;
using AntiSmokeRoomChatBot.Utils;

namespace AntiSmokeRoomChatBot.Controllers
{
    public class BotController
    {

        private readonly TelegramBotClient _bot;
        private readonly ApiAi _ai;
        private readonly KeyboardFactory _keyboardFactory;
        private readonly TextHandler _textHandler;
        private readonly Logger _logger;

        public BotController(TelegramBotClient bot, ApiAi ai) 
        {
            _logger = new Logger(this);
            _bot = bot;
            _ai = ai;
            _keyboardFactory = new KeyboardFactory();
            _textHandler = new TextHandler(_bot, _keyboardFactory, _ai);
            _bot.OnMessage += BotOnMessageReceived;
            _bot.OnCallbackQuery += BotOnCallbackQueryReceived;
        }

        public void Startup() 
        {
            var me = _bot.GetMeAsync().Result;
            _logger.Log($"Hello, World! I am user {me.Id} and my name is {me.FirstName}.");
            try {
                _bot.StartReceiving();
            } catch (Exception e) {
                _logger.Log(e.Message);
            }
        }

        public void Stop() 
        {
            _bot.StopReceiving();
        }

        public bool IsReceiving() 
        {
            return _bot.IsReceiving;
        }

        private async void BotOnCallbackQueryReceived(object sender, CallbackQueryEventArgs e)
        {
            string buttonText = e.CallbackQuery.Data;
            string name= $"{e.CallbackQuery.From.FirstName} {e.CallbackQuery.From.LastName} ";
            _logger.Log($"{name} pressed {buttonText}");

            await _bot.AnswerCallbackQueryAsync(e.CallbackQuery.Id, $"you press {buttonText}");
        }

        void BotOnMessageReceived(object sender, MessageEventArgs mea)
        {
            if (mea.Message == null)
                return;
            switch (mea.Message.Type) {
                case MessageType.Text:
                    _textHandler.Handle(mea.Message);
                    break;
            }
        }
    }
}