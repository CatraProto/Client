using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputStickerSetID : CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase
	{


        public static int StaticConstructorId { get => -1645763991; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("id")]
		public long Id { get; set; }

[Newtonsoft.Json.JsonProperty("access_hash")]
		public long AccessHash { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Id);
			writer.Write(AccessHash);

		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<long>();
			AccessHash = reader.Read<long>();

		}
				
		public override string ToString()
		{
		    return "inputStickerSetID";
		}
	}
}