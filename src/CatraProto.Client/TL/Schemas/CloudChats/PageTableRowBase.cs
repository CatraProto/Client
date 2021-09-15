using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class PageTableRowBase : IObject
    {

[Newtonsoft.Json.JsonProperty("cells")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.PageTableCellBase> Cells { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
