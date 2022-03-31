using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class SendMessageUploadPhotoAction : CatraProto.Client.TL.Schemas.CloudChats.SendMessageActionBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -774682074; }
        
[Newtonsoft.Json.JsonProperty("progress")]
		public int Progress { get; set; }


        #nullable enable
 public SendMessageUploadPhotoAction (int progress)
{
 Progress = progress;
 
}
#nullable disable
        internal SendMessageUploadPhotoAction() 
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
		    return "sendMessageUploadPhotoAction";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}