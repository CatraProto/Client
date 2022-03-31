using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class SecureFile : CatraProto.Client.TL.Schemas.CloudChats.SecureFileBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -534283678; }
        
[Newtonsoft.Json.JsonProperty("id")]
		public long Id { get; set; }

[Newtonsoft.Json.JsonProperty("access_hash")]
		public long AccessHash { get; set; }

[Newtonsoft.Json.JsonProperty("size")]
		public int Size { get; set; }

[Newtonsoft.Json.JsonProperty("dc_id")]
		public int DcId { get; set; }

[Newtonsoft.Json.JsonProperty("date")]
		public int Date { get; set; }

[Newtonsoft.Json.JsonProperty("file_hash")]
		public byte[] FileHash { get; set; }

[Newtonsoft.Json.JsonProperty("secret")]
		public byte[] Secret { get; set; }


        #nullable enable
 public SecureFile (long id,long accessHash,int size,int dcId,int date,byte[] fileHash,byte[] secret)
{
 Id = id;
AccessHash = accessHash;
Size = size;
DcId = dcId;
Date = date;
FileHash = fileHash;
Secret = secret;
 
}
#nullable disable
        internal SecureFile() 
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
			writer.Write(Size);
			writer.Write(DcId);
			writer.Write(Date);
			writer.Write(FileHash);
			writer.Write(Secret);

		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<long>();
			AccessHash = reader.Read<long>();
			Size = reader.Read<int>();
			DcId = reader.Read<int>();
			Date = reader.Read<int>();
			FileHash = reader.Read<byte[]>();
			Secret = reader.Read<byte[]>();

		}
		
		public override string ToString()
		{
		    return "secureFile";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}