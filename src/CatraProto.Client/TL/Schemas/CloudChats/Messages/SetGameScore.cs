using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
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
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

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

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Peer);
			writer.Write(Id);
			writer.Write(UserId);
			writer.Write(Score);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			EditMessage = FlagsHelper.IsFlagSet(Flags, 0);
			Force = FlagsHelper.IsFlagSet(Flags, 1);
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
			Id = reader.Read<int>();
			UserId = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
			Score = reader.Read<int>();

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