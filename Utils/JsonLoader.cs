

using System.Collections.Generic;
using System.IO;
using AntiSmokeRoomChatBot.Models;
using Newtonsoft.Json;

namespace AntiSmokeRoomChatBot.Utils {

    class JsonLoader {

        public Properties Load(string mode) {
            return JsonConvert.DeserializeObject<Properties>(File.ReadAllText($"{mode}.json"));
        }

        public Properties Load() 
        {
            return Load("app");
        }
    }
}