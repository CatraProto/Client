using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
	public partial class PromoData : CatraProto.Client.TL.Schemas.CloudChats.Help.PromoDataBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Proxy = 1 << 0,
			PsaType = 1 << 1,
			PsaMessage = 1 << 2
		}

        public static int StaticConstructorId { get => -1942390465; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("proxy")]
		public bool Proxy { get; set; }

[Newtonsoft.Json.JsonProperty("expires")]
		public sealed override int Expires { get; set; }

[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.PeerBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("chats")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

[Newtonsoft.Json.JsonProperty("psa_type")]
		public string PsaType { get; set; }

[Newtonsoft.Json.JsonProperty("psa_message")]
		public string PsaMessage { get; set; }


        #nullable enable
 public PromoData (int expires,CatraProto.Client.TL.Schemas.CloudChats.PeerBase peer,IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chats,IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
{
 Expires = expires;
Peer = peer;
Chats = chats;
Users = users;
 
}
#nullable disable
        internal PromoData() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Proxy ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = PsaType == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = PsaMessage == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
			Chats = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>();
			Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();
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