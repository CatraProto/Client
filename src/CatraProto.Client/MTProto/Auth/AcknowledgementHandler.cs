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
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.Connections.MessageScheduling.Enums;
using CatraProto.Client.Connections.MessageScheduling.Items;
using CatraProto.Client.TL.Schemas.MTProto;
using CatraProto.TL.Interfaces;
using Serilog;

namespace CatraProto.Client.MTProto.Auth
{
    internal class AcknowledgementHandler
    {
        private readonly List<long> _ackIds = new List<long>();
        private readonly object _mutex = new object();
        private readonly ILogger _logger;

        public AcknowledgementHandler(ILogger logger)
        {
            _logger = logger.ForContext<AcknowledgementHandler>();
        }

        public MsgsAck? GetAckObject()
        {
            lock (_mutex)
            {
                if (_ackIds.Count == 0)
                {
                    return null;
                }

                var newList = new List<long>();
                for (var i = (_ackIds.Count > 8192 ? 8192 : _ackIds.Count) - 1; i >= 0; i--)
                {
                    newList.Add(_ackIds[i]);
                    _ackIds.Remove(_ackIds[i]);
                }

                return new MsgsAck
                {
                    MsgIds = newList
                };
            }
        }

        public List<MessageItem> GetAckMessages()
        {
            lock (_mutex)
            {
                var result = new List<MessageItem>();
                while (true)
                {
                    var ack = GetAckObject();
                    if (ack == null)
                    {
                        if (result.Count > 0)
                        {
                            _logger.Information("Generated {Count} acknowledgments", result.Count);
                        }

                        return result;
                    }

                    result.Add(new MessageItem(ack, new MessageSendingOptions(true, awaiterType: AwaiterType.OnSent), new MessageStatus(new MessageCompletion(null, null, null)), _logger, default));
                }
            }
        }

        public void SetAsNeedsAck(long messageId)
        {
            lock (_mutex)
            {
                _ackIds.Add(messageId);
            }
        }

        public void SendAcknowledgment(long messageId, IObject? messageBody)
        {
            if (messageBody is not null && !IsContentRelated(messageBody))
            {
                _logger.Verbose("Not acknowledging message {Message} because it's not content related", messageBody);
                return;
            }

            SetAsNeedsAck(messageId);
        }

        public bool SetAsReceived(long messageId)
        {
            lock (_mutex)
            {
                return _ackIds.Remove(messageId);
            }
        }

        public void Reset()
        {
            lock (_mutex)
            {
                _ackIds.Clear();
            }
        }

        public static bool IsContentRelated(IObject obj)
        {
            switch (obj)
            {
                case MsgsAck:
                case RpcAnswerUnknown:
                case RpcAnswerDroppedRunning:
                case RpcAnswerDropped:
                case GetFutureSalts:
                case FutureSalts:
                case FutureSalt:
                case Ping:
                case Pong:
                case PingDelayDisconnect:
                case DestroySession:
                case DestroySessionOk:
                case DestroySessionNone:
                case MsgContainer:
                case MsgCopy:
                case GzipPacked:
                case HttpWait:
                case BadMsgNotification:
                case BadServerSalt:
                case MsgsStateReq:
                case MsgsStateInfo:
                case MsgsAllInfo:
                case MsgDetailedInfo:
                case MsgNewDetailedInfo:
                case MsgResendReq:
                    return false;
            }

            return true;
        }
    }
}