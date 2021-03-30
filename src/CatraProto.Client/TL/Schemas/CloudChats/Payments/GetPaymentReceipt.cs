using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;


namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
	public partial class GetPaymentReceipt : IMethod<CatraProto.Client.TL.Schemas.CloudChats.Payments.PaymentReceiptBase>
	{


        public static int ConstructorId { get; } = -1601001088;

		public int MsgId { get; set; }

		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(MsgId);

		}

		public void Deserialize(Reader reader)
		{
			MsgId = reader.Read<int>();

		}
	}
}