using System;

namespace antiSmokeRoomChatBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("start");
            var setting = new GeneralSetting();
            var bt = new BotController(setting.botClient, setting.apiAi);
            bt.Startup();
            Console.ReadKey();
            bt.Stop();
        }
    }
}
