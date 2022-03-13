using System;
using System.Diagnostics.CodeAnalysis;
using CatraProto.Client.Connections.MessageScheduling.Items;
using CatraProto.Client.TL.Schemas;
using CatraProto.TL;
using CatraProto.TL.Exceptions;
using Serilog;

namespace CatraProto.Client.Connections.Loop
{
    static class SocketTools
    {
        public static bool TrySerialize(MessageItem item, ILogger logger, [MaybeNullWhen(false)] out byte[] serialized)
        {
            logger.Verbose("Trying to serialize {Type}", item.Body);
            try
            {
                serialized = item.Body.ToArray(MergedProvider.Singleton);
                return true;
            }
            catch (Exception e)
            {
                logger.Error("Serialization of message of type {Type} failed, throwing exception on caller", item.Body);
                item.SetFailed(e);
            }

            serialized = null;
            return false;
        }
    }
}