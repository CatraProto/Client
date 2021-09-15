using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class HighScoreBase : IObject
    {

[Newtonsoft.Json.JsonProperty("pos")]
		public abstract int Pos { get; set; }

[Newtonsoft.Json.JsonProperty("user_id")]
		public abstract int UserId { get; set; }

[Newtonsoft.Json.JsonProperty("score")]
		public abstract int Score { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
