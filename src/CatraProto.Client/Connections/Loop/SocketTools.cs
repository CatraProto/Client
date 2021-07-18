using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections.Messages;
using CatraProto.Client.Connections.Protocols.Interfaces;
using CatraProto.Client.MTProto;
using CatraProto.Client.MTProto.Containers;
using CatraProto.Client.TL.Schemas;
using CatraProto.Client.TL.Schemas.MTProto;
using CatraProto.TL;
using CatraProto.TL.Exceptions;
using Serilog;

namespace CatraProto.Client.Connections.Loop
{
    static class SocketTools
    {
        public static async Task<bool> SendWithTimeoutAsync(this IProtocolWriter writer, byte[] array, ILogger logger)
        {
            var timeoutToken = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            try
            {
                await writer.SendAsync(array, timeoutToken.Token);
                return true;
            }
            catch (OperationCanceledException e) when (e.CancellationToken == timeoutToken.Token)
            {
                logger.Error("Write to socket operation timed out after 10 seconds");
                return false;
            }
        }

        public static bool TrySerialize(MessageContainer container, ILogger logger, out byte[] serialized)
        {
            logger.Information("Serializing message of type {Type}", container.OutgoingMessage.Body);
            try
            {
                serialized = container.OutgoingMessage.Body.ToArray(MergedProvider.Singleton);
                return true;
            }
            catch (SerializationException e)
            {
                logger.Error("Serialization of message of type {Type} failed, throwing exception on caller", container.OutgoingMessage.Body);
                container.CompletionSource.TrySetException(e);
            }

            serialized = null;
            return false;
        }
    }
}