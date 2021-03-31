using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class SetGameScore : IMethod<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>
	{
		[Flags]
		public enum FlagsEnum 
		{
			EditMessage = 1 << 0,
			Force = 1 << 1
		}

        public static int ConstructorId { get; } = -1896289088;

		public int Flags { get; set; }
		public bool EditMessage { get; set; }
		public bool Force { get; set; }
		public InputPeerBase Peer { get; set; }
		public int Id { get; set; }
		public InputUserBase UserId { get; set; }
		public int Score { get; set; }

		public void UpdateFlags() 
		{
			Flags = EditMessage ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Force ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Peer);
			writer.Write(Id);
			writer.Write(UserId);
			writer.Write(Score);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			EditMessage = FlagsHelper.IsFlagSet(Flags, 0);
			Force = FlagsHelper.IsFlagSet(Flags, 1);
			Peer = reader.Read<InputPeerBase>();
			Id = reader.Read<int>();
			UserId = reader.Read<InputUserBase>();
			Score = reader.Read<int>();

		}
	}
}