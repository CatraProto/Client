using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class BotInfoBase : IObject
    {
		public abstract int UserId { get; set; }
		public abstract string Description { get; set; }
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.BotCommandBase> Commands { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
