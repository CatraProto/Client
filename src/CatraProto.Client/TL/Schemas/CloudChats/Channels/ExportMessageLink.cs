using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class ExportMessageLink : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Grouped = 1 << 0,
			Thread = 1 << 1
		}

        public static int ConstructorId { get; } = -432034325;

		public System.Type Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Channels.ExportMessageLink);
		public bool IsVector { get; init; } = false;
		public int Flags { get; set; }
		public bool Grouped { get; set; }
		public bool Thread { get; set; }
		public InputChannelBase Channel { get; set; }
		public int Id { get; set; }

		public void UpdateFlags() 
		{
			Flags = Grouped ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Thread ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Channel);
			writer.Write(Id);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Grouped = FlagsHelper.IsFlagSet(Flags, 0);
			Thread = FlagsHelper.IsFlagSet(Flags, 1);
			Channel = reader.Read<InputChannelBase>();
			Id = reader.Read<int>();

		}
	}
}