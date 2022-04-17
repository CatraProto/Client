using Serilog;

namespace CatraProto.Client.Connections.MessageScheduling
{
    internal class MessagesHandler
    {
        public MessagesTrackers MessagesTrackers { get; }
        public MessagesQueue MessagesQueue { get; }
        public Connection Connection { get; }

        public MessagesHandler(Connection connection, ILogger logger)
        {
            Connection = connection;
            MessagesQueue = new MessagesQueue(this, logger);
            MessagesTrackers = new MessagesTrackers(logger);
        }
    }
}