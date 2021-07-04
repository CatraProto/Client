using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
	public partial class SetCallRating : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			UserInitiative = 1 << 0
		}

        public static int ConstructorId { get; } = 1508562471;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase);
		public bool IsVector { get; init; } = false;
		public int Flags { get; set; }
		public bool UserInitiative { get; set; }
		public CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase Peer { get; set; }
		public int Rating { get; set; }
		public string Comment { get; set; }

		public void UpdateFlags() 
		{
			Flags = UserInitiative ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Peer);
			writer.Write(Rating);
			writer.Write(Comment);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			UserInitiative = FlagsHelper.IsFlagSet(Flags, 0);
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase>();
			Rating = reader.Read<int>();
			Comment = reader.Read<string>();

		}
	}
}