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


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1645763991; }
        
[Newtonsoft.Json.JsonProperty("id")]
		public long Id { get; set; }

[Newtonsoft.Json.JsonProperty("access_hash")]
		public long AccessHash { get; set; }


        #nullable enable
 public InputStickerSetID (long id,long accessHash)
{
 Id = id;
AccessHash = accessHash;
 
}
#nullable disable
        internal InputStickerSetID() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}