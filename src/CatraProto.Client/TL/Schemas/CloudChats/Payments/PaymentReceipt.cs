using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
	public partial class PaymentReceipt : PaymentReceiptBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Info = 1 << 0,
			Shipping = 1 << 1
		}

        public static int StaticConstructorId { get => 1342771681; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("date")]
		public override int Date { get; set; }

[JsonPropertyName("bot_id")]
		public override int BotId { get; set; }

[JsonPropertyName("invoice")] public override InvoiceBase Invoice { get; set; }

[JsonPropertyName("provider_id")]
		public override int ProviderId { get; set; }

[JsonPropertyName("info")] public override PaymentRequestedInfoBase Info { get; set; }

[JsonPropertyName("shipping")] public override ShippingOptionBase Shipping { get; set; }

[JsonPropertyName("currency")]
		public override string Currency { get; set; }

[JsonPropertyName("total_amount")]
		public override long TotalAmount { get; set; }

[JsonPropertyName("credentials_title")]
		public override string CredentialsTitle { get; set; }

[JsonPropertyName("users")] public override IList<UserBase> Users { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Info == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = Shipping == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Date);
			writer.Write(BotId);
			writer.Write(Invoice);
			writer.Write(ProviderId);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Info);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(Shipping);
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
			BotId = reader.Read<int>();
			Invoice = reader.Read<InvoiceBase>();
			ProviderId = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Info = reader.Read<PaymentRequestedInfoBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				Shipping = reader.Read<ShippingOptionBase>();
			}

			Currency = reader.Read<string>();
			TotalAmount = reader.Read<long>();
			CredentialsTitle = reader.Read<string>();
			Users = reader.ReadVector<UserBase>();

		}
	}
}