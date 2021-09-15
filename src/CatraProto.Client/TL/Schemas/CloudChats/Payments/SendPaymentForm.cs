using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
	public partial class SendPaymentForm : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			RequestedInfoId = 1 << 0,
			ShippingOptionId = 1 << 1
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => 730364339; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Payments.PaymentResultBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("msg_id")]
		public int MsgId { get; set; }

[Newtonsoft.Json.JsonProperty("requested_info_id")]
		public string RequestedInfoId { get; set; }

[Newtonsoft.Json.JsonProperty("shipping_option_id")]
		public string ShippingOptionId { get; set; }

[Newtonsoft.Json.JsonProperty("credentials")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPaymentCredentialsBase Credentials { get; set; }


		public void UpdateFlags() 
		{
			Flags = RequestedInfoId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = ShippingOptionId == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(MsgId);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(RequestedInfoId);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(ShippingOptionId);
			}

			writer.Write(Credentials);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			MsgId = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				RequestedInfoId = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				ShippingOptionId = reader.Read<string>();
			}

			Credentials = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPaymentCredentialsBase>();

		}
		
		public override string ToString()
		{
		    return "payments.sendPaymentForm";
		}
	}
}