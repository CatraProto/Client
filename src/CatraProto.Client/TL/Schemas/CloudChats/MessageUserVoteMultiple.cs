using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class MessageUserVoteMultiple : CatraProto.Client.TL.Schemas.CloudChats.MessageUserVoteBase
	{


        public static int StaticConstructorId { get => 244310238; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("user_id")]
		public override int UserId { get; set; }

[Newtonsoft.Json.JsonProperty("options")]
		public IList<byte[]> Options { get; set; }

[Newtonsoft.Json.JsonProperty("date")]
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
				
		public override string ToString()
		{
		    return "messageUserVoteMultiple";
		}
	}
}