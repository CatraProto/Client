using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;

using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Updates
{
	public partial class GetChannelDifference : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Force = 1 << 0
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 51854712; }
        
[Newtonsoft.Json.JsonIgnore]
		ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("force")]
		public bool Force { get; set; }

[Newtonsoft.Json.JsonProperty("channel")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase Channel { get; set; }

[Newtonsoft.Json.JsonProperty("filter")]
		public CatraProto.Client.TL.Schemas.CloudChats.ChannelMessagesFilterBase Filter { get; set; }

[Newtonsoft.Json.JsonProperty("pts")]
		public int Pts { get; set; }

[Newtonsoft.Json.JsonProperty("limit")]
		public int Limit { get; set; }

        
        #nullable enable
 public GetChannelDifference (CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel,CatraProto.Client.TL.Schemas.CloudChats.ChannelMessagesFilterBase filter,int pts,int limit)
{
 Channel = channel;
Filter = filter;
Pts = pts;
Limit = limit;
 
}
#nullable disable
                
        internal GetChannelDifference() 
        {
        }
        
		public void UpdateFlags() 
		{
			Flags = Force ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
			UpdateFlags();

			writer.WriteInt32(Flags);
var checkchannel = 			writer.WriteObject(Channel);
if(checkchannel.IsError){
 return checkchannel; 
}
var checkfilter = 			writer.WriteObject(Filter);
if(checkfilter.IsError){
 return checkfilter; 
}
writer.WriteInt32(Pts);
writer.WriteInt32(Limit);

return new WriteResult();

		}

		public ReadResult<IObject> Deserialize(Reader reader)
		{
			var tryflags = reader.ReadInt32();
if(tryflags.IsError){
return ReadResult<IObject>.Move(tryflags);
}
Flags = tryflags.Value;
			Force = FlagsHelper.IsFlagSet(Flags, 0);
			var trychannel = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase>();
if(trychannel.IsError){
return ReadResult<IObject>.Move(trychannel);
}
Channel = trychannel.Value;
			var tryfilter = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ChannelMessagesFilterBase>();
if(tryfilter.IsError){
return ReadResult<IObject>.Move(tryfilter);
}
Filter = tryfilter.Value;
			var trypts = reader.ReadInt32();
if(trypts.IsError){
return ReadResult<IObject>.Move(trypts);
}
Pts = trypts.Value;
			var trylimit = reader.ReadInt32();
if(trylimit.IsError){
return ReadResult<IObject>.Move(trylimit);
}
Limit = trylimit.Value;
return new ReadResult<IObject>(this);

		}

		public override string ToString()
		{
		    return "updates.getChannelDifference";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}