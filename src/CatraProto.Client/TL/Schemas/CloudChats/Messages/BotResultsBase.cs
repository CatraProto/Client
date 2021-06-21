using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public abstract class BotResultsBase : IObject
    {
        public abstract bool Gallery { get; set; }
        public abstract long QueryId { get; set; }
        public abstract string NextOffset { get; set; }
        public abstract InlineBotSwitchPMBase SwitchPm { get; set; }
        public abstract IList<BotInlineResultBase> Results { get; set; }
        public abstract int CacheTime { get; set; }
        public abstract IList<UserBase> Users { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}