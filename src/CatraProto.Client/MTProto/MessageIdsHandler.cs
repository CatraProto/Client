using System;
using Serilog;

namespace CatraProto.Client.MTProto
{
    public class MessageIdsHandler
    {
        private object _mutex = new object();
        private long _lastGeneratedId = 0;
        private ILogger _logger;

        public MessageIdsHandler(ILogger logger)
        {
            _logger = logger.ForContext<MessageIdsHandler>();
        }

        public long GenerateMessageId()
        {
            lock (_mutex)
            {
                var currentSecond = DateTimeOffset.Now.ToUnixTimeSeconds();
                if (_lastGeneratedId != 0)
                {
                    var lastSecond = _lastGeneratedId >> 32;
                    if (lastSecond == currentSecond)
                    {
                        return _lastGeneratedId += 4;
                    }
                }

                return _lastGeneratedId = currentSecond << 32;
            }
        }

        public static bool IsMessageIdOld(long messageId)
        {
            var toSeconds = messageId >> 32;
            return DateTimeOffset.Now.ToUnixTimeSeconds() - toSeconds >= 300;
        }
    }
}