using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class InputSingleMediaBase : IObject
    {
		public abstract CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase Media { get; set; }
		public abstract long RandomId { get; set; }
		public abstract string Message { get; set; }
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> Entities { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
