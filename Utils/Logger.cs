using System;

namespace AntiSmokeRoomChatBot.Utils {

    class Logger {

        private readonly Object _obj;

        public Logger(Object obj) {
            _obj = obj;
        }

        public void Log(string message) {
            Console.WriteLine($"{DateTime.Now} - [{_obj.GetType().Name}] {message}");
        }
    }
}