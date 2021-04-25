using System;
using System.Linq;
using System.Threading.Tasks;
using CatraProto.Client.Crypto.Aes;
using CatraProto.Client.MTProto;
using Serilog.Core;
using Serilog.Events;


namespace CatraProto.Client
{
    public class Start
    {
        public static async Task Main(string[] args)
        {
            var settings = new Settings("TestSession");
            var session = new Session(settings, Logger.CreateDefaultLogger(new LoggingLevelSwitch(LogEventLevel.Debug)));
            //var client = new Client(session);
            //await client.Start();
            //await client.Test();
            Console.ReadLine();
        }
    }
}
