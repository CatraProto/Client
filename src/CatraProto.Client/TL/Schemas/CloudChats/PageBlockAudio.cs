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


        public static int StaticConstructorId { get => -2143067670; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("audio_id")]
		public long AudioId { get; set; }

[Newtonsoft.Json.JsonProperty("caption")]
		public CatraProto.Client.TL.Schemas.CloudChats.PageCaptionBase Caption { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
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
	}
}