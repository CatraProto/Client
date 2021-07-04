using System;
using System.Threading.Tasks;
using CatraProto.Client.Connections.Loop;
using CatraProto.Client.Connections.Protocols.Interfaces;
using CatraProto.Client.Connections.Protocols.TcpAbridged;
using CatraProto.Client.MTProto;
using CatraProto.Client.MTProto.Auth;
using CatraProto.Client.MTProto.AuthKeyHandler;
using CatraProto.Client.MTProto.AuthKeyHandler.Results;
using Serilog;

namespace CatraProto.Client.Connections
{
    class Connection : IDisposable
    {
        public MessageIdsHandler MessageIdsHandler
        {
            get => _session.MessageIdsHandler;
        }

        public SessionData SessionData { get; }
        public MessagesDispatcher MessagesDispatcher { get; }
        public ConnectionInfo ConnectionInfo { get; }
        public MessagesHandler MessagesHandler { get; }
        public IProtocol Protocol { get; private set; }

        private ILogger _logger;
        private ReadLoop _readLoop;
        private Session _session;
        private WriteLoop _writeLoop;
        private ConnectionProtocol _protocolType;

        public Connection(Session session, ConnectionInfo connectionInfo, ConnectionProtocol protocolType)
        {
            _logger = session.Logger.ForContext<Connection>();
            _session = session;
            MessagesHandler = new MessagesHandler(_logger);
            MessagesDispatcher = new MessagesDispatcher(MessagesHandler, _logger);
            SessionData = new SessionData
            {
                AuthKey = new AuthKey(new Api(MessagesHandler), _logger, -1)
            };
            ConnectionInfo = connectionInfo;
            _protocolType = protocolType;
            Protocol = CreateProtocol();
        }

        private IProtocol CreateProtocol()
        {
            switch (_protocolType)
            {
                case ConnectionProtocol.TcpAbridged:
                    return new Abridged(ConnectionInfo, _logger);
                default:
                    throw new NotSupportedException("Protocol not supported");
            }
        }

        public async Task ConnectAsync()
        {
            while (true)
            {
                try
                {
                    _logger.Information("Trying to connect to {Connection}", ConnectionInfo);
                    await Protocol.ConnectAsync();
                    await StartLoops();
                    
                    if (SessionData.AuthKey.RawAuthKey == null)
                    {
                        var authKey = await SessionData.AuthKey.ComputeAuthKey();
                        SessionData.Salt = BitConverter.ToInt64(((AuthKeySuccess)authKey).ServerSalt);
                    }
                    break;
                }
                catch (Exception e)
                {
                    _logger.Error("Couldn't connect due to {Message}, trying again in 3 seconds", e.Message);
                    await Task.Delay(3000);
                }
            }


            _logger.Information("Connected to {Connection}", ConnectionInfo);
        }

        private async Task StartLoops()
        {
            _writeLoop ??= new WriteLoop(this, _logger);
            _readLoop ??= new ReadLoop(this, _logger);

            await _writeLoop.StartAsync();
            await _readLoop.StartAsync();
        }

        public void Dispose()
        {
            MessagesHandler?.Dispose();
        }
    }
}