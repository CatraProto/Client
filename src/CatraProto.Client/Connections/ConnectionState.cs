using System;
using CatraProto.Client.MTProto;
using CatraProto.Client.MTProto.Auth;
using CatraProto.Client.MTProto.Auth.AuthKeyHandler;
using CatraProto.Client.MTProto.Session;
using CatraProto.TL;
using Serilog;

namespace CatraProto.Client.Connections
{
    class ConnectionState
    {
        public MessageIdsHandler MessageIdsHandler { get; set; }
        public MessagesHandler MessagesHandler { get; set; }
        public MessagesDispatcher MessagesDispatcher { get; set; }
        public TemporaryAuthKey TemporaryAuthKey { get; set; }
        public PermanentAuthKey PermanentAuthKey { get; set; }
        public SeqnoHandler SeqnoHandler { get; set; }
        public AcknowledgementHandler AcknowledgementHandler { get; set; }
        public SessionIdHandler SessionIdHandler { get; set; }
        public SaltHandler SaltHandler { get; set; }
        public Api Api { get; }
        private ILogger _logger;
        
        public ConnectionState(ILogger logger)
        {
            MessageIdsHandler = new MessageIdsHandler(logger);
            MessagesHandler = new MessagesHandler(logger);
            Api = new Api(MessagesHandler);
            MessagesDispatcher = new MessagesDispatcher(this, logger);
            _logger = logger;
        }

        public void ConfigureDefault()
        {
            SessionIdHandler = new SessionIdHandler();
            PermanentAuthKey = new PermanentAuthKey(Api, _logger);
            TemporaryAuthKey = new TemporaryAuthKey(Api, SessionIdHandler, PermanentAuthKey, 120, _logger);
            AcknowledgementHandler = new AcknowledgementHandler();
            SaltHandler = new SaltHandler(Api, TemporaryAuthKey);
            SeqnoHandler = new SeqnoHandler(_logger);
            SessionIdHandler = new SessionIdHandler();
            
            SessionIdHandler.SetSessionId(new Random().Next());
        }
        
        public void RegisterSerializer(SessionManager manager)
        {
            ConfigureDefault();
            manager.AddSerializer(PermanentAuthKey);
        }
    }
}