using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetPollVotes : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Option = 1 << 0,
			Offset = 1 << 1
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => -1200736242; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.VotesListBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("peer")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

[Newtonsoft.Json.JsonProperty("id")]
		public int Id { get; set; }

[Newtonsoft.Json.JsonProperty("option")]
		public byte[] Option { get; set; }

[Newtonsoft.Json.JsonProperty("offset")]
		public string Offset { get; set; }

[Newtonsoft.Json.JsonProperty("limit")]
		public int Limit { get; set; }

        
        #nullable enable
 public GetPollVotes (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer,int id,int limit)
{
 Peer = peer;
Id = id;
Limit = limit;
 
}
#nullable disable
                
        internal GetPollVotes() 
        {
        }
        
		public void UpdateFlags() 
		{
			Flags = Option == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = Offset == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Peer);
			writer.Write(Id);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Option);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(Offset);
			}

			writer.Write(Limit);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
			Id = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Option = reader.Read<byte[]>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				Offset = reader.Read<string>();
			}

			Limit = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "messages.getPollVotes";
		}
	}
}