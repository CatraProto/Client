using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class LangPackStringPluralized : LangPackStringBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			ZeroValue = 1 << 0,
			OneValue = 1 << 1,
			TwoValue = 1 << 2,
			FewValue = 1 << 3,
			ManyValue = 1 << 4
		}

        public static int ConstructorId { get; } = 1816636575;
		public int Flags { get; set; }
		public override string Key { get; set; }
		public string ZeroValue { get; set; }
		public string OneValue { get; set; }
		public string TwoValue { get; set; }
		public string FewValue { get; set; }
		public string ManyValue { get; set; }
		public string OtherValue { get; set; }

		public override void UpdateFlags() 
		{
			Flags = ZeroValue == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = OneValue == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = TwoValue == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = FewValue == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
			Flags = ManyValue == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Key);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(ZeroValue);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(OneValue);
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(TwoValue);
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				writer.Write(FewValue);
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				writer.Write(ManyValue);
			}

			writer.Write(OtherValue);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Key = reader.Read<string>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				ZeroValue = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				OneValue = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				TwoValue = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				FewValue = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				ManyValue = reader.Read<string>();
			}

			OtherValue = reader.Read<string>();

		}
	}
}