using CatraProto.Client.MTProto.Session.Interfaces;
using CatraProto.Client.MTProto.Session.Models;
using Serilog;

namespace CatraProto.Client
{
    class SessionEvents
    {
        private readonly TelegramClient _client;
        private readonly ILogger _logger;

        public SessionEvents(TelegramClient client, ILogger logger)
        {
            _client = client;
            _logger = logger.ForContext<SessionEvents>();
        }

        public void OnDataUpdate(SessionModel obj)
        {
            switch (obj)
            {
                case Authorization authorization:
                    _logger.Information("New authorization raised, fetching updates...");
                    if (authorization.IsAuthorized(out _, out _, out _))
                    {
                        //Not awaiting is fine here.
                        _client.UpdatesReceiver.ForceGetDifferenceAllAsync(false);
                    }

                    break;
            }
        }
    }
}