using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateNewMessage : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 522914557; }
        
[Newtonsoft.Json.JsonProperty("message")]
		public CatraProto.Client.TL.Schemas.CloudChats.MessageBase Message { get; set; }

[Newtonsoft.Json.JsonProperty("pts")]
		public int Pts { get; set; }

[Newtonsoft.Json.JsonProperty("pts_count")]
		public int PtsCount { get; set; }


        #nullable enable
 public UpdateNewMessage (CatraProto.Client.TL.Schemas.CloudChats.MessageBase message,int pts,int ptsCount)
{
 Message = message;
Pts = pts;
PtsCount = ptsCount;
 
}
#nullable disable
        internal UpdateNewMessage() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Message);
			writer.Write(Pts);
			writer.Write(PtsCount);

		}

		public override void Deserialize(Reader reader)
		{
			Message = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.MessageBase>();
			Pts = reader.Read<int>();
			PtsCount = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "updateNewMessage";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}