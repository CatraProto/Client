using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class BotInfoBase : IObject
    {

[Newtonsoft.Json.JsonProperty("user_id")]
		public abstract long UserId { get; set; }

[Newtonsoft.Json.JsonProperty("description")]
		public abstract string Description { get; set; }

[Newtonsoft.Json.JsonProperty("commands")]
		public abstract List<CatraProto.Client.TL.Schemas.CloudChats.BotCommandBase> Commands { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
