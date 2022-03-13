using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class SendReaction : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Big = 1 << 1,
			Reaction = 1 << 0
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => 627641572; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("big")]
		public bool Big { get; set; }

[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("msg_id")]
		public int MsgId { get; set; }

[Newtonsoft.Json.JsonProperty("reaction")]
		public string Reaction { get; set; }

        
        #nullable enable
 public SendReaction (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer,int msgId)
{
 Peer = peer;
MsgId = msgId;
 
}
#nullable disable
                
        internal SendReaction() 
        {
        }
        
		public void UpdateFlags() 
		{
			Flags = Big ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = Reaction == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Peer);
			writer.Write(MsgId);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Reaction);
			}


		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Big = FlagsHelper.IsFlagSet(Flags, 1);
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
			MsgId = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Reaction = reader.Read<string>();
			}


		}
		
		public override string ToString()
		{
		    return "messages.sendReaction";
		}
	}
}