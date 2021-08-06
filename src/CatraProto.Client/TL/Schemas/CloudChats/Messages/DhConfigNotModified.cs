using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class DhConfigNotModified : CatraProto.Client.TL.Schemas.CloudChats.Messages.DhConfigBase
	{


        public static int StaticConstructorId { get => -1058912715; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("random")]
		public override byte[] Random { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Random);

		}

		public override void Deserialize(Reader reader)
		{
			Random = reader.Read<byte[]>();

		}
	}
}