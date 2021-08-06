using Serilog;

namespace CatraProto.Client.Connections.MessageScheduling
{
    class MessagesHandler
    {
        public MessagesTrackers MessagesTrackers { get; }
        public MessagesQueue MessagesQueue { get; }

        public MessagesHandler(ILogger logger)
        {
            MessagesQueue = new MessagesQueue(logger);
            MessagesTrackers = new MessagesTrackers(MessagesQueue, logger);
        }
    }
}