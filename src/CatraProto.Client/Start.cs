using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CatraProto.Client.MTProto;
using Serilog.Core;
using Serilog.Events;

namespace CatraProto.Client
{
    public static class Start
    {
        public static async Task Main(string[] args)
        {
            var settings = new Settings("CutePony");
            var session = new Session(settings, Logger.CreateDefaultLogger(new LoggingLevelSwitch(LogEventLevel.Debug)));
            var client = new Client(session);
            await client.StartAsync();
            await client.Test();
            Console.ReadLine();
        }
    }
}