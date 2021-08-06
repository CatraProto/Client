using System;
using System.Collections.Generic;
using CatraProto.TL;
using System.Text.Json.Serialization;
using CatraProto.TL.Interfaces;
#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetAttachedStickers : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => -866424884; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.StickerSetCoveredBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = true;

[JsonPropertyName("media")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputStickeredMediaBase Media { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Media);

		}

		public void Deserialize(Reader reader)
		{
			Media = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputStickeredMediaBase>();

		}
	}
}