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
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> ChatsField { get; set; }


        #nullable enable
 public ChatsSlice (int count,IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chatsField)
{
 Count = count;
ChatsField = chatsField;
 
}
#nullable disable
        internal ChatsSlice() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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