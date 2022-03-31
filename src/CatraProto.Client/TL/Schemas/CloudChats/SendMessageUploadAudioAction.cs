using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class SendMessageUploadAudioAction : CatraProto.Client.TL.Schemas.CloudChats.SendMessageActionBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -212740181; }
        
[Newtonsoft.Json.JsonProperty("progress")]
		public int Progress { get; set; }


        #nullable enable
 public SendMessageUploadAudioAction (int progress)
{
 Progress = progress;
 
}
#nullable disable
        internal SendMessageUploadAudioAction() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Progress);

		}

		public override void Deserialize(Reader reader)
		{
			Progress = reader.Read<int>();

		}
		
		public override string ToString()
		{
		    return "sendMessageUploadAudioAction";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}