using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
	public partial class GetPaymentReceipt : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => -1601001088; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(PaymentReceiptBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("msg_id")]
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

		public override string ToString()
		{
			return "payments.getPaymentReceipt";
		}
	}
}