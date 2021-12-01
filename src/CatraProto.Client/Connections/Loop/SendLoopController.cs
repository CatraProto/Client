using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Async.Loops;
using CatraProto.Client.Async.Loops.Enums.Generic;
using CatraProto.Client.Connections.Loop.Enums;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.Connections.MessageScheduling.ConnectionMessages;
using CatraProto.Client.Connections.MessageScheduling.Items;
using CatraProto.Client.MTProto.Auth.AuthKeyHandler;
using CatraProto.Client.MTProto.Containers;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Auth;
using Serilog;

namespace CatraProto.Client.Connections.Loop
{
    //TODO: Impl
    class SendLoopController : GenericLoopController
    {
        private readonly Task<(int Loop, SendResult Result)>?[] _encryptedTasks = new Task<(int Loop, SendResult Result)>[3];
        private List<MessageItem> _pendingMessages = new List<MessageItem>();
        private readonly MessagesHandler _messagesHandler;
        private readonly MTProtoState _mtProtoState;
        private readonly Connection _connection;
        private Task<MessageItem>? _itemTask;
        private readonly ILogger _logger;
        private int _startTime;

        public SendLoopController(Connection connection, ILogger logger) : base(logger)
        {
            _connection = connection;
            _messagesHandler = _connection.MessagesHandler;
            _mtProtoState = _connection.MtProtoState;
            _logger = logger.ForContext<SendLoopController>();
            Task.Run(Loop);
        }

        private async Task Loop()
        {
            /*await StateSignaler.WaitStateAsync(false, default, SignalState.Start);
            _logger.Information("Listening for outgoing messages on connection {Info}...", _connection.ConnectionInfo);
            while (true)
            {
                try
                {
                    if (StateSignaler.GetCurrentState(true) == SignalState.Stop)
                    {
                        _logger.Information("SendLoop for connection {Info} shutdown", _connection.ConnectionInfo);
                        SetLoopStopped();

                        await StateSignaler.WaitStateAsync(false, default, SignalState.Start);
                        _logger.Information("Listening for outgoing messages on connection {Info}...", _connection.ConnectionInfo);
                        _startTime++;
                    }
                }
                catch (ObjectDisposedException e) when (e.ObjectName == "AsyncStateSignaler")
                {
                    break;
                }
                catch (Exception e)
                {
                    _logger.Error(e, "Exception thrown on SendLoop for {Info}", _connection.ConnectionInfo);
                }

                var shutdownToken = GetShutdownToken();
                try
                {
                    if (DoTasksCleanup() && !shutdownToken.IsCancellationRequested)
                    {
                        AskReconnection();
                        continue;
                    }

                    await LoopTickAsync(shutdownToken);
                }
                catch (OperationCanceledException e) when (e.CancellationToken == shutdownToken)
                {
                    _itemTask = null;
                }
                catch (Exception e)
                {
                    _logger.Error(e, "Exception thrown on SendLoop for {Info}", _connection.ConnectionInfo);
                }
            }*/
        }

        private async Task LoopTickAsync(CancellationToken shutdownToken)
        {
            var count = _messagesHandler.MessagesQueue.OutgoingCount == 0 ? 1 : _messagesHandler.MessagesQueue.OutgoingCount;
            for (var i = 0; i < count; i++)
            {
                MessageItem? item = null;
                if (_itemTask == null)
                {
                    var valueTask = _messagesHandler.MessagesQueue.GetMessageAsync(shutdownToken);
                    if (valueTask.IsCompleted)
                    {
                        item = await valueTask;
                    }
                    else
                    {
                        _itemTask = valueTask.AsTask();
                    }
                }

                if (item == null)
                {
                    await WaitReleaseAsync(_itemTask!);
                    if (_itemTask!.IsCompleted)
                    {
                        item = await _itemTask;
                        _itemTask = null;
                    }
                }

                var toStopCycle = false;
                if (item != null)
                {
                    if (item.MessageSendingOptions.IsEncrypted)
                    {
                        switch (item.Body)
                        {
                            case BindTempAuthKey:
                            case InvokeWithLayer { Query: InitConnection }:
                                await (_encryptedTasks[1] = SendEncryptedMessages(new List<MessageItem>(1) { item }, _startTime));
                                toStopCycle = true;
                                break;
                            default:
                                _pendingMessages.Add(item);
                                break;
                        }
                    }
                    else
                    {
                        await (_encryptedTasks[2] = SendUnencryptedMessage(item, _startTime));
                    }
                }

                if (toStopCycle)
                {
                    return;
                }
            }

            if (_pendingMessages.Count > 0 && _encryptedTasks[0] == null)
            {
                _encryptedTasks[1] = SendEncryptedMessages(_pendingMessages, _startTime);
                _pendingMessages = new List<MessageItem>();
            }
        }

        public async ValueTask WaitReleaseAsync(Task itemTask)
        {
            if (itemTask.IsCompleted)
            {
                return;
            }

            var tasks = new List<Task>
            {
                itemTask
            };

            foreach (var task in _encryptedTasks)
            {
                if (task == null)
                {
                    continue;
                }

                if (task.IsCompleted)
                {
                    return;
                }
                else
                {
                    tasks.Add(task);
                }
            }

            await Task.WhenAny(tasks);
        }

        public bool DoTasksCleanup()
        {
            for (var i = 0; i < _encryptedTasks.Length; i++)
            {
                if (_encryptedTasks[i]?.IsCompleted == true)
                {
                    var (loop, result) = _encryptedTasks[i]!.Result;
                    _encryptedTasks[i] = null;
                    if (result == SendResult.SocketException && loop == _startTime)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private async Task<(int Loop, SendResult Result)> SendUnencryptedMessage(MessageItem message, int loopCount)
        {
            if (!SocketTools.TrySerialize(message, _logger, out var body))
            {
                return (loopCount, SendResult.SerializationFailed);
            }

            var socketMessage = new UnencryptedConnectionMessage(_mtProtoState.MessageIdsHandler.ComputeMessageId(), body!);
            message.SetSent(0);
            if (!await _connection.Protocol!.Writer!.SendAsync(socketMessage.Export()))
            {
                message.SetToSend();
                return (loopCount, SendResult.SocketException);
            }

            _logger.Information("Successfully sent unencrypted message {Type}", message.Body);
            return (loopCount, SendResult.SuccessfullySent);
        }

        private async Task<(int Loop, SendResult Result)> SendEncryptedMessages(List<MessageItem> messages, int loopCount)
        {
            await _connection.Signaler.WaitAsync();
            AuthKey authKey;
            if (messages.Count == 1 && messages[0].MessageSendingOptions.SendWithAuthKey is not null)
            {
                authKey = messages[0].MessageSendingOptions.SendWithAuthKey!;
            }
            else
            {
                authKey = await _mtProtoState.KeysHandler.TemporaryAuthKey.GetAuthKeyAsync();
            }

            byte[] body;
            int seqno;
            long messageId;

            var acknowledgments = _messagesHandler.MessagesTrackers.MessagesAckTracker.GetAcknowledgements();
            messages = acknowledgments.Concat(messages).ToList();
            List<MessageItem> sentMessages;
            if (messages.Count == 1)
            {
                var message = messages[0];
                sentMessages = new List<MessageItem>(1) { message };
                if (!SocketTools.TrySerialize(message, _logger, out body!))
                {
                    return (loopCount, SendResult.SerializationFailed);
                }

                var messageSendingOptions = message.MessageSendingOptions;
                messageId = messageSendingOptions.SendWithMessageId ?? _mtProtoState.MessageIdsHandler.ComputeMessageId();
                seqno = _mtProtoState.SeqnoHandler.ComputeSeqno(message.Body);
                message.SetSent(messageId);
            }
            else
            {
                var writer = new ContainersWriter(_logger);
                writer.CreateContainer(messages, _messagesHandler, _mtProtoState);
                body = writer.SerializedContainer!;
                messageId = _mtProtoState.MessageIdsHandler.ComputeMessageId();
                seqno = _mtProtoState.SeqnoHandler.ContentRelatedSent * 2;
                sentMessages = writer.MessageItems.Select(x => x.Item2).ToList();
                foreach (var t in writer.MessageItems)
                {
                    t.Item2.SetSent(t.Item1.MsgId);
                }
            }

            var encryptedMessage = new EncryptedConnectionMessage(authKey, messageId, _mtProtoState.SaltHandler.GetSalt(), _mtProtoState.SessionIdHandler.GetSessionId(), seqno, body);
            if (!await _connection.Protocol!.Writer!.SendAsync(encryptedMessage.Export()))
            {
                sentMessages.SetToSend();
                return (loopCount, SendResult.SocketException);
            }

            return (loopCount, SendResult.SuccessfullySent);
        }

        private void AskReconnection()
        {
            _logger.Information("SendLoop asking to reconnect to {Info}", _connection.ConnectionInfo);
            _connection.ConnectAsync();
        }
    }
}