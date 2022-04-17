using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputMediaPoll : CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			CorrectAnswers = 1 << 0,
			Solution = 1 << 1,
			SolutionEntities = 1 << 1
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 261416433; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("poll")]
		public CatraProto.Client.TL.Schemas.CloudChats.PollBase Poll { get; set; }

[Newtonsoft.Json.JsonProperty("correct_answers")]
		public List<byte[]> CorrectAnswers { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("solution")]
		public string Solution { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("solution_entities")]
		public List<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> SolutionEntities { get; set; }


        #nullable enable
 public InputMediaPoll (CatraProto.Client.TL.Schemas.CloudChats.PollBase poll)
{
 Poll = poll;
 
}
#nullable disable
        internal InputMediaPoll() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = CorrectAnswers == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = Solution == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = SolutionEntities == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
			UpdateFlags();

			writer.WriteInt32(Flags);
var checkpoll = 			writer.WriteObject(Poll);
if(checkpoll.IsError){
 return checkpoll; 
}
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{

				writer.WriteVector(CorrectAnswers, false);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{

				writer.WriteString(Solution);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
var checksolutionEntities = 				writer.WriteVector(SolutionEntities, false);
if(checksolutionEntities.IsError){
 return checksolutionEntities; 
}
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
			var trypoll = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PollBase>();
if(trypoll.IsError){
return ReadResult<IObject>.Move(trypoll);
}
Poll = trypoll.Value;
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				var trycorrectAnswers = reader.ReadVector<byte[]>(ParserTypes.Bytes, nakedVector: false, nakedObjects: false);
if(trycorrectAnswers.IsError){
return ReadResult<IObject>.Move(trycorrectAnswers);
}
CorrectAnswers = trycorrectAnswers.Value;
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				var trysolution = reader.ReadString();
if(trysolution.IsError){
return ReadResult<IObject>.Move(trysolution);
}
Solution = trysolution.Value;
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				var trysolutionEntities = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
if(trysolutionEntities.IsError){
return ReadResult<IObject>.Move(trysolutionEntities);
}
SolutionEntities = trysolutionEntities.Value;
			}

return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "inputMediaPoll";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}