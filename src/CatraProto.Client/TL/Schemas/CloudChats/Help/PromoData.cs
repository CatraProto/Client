using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
	public partial class PromoData : PromoDataBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Proxy = 1 << 0,
			PsaType = 1 << 1,
			PsaMessage = 1 << 2
		}

        public static int StaticConstructorId { get => -1942390465; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("proxy")]
		public bool Proxy { get; set; }

[JsonPropertyName("expires")]
		public override int Expires { get; set; }

[JsonPropertyName("peer")]
		public PeerBase Peer { get; set; }

[JsonPropertyName("chats")]
		public IList<ChatBase> Chats { get; set; }

[JsonPropertyName("users")]
		public IList<UserBase> Users { get; set; }

[JsonPropertyName("psa_type")]
		public string PsaType { get; set; }

[JsonPropertyName("psa_message")]
		public string PsaMessage { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Proxy ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = PsaType == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = PsaMessage == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Expires);
			writer.Write(Peer);
			writer.Write(Chats);
			writer.Write(Users);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(PsaType);
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(PsaMessage);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Proxy = FlagsHelper.IsFlagSet(Flags, 0);
			Expires = reader.Read<int>();
			Peer = reader.Read<PeerBase>();
			Chats = reader.ReadVector<ChatBase>();
			Users = reader.ReadVector<UserBase>();
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				PsaType = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				PsaMessage = reader.Read<string>();
			}
		}

		public override string ToString()
		{
			return "help.promoData";
		}
	}
}