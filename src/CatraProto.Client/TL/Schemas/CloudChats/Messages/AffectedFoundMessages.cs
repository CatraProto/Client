using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class AffectedFoundMessages : CatraProto.Client.TL.Schemas.CloudChats.Messages.AffectedFoundMessagesBase
	{


        public static int StaticConstructorId { get => -275956116; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("pts")]
		public override int Pts { get; set; }

[Newtonsoft.Json.JsonProperty("pts_count")]
		public override int PtsCount { get; set; }

[Newtonsoft.Json.JsonProperty("offset")]
		public override int Offset { get; set; }

[Newtonsoft.Json.JsonProperty("messages")]
		public override IList<int> Messages { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Pts);
			writer.Write(PtsCount);
			writer.Write(Offset);
			writer.Write(Messages);

		}

		public override void Deserialize(Reader reader)
		{
			Pts = reader.Read<int>();
			PtsCount = reader.Read<int>();
			Offset = reader.Read<int>();
			Messages = reader.ReadVector<int>();

		}
				
		public override string ToString()
		{
		    return "messages.affectedFoundMessages";
		}
	}
}