using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class ConfirmPasswordEmail : IMethod
	{
		public static int ConstructorId { get; } = -1881204448;
		public string Code { get; set; }

		public Type Type { get; init; } = typeof(bool);
		public bool IsVector { get; init; } = false;

		public void UpdateFlags()
		{
		}

		public void Serialize(Writer writer)
		{
			if (ConstructorId != 0)
			{
				writer.Write(ConstructorId);
			}

			writer.Write(Code);
		}

		public void Deserialize(Reader reader)
		{
			Code = reader.Read<string>();
		}
	}
}