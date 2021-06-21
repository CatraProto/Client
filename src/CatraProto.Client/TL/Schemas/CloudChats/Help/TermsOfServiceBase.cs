using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public abstract class TermsOfServiceBase : IObject
    {
		public abstract bool Popup { get; set; }
		public abstract CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase Id { get; set; }
		public abstract string Text { get; set; }
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> Entities { get; set; }
		public abstract int? MinAgeConfirm { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
