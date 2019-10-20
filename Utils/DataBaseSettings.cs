using MongoDB.Driver;
using Telegram.Bot.Args;
using AntiSmokeRoomChatBot.Models;

namespace AntiSmokeRoomChatBot.Utils
{
    public class DataBaseSettings
    {
        private IMongoDatabase _database;

        public void SaveToMongo(string conStr, string ChatId, string message)
        {
            _database = new MongoClient(conStr)
                .GetDatabase("antiSmokeRoomChatBot");
            var collection =_database.GetCollection<string>(ChatId);
            collection.InsertOne(message);
        }

    }
}