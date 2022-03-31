using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class SetBotShippingResults : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Error = 1 << 0,
			ShippingOptions = 1 << 1
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -436833542; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("query_id")]
		public long QueryId { get; set; }

[Newtonsoft.Json.JsonProperty("error")]
		public string Error { get; set; }

[Newtonsoft.Json.JsonProperty("shipping_options")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.ShippingOptionBase> ShippingOptions { get; set; }

        
        #nullable enable
 public SetBotShippingResults (long queryId)
{
 QueryId = queryId;
 
}
#nullable disable
                
        internal SetBotShippingResults() 
        {
        }
        
		public void UpdateFlags() 
		{
			Flags = Error == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = ShippingOptions == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(QueryId);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Error);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(ShippingOptions);
			}


		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			QueryId = reader.Read<long>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Error = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				ShippingOptions = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ShippingOptionBase>();
			}


		}

		public override string ToString()
		{
		    return "messages.setBotShippingResults";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}