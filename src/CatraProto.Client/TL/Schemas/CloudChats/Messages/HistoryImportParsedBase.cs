using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public abstract class HistoryImportParsedBase : IObject
    {

[Newtonsoft.Json.JsonProperty("pm")]
		public abstract bool Pm { get; set; }

[Newtonsoft.Json.JsonProperty("group")]
		public abstract bool Group { get; set; }

[Newtonsoft.Json.JsonProperty("title")]
		public abstract string Title { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
