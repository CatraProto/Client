using CatraProto.Client;
using CatraProto.Client.ApiManagers;
using CatraProto.Client.MTProto;
using CatraProto.Client.TL;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.Updates.Interfaces;

namespace ConsoleLogin;
public class EventHandler : IEventHandler
{
    private readonly TelegramClient _client;
    private readonly SemaphoreSlim _blockingConsole = new SemaphoreSlim(0, 1);

    public EventHandler(TelegramClient client)
    {
        _client = client;
    }

    public async Task OnSessionUpdateAsync(LoginState loginState)
    {
        if (loginState is LoginState.AwaitingLogin)
        {
            var r = await _client.LoginManager.UseBotTokenAsync("5525446665:AAH95cataglrak0Mpro9Awto4gud0zbUM");
            if (r is not null)
            {
                Console.WriteLine($"Could not login, the following error occurred: {r}");
            }
        }
        else if (loginState is LoginState.LoggedIn)
        {
            _blockingConsole.Release();
            var getSelf = await _client.Api.CloudChatsApi.Users.GetSelfAsync();
            if (getSelf.RpcCallFailed)
            {
                Console.WriteLine($"Something went wrong and I could not fetch the bot's profile. Error {getSelf.Error}");
            }

            Console.WriteLine($"We are logged-in as {getSelf.Response.ToJson()}");
        }
        else if (loginState >= LoginState.LoggedOut)
        {
            _blockingConsole.Release();
            Console.WriteLine($"Received state {loginState}");
        }
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

    public Task WaitConsoleAsync()
    {
        return _blockingConsole.WaitAsync();
    }
}
