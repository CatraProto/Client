using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Channels;
using CatraProto.Client.Connections;
using CatraProto.Client.Connections.Loop;
using CatraProto.Client.TL.Schemas;
using CatraProto.Client.TL.Schemas.MTProto;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using Serilog;
using MessageContainer = CatraProto.Client.Connections.MessageContainer;

namespace CatraProto.Client.MTProto.Containers
{
    class ContainersWriter
    {
        public byte[] SerializedContainer { get; set; }
        public List<MessageContainer> MessageContainers { get; set; } = new List<MessageContainer>();
        public List<ContainerMessage> Messages { get; set; } = new List<ContainerMessage>();

        private static readonly int ContainerMessagesLimit = 1020;
        private static readonly int ContainerBytesLimit = (int)Math.Pow(2, 15);
        private Writer _currentWriter;
        private int _currentMessagesCount;
        private int _currentBytes;
        private ILogger _logger;

        public ContainersWriter(ILogger logger)
        {
            _logger = logger;
            _currentWriter = new Writer(MergedProvider.Singleton, new MemoryStream());
            WriteContainer();
        }

        private void SaveContainer()
        {
            _currentWriter.WriteNakedVector(Messages);
            SerializedContainer = ((MemoryStream)_currentWriter.Stream).ToArray();
            _currentWriter.Dispose();
        }

        private void WriteContainer()
        {
            _currentWriter.Write(MsgContainer.StaticConstructorId);
        }

        public void CreateContainer(List<MessageContainer> messages, ConnectionState connectionState)
        {
            _logger.Information("Converting {Count} messages to containers", messages.Count);
            
            for (var i = 0; i < messages.Count; i++)
            {
                var messageContainer = messages[i];
                if (SocketTools.TrySerialize(messageContainer, _logger, out var serialized))
                {
                    //serialized = messageContainer.OutgoingMessage.Body is IMethod ? GzipHandler.FromBytes(serialized) : serialized;
                    if (_currentBytes + (serialized.Length + 8 + 4 + 4) > ContainerBytesLimit || _currentMessagesCount > ContainerMessagesLimit)
                    {
                        connectionState.MessagesHandler.OutgoingMessages.Writer.TryWrite(messageContainer);
                        continue;
                    }

                    var sendingOptions = messageContainer.OutgoingMessage.MessageSendingOptions;
                    Messages.Add(new ContainerMessage
                    {
                        MsgId = sendingOptions.SendWithMessageId != 0 ? sendingOptions.SendWithMessageId : connectionState.MessageIdsHandler.ComputeMessageId(),
                        Seqno = connectionState.SeqnoHandler.ComputeSeqno(messageContainer.OutgoingMessage.Body),
                        Body = serialized
                    });
                    MessageContainers.Add(messageContainer);

                    _currentBytes += serialized.Length + 8 + 4 + 4;
                    _currentMessagesCount++;
                }
            }
            
            SaveContainer();
            _logger.Information("Created a container of {Count} messages and size {Size}", Messages.Count, SerializedContainer.Length);
        }
    }
}