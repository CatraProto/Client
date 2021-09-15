using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelAdminLogEventActionChangeStickerSet : CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase
	{


        public static int StaticConstructorId { get => -1312568665; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("prev_stickerset")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase PrevStickerset { get; set; }

[Newtonsoft.Json.JsonProperty("new_stickerset")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase NewStickerset { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(PrevStickerset);
			writer.Write(NewStickerset);

		}

		public override void Deserialize(Reader reader)
		{
			PrevStickerset = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase>();
			NewStickerset = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase>();

		}
				
		public override string ToString()
		{
		    return "channelAdminLogEventActionChangeStickerSet";
		}
	}
}