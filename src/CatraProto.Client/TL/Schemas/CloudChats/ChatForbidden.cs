using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChatForbidden : CatraProto.Client.TL.Schemas.CloudChats.ChatBase
	{


        public static int StaticConstructorId { get => 120753115; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("id")]
		public override int Id { get; set; }

[Newtonsoft.Json.JsonProperty("title")]
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
				
		public override string ToString()
		{
		    return "chatForbidden";
		}
	}
}