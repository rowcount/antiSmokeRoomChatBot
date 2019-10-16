using System;
using Telegram.Bot.Types.ReplyMarkups;

namespace bot.Factories 
{
    class KeyboardFactory 
    {
        public InlineKeyboardMarkup GetInlineKeyboardButtons() 
        {
            return new InlineKeyboardMarkup(new[]
                    {
                        new[]
                        {
                            InlineKeyboardButton.WithUrl("TG","https://t.me/antiKurilkachbot"),
                            InlineKeyboardButton.WithUrl("TG","https://t.me/antiKurilkachbot")
                        },
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("Пункт1","1"),
                            InlineKeyboardButton.WithCallbackData("Пункт2","2")
                        }
                    });
        }

        public ReplyKeyboardMarkup GetReplyKeyboardButtons() {
            return new ReplyKeyboardMarkup(new[]
                    {
                        new[]
                        {
                            new KeyboardButton("Привет"),
                            new KeyboardButton("Как дела")
                        },
                        new[]
                        {
                            new KeyboardButton("Контакт") {RequestContact = true},
                            new KeyboardButton("Геолокация") {RequestLocation = true}
                        }
                    });
        }
    }
}