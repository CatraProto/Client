using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class RecoverPassword : IMethod
	{
		public static int ConstructorId { get; } = 1319464594;
		public string Code { get; set; }

		public Type Type { get; init; } = typeof(AuthorizationBase);
		public bool IsVector { get; init; } = false;

		public void UpdateFlags()
		{
		}

		public void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Code);
		}

		public void Deserialize(Reader reader)
		{
			Code = reader.Read<string>();
		}
	}
}