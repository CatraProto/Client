
# What is CatraProto?
CatraProto is a fully-asynchronous library that implements the MTProto protocol and the Telegram API. 
This means you can interact with the Telegram API (**as a regular user** as well) **without having any knowledge of the encryption and communication protocol**, it also implements the API so **you won't have to take care of any database implementation or updates handling.**

# Full documentation
Full documentation is available at https://catraproto.github.io/docs

# Getting started
## Receiving messages
To start receiving incoming updates, we start off by creating an EventHandler class which extends the [IEventHandler](https://github.com/CatraProto/Client/blob/master/src/CatraProto.Client/Updates/Interfaces/IEventHandler.cs) interface.
```cs
public class EventHandler : IEventHandler
{
    private readonly TelegramClient _client;

    public EventHandler(TelegramClient client)
    {
        _client = client;
    }

    public async Task OnUpdateAsync(UpdateBase update)
    {
        if (update is UpdateNewMessage { Message: Message { Out: false } message })
        {
            var asPeerId = PeerId.FromPeer(message.PeerId);
            if (asPeerId.Type is not PeerType.User)
            {
                // We only want to reply to messages sent in private chat.
                return;
            }

            await _client.Api.CloudChatsApi.Messages.SendMessageAsync(asPeerId, "Hello user. Thank you for contacting me and trying CatraProto!");
        }
    }
}
```

## Initializing the client
Now that we have written the EventHandler and implemented our own logic, we initialize CatraProto and login for the first time.

```cs
// Create the SeriLog logger to use.
var logger = Logger.CreateDefaultLogger();
var apiSettings = new ApiSettings(YOUR_API_ID, YOUR_API_HASH, "CatraProto", "1.0", "en", "android", "en", "1.0");
var sessionSettings = new SessionSettings(new FileSerializer($"data/MySession.catra"), new DatabaseSettings("data/MySession.db", 50), sessionName);
var connectionInfo = new ConnectionInfo(IPAddress.Parse(DC_IP), IS_TEST, 443, ID);
var connectionSettings = new ConnectionSettings(connectionInfo, 86400, 30);
var settings = new ClientSettings(sessionSettings, apiSettings, connectionSettings);

await using var client = new TelegramClient(settings, logger);
client.SetEventHandler(new EventHandler(client, logger));

var clientState = await client.InitClientAsync();
if(clientState is ClientState.Corrupted)
{
    //The session is corrupted, you need to delete it and login again.
    return;
}

if(clientState is ClientState.Unauthenticated)
{
    var login = client.GetLoginFlow();
    // You can obviously also use Console.ReadLine() to get the phone number for the console
    var authentication = await login.AsUser(PHONE_NUMBER_HERE, new CodeSettings());
    // If you want to login as a user, you can just uncomment the line below and comment the line above.
    //var authentication = await login.AsBotAsync(BOT_TOKEN_HERE);
    var finished = false;
    while (!finished)
    {
        switch (authentication)
        {
            case LoginNeedsCode completeLogin:
                logger.Information("Now insert the login code: ");
                authentication = await completeLogin.WithCodeAsync(Console.ReadLine());
                break;
            case LoginNeedsSignup signup:
                logger.Information("Creating account");
                authentication = await signup.WithProfileData("My CatraProto", "Account");
                break;
            case LoginFailed loginFailed:
                logger.Error("Login failed error {Error}", loginFailed.FailReason);
                finished = true;
                break;
            case LoginSuccessful loginSuccessful:
                logger.Information("Login successful, user: {User}", loginSuccessful.LoggedUser.ToJson());
                finished = true;
                break;
            default:
                logger.Error("Type {Authentication} is not supported", authentication);
                return;
        }
    }
}

logger.Information("Press any key to kill the client");
Console.ReadLine();
await client.ForceSaveAsync();
```
 
 # License
 Licensed under LGPL 3.0. See [COPYING](COPYING) and [COPYING.LESSER](COPYING.LESSER)
