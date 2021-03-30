using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using CatraProto.Client.TL.Schemas.CloudChats.Auth;


namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class SentCode : SentCodeBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			NextType = 1 << 1,
			Timeout = 1 << 2
		}

        public static int ConstructorId { get; } = 1577067778;
		public int Flags { get; set; }
		public override SentCodeTypeBase Type { get; set; }
		public override string PhoneCodeHash { get; set; }
		public override CodeTypeBase NextType { get; set; }
		public override int? Timeout { get; set; }

		public override void UpdateFlags() 
		{
			Flags = NextType == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = Timeout == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Type);
			writer.Write(PhoneCodeHash);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(NextType);
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(Timeout.Value);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Type = reader.Read<SentCodeTypeBase>();
			PhoneCodeHash = reader.Read<string>();
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				NextType = reader.Read<CodeTypeBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				Timeout = reader.Read<int>();
			}


		}
	}
}