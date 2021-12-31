using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateMessagePollVote : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{


        public static int StaticConstructorId { get => 274961865; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("poll_id")]
		public long PollId { get; set; }

[Newtonsoft.Json.JsonProperty("user_id")]
		public long UserId { get; set; }

[Newtonsoft.Json.JsonProperty("options")]
		public IList<byte[]> Options { get; set; }

[Newtonsoft.Json.JsonProperty("qts")]
		public int Qts { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(PollId);
			writer.Write(UserId);
			writer.Write(Options);
			writer.Write(Qts);

		}

		public override void Deserialize(Reader reader)
		{
			PollId = reader.Read<long>();
			UserId = reader.Read<long>();
			Options = reader.ReadVector<byte[]>();
			Qts = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "updateMessagePollVote";
		}
	}
}