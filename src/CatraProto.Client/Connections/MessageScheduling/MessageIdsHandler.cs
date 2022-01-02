using System;
using Serilog;

namespace CatraProto.Client.Connections.MessageScheduling
{
    class MessageIdsHandler
    {
        private long _lastGeneratedId;
        private readonly ILogger _logger;
        private readonly object _mutex = new object();

        public MessageIdsHandler(ILogger logger)
        {
            _logger = logger.ForContext<MessageIdsHandler>();
        }

        public long ComputeMessageId()
        {
            lock (_mutex)
            {
                var currentSecond = DateTimeOffset.Now.ToUnixTimeSeconds();
                if (_lastGeneratedId != 0)
                {
                    var lastSecond = _lastGeneratedId / 4294967296;
                    if (lastSecond == currentSecond)
                    {
                        return _lastGeneratedId += 4;
                    }
                }

                return _lastGeneratedId = currentSecond * 4294967296;
            }
        }

        public static bool IsMessageIdTooOld(long messageId)
        {
            return IsOlderThan(messageId, 300);
        }

        public static bool IsMessageIdTooNew(long messageId)
        {
            return IsNewerThan(messageId, -30);
        }
        
        public static bool IsOlderThan(long messageId, int seconds)
        {
            return DateTimeOffset.Now.ToUnixTimeSeconds() - GetSeconds(messageId) >= seconds;
        }
        
        public static bool IsNewerThan(long messageId, int seconds)
        {
            return DateTimeOffset.Now.ToUnixTimeSeconds() - GetSeconds(messageId) <= seconds;
        }
        
        public static int GetSeconds(long messageId)
        {
            return (int)(messageId / 4294967296);
        }

        public bool CheckMessageId(long messageId, bool fromServer = true)
        {
            if (IsMessageIdTooOld(messageId))
            {
                _logger.Warning("Message id {Id} is too old", messageId);
                return false;
            }

            if (IsMessageIdTooNew(messageId))
            {
                _logger.Warning("Message id {Id} is too new", messageId);
                return false;
            }

            if (messageId % 4 == 0 && fromServer)
            {
                _logger.Warning("Message id {Id} is divisible by 4 but it's been sent from the server", messageId);
                return false;
            }

            return true;
        }
    }
}