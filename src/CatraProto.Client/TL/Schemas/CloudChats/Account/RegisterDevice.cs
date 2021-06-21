using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using System.Collections.Generic;


namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class RegisterDevice : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			NoMuted = 1 << 0
		}

        public static int ConstructorId { get; } = 1754754159;

		public System.Type Type { get; init; } = typeof(bool);
		public bool IsVector { get; init; } = false;
		public int Flags { get; set; }
		public bool NoMuted { get; set; }
		public int TokenType { get; set; }
		public string Token { get; set; }
		public bool AppSandbox { get; set; }
		public byte[] Secret { get; set; }
		public IList<int> OtherUids { get; set; }

		public void UpdateFlags() 
		{
			Flags = NoMuted ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(TokenType);
			writer.Write(Token);
			writer.Write(AppSandbox);
			writer.Write(Secret);
			writer.Write(OtherUids);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			NoMuted = FlagsHelper.IsFlagSet(Flags, 0);
			TokenType = reader.Read<int>();
			Token = reader.Read<string>();
			AppSandbox = reader.Read<bool>();
			Secret = reader.Read<byte[]>();
			OtherUids = reader.ReadVector<int>();

		}
	}
}