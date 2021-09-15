using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ImportedContact : CatraProto.Client.TL.Schemas.CloudChats.ImportedContactBase
	{


        public static int StaticConstructorId { get => -805141448; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("user_id")]
		public override int UserId { get; set; }

[Newtonsoft.Json.JsonProperty("client_id")]
		public override long ClientId { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(UserId);
			writer.Write(ClientId);

		}

		public override void Deserialize(Reader reader)
		{
			UserId = reader.Read<int>();
			ClientId = reader.Read<long>();

		}
				
		public override string ToString()
		{
		    return "importedContact";
		}
	}
}