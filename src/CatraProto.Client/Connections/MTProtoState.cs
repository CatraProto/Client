using System;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.MTProto.Auth;
using CatraProto.Client.MTProto.Session;
using CatraProto.Client.Settings;
using Serilog;

namespace CatraProto.Client.Connections
{
    class MTProtoState
    {
        public KeysHandler KeysHandler { get; }
        public MessageIdsHandler MessageIdsHandler { get; }
        public SeqnoHandler SeqnoHandler { get; }
        public SessionIdHandler SessionIdHandler { get; }
        public SaltHandler SaltHandler { get; }
        public Api Api { get; }
        private readonly ILogger _logger;

        public MTProtoState(Api api, ClientSettings settings, ILogger logger)
        {
            Api = api;
            MessageIdsHandler = new MessageIdsHandler(logger);
            SessionIdHandler = new SessionIdHandler();
            SeqnoHandler = new SeqnoHandler(logger);
            SessionIdHandler = new SessionIdHandler();
            SessionIdHandler.SetSessionId(new Random().Next());
            KeysHandler = new KeysHandler(this, api, settings, logger);
            SaltHandler = new SaltHandler(api, KeysHandler.TemporaryAuthKey, logger);
            _logger = logger;
        }

        public void StartLoops()
        {
            SaltHandler.Start();
        }

        public void RegisterSerializer(SessionManager manager)
        {
            manager.AddSerializer(KeysHandler.PermanentAuthKey);
        }
    }
}