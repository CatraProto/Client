using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputPhoto : CatraProto.Client.TL.Schemas.CloudChats.InputPhotoBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1001634122; }
        
[Newtonsoft.Json.JsonProperty("id")]
		public long Id { get; set; }

[Newtonsoft.Json.JsonProperty("access_hash")]
		public long AccessHash { get; set; }

[Newtonsoft.Json.JsonProperty("file_reference")]
		public byte[] FileReference { get; set; }


        #nullable enable
 public InputPhoto (long id,long accessHash,byte[] fileReference)
{
 Id = id;
AccessHash = accessHash;
FileReference = fileReference;
 
}
#nullable disable
        internal InputPhoto() 
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
			writer.Write(FileReference);

		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<long>();
			AccessHash = reader.Read<long>();
			FileReference = reader.Read<byte[]>();

		}
		
		public override string ToString()
		{
		    return "inputPhoto";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}