using System;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageActionPaymentSentMe : MessageActionBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Info = 1 << 0,
			ShippingOptionId = 1 << 1
		}

        public static int ConstructorId { get; } = -1892568281;
		public int Flags { get; set; }
		public string Currency { get; set; }
		public long TotalAmount { get; set; }
		public byte[] Payload { get; set; }
		public PaymentRequestedInfoBase Info { get; set; }
		public string ShippingOptionId { get; set; }
		public PaymentChargeBase Charge { get; set; }

		public override void UpdateFlags() 
		{
			Flags = Info == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = ShippingOptionId == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Currency);
			writer.Write(TotalAmount);
			writer.Write(Payload);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Info);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(ShippingOptionId);
			}

			writer.Write(Charge);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Currency = reader.Read<string>();
			TotalAmount = reader.Read<long>();
			Payload = reader.Read<byte[]>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Info = reader.Read<PaymentRequestedInfoBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				ShippingOptionId = reader.Read<string>();
			}

			Charge = reader.Read<PaymentChargeBase>();

		}
	}
}