using System;
using bot.Controllers;
using bot.Utils;

namespace bot
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
