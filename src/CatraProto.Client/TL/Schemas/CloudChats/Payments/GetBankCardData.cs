using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
	public partial class GetBankCardData : IMethod<CatraProto.Client.TL.Schemas.CloudChats.Payments.BankCardDataBase>
	{


        public static int ConstructorId { get; } = 779736953;

		public string Number { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Number);

		}

		public void Deserialize(Reader reader)
		{
			Number = reader.Read<string>();

		}
	}
}