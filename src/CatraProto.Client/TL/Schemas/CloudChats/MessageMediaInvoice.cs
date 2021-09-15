using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageMediaInvoice : CatraProto.Client.TL.Schemas.CloudChats.MessageMediaBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			ShippingAddressRequested = 1 << 1,
			Test = 1 << 3,
			Photo = 1 << 0,
			ReceiptMsgId = 1 << 2
		}

        public static int StaticConstructorId { get => -2074799289; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("shipping_address_requested")]
		public bool ShippingAddressRequested { get; set; }

[Newtonsoft.Json.JsonProperty("test")]
		public bool Test { get; set; }

[Newtonsoft.Json.JsonProperty("title")]
		public string Title { get; set; }

[Newtonsoft.Json.JsonProperty("description")]
		public string Description { get; set; }

[Newtonsoft.Json.JsonProperty("photo")]
		public CatraProto.Client.TL.Schemas.CloudChats.WebDocumentBase Photo { get; set; }

[Newtonsoft.Json.JsonProperty("receipt_msg_id")]
		public int? ReceiptMsgId { get; set; }

[Newtonsoft.Json.JsonProperty("currency")]
		public string Currency { get; set; }

[Newtonsoft.Json.JsonProperty("total_amount")]
		public long TotalAmount { get; set; }

[Newtonsoft.Json.JsonProperty("start_param")]
		public string StartParam { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = ShippingAddressRequested ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = Test ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
			Flags = Photo == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = ReceiptMsgId == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Title);
			writer.Write(Description);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Photo);
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(ReceiptMsgId.Value);
			}

			writer.Write(Currency);
			writer.Write(TotalAmount);
			writer.Write(StartParam);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			ShippingAddressRequested = FlagsHelper.IsFlagSet(Flags, 1);
			Test = FlagsHelper.IsFlagSet(Flags, 3);
			Title = reader.Read<string>();
			Description = reader.Read<string>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Photo = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.WebDocumentBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				ReceiptMsgId = reader.Read<int>();
			}

			Currency = reader.Read<string>();
			TotalAmount = reader.Read<long>();
			StartParam = reader.Read<string>();

		}
				
		public override string ToString()
		{
		    return "messageMediaInvoice";
		}
	}
}