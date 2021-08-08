using CatraProto.TL.Interfaces;
using Serilog;

namespace CatraProto.Client.MTProto.Auth
{
    class SeqnoHandler
    {
        public int ContentRelatedReceived { get; set; }
        public int ContentRelatedSent { get; set; }
        private readonly ILogger _logger;

        public SeqnoHandler(ILogger logger, int clientInitialState = 0, int serverInitialState = 0)
        {
            _logger = logger.ForContext<SeqnoHandler>();
            ContentRelatedReceived = clientInitialState;
            ContentRelatedSent = serverInitialState;
        }

        public int ComputeSeqno(IObject obj, bool computeServer = false)
        {
            var add = AcknowledgementHandler.IsContentRelated(obj) ? 1 : 0;
            var currentCount = computeServer ? ContentRelatedReceived : ContentRelatedSent;
            var newCount = currentCount + add;

            if (computeServer)
            {
                ContentRelatedReceived = newCount;
            }
            else
            {
                ContentRelatedSent = newCount;
            }
            
            var computeSeqno = currentCount * 2 + add;
            
            var side = computeServer ? "server" : "client";
            _logger.Verbose("Computed {Side} seqno for object {Obj}, new value is {NSeqno}, old contentRelated {CRelated}", side, obj, computeSeqno, currentCount);
            return computeSeqno;
        }
    }
}