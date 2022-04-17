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
	public partial class BotResults : CatraProto.Client.TL.Schemas.CloudChats.Messages.BotResultsBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Gallery = 1 << 0,
			NextOffset = 1 << 1,
			SwitchPm = 1 << 2
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1803769784; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("gallery")]
		public sealed override bool Gallery { get; set; }

[Newtonsoft.Json.JsonProperty("query_id")]
		public sealed override long QueryId { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("next_offset")]
		public sealed override string NextOffset { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("switch_pm")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.InlineBotSwitchPMBase SwitchPm { get; set; }

[Newtonsoft.Json.JsonProperty("results")]
		public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.BotInlineResultBase> Results { get; set; }

[Newtonsoft.Json.JsonProperty("cache_time")]
		public sealed override int CacheTime { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


        #nullable enable
 public BotResults (long queryId,List<CatraProto.Client.TL.Schemas.CloudChats.BotInlineResultBase> results,int cacheTime,List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
{
 QueryId = queryId;
Results = results;
CacheTime = cacheTime;
Users = users;
 
}
#nullable disable
        internal BotResults() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Gallery ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = NextOffset == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = SwitchPm == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

		}

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
			UpdateFlags();

			writer.WriteInt32(Flags);
writer.WriteInt64(QueryId);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{

				writer.WriteString(NextOffset);
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
var checkswitchPm = 				writer.WriteObject(SwitchPm);
if(checkswitchPm.IsError){
 return checkswitchPm; 
}
			}

var checkresults = 			writer.WriteVector(Results, false);
if(checkresults.IsError){
 return checkresults; 
}
writer.WriteInt32(CacheTime);
var checkusers = 			writer.WriteVector(Users, false);
if(checkusers.IsError){
 return checkusers; 
}

return new WriteResult();

		}

		public override ReadResult<IObject> Deserialize(Reader reader)
		{
			var tryflags = reader.ReadInt32();
if(tryflags.IsError){
return ReadResult<IObject>.Move(tryflags);
}
Flags = tryflags.Value;
			Gallery = FlagsHelper.IsFlagSet(Flags, 0);
			var tryqueryId = reader.ReadInt64();
if(tryqueryId.IsError){
return ReadResult<IObject>.Move(tryqueryId);
}
QueryId = tryqueryId.Value;
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				var trynextOffset = reader.ReadString();
if(trynextOffset.IsError){
return ReadResult<IObject>.Move(trynextOffset);
}
NextOffset = trynextOffset.Value;
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				var tryswitchPm = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InlineBotSwitchPMBase>();
if(tryswitchPm.IsError){
return ReadResult<IObject>.Move(tryswitchPm);
}
SwitchPm = tryswitchPm.Value;
			}

			var tryresults = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.BotInlineResultBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
if(tryresults.IsError){
return ReadResult<IObject>.Move(tryresults);
}
Results = tryresults.Value;
			var trycacheTime = reader.ReadInt32();
if(trycacheTime.IsError){
return ReadResult<IObject>.Move(trycacheTime);
}
CacheTime = trycacheTime.Value;
			var tryusers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
if(tryusers.IsError){
return ReadResult<IObject>.Move(tryusers);
}
Users = tryusers.Value;
return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "messages.botResults";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}