using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Upload
{
	public partial class GetFile : IMethod<CatraProto.Client.TL.Schemas.CloudChats.Upload.FileBase>
	{
		[Flags]
		public enum FlagsEnum 
		{
			Precise = 1 << 0,
			CdnSupported = 1 << 1
		}

        public static int ConstructorId { get; } = -1319462148;

		public int Flags { get; set; }
		public bool Precise { get; set; }
		public bool CdnSupported { get; set; }
		public InputFileLocationBase Location { get; set; }
		public int Offset { get; set; }
		public int Limit { get; set; }

		public void UpdateFlags() 
		{
			Flags = Precise ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = CdnSupported ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Location);
			writer.Write(Offset);
			writer.Write(Limit);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Precise = FlagsHelper.IsFlagSet(Flags, 0);
			CdnSupported = FlagsHelper.IsFlagSet(Flags, 1);
			Location = reader.Read<InputFileLocationBase>();
			Offset = reader.Read<int>();
			Limit = reader.Read<int>();

		}
	}
}