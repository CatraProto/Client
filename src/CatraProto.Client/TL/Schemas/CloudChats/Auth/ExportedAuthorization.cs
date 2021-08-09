using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class ExportedAuthorization : CatraProto.Client.TL.Schemas.CloudChats.Auth.ExportedAuthorizationBase
	{


        public static int StaticConstructorId { get => -543777747; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("id")]
		public override int Id { get; set; }

[JsonPropertyName("bytes")]
		public override byte[] Bytes { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Id);
			writer.Write(Bytes);

		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<int>();
			Bytes = reader.Read<byte[]>();

		}
	}
}