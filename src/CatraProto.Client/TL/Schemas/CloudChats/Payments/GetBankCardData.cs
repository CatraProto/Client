using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
	public partial class GetBankCardData : IMethod
	{
		public static int ConstructorId { get; } = 779736953;
		public string Number { get; set; }

		public Type Type { get; init; } = typeof(BankCardDataBase);
		public bool IsVector { get; init; } = false;

		public void UpdateFlags()
		{
		}

		public void Serialize(Writer writer)
		{
			if (ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Number);
		}

		public void Deserialize(Reader reader)
		{
			Number = reader.Read<string>();
		}
	}
}