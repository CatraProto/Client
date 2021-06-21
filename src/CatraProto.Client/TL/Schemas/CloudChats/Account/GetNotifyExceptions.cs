using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class GetNotifyExceptions : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			CompareSound = 1 << 1,
			Peer = 1 << 0
		}

        public static int ConstructorId { get; } = 1398240377;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase);
		public bool IsVector { get; init; } = false;
		public int Flags { get; set; }
		public bool CompareSound { get; set; }
		public CatraProto.Client.TL.Schemas.CloudChats.InputNotifyPeerBase Peer { get; set; }

		public void UpdateFlags() 
		{
			Flags = CompareSound ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = Peer == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Peer);
			}


		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			CompareSound = FlagsHelper.IsFlagSet(Flags, 1);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputNotifyPeerBase>();
			}


		}
	}
}