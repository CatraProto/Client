using System;
using System.Collections.Generic;
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
        public byte[]? SerializedContainer { get; set; }
        public List<Tuple<ContainerMessage, MessageItem>> MessageItems { get; set; } = new List<Tuple<ContainerMessage, MessageItem>>();

        private readonly Writer _currentWriter;
        private int _currentMessagesCount;
        private int _currentBytes;
        private readonly ILogger _logger;

        public ContainersWriter(ILogger logger)
        {
            _logger = logger;
            _currentWriter = new Writer(MergedProvider.Singleton, new MemoryStream());
            WriteContainer();
        }

        private void SaveContainer()
        {
            _currentWriter.WriteNakedVector(MessageItems.Select(x => x.Item1).ToList());
            SerializedContainer = ((MemoryStream)_currentWriter.Stream).ToArray();
            var ser = SerializedContainer.ToObject<MsgContainer>(MergedProvider.Singleton);
            _currentWriter.Dispose();
        }

        private void WriteContainer()
        {
            _currentWriter.Write(MsgContainer.StaticConstructorId);
        }

        public void CreateContainer(List<MessageItem> messages, MessagesHandler messagesHandler, MTProtoState mtProtoState)
        {
            _logger.Verbose("Generating a container of {Count} messages", messages.Count);
            foreach (var messageItem in messages)
            {
                if (SocketTools.TrySerialize(messageItem, _logger, out var serialized))
                {
                    if (_currentBytes + (serialized!.Length + 8 + 4 + 4) > ContainerBytesLimit || _currentMessagesCount > ContainerMessagesLimit)
                    {
                        messagesHandler.MessagesQueue.EnqueueMessage(messageItem);
                        continue;
                    }

                    var sendingOptions = messageItem.MessageSendingOptions;
                    var containerMessage = new ContainerMessage
                    {
                        MsgId = sendingOptions.SendWithMessageId ?? mtProtoState.MessageIdsHandler.ComputeMessageId(),
                        Seqno = mtProtoState.SeqnoHandler.ComputeSeqno(messageItem.Body),
                        Body = serialized
                    };
                    MessageItems.Add(new Tuple<ContainerMessage, MessageItem>(containerMessage, messageItem));

                    _currentBytes += serialized.Length + 8 + 4 + 4;
                    _currentMessagesCount++;
                }
            }

            SaveContainer();
            _logger.Information("Generating a container of {Count} messages and size {Size}bytes", MessageItems.Count, SerializedContainer!.Length);
        }
    }
}