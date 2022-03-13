using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdatePeerHistoryTTL : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			TtlPeriod = 1 << 0
		}

        public static int StaticConstructorId { get => -1147422299; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.PeerBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("ttl_period")]
		public int? TtlPeriod { get; set; }


        #nullable enable
 public UpdatePeerHistoryTTL (CatraProto.Client.TL.Schemas.CloudChats.PeerBase peer)
{
 Peer = peer;
 
}
#nullable disable
        internal UpdatePeerHistoryTTL() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = TtlPeriod == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Peer);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(TtlPeriod.Value);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				TtlPeriod = reader.Read<int>();
			}


		}
				
		public override string ToString()
		{
		    return "updatePeerHistoryTTL";
		}
	}
}