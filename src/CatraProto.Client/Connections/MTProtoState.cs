using System;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.MTProto.Auth;
using CatraProto.Client.MTProto.Session.Models;
using CatraProto.Client.MTProto.Settings;
using Serilog;

namespace CatraProto.Client.Connections
{
    class MTProtoState
    {
        public KeysHandler KeysHandler { get; }
        public MessageIdsHandler MessageIdsHandler { get; }
        public SessionData SessionData { get; }
        public SeqnoHandler SeqnoHandler { get; }
        public SessionIdHandler SessionIdHandler { get; }
        public SaltHandler SaltHandler { get; }
        public ConnectionInfo ConnectionInfo { get; }
        public Api Api { get; }

        public MTProtoState(ConnectionInfo connectionInfo, Api api, ClientSettings settings, SessionData sessionData, ILogger logger)
        {
            Api = api;
            SessionData = sessionData;
            ConnectionInfo = connectionInfo;
            MessageIdsHandler = new MessageIdsHandler(logger);
            SessionIdHandler = new SessionIdHandler();
            SeqnoHandler = new SeqnoHandler(logger);
            SessionIdHandler = new SessionIdHandler();
            SessionIdHandler.SetSessionId(new Random().Next());
            KeysHandler = new KeysHandler(this, api, settings, logger);
            SaltHandler = new SaltHandler(api, KeysHandler.TemporaryAuthKey, logger);
        }

        public void StartLoops()
        {
            SaltHandler.Start();
        }
    }
}