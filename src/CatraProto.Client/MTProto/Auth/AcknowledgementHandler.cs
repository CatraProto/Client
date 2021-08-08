using System.Collections.Generic;
using CatraProto.Client.Connections.MessageScheduling;
using CatraProto.Client.Connections.MessageScheduling.Items;
using CatraProto.Client.TL.Schemas.MTProto;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.MTProto.Auth
{
    class AcknowledgementHandler
    {
        private readonly List<long> _ackIds = new List<long>();
        private readonly object _mutex = new object();

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

        public IEnumerable<MessageItem> GetAckMessages()
        {
            lock (_mutex)
            {
                var result = new List<MessageItem>();
                while (true)
                {
                    var ack = GetAckObject();
                    if (ack == null)
                    {
                        return result;
                    }

                    result.Add(new MessageItem(ack, new MessageSendingOptions(true), new MessageStatus(new MessageCompletion(null, null, null)), default));
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

        public bool SetAsReceived(long messageId)
        {
            lock (_mutex)
            {
                return _ackIds.Remove(messageId);
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