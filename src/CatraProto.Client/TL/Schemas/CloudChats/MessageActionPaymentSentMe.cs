using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageActionPaymentSentMe : CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Info = 1 << 0,
			ShippingOptionId = 1 << 1
		}

        public static int StaticConstructorId { get => -1892568281; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("currency")]
		public string Currency { get; set; }

[JsonPropertyName("total_amount")]
		public long TotalAmount { get; set; }

[JsonPropertyName("payload")]
		public byte[] Payload { get; set; }

[JsonPropertyName("info")]
		public CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase Info { get; set; }

[JsonPropertyName("shipping_option_id")]
		public string ShippingOptionId { get; set; }

[JsonPropertyName("charge")]
		public CatraProto.Client.TL.Schemas.CloudChats.PaymentChargeBase Charge { get; set; }

        
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
				Info = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				ShippingOptionId = reader.Read<string>();
			}

			Charge = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PaymentChargeBase>();

		}
	}
}