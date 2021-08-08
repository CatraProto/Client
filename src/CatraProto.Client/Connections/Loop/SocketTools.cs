using CatraProto.Client.Connections.MessageScheduling.Items;
using CatraProto.Client.TL.Schemas;
using CatraProto.TL;
using CatraProto.TL.Exceptions;
using Serilog;

namespace CatraProto.Client.Connections.Loop
{
    static class SocketTools
    {
        public static bool TrySerialize(MessageItem item, ILogger logger, out byte[]? serialized)
        {
            logger.Information("Serializing message of type {Type}", item.Body);
            try
            {
                serialized = item.Body.ToArray(MergedProvider.Singleton);
                return true;
            }
            catch (SerializationException e)
            {
                logger.Error("Serialization of message of type {Type} failed, throwing exception on caller", item.Body);
                item.MessageStatus.MessageCompletion.TaskCompletionSource?.TrySetException(e);
            }

            serialized = null;
            return false;
        }
    }
}