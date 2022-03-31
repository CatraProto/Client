using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Updates
{
	public partial class ChannelDifference : CatraProto.Client.TL.Schemas.CloudChats.Updates.ChannelDifferenceBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Final = 1 << 0,
			Timeout = 1 << 1
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 543450958; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("final")]
		public sealed override bool Final { get; set; }

[Newtonsoft.Json.JsonProperty("pts")]
		public int Pts { get; set; }

[Newtonsoft.Json.JsonProperty("timeout")]
		public sealed override int? Timeout { get; set; }

[Newtonsoft.Json.JsonProperty("new_messages")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.MessageBase> NewMessages { get; set; }

[Newtonsoft.Json.JsonProperty("other_updates")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.UpdateBase> OtherUpdates { get; set; }

[Newtonsoft.Json.JsonProperty("chats")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


        #nullable enable
 public ChannelDifference (int pts,IList<CatraProto.Client.TL.Schemas.CloudChats.MessageBase> newMessages,IList<CatraProto.Client.TL.Schemas.CloudChats.UpdateBase> otherUpdates,IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chats,IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
{
 Pts = pts;
NewMessages = newMessages;
OtherUpdates = otherUpdates;
Chats = chats;
Users = users;
 
}
#nullable disable
        internal ChannelDifference() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Final ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Timeout == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Pts);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(Timeout.Value);
			}

			writer.Write(NewMessages);
			writer.Write(OtherUpdates);
			writer.Write(Chats);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Final = FlagsHelper.IsFlagSet(Flags, 0);
			Pts = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				Timeout = reader.Read<int>();
			}

			NewMessages = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageBase>();
			OtherUpdates = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UpdateBase>();
			Chats = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>();
			Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();

		}
		
		public override string ToString()
		{
		    return "updates.channelDifference";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}