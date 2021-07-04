using System;
using CatraProto.Client.MTProto.AuthKeyHandler;

namespace CatraProto.Client.MTProto.Auth
{
    class SessionData
    {
        public AuthKey AuthKey { get; set; }
        public SeqnoHandler SeqnoHandler { get; set; } = new SeqnoHandler();
        public long SessionId { get; set; } = new Random().Next();
        public long Salt { get; set; }
    }
}