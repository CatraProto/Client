using System;
using Serilog;

namespace CatraProto.Client.MTProto
{
    public class MessageIdsHandler
    {
        private long _lastGeneratedId;
        private ILogger _logger;
        private object _mutex = new object();

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

        public static bool IsMessageIdOld(long messageId)
        {
            var toSeconds = messageId / 4294967296;
            return DateTimeOffset.Now.ToUnixTimeSeconds() - toSeconds >= 300;
        }
    }
}