using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChatInvite : CatraProto.Client.TL.Schemas.CloudChats.ChatInviteBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Channel = 1 << 0,
			Broadcast = 1 << 1,
			Public = 1 << 2,
			Megagroup = 1 << 3,
			Participants = 1 << 4
		}

        public static int StaticConstructorId { get => -540871282; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("channel")]
		public bool Channel { get; set; }

[Newtonsoft.Json.JsonProperty("broadcast")]
		public bool Broadcast { get; set; }

[Newtonsoft.Json.JsonProperty("public")]
		public bool Public { get; set; }

[Newtonsoft.Json.JsonProperty("megagroup")]
		public bool Megagroup { get; set; }

[Newtonsoft.Json.JsonProperty("title")]
		public string Title { get; set; }

[Newtonsoft.Json.JsonProperty("photo")]
		public CatraProto.Client.TL.Schemas.CloudChats.PhotoBase Photo { get; set; }

[Newtonsoft.Json.JsonProperty("participants_count")]
		public int ParticipantsCount { get; set; }

[Newtonsoft.Json.JsonProperty("participants")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Participants { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Channel ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Broadcast ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = Public ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
			Flags = Megagroup ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
			Flags = Participants == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Title);
			writer.Write(Photo);
			writer.Write(ParticipantsCount);
			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				writer.Write(Participants);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Channel = FlagsHelper.IsFlagSet(Flags, 0);
			Broadcast = FlagsHelper.IsFlagSet(Flags, 1);
			Public = FlagsHelper.IsFlagSet(Flags, 2);
			Megagroup = FlagsHelper.IsFlagSet(Flags, 3);
			Title = reader.Read<string>();
			Photo = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PhotoBase>();
			ParticipantsCount = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				Participants = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();
			}


		}
				
		public override string ToString()
		{
		    return "chatInvite";
		}
	}
}