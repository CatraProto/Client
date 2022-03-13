using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessagePeerReaction : CatraProto.Client.TL.Schemas.CloudChats.MessagePeerReactionBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Big = 1 << 0,
			Unread = 1 << 1
		}

        public static int StaticConstructorId { get => 1370914559; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("big")]
		public sealed override bool Big { get; set; }

[Newtonsoft.Json.JsonProperty("unread")]
		public sealed override bool Unread { get; set; }

[Newtonsoft.Json.JsonProperty("peer_id")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.PeerBase PeerId { get; set; }

[Newtonsoft.Json.JsonProperty("reaction")]
		public sealed override string Reaction { get; set; }


        #nullable enable
 public MessagePeerReaction (CatraProto.Client.TL.Schemas.CloudChats.PeerBase peerId,string reaction)
{
 PeerId = peerId;
Reaction = reaction;
 
}
#nullable disable
        internal MessagePeerReaction() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Big ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Unread ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(PeerId);
			writer.Write(Reaction);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Big = FlagsHelper.IsFlagSet(Flags, 0);
			Unread = FlagsHelper.IsFlagSet(Flags, 1);
			PeerId = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
			Reaction = reader.Read<string>();

		}
				
		public override string ToString()
		{
		    return "messagePeerReaction";
		}
	}
}