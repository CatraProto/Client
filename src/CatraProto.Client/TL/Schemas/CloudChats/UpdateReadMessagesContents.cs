using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateReadMessagesContents : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1757493555; }
        
[Newtonsoft.Json.JsonProperty("messages")]
		public IList<int> Messages { get; set; }

[Newtonsoft.Json.JsonProperty("pts")]
		public int Pts { get; set; }

[Newtonsoft.Json.JsonProperty("pts_count")]
		public int PtsCount { get; set; }


        #nullable enable
 public UpdateReadMessagesContents (IList<int> messages,int pts,int ptsCount)
{
 Messages = messages;
Pts = pts;
PtsCount = ptsCount;
 
}
#nullable disable
        internal UpdateReadMessagesContents() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Messages);
			writer.Write(Pts);
			writer.Write(PtsCount);

		}

		public override void Deserialize(Reader reader)
		{
			Messages = reader.ReadVector<int>();
			Pts = reader.Read<int>();
			PtsCount = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "updateReadMessagesContents";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}