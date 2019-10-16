using System;
using Telegram.Bot;
using Telegram.Bot.Types;
using antiSmokeRoomChatBot.Factories;
using antiSmokeRoomChatBot.Utils;
using ApiAiSDK;

namespace antiSmokeRoomChatBot.Handlers {

    class TextHandler {
        private static readonly string START_MESSAGE =
@"List of commands:
/start - start bot
/inline - menu
/keyboard - keyboard";

        private TelegramBotClient _bot;
        private KeyboardFactory _keyboardFactory;
        private ApiAi _ai;

        private readonly Logger _logger;


        public TextHandler(TelegramBotClient bot, KeyboardFactory keyboardFactory, ApiAi ai) {
            _bot = bot;
            _keyboardFactory = keyboardFactory;
            _ai = ai;
            _logger = new Logger(this);
        }

        public async void Handle(Message message) {
            string answer = "";
            string userName = $"{message.From.FirstName} {message.From.LastName} from {message.Chat.Id}";
            _logger.Log($"{userName} send {message.Text}");
            switch (message.Text)
            {
                case "/start":
                    await _bot.SendTextMessageAsync(message.Chat.Id, START_MESSAGE);
                    break;
                case "/inline":
                    var inlineKeyboard = _keyboardFactory.GetInlineKeyboardButtons();
                    await _bot.SendTextMessageAsync(message.Chat.Id, "keyboard ", replyMarkup: inlineKeyboard);
                    break;
                case "/keyboard":
                    var replykeyboard = _keyboardFactory.GetReplyKeyboardButtons();
                    await _bot.SendTextMessageAsync(message.Chat.Id, "replies ", replyMarkup: replykeyboard);
                    break;
                default:
                    try {
                        var response = _ai.TextRequest(message.Text);
                        answer = response.Result.Fulfillment.Speech;
                    } catch (Exception e) {
                        _logger.Log(e.Message);
                    }
                    if (answer == "")
                    {
                        _logger.Log("ai answer is empty");
                        return;
                    }
                    else await _bot.SendTextMessageAsync(message.Chat.Id, answer);
                    _logger.Log("Answer: " + answer);
                    break;
            }
        }
    }
}