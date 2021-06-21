using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class InstallTheme : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Dark = 1 << 0,
			Format = 1 << 1,
			Theme = 1 << 1
		}

        public static int ConstructorId { get; } = 2061776695;

		public System.Type Type { get; init; } = typeof(bool);
		public bool IsVector { get; init; } = false;
		public int Flags { get; set; }
		public bool Dark { get; set; }
		public string Format { get; set; }
		public CatraProto.Client.TL.Schemas.CloudChats.InputThemeBase Theme { get; set; }

		public void UpdateFlags() 
		{
			Flags = Dark ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Format == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = Theme == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(Format);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(Theme);
			}


		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Dark = FlagsHelper.IsFlagSet(Flags, 0);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				Format = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				Theme = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputThemeBase>();
			}


		}
	}
}