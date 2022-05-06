/*
CatraProto, a C# library that implements the MTProto protocol and the Telegram API.
Copyright (C) 2022 Aquatica <aquathing@protonmail.com>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

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
	public partial class PollResults : CatraProto.Client.TL.Schemas.CloudChats.PollResultsBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Min = 1 << 0,
			Results = 1 << 1,
			TotalVoters = 1 << 2,
			RecentVoters = 1 << 3,
			Solution = 1 << 4,
			SolutionEntities = 1 << 4
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -591909213; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("min")]
		public sealed override bool Min { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("results")]
		public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.PollAnswerVotersBase> Results { get; set; }

[Newtonsoft.Json.JsonProperty("total_voters")]
		public sealed override int? TotalVoters { get; set; }

[Newtonsoft.Json.JsonProperty("recent_voters")]
		public sealed override List<long> RecentVoters { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("solution")]
		public sealed override string Solution { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("solution_entities")]
		public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> SolutionEntities { get; set; }


        
        public PollResults() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Min ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Results == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = TotalVoters == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = RecentVoters == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
			Flags = Solution == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
			Flags = SolutionEntities == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);

		}

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
			UpdateFlags();

			writer.WriteInt32(Flags);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
var checkresults = 				writer.WriteVector(Results, false);
if(checkresults.IsError){
 return checkresults; 
}
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
writer.WriteInt32(TotalVoters.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{

				writer.WriteVector(RecentVoters, false);
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
			{

				writer.WriteString(Solution);
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
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
			Min = FlagsHelper.IsFlagSet(Flags, 0);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				var tryresults = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PollAnswerVotersBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
if(tryresults.IsError){
return ReadResult<IObject>.Move(tryresults);
}
Results = tryresults.Value;
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				var trytotalVoters = reader.ReadInt32();
if(trytotalVoters.IsError){
return ReadResult<IObject>.Move(trytotalVoters);
}
TotalVoters = trytotalVoters.Value;
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				var tryrecentVoters = reader.ReadVector<long>(ParserTypes.Int64);
if(tryrecentVoters.IsError){
return ReadResult<IObject>.Move(tryrecentVoters);
}
RecentVoters = tryrecentVoters.Value;
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				var trysolution = reader.ReadString();
if(trysolution.IsError){
return ReadResult<IObject>.Move(trysolution);
}
Solution = trysolution.Value;
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
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
		    return "pollResults";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}

		#nullable enable
		public override IObject? Clone()
		{
			var newClonedObject = new PollResults();
newClonedObject.Flags = Flags;
newClonedObject.Min = Min;
if (Results is not null){
newClonedObject.Results = new List<CatraProto.Client.TL.Schemas.CloudChats.PollAnswerVotersBase>();
foreach(var results in Results){
var cloneresults = (CatraProto.Client.TL.Schemas.CloudChats.PollAnswerVotersBase?)results.Clone();
if(cloneresults is null){
return null;
}
newClonedObject.Results.Add(cloneresults);
}
}
newClonedObject.TotalVoters = TotalVoters;
newClonedObject.RecentVoters = new List<long>();
foreach(var recentVoters in RecentVoters){
newClonedObject.RecentVoters.Add(recentVoters);
}
newClonedObject.Solution = Solution;
if (SolutionEntities is not null){
newClonedObject.SolutionEntities = new List<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>();
foreach(var solutionEntities in SolutionEntities){
var clonesolutionEntities = (CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase?)solutionEntities.Clone();
if(clonesolutionEntities is null){
return null;
}
newClonedObject.SolutionEntities.Add(clonesolutionEntities);
}
}
return newClonedObject;

		}
		#nullable disable
	}
}