using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateChannelMessageForwards : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{


        public static int StaticConstructorId { get => 1854571743; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("channel_id")]
		public int ChannelId { get; set; }

[Newtonsoft.Json.JsonProperty("id")]
		public int Id { get; set; }

[Newtonsoft.Json.JsonProperty("forwards")]
		public int Forwards { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(ChannelId);
			writer.Write(Id);
			writer.Write(Forwards);

		}

		public override void Deserialize(Reader reader)
		{
			ChannelId = reader.Read<int>();
			Id = reader.Read<int>();
			Forwards = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "updateChannelMessageForwards";
		}
	}
}