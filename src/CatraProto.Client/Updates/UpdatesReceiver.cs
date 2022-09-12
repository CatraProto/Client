/*
CatraProto, a C# library that implements the MTProto protocol and the Telegram API.
Copyright (C) 2022 Aquatica <aquathing@protonmail.com>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using System.Collections.Generic;
using System.Threading.Tasks;
using CatraProto.Client.Async.Loops;
using CatraProto.Client.Async.Loops.Enums.Resumable;
using CatraProto.Client.Async.Loops.Extensions;
using CatraProto.Client.MTProto.Session.Models;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Messages;
using CatraProto.Client.Tools;
using CatraProto.Client.Updates.CustomTypes;
using CatraProto.TL.Interfaces;
using Serilog;

namespace CatraProto.Client.Updates
{
    internal class UpdatesReceiver
    {
        private readonly Dictionary<long, (ResumableLoopController Controller, UpdateProcessor Processor)> _processors = new Dictionary<long, (ResumableLoopController, UpdateProcessor)>();
        private readonly (ResumableLoopController Controller, UpdateProcessor Processor) _commonLoop;
        private readonly object _mutex = new object();
        private readonly UpdatesState _commonSequence;
        private readonly TelegramClient _client;
        private readonly ILogger _logger;

        public UpdatesReceiver(TelegramClient client, ILogger logger)
        {
            _client = client;
            _logger = logger.ForContext<UpdatesReceiver>();
            _commonSequence = client.ClientSession.SessionManager.SessionData.UpdatesStates.GetState();
            _commonLoop.Processor = new UpdateProcessor(client, null, logger, _commonSequence);
            _commonLoop.Controller = new ResumableLoopController(_logger);
        }

        public void OnNewUpdates(IObject socketObject, IMethod? callingMethod = null)
        {
            var localSeq = _commonSequence.GetData().seq;
            if (socketObject is UpdateRedirect redirect)
            {
                socketObject = redirect.Update;
            }

            _logger.Information("Received new update {Update}", socketObject);
            if (socketObject is UpdatesBase updatesBase)
            {
                if (UpdatesTools.GetSeq(updatesBase, out var finalSeq, out var seqStart, out var date))
                {
                    if (seqStart == 0 || localSeq + 1 == seqStart)
                    {
                        if (UpdatesTools.GetUpdatesData(updatesBase, out var updates))
                        {
                            foreach (var updateObj in updates)
                            {
                                PushUpdate(updateObj);
                            }

                            if (finalSeq > 0 && date > 0)
                            {
                                _commonSequence.SetData(seq: finalSeq, date: date);
                            }
                        }
                    }
                    else if (localSeq + 1 > seqStart)
                    {
                        _logger.Information("Received update was already applied SEQ({LocalSeq} + 1 > {SeqStart})", localSeq, seqStart);
                        return;
                    }
                    else if (localSeq + 1 < seqStart)
                    {
                        _logger.Information("Seq gap detected SEQ({LocalSeq} + 1 < {SeqStart}), Manually sending updates too long to fetch difference...", localSeq, seqStart);
                        PushUpdate(new UpdatesTooLong());
                    }
                }
                else
                {
                    switch (socketObject)
                    {
                        case UpdatesTooLong:
                            PushUpdate(socketObject);
                            break;
                        case UpdateShort updateShort:
                            PushUpdate(updateShort.Update);
                            break;
                        default:
                            PushUpdate((IObject?)ConvertUpdate(updatesBase, callingMethod) ?? new UpdatesTooLong());
                            break;
                    }
                }
            }
            else if (socketObject is UpdateBase)
            {
                PushUpdate(socketObject);
            }
        }

        private void PushUpdate(IObject update)
        {
            lock (_mutex)
            {
                if (!UpdatesTools.IsFromChannel(update, out var channelId))
                {
                    if (_commonLoop.Processor.AddUpdateToQueue(update))
                    {
                        _commonLoop.Controller.ResumeAndSuspendAsync();
                    }
                }
                else
                {
                    var getProcessor = GetProcessor(channelId!.Value);
                    if (getProcessor != null)
                    {
                        var (controller, processor) = getProcessor.Value;
                        if (processor.AddUpdateToQueue(update))
                        {
                            controller.ResumeAndSuspendAsync();
                        }
                    }
                    else
                    {
                        _logger.Information("Won't process updates for channel {Channel} because processor does not exist", channelId);
                    }
                }
            }
        }

        private UpdateBase? ConvertUpdate(UpdatesBase updatesBase, IMethod? query = null)
        {
            UpdateBase converted;
            switch (updatesBase)
            {
                case UpdateShortMessage updateShortMessage:
                    var toNewMessage = new UpdateNewMessage();
                    var message = new Message();

                    toNewMessage.Pts = updateShortMessage.Pts;
                    toNewMessage.PtsCount = updateShortMessage.PtsCount;
                    toNewMessage.Message = message;

                    if (updateShortMessage.Out)
                    {
                        _client.ClientSession.SessionManager.SessionData.Authorization.GetAuthorization(out _, out var currentId);
                        if (currentId is null)
                        {
                            return null;
                        }

                        message.FromId = new PeerUser()
                        {
                            UserId = currentId.Value
                        };
                    }
                    else
                    {
                        message.FromId = new PeerUser()
                        {
                            UserId = updateShortMessage.UserId
                        };
                    }

                    message.Date = updateShortMessage.Date;
                    message.Out = updateShortMessage.Out;
                    message.Mentioned = updateShortMessage.Mentioned;
                    message.MediaUnread = updateShortMessage.MediaUnread;
                    message.Silent = updateShortMessage.Silent;
                    message.Id = updateShortMessage.Id;
                    message.PeerId = new PeerUser
                    {
                        UserId = updateShortMessage.UserId
                    };
                    message.MessageField = updateShortMessage.Message;
                    message.FwdFrom = updateShortMessage.FwdFrom;
                    message.ViaBotId = updateShortMessage.ViaBotId;
                    message.ReplyTo = updateShortMessage.ReplyTo;
                    message.Entities = updateShortMessage.Entities;
                    message.TtlPeriod = updateShortMessage.TtlPeriod;
                    message.UpdateFlags();
                    converted = toNewMessage;
                    break;
                case UpdateShort updateShort:
                    return updateShort.Update;
                case UpdateShortSentMessage updateShortSentMessage:
                    if (query is null)
                    {
                        _logger.Warning("Received updateShortSentMessage with null query");
                        return null;
                    }

                    if (query is not SendMessage sendMessage)
                    {
                        _logger.Warning("Received updateShortSentMessage from method {Query}", query);
                        return null;
                    }

                    PeerBase fromId;
                    if (sendMessage.SendAs is null)
                    {
                        _client.ClientSession.SessionManager.SessionData.Authorization.GetAuthorization(out _, out var currentId);
                        if (currentId is null)
                        {
                            return null;
                        }

                        fromId = new PeerUser()
                        {
                            UserId = currentId.Value
                        };
                    }
                    else
                    {
                        var peer = PeerTools.FromInputToPeer(sendMessage.SendAs);
                        if (peer is null)
                        {
                            return null;
                        }

                        fromId = peer;
                    }

                    var messageObj = new Message()
                    {
                        FromId = fromId,
                        PeerId = PeerTools.FromInputToPeer(sendMessage.Peer),
                        Media = updateShortSentMessage.Media,
                        Date = updateShortSentMessage.Date,
                        TtlPeriod = updateShortSentMessage.TtlPeriod,
                        Entities = updateShortSentMessage.Entities,
                        Out = updateShortSentMessage.Out,
                        Id = updateShortSentMessage.Id,
                        MessageField = sendMessage.Message
                    };

                    converted = sendMessage.Peer switch
                    {
                        InputPeerChannel => new UpdateNewChannelMessage()
                        {
                            Message = messageObj,
                            Pts = updateShortSentMessage.Pts,
                            PtsCount = updateShortSentMessage.PtsCount
                        },
                        _ => new UpdateNewMessage
                        {
                            Message = messageObj,
                            Pts = updateShortSentMessage.Pts,
                            PtsCount = updateShortSentMessage.PtsCount
                        }
                    };
                    messageObj.UpdateFlags();
                    break;
                case UpdateShortChatMessage updateShortChatMessage:
                    var toChatMessage = new UpdateNewMessage();
                    var originalMessage = new Message();
                    toChatMessage.Pts = updateShortChatMessage.Pts;
                    toChatMessage.PtsCount = updateShortChatMessage.PtsCount;

                    originalMessage.FromId = new PeerUser()
                    {
                        UserId = updateShortChatMessage.FromId
                    };
                    originalMessage.Date = updateShortChatMessage.Date;
                    originalMessage.Out = updateShortChatMessage.Out;
                    originalMessage.Mentioned = updateShortChatMessage.Mentioned;
                    originalMessage.MediaUnread = updateShortChatMessage.MediaUnread;
                    originalMessage.Silent = updateShortChatMessage.Silent;
                    originalMessage.Id = updateShortChatMessage.Id;
                    originalMessage.PeerId = new PeerChat()
                    {
                        ChatId = updateShortChatMessage.ChatId
                    };
                    originalMessage.MessageField = updateShortChatMessage.Message;
                    originalMessage.FwdFrom = updateShortChatMessage.FwdFrom;
                    originalMessage.ViaBotId = updateShortChatMessage.ViaBotId;
                    originalMessage.ReplyTo = updateShortChatMessage.ReplyTo;
                    originalMessage.Entities = updateShortChatMessage.Entities;
                    originalMessage.TtlPeriod = updateShortChatMessage.TtlPeriod;
                    toChatMessage.Message = originalMessage;
                    originalMessage.UpdateFlags();
                    converted = toChatMessage;
                    break;
                default:
                    return null;
            }

            converted.UpdateFlags();
            return converted;
        }

        public void FillProcessors()
        {
            lock (_mutex)
            {
                _commonLoop.Controller.BindTo(_commonLoop.Processor);
                _commonLoop.Controller.SendSignal(ResumableSignalState.Start, out _);
                _commonLoop.Controller.SendSignal(ResumableSignalState.Suspend, out _);
                foreach (var (chatId, state) in _client.ClientSession.SessionManager.SessionData.UpdatesStates.GetAllChannelsStates())
                {
                    if (!state.GetData().isActive)
                    {
                        continue;
                    }

                    _logger.Information("Creating processor for channelId {ChatId}", chatId);
                    var tuple = CreateProcessor(chatId);
                    _processors.TryAdd(chatId, tuple);
                }
            }
        }

        public (ResumableLoopController Controller, UpdateProcessor Processor)? GetProcessor(long channelId)
        {
            lock (_mutex)
            {
                if (_processors.TryGetValue(channelId, out var tuple))
                {
                    return tuple;
                }
                else
                {
                    return null;
                }
            }
        }

        public (ResumableLoopController Controller, UpdateProcessor Processor) CreateProcessor(long channelId, bool forceFetchOnCreate = false)
        {
            lock (_mutex)
            {
                if (!_processors.TryGetValue(channelId, out var tuple))
                {
                    _logger.Information("Creating processor for channel {Id}", channelId);
                    var state = _client.ClientSession.SessionManager.SessionData.UpdatesStates.GetState(channelId);
                    tuple.Processor = new UpdateProcessor(_client, channelId, _logger, state);
                    tuple.Controller = new ResumableLoopController(_logger);
                    tuple.Controller.BindTo(tuple.Processor);
                    state.SetData(isActive: true);

                    tuple.Controller.SendSignal(ResumableSignalState.Start, out _);
                    tuple.Controller.SendSignal(ResumableSignalState.Suspend, out _);

                    if (forceFetchOnCreate)
                    {
                        _logger.Information("Forcing get difference on channel {Id}", channelId);
                        tuple.Processor.AddUpdateToQueue(new UpdateChannelTooLong());
                        tuple.Controller.ResumeAndSuspendAsync();
                    }

                    _processors.TryAdd(channelId, tuple);
                }

                return tuple;
            }
        }

        public void CloseProcessor(long channelId)
        {
            lock (_mutex)
            {
                if (_processors.Remove(channelId, out var tuple))
                {
                    _logger.Information("Closing processor for channel {Id}", channelId);
                    tuple.Controller.SendSignal(ResumableSignalState.Stop, out _);
                    _client.ClientSession.SessionManager.SessionData.UpdatesStates.GetState(channelId).SetData(isActive: false);
                }
            }
        }

        public Task ForceGetDifferenceAllAsync(bool waitCompletion)
        {
            lock (_mutex)
            {
                if (_client.ClientSession.SessionManager.SessionData.Authorization.GetAuthorization(out _, out _) is not ApiManagers.LoginState.LoggedIn)
                {
                    _logger.Information("Skipping get difference all because we are not authorized");
                    return Task.CompletedTask;
                }

                _logger.Information("Forcefully fetching difference in all states by sending UpdatesTooLong");
                _commonLoop.Processor.AddUpdateToQueue(new UpdatesTooLong());
                var commonTask = _commonLoop.Controller.ResumeAndSuspendAsync();
                return waitCompletion ? commonTask : Task.CompletedTask;
            }
        }

        public Task CloseAllAsync()
        {
            lock (_mutex)
            {
                _logger.Information("Stopping all updates processors");
                var size = _processors.Count;
                var tasksToWait = new Task[size + 1];

                var i = 0;
                foreach (var (chatId, (controller, processor)) in _processors)
                {
                    _logger.Information("Stopping update processor for channel {ChatId}", chatId);
                    tasksToWait[i++] = controller.TrySignalAsync(ResumableSignalState.Stop);
                }

                tasksToWait[size] = _commonLoop.Controller.TrySignalAsync(ResumableSignalState.Stop);
                return Task.WhenAll(tasksToWait);
            }
        }
    }
}