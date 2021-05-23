using System;
using System.Threading.Tasks;
using CatraProto.Client.Async.Locks;
using CatraProto.Client.Connections;
using CatraProto.Client.MTProto;
using CatraProto.Client.MTProto.Messages;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.TL.Schemas.CloudChats;
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
            var connection = new Connection(session, new ConnectionInfo(), ConnectionProtocol.TcpAbridged);
            //var client = new Client(session);
            //await client.Start();
            //await client.Test();
            Console.ReadLine();
        }
    }
}