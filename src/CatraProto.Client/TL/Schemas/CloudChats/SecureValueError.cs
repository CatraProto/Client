using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class SecureValueError : CatraProto.Client.TL.Schemas.CloudChats.SecureValueErrorBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -2036501105; }
        
[Newtonsoft.Json.JsonProperty("type")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase Type { get; set; }

[Newtonsoft.Json.JsonProperty("hash")]
		public byte[] Hash { get; set; }

[Newtonsoft.Json.JsonProperty("text")]
		public sealed override string Text { get; set; }


        #nullable enable
 public SecureValueError (CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase type,byte[] hash,string text)
{
 Type = type;
Hash = hash;
Text = text;
 
}
#nullable disable
        internal SecureValueError() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Type);
			writer.Write(Hash);
			writer.Write(Text);

		}

		public override void Deserialize(Reader reader)
		{
			Type = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase>();
			Hash = reader.Read<byte[]>();
			Text = reader.Read<string>();

		}
		
		public override string ToString()
		{
		    return "secureValueError";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}