using System.Collections.Generic;
using CatraProto.Client.Connections;
using CatraProto.Client.TL.Schemas.MTProto;

namespace CatraProto.Client.MTProto.Auth
{
    class AcknowledgeHandler
    {
        private List<long> _toAcknowledge = new List<long>();
        private MessagesHandler _scheduler;
        public AcknowledgeHandler(MessagesHandler scheduler)
        {
            _scheduler = scheduler;
        }
        
        public void AddMessage(long messageId)
        {
            _toAcknowledge.Add(messageId);
        }

        public MsgsAck GetAck()
        {
            var msgsAck = new MsgsAck()
            {
                MsgIds = _toAcknowledge
            };
            _toAcknowledge = new List<long>();
            return msgsAck;
        }
    }
}