using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using CatraProto.Client.Connections;
using CatraProto.Client.Connections.Loop;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.Connections.MessageScheduling.Items;
using CatraProto.Client.TL.Schemas;
using CatraProto.Client.TL.Schemas.MTProto;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Serilog;

namespace CatraProto.Client.MTProto.Containers
{
    class ContainersWriter
    {
        public const int ContainerMessagesLimit = 1020;
        public const int ContainerBytesLimit = 2 << 15;
        public static bool GetContainer(List<MessageItem> messageItems, MTProtoState mtProtoState, [MaybeNullWhen(false)] out List<MessageItem> containerizedItems, [MaybeNullWhen(false)] out byte[] container, ILogger logger)
        {
            var currentBytes = 0;
            var currentMessagesCount = 0;
            logger = logger.ForContext<ContainersWriter>();
            var fineList = new List<Tuple<MessageItem, byte[]>>();
            foreach (var messageItem in messageItems)
            {
                if (SocketTools.TrySerialize(messageItem, logger, out var serialized))
                {
                    if (currentBytes + (serialized.Length + 8 + 4 + 4) > ContainerBytesLimit || currentMessagesCount > ContainerMessagesLimit)
                    {
                        logger.Information("Postponing {Message} as container size would be too big", messageItem.Body);
                        messageItem.SetToSend();
                        continue;
                    }

                    currentMessagesCount++;
                    currentBytes = serialized.Length + 8 + 4 + 4;
                    fineList.Add(Tuple.Create(messageItem, serialized));
                }
            }

            if (fineList.Count == 0)
            {
                logger.Verbose("No message made it into the container");
                containerizedItems = null;
                container = null;
                return false;
            }

            containerizedItems = fineList.Select(x => x.Item1).ToList();

            using var writer = new Writer(MergedProvider.Singleton, new MemoryStream());
            writer.Write(MsgContainer.StaticConstructorId);
            writer.Write(containerizedItems.Count);
            foreach (var item in fineList)
            {
                var messageItem = item.Item1;
                var messageId = mtProtoState.MessageIdsHandler.ComputeMessageId();
                var seqno = mtProtoState.SeqnoHandler.ComputeSeqno(messageItem.Body);
                messageItem.SetProtocolInfo(messageId, seqno);
                writer.Write(messageId);
                writer.Write(seqno);
                writer.Write(item.Item2.Length);
                writer.Stream.Write(item.Item2);
            }

            container = ((MemoryStream)writer.Stream).ToArray();
            return true;
        }
    }
}