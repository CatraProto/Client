using CatraProto.Client.Connections.MessageScheduling.Trackers;
using Serilog;

namespace CatraProto.Client.Connections.MessageScheduling
{
    class MessagesTrackers
    {
        public MessagesAckTracker MessagesAckTracker { get; }       
        public MessageCompletionTracker MessageCompletionTracker { get; }
        
        public MessagesTrackers(MessagesQueue messagesQueue, ILogger logger)
        {
            MessagesAckTracker = new MessagesAckTracker(messagesQueue, logger);
            MessageCompletionTracker = new MessageCompletionTracker(logger);
        }
    }
}