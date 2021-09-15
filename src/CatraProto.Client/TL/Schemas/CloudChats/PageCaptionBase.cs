using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class PageCaptionBase : IObject
    {

[Newtonsoft.Json.JsonProperty("text")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.RichTextBase Text { get; set; }

[Newtonsoft.Json.JsonProperty("credit")]
		public abstract CatraProto.Client.TL.Schemas.CloudChats.RichTextBase Credit { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
