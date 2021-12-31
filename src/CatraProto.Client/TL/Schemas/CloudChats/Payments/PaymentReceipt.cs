using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
	public partial class PaymentReceipt : CatraProto.Client.TL.Schemas.CloudChats.Payments.PaymentReceiptBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Photo = 1 << 2,
			Info = 1 << 0,
			Shipping = 1 << 1,
			TipAmount = 1 << 3
		}

        public static int StaticConstructorId { get => 1891958275; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("date")]
		public override int Date { get; set; }

[Newtonsoft.Json.JsonProperty("bot_id")]
		public override long BotId { get; set; }

[Newtonsoft.Json.JsonProperty("provider_id")]
		public override long ProviderId { get; set; }

[Newtonsoft.Json.JsonProperty("title")]
		public override string Title { get; set; }

[Newtonsoft.Json.JsonProperty("description")]
		public override string Description { get; set; }

[Newtonsoft.Json.JsonProperty("photo")]
		public override CatraProto.Client.TL.Schemas.CloudChats.WebDocumentBase Photo { get; set; }

[Newtonsoft.Json.JsonProperty("invoice")]
		public override CatraProto.Client.TL.Schemas.CloudChats.InvoiceBase Invoice { get; set; }

[Newtonsoft.Json.JsonProperty("info")]
		public override CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase Info { get; set; }

[Newtonsoft.Json.JsonProperty("shipping")]
		public override CatraProto.Client.TL.Schemas.CloudChats.ShippingOptionBase Shipping { get; set; }

[Newtonsoft.Json.JsonProperty("tip_amount")]
		public override long? TipAmount { get; set; }

[Newtonsoft.Json.JsonProperty("currency")]
		public override string Currency { get; set; }

[Newtonsoft.Json.JsonProperty("total_amount")]
		public override long TotalAmount { get; set; }

[Newtonsoft.Json.JsonProperty("credentials_title")]
		public override string CredentialsTitle { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Photo == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = Info == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = Shipping == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = TipAmount == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Date);
			writer.Write(BotId);
			writer.Write(ProviderId);
			writer.Write(Title);
			writer.Write(Description);
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(Photo);
			}

			writer.Write(Invoice);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Info);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(Shipping);
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				writer.Write(TipAmount.Value);
			}

			writer.Write(Currency);
			writer.Write(TotalAmount);
			writer.Write(CredentialsTitle);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Date = reader.Read<int>();
			BotId = reader.Read<long>();
			ProviderId = reader.Read<long>();
			Title = reader.Read<string>();
			Description = reader.Read<string>();
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				Photo = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.WebDocumentBase>();
			}

			Invoice = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InvoiceBase>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Info = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				Shipping = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ShippingOptionBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				TipAmount = reader.Read<long>();
			}

			Currency = reader.Read<string>();
			TotalAmount = reader.Read<long>();
			CredentialsTitle = reader.Read<string>();
			Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();

		}
				
		public override string ToString()
		{
		    return "payments.paymentReceipt";
		}
	}
}