using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class FileHash : CatraProto.Client.TL.Schemas.CloudChats.FileHashBase
	{


        public static int StaticConstructorId { get => 1648543603; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("offset")]
		public override int Offset { get; set; }

[Newtonsoft.Json.JsonProperty("limit")]
		public override int Limit { get; set; }

[Newtonsoft.Json.JsonProperty("hash")]
		public override byte[] Hash { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Offset);
			writer.Write(Limit);
			writer.Write(Hash);

		}

		public override void Deserialize(Reader reader)
		{
			Offset = reader.Read<int>();
			Limit = reader.Read<int>();
			Hash = reader.Read<byte[]>();

		}
				
		public override string ToString()
		{
		    return "fileHash";
		}
	}
}