using System;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.MTProto.Auth;
using CatraProto.Client.MTProto.Session;

namespace CatraProto.Client.Connections
{
    class MTProtoState
    {
        public KeysHandler KeysHandler { get; }
        public MessageIdsHandler MessageIdsHandler { get; }
        public SeqnoHandler SeqnoHandler { get; }
        public SessionIdHandler SessionIdHandler { get; }
        public SaltHandler SaltHandler { get; }
        public ConnectionInfo ConnectionInfo { get; }
        public Api Api { get; }

        public MTProtoState(ConnectionInfo connectionInfo, Api api, ClientSession clientSession)
        {
            Api = api;
            ConnectionInfo = connectionInfo;
            MessageIdsHandler = new MessageIdsHandler(clientSession.Logger);
            SessionIdHandler = new SessionIdHandler();
            SeqnoHandler = new SeqnoHandler(clientSession.Logger);
            SessionIdHandler = new SessionIdHandler();
            SessionIdHandler.SetSessionId(new Random().Next());
            KeysHandler = new KeysHandler(this, api, clientSession);
            SaltHandler = new SaltHandler(api, KeysHandler.TemporaryAuthKey, clientSession.Logger);
        }

        public void StartLoops()
        {
            SaltHandler.Start();
        }
    }
}