using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class PageBlockAudio : CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -2143067670; }
        
[Newtonsoft.Json.JsonProperty("audio_id")]
		public long AudioId { get; set; }

[Newtonsoft.Json.JsonProperty("caption")]
		public CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase Caption { get; set; }


        #nullable enable
 public PageBlockAudio (long audioId,CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase caption)
{
 AudioId = audioId;
Caption = caption;
 
}
#nullable disable
        internal PageBlockAudio() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(AudioId);
			writer.Write(Caption);

		}

		public override void Deserialize(Reader reader)
		{
			AudioId = reader.Read<long>();
			Caption = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase>();

		}
		
		public override string ToString()
		{
		    return "pageBlockAudio";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}