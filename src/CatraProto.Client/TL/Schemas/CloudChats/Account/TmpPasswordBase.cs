using CatraProto.TL;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public abstract class TmpPasswordBase : IObject
    {

[JsonPropertyName("TmpPassword_")]
		public abstract byte[] TmpPassword_ { get; set; }

[JsonPropertyName("valid_until")]
		public abstract int ValidUntil { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
