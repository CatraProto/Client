using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputMediaGame : CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase
	{


        public static int StaticConstructorId { get => -750828557; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("id")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputGameBase Id { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Id);

		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputGameBase>();

		}
	}
}