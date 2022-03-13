using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateBotPrecheckoutQuery : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Info = 1 << 0,
			ShippingOptionId = 1 << 1
		}

        public static int StaticConstructorId { get => -1934976362; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("query_id")]
		public long QueryId { get; set; }

[Newtonsoft.Json.JsonProperty("user_id")]
		public long UserId { get; set; }

[Newtonsoft.Json.JsonProperty("payload")]
		public byte[] Payload { get; set; }

[Newtonsoft.Json.JsonProperty("info")]
		public CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase Info { get; set; }

[Newtonsoft.Json.JsonProperty("shipping_option_id")]
		public string ShippingOptionId { get; set; }

[Newtonsoft.Json.JsonProperty("currency")]
		public string Currency { get; set; }

[Newtonsoft.Json.JsonProperty("total_amount")]
		public long TotalAmount { get; set; }


        #nullable enable
 public UpdateBotPrecheckoutQuery (long queryId,long userId,byte[] payload,string currency,long totalAmount)
{
 QueryId = queryId;
UserId = userId;
Payload = payload;
Currency = currency;
TotalAmount = totalAmount;
 
}
#nullable disable
        internal UpdateBotPrecheckoutQuery() 
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
			writer.Write(QueryId);
			writer.Write(UserId);
			writer.Write(Payload);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Info);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(ShippingOptionId);
			}

			writer.Write(Currency);
			writer.Write(TotalAmount);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			QueryId = reader.Read<long>();
			UserId = reader.Read<long>();
			Payload = reader.Read<byte[]>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Info = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				ShippingOptionId = reader.Read<string>();
			}

			Currency = reader.Read<string>();
			TotalAmount = reader.Read<long>();

		}
				
		public override string ToString()
		{
		    return "updateBotPrecheckoutQuery";
		}
	}
}