using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class MessagesSlice : CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Inexact = 1 << 1,
			NextRate = 1 << 0,
			OffsetIdOffset = 1 << 2
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 978610270; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("inexact")]
		public bool Inexact { get; set; }

[Newtonsoft.Json.JsonProperty("count")]
		public int Count { get; set; }

[Newtonsoft.Json.JsonProperty("next_rate")]
		public int? NextRate { get; set; }

[Newtonsoft.Json.JsonProperty("offset_id_offset")]
		public int? OffsetIdOffset { get; set; }

[Newtonsoft.Json.JsonProperty("messages")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.MessageBase> Messages { get; set; }

[Newtonsoft.Json.JsonProperty("chats")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


        #nullable enable
 public MessagesSlice (int count,IList<CatraProto.Client.TL.Schemas.CloudChats.MessageBase> messages,IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chats,IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
{
 Count = count;
Messages = messages;
Chats = chats;
Users = users;
 
}
#nullable disable
        internal MessagesSlice() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Inexact ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = NextRate == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = OffsetIdOffset == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Count);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(NextRate.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(OffsetIdOffset.Value);
			}

			writer.Write(Messages);
			writer.Write(Chats);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Inexact = FlagsHelper.IsFlagSet(Flags, 1);
			Count = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				NextRate = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				OffsetIdOffset = reader.Read<int>();
			}

			Messages = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageBase>();
			Chats = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>();
			Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();

		}
		
		public override string ToString()
		{
		    return "messages.messagesSlice";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}