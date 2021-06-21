using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class ImportLoginToken : IMethod
	{
		public static int ConstructorId { get; } = -1783866140;
		public byte[] Token { get; set; }

		public Type Type { get; init; } = typeof(LoginTokenBase);
		public bool IsVector { get; init; } = false;

		public void UpdateFlags()
		{
		}

		public void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Token);
		}

		public void Deserialize(Reader reader)
		{
			Token = reader.Read<byte[]>();
		}
	}
}