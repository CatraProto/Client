using System.Net;
using CatraProto.Client;
using CatraProto.Client.Connections;
using CatraProto.Client.MTProto.Session;
using CatraProto.Client.MTProto.Session.Deserializers;
using CatraProto.Client.MTProto.Settings;
using Serilog.Core;
using Serilog.Events;
using Logger = CatraProto.Client.Logger;

var logger = Logger.CreateDefaultLogger(new LoggingLevelSwitch(LogEventLevel.Verbose));
var apiSettings = new ApiSettings(YOUR_API_ID, YOUR_API_HASH, "CatraProto", "1.0", "en", "android_x", "en", "1.0");
var sessionSettings = new SessionSettings(new FileSerializer("data/MySession.catra"), new DatabaseSettings($"data/MySession.db", 50), "MySession");
var connectionSettings = new ConnectionInfo(IPAddress.Parse("149.154.167.50"), 443, 2, false);
var settings = new ClientSettings(sessionSettings, apiSettings, new ConnectionSettings(connectionSettings, 86400, 30));
await using var client = new TelegramClient(settings, logger);
var eventHandler = new ConsoleLogin.EventHandler(client);
client.SetEventHandler(eventHandler);
ClientState clientState = await client.InitClientAsync();
if (clientState is ClientState.Corrupted)
{
    logger.Error("Session corrupted");
    return 0;
}

await eventHandler.WaitConsoleAsync();
Console.WriteLine("Press enter to stop the program");
Console.Read();
await client.ForceSaveAsync();
return 0;