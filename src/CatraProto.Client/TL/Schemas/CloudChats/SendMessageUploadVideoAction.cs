using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class SendMessageUploadVideoAction : CatraProto.Client.TL.Schemas.CloudChats.SendMessageActionBase
	{


        public static int StaticConstructorId { get => -378127636; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("progress")]
		public int Progress { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Progress);

		}

		public override void Deserialize(Reader reader)
		{
			Progress = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "sendMessageUploadVideoAction";
		}
	}
}