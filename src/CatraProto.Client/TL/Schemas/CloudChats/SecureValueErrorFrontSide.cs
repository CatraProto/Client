using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class SecureValueErrorFrontSide : CatraProto.Client.TL.Schemas.CloudChats.SecureValueErrorBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 12467706; }
        
[Newtonsoft.Json.JsonProperty("type")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase Type { get; set; }

[Newtonsoft.Json.JsonProperty("file_hash")]
		public byte[] FileHash { get; set; }

[Newtonsoft.Json.JsonProperty("text")]
		public sealed override string Text { get; set; }


        #nullable enable
 public SecureValueErrorFrontSide (CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase type,byte[] fileHash,string text)
{
 Type = type;
FileHash = fileHash;
Text = text;
 
}
#nullable disable
        internal SecureValueErrorFrontSide() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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
		    return "secureValueErrorFrontSide";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}