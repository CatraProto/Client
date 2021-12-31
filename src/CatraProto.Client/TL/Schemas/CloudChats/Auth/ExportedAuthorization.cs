using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class ExportedAuthorization : CatraProto.Client.TL.Schemas.CloudChats.Auth.ExportedAuthorizationBase
	{


        public static int StaticConstructorId { get => -1271602504; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("id")]
		public override long Id { get; set; }

[Newtonsoft.Json.JsonProperty("bytes")]
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
			Id = reader.Read<long>();
			Bytes = reader.Read<byte[]>();

		}
				
		public override string ToString()
		{
		    return "auth.exportedAuthorization";
		}
	}
}