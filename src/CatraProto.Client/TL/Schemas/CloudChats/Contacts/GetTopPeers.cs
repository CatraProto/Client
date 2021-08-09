using System;
using System.Collections.Generic;
using CatraProto.TL;
using System.Text.Json.Serialization;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
	public partial class GetTopPeers : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Correspondents = 1 << 0,
			BotsPm = 1 << 1,
			BotsInline = 1 << 2,
			PhoneCalls = 1 << 3,
			ForwardUsers = 1 << 4,
			ForwardChats = 1 << 5,
			Groups = 1 << 10,
			Channels = 1 << 15
		}

        [JsonIgnore]
        public static int StaticConstructorId { get => -728224331; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Contacts.TopPeersBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("correspondents")]
		public bool Correspondents { get; set; }

[JsonPropertyName("bots_pm")]
		public bool BotsPm { get; set; }

[JsonPropertyName("bots_inline")]
		public bool BotsInline { get; set; }

[JsonPropertyName("phone_calls")]
		public bool PhoneCalls { get; set; }

[JsonPropertyName("forward_users")]
		public bool ForwardUsers { get; set; }

[JsonPropertyName("forward_chats")]
		public bool ForwardChats { get; set; }

[JsonPropertyName("groups")]
		public bool Groups { get; set; }

[JsonPropertyName("channels")]
		public bool Channels { get; set; }

[JsonPropertyName("offset")]
		public int Offset { get; set; }

[JsonPropertyName("limit")]
		public int Limit { get; set; }

[JsonPropertyName("hash")]
		public int Hash { get; set; }


		public void UpdateFlags() 
		{
			Flags = Correspondents ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = BotsPm ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = BotsInline ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
			Flags = PhoneCalls ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
			Flags = ForwardUsers ? FlagsHelper.SetFlag(Flags, 4) : FlagsHelper.UnsetFlag(Flags, 4);
			Flags = ForwardChats ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
			Flags = Groups ? FlagsHelper.SetFlag(Flags, 10) : FlagsHelper.UnsetFlag(Flags, 10);
			Flags = Channels ? FlagsHelper.SetFlag(Flags, 15) : FlagsHelper.UnsetFlag(Flags, 15);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Offset);
			writer.Write(Limit);
			writer.Write(Hash);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Correspondents = FlagsHelper.IsFlagSet(Flags, 0);
			BotsPm = FlagsHelper.IsFlagSet(Flags, 1);
			BotsInline = FlagsHelper.IsFlagSet(Flags, 2);
			PhoneCalls = FlagsHelper.IsFlagSet(Flags, 3);
			ForwardUsers = FlagsHelper.IsFlagSet(Flags, 4);
			ForwardChats = FlagsHelper.IsFlagSet(Flags, 5);
			Groups = FlagsHelper.IsFlagSet(Flags, 10);
			Channels = FlagsHelper.IsFlagSet(Flags, 15);
			Offset = reader.Read<int>();
			Limit = reader.Read<int>();
			Hash = reader.Read<int>();

		}
	}
}