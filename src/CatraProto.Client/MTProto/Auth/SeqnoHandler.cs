using System;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.MTProto;
using CatraProto.TL.Interfaces;
using Serilog;

namespace CatraProto.Client.MTProto.Auth
{
    class SeqnoHandler
    {
        private static List<Type> _notContentRelatedMessages = new List<Type>()
        {
            typeof(MsgsAck),
            typeof(Ping),
            typeof(MsgContainer)
        };

        private int _contentRelatedSent = 0;
        private ILogger _logger;
        public SeqnoHandler()
        {
            //_logger = logger.ForContext<SeqnoHandler>();
        }

        public bool IsContentRelated(IObject obj)
        {
            return !_notContentRelatedMessages.Contains(obj.GetType());
        }

        public int ComputeSeqno(IObject obj)
        {
            var seqno = _contentRelatedSent * 2;
            if (!IsContentRelated(obj))
            {
                return seqno;
            }

            _contentRelatedSent++;
            seqno++;

            return seqno;
        }
    }
}