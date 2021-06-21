using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using CatraProto.Client.TL.Schemas.CloudChats;
using System.Collections.Generic;


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

        public static int ConstructorId { get; } = -1942390465;
		public int Flags { get; set; }
		public bool Proxy { get; set; }
		public override int Expires { get; set; }
		public CatraProto.Client.TL.Schemas.CloudChats.PeerBase Peer { get; set; }
		public IList<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }
		public IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }
		public string PsaType { get; set; }
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
	}
}