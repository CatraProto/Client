using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;

using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Payments
{
	public partial class GetPaymentForm : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			ThemeParams = 1 << 0
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1976353651; }
        
[Newtonsoft.Json.JsonIgnore]
		ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("msg_id")]
		public int MsgId { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("theme_params")]
		public CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase ThemeParams { get; set; }

        
        #nullable enable
 public GetPaymentForm (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer,int msgId)
{
 Peer = peer;
MsgId = msgId;
 
}
#nullable disable
                
        internal GetPaymentForm() 
        {
        }
        
		public void UpdateFlags() 
		{
			Flags = ThemeParams == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
			UpdateFlags();

			writer.WriteInt32(Flags);
var checkpeer = 			writer.WriteObject(Peer);
if(checkpeer.IsError){
 return checkpeer; 
}
writer.WriteInt32(MsgId);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
var checkthemeParams = 				writer.WriteObject(ThemeParams);
if(checkthemeParams.IsError){
 return checkthemeParams; 
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
			var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
if(trypeer.IsError){
return ReadResult<IObject>.Move(trypeer);
}
Peer = trypeer.Value;
			var trymsgId = reader.ReadInt32();
if(trymsgId.IsError){
return ReadResult<IObject>.Move(trymsgId);
}
MsgId = trymsgId.Value;
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				var trythemeParams = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase>();
if(trythemeParams.IsError){
return ReadResult<IObject>.Move(trythemeParams);
}
ThemeParams = trythemeParams.Value;
			}

return new ReadResult<IObject>(this);

		}

		public override string ToString()
		{
		    return "payments.getPaymentForm";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}