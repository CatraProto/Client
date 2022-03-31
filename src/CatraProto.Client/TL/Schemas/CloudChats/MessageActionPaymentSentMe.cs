using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
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

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1892568281; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("currency")]
		public string Currency { get; set; }

[Newtonsoft.Json.JsonProperty("total_amount")]
		public long TotalAmount { get; set; }

[Newtonsoft.Json.JsonProperty("payload")]
		public byte[] Payload { get; set; }

[Newtonsoft.Json.JsonProperty("info")]
		public CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase Info { get; set; }

[Newtonsoft.Json.JsonProperty("shipping_option_id")]
		public string ShippingOptionId { get; set; }

[Newtonsoft.Json.JsonProperty("charge")]
		public CatraProto.Client.TL.Schemas.CloudChats.PaymentChargeBase Charge { get; set; }


        #nullable enable
 public MessageActionPaymentSentMe (string currency,long totalAmount,byte[] payload,CatraProto.Client.TL.Schemas.CloudChats.PaymentChargeBase charge)
{
 Currency = currency;
TotalAmount = totalAmount;
Payload = payload;
Charge = charge;
 
}
#nullable disable
        internal MessageActionPaymentSentMe() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Info == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = ShippingOptionId == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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
		
		public override string ToString()
		{
		    return "messageActionPaymentSentMe";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}