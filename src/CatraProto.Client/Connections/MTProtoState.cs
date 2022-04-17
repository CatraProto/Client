using System.Threading.Tasks;
using CatraProto.Client.Async.Loops;
using CatraProto.Client.Async.Loops.Enums.Generic;
using CatraProto.Client.Async.Loops.Extensions;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.Crypto;
using CatraProto.Client.MTProto.Auth;

namespace CatraProto.Client.Connections
{
    internal class MTProtoState
    {
        public TelegramClient Client { get; }
        public KeysHandler KeysHandler { get; }
        public MessageIdsHandler MessageIdsHandler { get; }
        public SeqnoHandler SeqnoHandler { get; }
        public SessionIdHandler SessionIdHandler { get; }
        public SaltHandler SaltHandler { get; }
        public Connection Connection { get; }
        public Api Api { get; }

        public ConnectionInfo ConnectionInfo
        {
            get => Connection.ConnectionInfo;
        }
        private readonly GenericLoopController _saltController;
        public MTProtoState(Connection connection, Api api, TelegramClient client)
        {
            Api = api;
            Client = client;
            Connection = connection;
            MessageIdsHandler = new MessageIdsHandler(client.ClientSession.Logger);
            SessionIdHandler = new SessionIdHandler();
            SeqnoHandler = new SeqnoHandler(client.ClientSession.Logger);
            SessionIdHandler = new SessionIdHandler();
            SessionIdHandler.SetSessionId(CryptoTools.CreateRandomLong());
            KeysHandler = new KeysHandler(this, api, client.ClientSession, client.ClientSession.Logger);
            SaltHandler = new SaltHandler(this, client.ClientSession.Logger);
            _saltController = new GenericLoopController(client.ClientSession.Logger);
            _saltController.BindTo(SaltHandler);
        }

        public async ValueTask StartSaltHandlerAsync()
        {
            if (_saltController.GetCurrentState() is GenericLoopState.NotYetStarted)
            {
                await _saltController.SignalAsync(GenericSignalState.Start);
            }
        }

        public async Task StopSaltHandlerAsync()
        {
            if (_saltController.GetCurrentState() is GenericLoopState.Running)
            {
                await _saltController.SignalAsync(GenericSignalState.Stop);
            }
        }
    }
}