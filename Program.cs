using System;
using AntiSmokeRoomChatBot.Controllers;
using AntiSmokeRoomChatBot.Models;
using AntiSmokeRoomChatBot.Utils;

namespace AntiSmokeRoomChatBot
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("start");
            if (args.Length == 0) {
                Console.WriteLine("Startup mode is requred!");
            } else {
                var json = new JsonLoader();
                Properties props = json.Load(args[0]);
                var setting = new GeneralSettings(props);
                var bt = new BotController(setting.botClient, setting.apiAi);
                bt.Startup();
                Console.ReadKey();
                bt.Stop();
            }
        }
    }
}
