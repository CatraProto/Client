using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageEmpty : CatraProto.Client.TL.Schemas.CloudChats.MessageBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			PeerId = 1 << 0
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1868117372; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("id")]
		public sealed override int Id { get; set; }

[Newtonsoft.Json.JsonProperty("peer_id")]
		public CatraProto.Client.TL.Schemas.CloudChats.PeerBase PeerId { get; set; }


        #nullable enable
 public MessageEmpty (int id)
{
 Id = id;
 
}
#nullable disable
        internal MessageEmpty() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = PeerId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Id);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(PeerId);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Id = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				PeerId = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
			}


		}
		
		public override string ToString()
		{
		    return "messageEmpty";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}