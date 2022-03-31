using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class MessageReactionsList : CatraProto.Client.TL.Schemas.CloudChats.Messages.MessageReactionsListBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			NextOffset = 1 << 0
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 834488621; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("count")]
		public sealed override int Count { get; set; }

[Newtonsoft.Json.JsonProperty("reactions")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.MessagePeerReactionBase> Reactions { get; set; }

[Newtonsoft.Json.JsonProperty("chats")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

[Newtonsoft.Json.JsonProperty("next_offset")]
		public sealed override string NextOffset { get; set; }


        #nullable enable
 public MessageReactionsList (int count,IList<CatraProto.Client.TL.Schemas.CloudChats.MessagePeerReactionBase> reactions,IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chats,IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
{
 Count = count;
Reactions = reactions;
Chats = chats;
Users = users;
 
}
#nullable disable
        internal MessageReactionsList() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = NextOffset == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Count);
			writer.Write(Reactions);
			writer.Write(Chats);
			writer.Write(Users);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(NextOffset);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Count = reader.Read<int>();
			Reactions = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessagePeerReactionBase>();
			Chats = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>();
			Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				NextOffset = reader.Read<string>();
			}


		}
		
		public override string ToString()
		{
		    return "messages.messageReactionsList";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}