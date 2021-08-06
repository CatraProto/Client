using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class AccountDaysTTLBase : IObject
    {

[JsonPropertyName("days")]
		public abstract int Days { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
