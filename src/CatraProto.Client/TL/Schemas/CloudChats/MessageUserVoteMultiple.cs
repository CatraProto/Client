using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageUserVoteMultiple : CatraProto.Client.TL.Schemas.CloudChats.MessageUserVoteBase
	{


        public static int StaticConstructorId { get => 244310238; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("user_id")]
		public override int UserId { get; set; }

[JsonPropertyName("options")]
		public IList<byte[]> Options { get; set; }

[JsonPropertyName("date")]
		public override int Date { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(UserId);
			writer.Write(Options);
			writer.Write(Date);

		}

		public override void Deserialize(Reader reader)
		{
			UserId = reader.Read<int>();
			Options = reader.ReadVector<byte[]>();
			Date = reader.Read<int>();

		}
	}
}