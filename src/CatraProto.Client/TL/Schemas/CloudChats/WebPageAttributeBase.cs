using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class WebPageAttributeBase : IObject
    {
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> Documents { get; set; }
		public abstract CatraProto.Client.TL.Schemas.CloudChats.ThemeSettingsBase Settings { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
