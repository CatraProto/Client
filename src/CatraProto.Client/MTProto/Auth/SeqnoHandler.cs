using CatraProto.TL.Interfaces;
using Serilog;

namespace CatraProto.Client.MTProto.Auth
{
    class SeqnoHandler
    {
        public int ContentRelatedReceived { get; set; }
        public int ContentRelatedSent { get; set; }
        private ILogger _logger;

        public SeqnoHandler(ILogger logger, int clientInitialState = 0, int serverInitialState = 0)
        {
            _logger = logger.ForContext<SeqnoHandler>();
            ContentRelatedReceived = clientInitialState;
            ContentRelatedSent = serverInitialState;
        }

        public int ComputeSeqno(IObject obj, bool computeServer = false)
        {
            var side = computeServer ? "server" : "client";
            var add = AcknowledgementHandler.IsContentRelated(obj) ? 1 : 0;
            var currentSeqno = computeServer ? ContentRelatedReceived : ContentRelatedSent;
            var newSeqno = currentSeqno + add;

            if (computeServer)
            {
                ContentRelatedReceived = newSeqno;
            }
            else
            {
                ContentRelatedSent = newSeqno;
            }
            
            var computedNewSeqno = currentSeqno * 2 + add;
            _logger.Verbose("Computed {Side} seqno for object {Obj}, new value is {NSeqno}, old contentRelated {CRelated}", side, obj, computedNewSeqno, currentSeqno);
            return computedNewSeqno;
        }
    }
}