using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Updates
{
	public partial class ChannelDifferenceTooLong : CatraProto.Client.TL.Schemas.CloudChats.Updates.ChannelDifferenceBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Final = 1 << 0,
			Timeout = 1 << 1
		}

        public static int StaticConstructorId { get => -1531132162; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("final")]
		public sealed override bool Final { get; set; }

[Newtonsoft.Json.JsonProperty("timeout")]
		public sealed override int? Timeout { get; set; }

[Newtonsoft.Json.JsonProperty("dialog")]
		public CatraProto.Client.TL.Schemas.CloudChats.DialogBase Dialog { get; set; }

[Newtonsoft.Json.JsonProperty("messages")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.MessageBase> Messages { get; set; }

[Newtonsoft.Json.JsonProperty("chats")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


        #nullable enable
 public ChannelDifferenceTooLong (CatraProto.Client.TL.Schemas.CloudChats.DialogBase dialog,IList<CatraProto.Client.TL.Schemas.CloudChats.MessageBase> messages,IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chats,IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
{
 Dialog = dialog;
Messages = messages;
Chats = chats;
Users = users;
 
}
#nullable disable
        internal ChannelDifferenceTooLong() 
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
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(Timeout.Value);
			}

			writer.Write(Dialog);
			writer.Write(Messages);
			writer.Write(Chats);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Final = FlagsHelper.IsFlagSet(Flags, 0);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				Timeout = reader.Read<int>();
			}

			Dialog = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.DialogBase>();
			Messages = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageBase>();
			Chats = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>();
			Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();

		}
				
		public override string ToString()
		{
		    return "updates.channelDifferenceTooLong";
		}
	}
}