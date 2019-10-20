using MongoDB.Driver;
using MongoDB.Bson;
using Telegram.Bot.Args;
using System.Collections.Generic;
using AntiSmokeRoomChatBot.Models;

namespace AntiSmokeRoomChatBot.Utils
{
    public class DataBaseSettings
    {
        private IMongoDatabase _database;
        private Message _message;

        public void SaveToMongo(string conStr, MessageEventArgs mea)
        {
            var ChatId = mea.Message.Chat.Id.ToString();
            _database = new MongoClient(conStr)
                .GetDatabase("antiSmokeRoomChatBot");
            var collection =_database.GetCollection<MessageEventArgs>(ChatId);
            collection.InsertOne(mea);
        }

    }
}