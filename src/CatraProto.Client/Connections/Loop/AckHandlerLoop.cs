using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Async.Loops.Enums.Resumable;
using CatraProto.Client.Async.Loops.Interfaces;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.Connections.MessageScheduling.Items;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.TL.Schemas.MTProto;
using CatraProto.TL;
using Serilog;

namespace CatraProto.Client.Connections.Loop
{
    class AckHandlerLoop : LoopImplementation<ResumableLoopState, ResumableSignalState>
    {
        private readonly Connection _connection;
        private readonly ILogger _logger;

        public AckHandlerLoop(Connection connection, ILogger logger)
        {
            _connection = connection;
            _logger = logger.ForContext<AckHandlerLoop>();
        }

        public override async Task LoopAsync(CancellationToken stoppingToken)
        {
            var currentState = StateSignaler.GetCurrentState(true);
            var isStart = true;
            while (true)
            {
                if (currentState!.AlreadyHandled)
                {
                    currentState = StateSignaler.GetCurrentState(true);
                }

                if (!currentState!.AlreadyHandled)
                {
                    switch (currentState.Signal)
                    {
                        case ResumableSignalState.Start:
                            SetSignalHandled(ResumableLoopState.Running, currentState);
                            _logger.Information("Acknowledgment handler loop started for connection {Connection}", _connection.ConnectionInfo);
                            break;
                        case ResumableSignalState.Stop:
                            _logger.Information("Acknowledgment handler loop stopped for connection {Connection}", _connection.ConnectionInfo);
                            SetSignalHandled(ResumableLoopState.Stopped, currentState);
                            return;
                        case ResumableSignalState.Resume:
                            SetSignalHandled(ResumableLoopState.Running, currentState);
                            _logger.Verbose("Acknowledgment handler loop for connection {Connection} woken up", _connection.ConnectionInfo);
                            break;
                        case ResumableSignalState.Suspend:
                            SetSignalHandled(ResumableLoopState.Suspended, currentState);
                            _logger.Verbose("Acknowledgment handler loop for connection {Connection} paused. Waiting for signal...", _connection.ConnectionInfo);
                            currentState = await StateSignaler.WaitAsync(stoppingToken);
                            isStart = false;
                            break;
                    }
                }

                _logger.Information("Getting list of acknowledgments to send to the server");
                var acknowledgements = _connection.MessagesHandler.MessagesTrackers.AcknowledgementHandler.GetAckMessages();
                var count = acknowledgements.Count;
                if (count > 0)
                {
                    _logger.Information("Sending {Count} acknowledgments to {Connection}", count, _connection.ConnectionInfo);
                    foreach (var acknowledgement in acknowledgements)
                    {
                        _logger.Information("Sending acknowledgments of {Count} messages to {Connection}", ((MsgsAck)acknowledgement.Body).MsgIds.Count, _connection.ConnectionInfo);
                        acknowledgement.BindTo(_connection.MessagesHandler);
                        acknowledgement.SetToSend();
                    }
                }

                _logger.Information("Getting list of old messages that have not yet received an answer from the server");
                var messages = _connection.MessagesHandler.MessagesTrackers.MessageCompletionTracker.GetUnanswered(isStart);
                var listOfIds = new List<Tuple<long, MessageItem>>();

                foreach (var message in messages)
                {
                    var messageId = message.GetProtocolInfo().MessageId!.Value;
                    if (isStart || MessageIdsHandler.IsOlderThan(messageId, 30))
                    {
                        _logger.Information("Going to send state request for message {Message}", messageId);
                        listOfIds.Add(new Tuple<long, MessageItem>(messageId, message));
                    }
                }

                _logger.Information("Sending state request for {Count} messages to {Connection}", listOfIds.Count, _connection.ConnectionInfo);
                if (listOfIds.Count > 0)
                {
                    try
                    {
                        var msgStates = (await _connection.MtProtoState.Api.MtProtoApi.MsgsStateReqAsync(listOfIds.Select(x => x.Item1).ToList(), cancellationToken: stoppingToken)).Response;
                        for (var index = 0; index < msgStates.Info.Length; index++)
                        {
                            var originalMessage = listOfIds[index];
                            var state = msgStates.Info[index];
                            if (FlagsHelper.IsFlagSet(state, 0) || FlagsHelper.IsFlagSet(state, 1) || (state & 3) != 0)
                            {
                                _logger.Information("Received state {State} for message {Message}, scheduling message to be resent", state, originalMessage.Item1);
                                originalMessage.Item2.SetToSend();
                            }

                            if (FlagsHelper.IsFlagSet(state, 3) || FlagsHelper.IsFlagSet(state, 4))
                            {
                                _logger.Information("Received state {State} for message {Message}, setting as acknowledged and waiting for message to arrive", state, originalMessage.Item1);
                                originalMessage.Item2.SetAcknowledged(new ExecutionInfo(_connection.ConnectionInfo));
                            }

                            //msg_resend_ans_req doesn't seem to be working so I'm not bothering implementing it
                            /*if (FlagsHelper.IsFlagSet(state, 5) && FlagsHelper.IsFlagSet(state, 6))
                            {
                                _logger.Information("Server already generated a response for {MessageId} but we didn't receive it, asking to resend...", originalMessage.Item1);
                            }*/
                        }
                    }
                    catch (OperationCanceledException e) when (e.CancellationToken == stoppingToken)
                    {
                        _logger.Information("Operation canceled because loop stopped on connection {Connection}", _connection.ConnectionInfo);
                        SetLoopState(ResumableLoopState.Stopped);
                        return;
                    }
                }
            }
        }

        public override string ToString()
        {
            return $"Ack handler loop for {_connection.ConnectionInfo}";
        }
    }
}