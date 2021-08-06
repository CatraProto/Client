using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class FeaturedStickersNotModified : CatraProto.Client.TL.Schemas.CloudChats.Messages.FeaturedStickersBase
	{


        public static int StaticConstructorId { get => -958657434; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("count")]
		public override int Count { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Count);

		}

		public override void Deserialize(Reader reader)
		{
			Count = reader.Read<int>();

		}
	}
}