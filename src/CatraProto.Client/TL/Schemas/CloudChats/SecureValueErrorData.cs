using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class SecureValueErrorData : CatraProto.Client.TL.Schemas.CloudChats.SecureValueErrorBase
	{


        public static int StaticConstructorId { get => -391902247; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("type")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase Type { get; set; }

[Newtonsoft.Json.JsonProperty("data_hash")]
		public byte[] DataHash { get; set; }

[Newtonsoft.Json.JsonProperty("field")]
		public string Field { get; set; }

[Newtonsoft.Json.JsonProperty("text")]
		public sealed override string Text { get; set; }


        #nullable enable
 public SecureValueErrorData (CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase type,byte[] dataHash,string field,string text)
{
 Type = type;
DataHash = dataHash;
Field = field;
Text = text;
 
}
#nullable disable
        internal SecureValueErrorData() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Type);
			writer.Write(DataHash);
			writer.Write(Field);
			writer.Write(Text);

		}

		public override void Deserialize(Reader reader)
		{
			Type = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase>();
			DataHash = reader.Read<byte[]>();
			Field = reader.Read<string>();
			Text = reader.Read<string>();

		}
				
		public override string ToString()
		{
		    return "secureValueErrorData";
		}
	}
}