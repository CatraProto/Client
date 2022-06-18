using CatraProto.Client;
using CatraProto.Client.ApiManagers;
using CatraProto.Client.MTProto;
using CatraProto.Client.MTProto.Rpc.Interfaces;
using CatraProto.Client.MTProto.Rpc.RpcErrors.ClientErrors.Login;
using CatraProto.Client.TL;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.Updates.Interfaces;
using Serilog;

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
        Task<RpcError?>? task = null;
        if (loginState is LoginState.AwaitingLogin)
        {
            char finalChoice;
            while (true)
            {
                Console.Write("Welcome! Would you like to login as a bot or as a user? (b/u): ");
                var readLine = Console.ReadLine();
                if (readLine is null || readLine.Length != 1 || (readLine[0] != 'u' && readLine[0] != 'b'))
                {
                    Console.WriteLine("I'm sorry but this option is invalid");
                    continue;
                }

                finalChoice = readLine[0];
                break;
            }

            if (finalChoice == 'u')
            {
                Console.Write("You've selected login as user. Please enter the phone number: ");
                task = _client.LoginManager.UsePhoneNumberAsync(Console.ReadLine() ?? "", new CodeSettings());
            }
            else
            {
                Console.Write("You've selected login as bot. Please enter the bot token: ");
                task = _client.LoginManager.UseBotTokenAsync(Console.ReadLine() ?? "");
            }

            var result = await task;
            if (result is BotTokenIncorrectError)
            {
                Console.WriteLine("I'm sorry, but this token does not work. Make sure you're copying it correctly.");
                return;
            }
            else if (result is PhoneNumberIncorrectError)
            {
                Console.WriteLine("I'm sorry, but this phone number does not work. Make sure you're typing every digit correctly.");
                return;
            }
        }
        else if (loginState is LoginState.AwaitingCode)
        {
            Console.Write("Please insert the login code or r to resend it: ");
            while (true)
            {
                var read = Console.ReadLine();
                if (read is null)
                {
                    continue;
                }

                if (read == "r")
                {
                    task = _client.LoginManager.ResendCodeAsync();
                    var result = await task;
                    if (result is null)
                    {
                        Console.WriteLine($"The code was resent successfully. Code type {_client.LoginManager.GetCodeTypes()!.Value.CodeType}");
                    }
                }
                else
                {
                    task = _client.LoginManager.UseLoginCodeAsync(read);
                    var result = await task;
                    if (result is not null)
                    {
                        if (result is PhoneCodeIncorrectError)
                        {
                            Console.WriteLine("The given phone code was invalid, try again or press r to resend it: ");
                            continue;
                        }
                    }
                    break;
                }
            }
        }
        else if (loginState is LoginState.AwaitingTermsAcceptance)
        {
            Console.WriteLine(_client.LoginManager.GetTermsOfService()!.Text);
            Console.Write("Great! Please accept the terms of service (y/n): ");
            _client.LoginManager.SetTerms(Console.ReadKey().KeyChar == 'y');
            Console.WriteLine();
        }
        else if (loginState is LoginState.AwaitingRegistration)
        {
            Console.WriteLine("It looks like this phone number is not registered.");
            var name = string.Empty;
            while (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                Console.Write("What's your first name? ");
                name = Console.ReadLine();
            }

            Console.Write($"Ok {name}. What about your last name (Press enter to leave blank)? ");
            var lastName = Console.ReadLine() ?? "";
            task = _client.LoginManager.UseProfileDataAsync(name, lastName);
        }
        else if (loginState is LoginState.AwaitingPassword)
        {
            Console.Write("Yay! Please type your 2FA password here: ");
            while (true)
            {
                task = _client.LoginManager.UsePasswordAsync(Console.ReadLine() ?? "");
                var error = await task;
                if (error is not null)
                {
                    if (error is PasswordIncorrectError)
                    {
                        Console.WriteLine("Oops! The password is incorrect. Please try again.");
                        continue;
                    }

                    break;
                }
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
            Console.WriteLine($"Wow! We are logged in! We are: {getSelf.Response}");
        }
        else if (loginState >= LoginState.LoggedOut)
        {
            _blockingConsole.Release();
            Console.WriteLine($"Hey! The session is dead. I received the following state: {loginState}");
        }
        else
        {
            Console.WriteLine($"Oh oh! It looks like I don't know how to handle this state: {loginState}");
        }

        if (task is not null)
        {
            var result = await task;
            if (result is not null)
            {
                Console.WriteLine($"I'm sorry, the following error occurred while logging in {result}");
            }
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
