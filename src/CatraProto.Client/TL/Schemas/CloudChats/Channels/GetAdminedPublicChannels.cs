using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;


namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class GetAdminedPublicChannels : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			ByLocation = 1 << 0,
			CheckLimit = 1 << 1
		}

        public static int ConstructorId { get; } = -122669393;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatsBase);
		public bool IsVector { get; init; } = false;
		public int Flags { get; set; }
		public bool ByLocation { get; set; }
		public bool CheckLimit { get; set; }

		public void UpdateFlags() 
		{
			Flags = ByLocation ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = CheckLimit ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			ByLocation = FlagsHelper.IsFlagSet(Flags, 0);
			CheckLimit = FlagsHelper.IsFlagSet(Flags, 1);

		}
	}
}