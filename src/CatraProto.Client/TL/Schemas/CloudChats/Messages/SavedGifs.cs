using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class SavedGifs : CatraProto.Client.TL.Schemas.CloudChats.Messages.SavedGifsBase
	{


        public static int StaticConstructorId { get => 772213157; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("hash")]
		public int Hash { get; set; }

[JsonPropertyName("gifs")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> Gifs { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Hash);
			writer.Write(Gifs);

		}

		public override void Deserialize(Reader reader)
		{
			Hash = reader.Read<int>();
			Gifs = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();

		}
	}
}