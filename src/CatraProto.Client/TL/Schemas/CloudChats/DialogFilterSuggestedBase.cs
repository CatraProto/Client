using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class DialogFilterSuggestedBase : IObject
    {
		public abstract CatraProto.Client.TL.Schemas.CloudChats.DialogFilterBase Filter { get; set; }
		public abstract string Description { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
