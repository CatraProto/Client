using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public abstract class BotResultsBase : IObject
    {
		public abstract bool Gallery { get; set; }
		public abstract long QueryId { get; set; }
		public abstract string NextOffset { get; set; }
		public abstract CatraProto.Client.TL.Schemas.CloudChats.InlineBotSwitchPMBase SwitchPm { get; set; }
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.BotInlineResultBase> Results { get; set; }
		public abstract int CacheTime { get; set; }
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
