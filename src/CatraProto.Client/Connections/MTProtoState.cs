using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.Crypto;
using CatraProto.Client.MTProto.Auth;

namespace CatraProto.Client.Connections
{
    class MTProtoState
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
            SaltHandler = new SaltHandler(api, KeysHandler.TemporaryAuthKey, client.ClientSession.Logger);
        }

        public void StartLoops()
        {
            //TODO: fix
            //SaltHandler.Start();
        }
    }
}