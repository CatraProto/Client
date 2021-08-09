using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class EmojiURL : CatraProto.Client.TL.Schemas.CloudChats.EmojiURLBase
	{


        public static int StaticConstructorId { get => -1519029347; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("url")]
		public override string Url { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Url);

		}

		public override void Deserialize(Reader reader)
		{
			Url = reader.Read<string>();

		}
	}
}