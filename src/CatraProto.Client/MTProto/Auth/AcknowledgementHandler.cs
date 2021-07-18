using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CatraProto.Client.Async.Signalers;
using CatraProto.Client.Connections;
using CatraProto.Client.TL.Schemas.MTProto;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.MTProto.Auth
{
    class AcknowledgementHandler
    {
        private List<long> _toAcknowledge = new List<long>();
        private List<long> _mustReceiveAcknowledge = new List<long>();

        public void AddWaitAck(long messageId)
        {
            _mustReceiveAcknowledge.Add(messageId);
        }

        public bool WaitingAck(long messageId)
        {
            return _mustReceiveAcknowledge.Remove(messageId);
        }
        
        public void AddToAck(long messageId)
        {
            _toAcknowledge.Add(messageId);
        }

        public MsgsAck GetAckMessage()
        {
            if (_toAcknowledge.Count == 0)
            {
                return null;
            }
            
            var newList = new List<long>();
            for (var i = (_toAcknowledge.Count > 8192 ? 8192 : _toAcknowledge.Count) - 1; i >= 0; i--)
            {
                newList.Add(_toAcknowledge[i]);
                _toAcknowledge.Remove(_toAcknowledge[i]);
            }

            return new MsgsAck
            {
                MsgIds = newList
            };
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