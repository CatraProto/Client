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


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 812830625; }
        
[Newtonsoft.Json.JsonProperty("packed_data")]
		public byte[] PackedData { get; set; }


        #nullable enable
 public GzipPacked (byte[] packedData)
{
 PackedData = packedData;
 
}
#nullable disable
        internal GzipPacked() 
        {
        }
		
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}