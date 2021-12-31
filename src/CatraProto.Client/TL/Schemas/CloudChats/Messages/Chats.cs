using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class Chats : CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatsBase
	{


        public static int StaticConstructorId { get => 1694474197; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("chats")]
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> ChatsField { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(ChatsField);

		}

		public override void Deserialize(Reader reader)
		{
			ChatsField = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>();

		}
				
		public override string ToString()
		{
		    return "messages.chats";
		}
	}
}