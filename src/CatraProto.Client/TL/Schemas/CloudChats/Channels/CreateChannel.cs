using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class CreateChannel : IMethod<CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase>
	{
		[Flags]
		public enum FlagsEnum 
		{
			Broadcast = 1 << 0,
			Megagroup = 1 << 1,
			ForImport = 1 << 3,
			GeoPoint = 1 << 2,
			Address = 1 << 2
		}

        public static int ConstructorId { get; } = 1029681423;

		public int Flags { get; set; }
		public bool Broadcast { get; set; }
		public bool Megagroup { get; set; }
		public bool ForImport { get; set; }
		public string Title { get; set; }
		public string About { get; set; }
		public InputGeoPointBase GeoPoint { get; set; }
		public string Address { get; set; }

		public void UpdateFlags() 
		{
			Flags = Broadcast ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Megagroup ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = ForImport ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
			Flags = GeoPoint == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = Address == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Title);
			writer.Write(About);
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(GeoPoint);
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(Address);
			}


		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Broadcast = FlagsHelper.IsFlagSet(Flags, 0);
			Megagroup = FlagsHelper.IsFlagSet(Flags, 1);
			ForImport = FlagsHelper.IsFlagSet(Flags, 3);
			Title = reader.Read<string>();
			About = reader.Read<string>();
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				GeoPoint = reader.Read<InputGeoPointBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				Address = reader.Read<string>();
			}


		}
	}
}