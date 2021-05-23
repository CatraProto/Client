using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetPollVotes : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Option = 1 << 0,
			Offset = 1 << 1
		}

        public static int ConstructorId { get; } = -1200736242;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.GetPollVotes);
		public bool IsVector { get; init; } = false;
		public int Flags { get; set; }
		public InputPeerBase Peer { get; set; }
		public int Id { get; set; }
		public byte[] Option { get; set; }
		public string Offset { get; set; }
		public int Limit { get; set; }

		public void UpdateFlags() 
		{
			Flags = Option == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = Offset == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Peer);
			writer.Write(Id);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Option);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(Offset);
			}

			writer.Write(Limit);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Peer = reader.Read<InputPeerBase>();
			Id = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Option = reader.Read<byte[]>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				Offset = reader.Read<string>();
			}

			Limit = reader.Read<int>();

		}
	}
}