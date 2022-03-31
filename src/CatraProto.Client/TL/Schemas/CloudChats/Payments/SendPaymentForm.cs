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
			ShippingOptionId = 1 << 1,
			TipAmount = 1 << 2
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 818134173; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Payments.PaymentResultBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("form_id")]
		public long FormId { get; set; }

[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("msg_id")]
		public int MsgId { get; set; }

[Newtonsoft.Json.JsonProperty("requested_info_id")]
		public string RequestedInfoId { get; set; }

[Newtonsoft.Json.JsonProperty("shipping_option_id")]
		public string ShippingOptionId { get; set; }

[Newtonsoft.Json.JsonProperty("credentials")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPaymentCredentialsBase Credentials { get; set; }

[Newtonsoft.Json.JsonProperty("tip_amount")]
		public long? TipAmount { get; set; }

        
        #nullable enable
 public SendPaymentForm (long formId,CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer,int msgId,CatraProto.Client.TL.Schemas.CloudChats.InputPaymentCredentialsBase credentials)
{
 FormId = formId;
Peer = peer;
MsgId = msgId;
Credentials = credentials;
 
}
#nullable disable
                
        internal SendPaymentForm() 
        {
        }
        
		public void UpdateFlags() 
		{
			Flags = RequestedInfoId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = ShippingOptionId == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = TipAmount == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(FormId);
			writer.Write(Peer);
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
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(TipAmount.Value);
			}


		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			FormId = reader.Read<long>();
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
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
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				TipAmount = reader.Read<long>();
			}


		}

		public override string ToString()
		{
		    return "payments.sendPaymentForm";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}