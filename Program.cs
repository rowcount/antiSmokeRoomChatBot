using System;
using AntiSmokeRoomChatBot.Controllers;
using AntiSmokeRoomChatBot.Utils;

namespace AntiSmokeRoomChatBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("start");
            var setting = new GeneralSettings();
            var bt = new BotController(setting.botClient, setting.apiAi);
            bt.Startup();
            Console.ReadKey();
            bt.Stop();
        }
    }
}
