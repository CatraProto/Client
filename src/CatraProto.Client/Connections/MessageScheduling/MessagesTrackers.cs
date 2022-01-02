using CatraProto.Client.Connections.MessageScheduling.Trackers;
using CatraProto.Client.MTProto.Auth;
using Serilog;

namespace CatraProto.Client.Connections.MessageScheduling
{
    class MessagesTrackers
    {
        public AcknowledgementHandler AcknowledgementHandler { get; }
        public MessageCompletionTracker MessageCompletionTracker { get; }

        public MessagesTrackers(ILogger logger)
        {
            AcknowledgementHandler = new AcknowledgementHandler(logger);
            MessageCompletionTracker = new MessageCompletionTracker(logger);
        }
    }
}