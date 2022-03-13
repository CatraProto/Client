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
		public sealed override int Pts { get; set; }

[Newtonsoft.Json.JsonProperty("pts_count")]
		public sealed override int PtsCount { get; set; }

[Newtonsoft.Json.JsonProperty("offset")]
		public sealed override int Offset { get; set; }

[Newtonsoft.Json.JsonProperty("messages")]
		public sealed override IList<int> Messages { get; set; }


        #nullable enable
 public AffectedFoundMessages (int pts,int ptsCount,int offset,IList<int> messages)
{
 Pts = pts;
PtsCount = ptsCount;
Offset = offset;
Messages = messages;
 
}
#nullable disable
        internal AffectedFoundMessages() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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