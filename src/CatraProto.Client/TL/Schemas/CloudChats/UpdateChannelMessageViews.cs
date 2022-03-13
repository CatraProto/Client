using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateChannelMessageViews : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{


        public static int StaticConstructorId { get => -232346616; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("channel_id")]
		public long ChannelId { get; set; }

[Newtonsoft.Json.JsonProperty("id")]
		public int Id { get; set; }

[Newtonsoft.Json.JsonProperty("views")]
		public int Views { get; set; }


        #nullable enable
 public UpdateChannelMessageViews (long channelId,int id,int views)
{
 ChannelId = channelId;
Id = id;
Views = views;
 
}
#nullable disable
        internal UpdateChannelMessageViews() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(ChannelId);
			writer.Write(Id);
			writer.Write(Views);

		}

		public override void Deserialize(Reader reader)
		{
			ChannelId = reader.Read<long>();
			Id = reader.Read<int>();
			Views = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "updateChannelMessageViews";
		}
	}
}