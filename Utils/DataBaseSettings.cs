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

        public void SaveToMongo(string conStr, MessageEventArgs mea)
        {
            var ChatId = mea.Message.Chat.Id.ToString();
            string DatabaseName;
            if (mea.Message.Chat.Id < 0)
                DatabaseName = $"group_chat_{mea.Message.Chat.Title}";
            else
                if ( mea.Message.Chat.Username == null)
                    DatabaseName = mea.Message.Chat.Id.ToString();
                else    
                    DatabaseName = mea.Message.Chat.Username;
            _database = new MongoClient(conStr)
                .GetDatabase(DatabaseName);
            var collection =_database.GetCollection<MessageEventArgs>(ChatId);
            collection.InsertOne(mea);
        }

    }
}