using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class GzipPacked : IObject
	{


        public static int StaticConstructorId { get => 812830625; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("packed_data")]
		public byte[] PackedData { get; set; }

        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(PackedData);

		}

		public void Deserialize(Reader reader)
		{
			PackedData = reader.Read<byte[]>();

		}
				
		public override string ToString()
		{
		    return "gzip_packed";
		}
	}
}