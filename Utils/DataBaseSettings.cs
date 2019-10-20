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

        public void SaveToMongo(string conStr, string message, string ChatId = "systemMessage")
        {
            _message = new Message();
            _database = new MongoClient(conStr)
                .GetDatabase("antiSmokeRoomChatBot");
            _message.msg = message;
            var collection =_database.GetCollection<Message>(ChatId);
            collection.InsertOne(_message);
        }

    }
}