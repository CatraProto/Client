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


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1694474197; }
        
[Newtonsoft.Json.JsonProperty("chats")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> ChatsField { get; set; }


        #nullable enable
 public Chats (IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chatsField)
{
 ChatsField = chatsField;
 
}
#nullable disable
        internal Chats() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}