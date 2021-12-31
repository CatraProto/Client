using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class ChatsSlice : CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatsBase
	{


        public static int StaticConstructorId { get => -1663561404; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("count")]
		public int Count { get; set; }

[Newtonsoft.Json.JsonProperty("chats")]
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> ChatsField { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Count);
			writer.Write(ChatsField);

		}

		public override void Deserialize(Reader reader)
		{
			Count = reader.Read<int>();
			ChatsField = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>();

		}
				
		public override string ToString()
		{
		    return "messages.chatsSlice";
		}
	}
}