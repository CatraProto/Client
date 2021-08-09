using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelAdminLogEventActionEditMessage : CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase
	{


        public static int StaticConstructorId { get => 1889215493; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("prev_message")]
		public CatraProto.Client.TL.Schemas.CloudChats.MessageBase PrevMessage { get; set; }

[JsonPropertyName("new_message")]
		public CatraProto.Client.TL.Schemas.CloudChats.MessageBase NewMessage { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(PrevMessage);
			writer.Write(NewMessage);

		}

		public override void Deserialize(Reader reader)
		{
			PrevMessage = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.MessageBase>();
			NewMessage = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.MessageBase>();

		}
	}
}