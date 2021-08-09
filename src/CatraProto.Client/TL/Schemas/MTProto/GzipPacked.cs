using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
	public partial class GzipPacked : IObject
	{


        public static int StaticConstructorId { get => 812830625; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("packed_data")]
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
	}
}