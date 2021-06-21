using System;
using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class SecureValue : SecureValueBase
	{
		[Flags]
		public enum FlagsEnum
		{
			Data = 1 << 0,
			FrontSide = 1 << 1,
			ReverseSide = 1 << 2,
			Selfie = 1 << 3,
			Translation = 1 << 6,
			Files = 1 << 4,
			PlainData = 1 << 5
		}

		public static int ConstructorId { get; } = 411017418;
		public int Flags { get; set; }
		public override SecureValueTypeBase Type { get; set; }
		public override SecureDataBase Data { get; set; }
		public override SecureFileBase FrontSide { get; set; }
		public override SecureFileBase ReverseSide { get; set; }
		public override SecureFileBase Selfie { get; set; }
		public override IList<SecureFileBase> Translation { get; set; }
		public override IList<SecureFileBase> Files { get; set; }
		public override SecurePlainDataBase PlainData { get; set; }
		public override byte[] Hash { get; set; }

		public override void UpdateFlags()
		{
			Flags = Data == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = FrontSide == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = ReverseSide == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = Selfie == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
			Flags = Translation == null ? FlagsHelper.UnsetFlag(Flags, 6) : FlagsHelper.SetFlag(Flags, 6);
			Flags = Files == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
			Flags = PlainData == null ? FlagsHelper.UnsetFlag(Flags, 5) : FlagsHelper.SetFlag(Flags, 5);
		}

		public override void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Type);
			if (FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Data);
			}

			if (FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(FrontSide);
			}

			if (FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(ReverseSide);
			}

			if (FlagsHelper.IsFlagSet(Flags, 3))
			{
				writer.Write(Selfie);
			}

			if (FlagsHelper.IsFlagSet(Flags, 6))
			{
				writer.Write(Translation);
			}

			if (FlagsHelper.IsFlagSet(Flags, 4))
			{
				writer.Write(Files);
			}

			if (FlagsHelper.IsFlagSet(Flags, 5))
			{
				writer.Write(PlainData);
			}

			writer.Write(Hash);
		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Type = reader.Read<SecureValueTypeBase>();
			if (FlagsHelper.IsFlagSet(Flags, 0))
			{
				Data = reader.Read<SecureDataBase>();
			}

			if (FlagsHelper.IsFlagSet(Flags, 1))
			{
				FrontSide = reader.Read<SecureFileBase>();
			}

			if (FlagsHelper.IsFlagSet(Flags, 2))
			{
				ReverseSide = reader.Read<SecureFileBase>();
			}

			if (FlagsHelper.IsFlagSet(Flags, 3))
			{
				Selfie = reader.Read<SecureFileBase>();
			}

			if (FlagsHelper.IsFlagSet(Flags, 6))
			{
				Translation = reader.ReadVector<SecureFileBase>();
			}

			if (FlagsHelper.IsFlagSet(Flags, 4))
			{
				Files = reader.ReadVector<SecureFileBase>();
			}

			if (FlagsHelper.IsFlagSet(Flags, 5))
			{
				PlainData = reader.Read<SecurePlainDataBase>();
			}

			Hash = reader.Read<byte[]>();
		}
	}
}