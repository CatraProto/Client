using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class SecureValueErrorReverseSide : CatraProto.Client.TL.Schemas.CloudChats.SecureValueErrorBase
	{


        public static int StaticConstructorId { get => -2037765467; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("type")]
		public override CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase Type { get; set; }

[Newtonsoft.Json.JsonProperty("file_hash")]
		public byte[] FileHash { get; set; }

[Newtonsoft.Json.JsonProperty("text")]
		public override string Text { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Type);
			writer.Write(FileHash);
			writer.Write(Text);

		}

		public override void Deserialize(Reader reader)
		{
			Type = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase>();
			FileHash = reader.Read<byte[]>();
			Text = reader.Read<string>();

		}
				
		public override string ToString()
		{
		    return "secureValueErrorReverseSide";
		}
	}
}