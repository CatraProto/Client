using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChatForbidden : CatraProto.Client.TL.Schemas.CloudChats.ChatBase
	{


        public static int StaticConstructorId { get => 120753115; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("id")]
		public override int Id { get; set; }

[JsonPropertyName("title")]
		public string Title { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Id);
			writer.Write(Title);

		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<int>();
			Title = reader.Read<string>();

		}
	}
}