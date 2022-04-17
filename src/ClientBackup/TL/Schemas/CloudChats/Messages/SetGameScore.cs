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
	public partial class SetGameScore : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			EditMessage = 1 << 0,
			Force = 1 << 1
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1896289088; }
        
[Newtonsoft.Json.JsonIgnore]
		ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("edit_message")]
		public bool EditMessage { get; set; }

[Newtonsoft.Json.JsonProperty("force")]
		public bool Force { get; set; }

[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("id")]
		public int Id { get; set; }

[Newtonsoft.Json.JsonProperty("user_id")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase UserId { get; set; }

[Newtonsoft.Json.JsonProperty("score")]
		public int Score { get; set; }

        
        #nullable enable
 public SetGameScore (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer,int id,CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId,int score)
{
 Peer = peer;
Id = id;
UserId = userId;
Score = score;
 
}
#nullable disable
                
        internal SetGameScore() 
        {
        }
        
		public void UpdateFlags() 
		{
			Flags = EditMessage ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Force ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);

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
writer.WriteInt32(Id);
var checkuserId = 			writer.WriteObject(UserId);
if(checkuserId.IsError){
 return checkuserId; 
}
writer.WriteInt32(Score);

return new WriteResult();

		}

		public ReadResult<IObject> Deserialize(Reader reader)
		{
			var tryflags = reader.ReadInt32();
if(tryflags.IsError){
return ReadResult<IObject>.Move(tryflags);
}
Flags = tryflags.Value;
			EditMessage = FlagsHelper.IsFlagSet(Flags, 0);
			Force = FlagsHelper.IsFlagSet(Flags, 1);
			var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
if(trypeer.IsError){
return ReadResult<IObject>.Move(trypeer);
}
Peer = trypeer.Value;
			var tryid = reader.ReadInt32();
if(tryid.IsError){
return ReadResult<IObject>.Move(tryid);
}
Id = tryid.Value;
			var tryuserId = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
if(tryuserId.IsError){
return ReadResult<IObject>.Move(tryuserId);
}
UserId = tryuserId.Value;
			var tryscore = reader.ReadInt32();
if(tryscore.IsError){
return ReadResult<IObject>.Move(tryscore);
}
Score = tryscore.Value;
return new ReadResult<IObject>(this);

		}

		public override string ToString()
		{
		    return "messages.setGameScore";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}