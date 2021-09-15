using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
    public abstract class BankCardDataBase : IObject
    {

[Newtonsoft.Json.JsonProperty("title")]
		public abstract string Title { get; set; }

[Newtonsoft.Json.JsonProperty("open_urls")]
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.BankCardOpenUrlBase> OpenUrls { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
