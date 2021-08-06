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
            var toSeconds = messageId / 4294967296;
            return DateTimeOffset.Now.ToUnixTimeSeconds() - toSeconds >= 300;
        }
        
        public static bool IsMessageIdTooNew(long messageId)
        {
            var toSeconds = messageId / 4294967296;
            return DateTimeOffset.Now.ToUnixTimeSeconds() - toSeconds <= -30;
        }

        public bool CheckMessageId(long messageId, bool fromServer = true)
        {
            if (IsMessageIdTooOld(messageId))
            {
                _logger.Warning("Given message id {Id} is too old", messageId);
                return false;
            }

            if (IsMessageIdTooNew(messageId))
            {
                _logger.Warning("Given message id {Id} is too young", messageId);
                return false;
            }
            
            if (messageId % 4 == 0 && fromServer)
            {
                _logger.Warning("Given message id {Id} is divisible by 4 but it's been sent from the server", messageId);
                return false;
            }

            return true;
        }
    }
}