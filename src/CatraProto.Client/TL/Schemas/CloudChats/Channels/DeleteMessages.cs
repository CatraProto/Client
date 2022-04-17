using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;

using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class DeleteMessages : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -2067661490; }
        
[Newtonsoft.Json.JsonIgnore]
		ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

[Newtonsoft.Json.JsonProperty("channel")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase Channel { get; set; }

[Newtonsoft.Json.JsonProperty("id")]
		public List<int> Id { get; set; }

        
        #nullable enable
 public DeleteMessages (CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel,List<int> id)
{
 Channel = channel;
Id = id;
 
}
#nullable disable
                
        internal DeleteMessages() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
var checkchannel = 			writer.WriteObject(Channel);
if(checkchannel.IsError){
 return checkchannel; 
}

			writer.WriteVector(Id, false);

return new WriteResult();

		}

		public ReadResult<IObject> Deserialize(Reader reader)
		{
			var trychannel = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase>();
if(trychannel.IsError){
return ReadResult<IObject>.Move(trychannel);
}
Channel = trychannel.Value;
			var tryid = reader.ReadVector<int>(ParserTypes.Int);
if(tryid.IsError){
return ReadResult<IObject>.Move(tryid);
}
Id = tryid.Value;
return new ReadResult<IObject>(this);

		}

		public override string ToString()
		{
		    return "channels.deleteMessages";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}