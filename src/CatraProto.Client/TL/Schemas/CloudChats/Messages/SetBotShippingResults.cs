using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;

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
		ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("query_id")]
		public long QueryId { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("error")]
		public string Error { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("shipping_options")]
		public List<CatraProto.Client.TL.Schemas.CloudChats.ShippingOptionBase> ShippingOptions { get; set; }

        
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

		public WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
			UpdateFlags();

			writer.WriteInt32(Flags);
writer.WriteInt64(QueryId);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{

				writer.WriteString(Error);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
var checkshippingOptions = 				writer.WriteVector(ShippingOptions, false);
if(checkshippingOptions.IsError){
 return checkshippingOptions; 
}
			}


return new WriteResult();

		}

		public ReadResult<IObject> Deserialize(Reader reader)
		{
			var tryflags = reader.ReadInt32();
if(tryflags.IsError){
return ReadResult<IObject>.Move(tryflags);
}
Flags = tryflags.Value;
			var tryqueryId = reader.ReadInt64();
if(tryqueryId.IsError){
return ReadResult<IObject>.Move(tryqueryId);
}
QueryId = tryqueryId.Value;
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				var tryerror = reader.ReadString();
if(tryerror.IsError){
return ReadResult<IObject>.Move(tryerror);
}
Error = tryerror.Value;
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				var tryshippingOptions = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ShippingOptionBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
if(tryshippingOptions.IsError){
return ReadResult<IObject>.Move(tryshippingOptions);
}
ShippingOptions = tryshippingOptions.Value;
			}

return new ReadResult<IObject>(this);

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