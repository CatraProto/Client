using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class Chats : CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatsBase
	{


        public static int StaticConstructorId { get => 1694474197; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("Chats_")]
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats_ { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Chats_);

		}

		public override void Deserialize(Reader reader)
		{
			Chats_ = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>();

		}
	}
}