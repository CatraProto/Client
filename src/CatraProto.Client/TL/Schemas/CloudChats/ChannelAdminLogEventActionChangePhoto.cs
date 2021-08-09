using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class ChannelAdminLogEventActionChangePhoto : CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase
	{


        public static int StaticConstructorId { get => 1129042607; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("prev_photo")]
		public CatraProto.Client.TL.Schemas.CloudChats.PhotoBase PrevPhoto { get; set; }

[JsonPropertyName("new_photo")]
		public CatraProto.Client.TL.Schemas.CloudChats.PhotoBase NewPhoto { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(PrevPhoto);
			writer.Write(NewPhoto);

		}

		public override void Deserialize(Reader reader)
		{
			PrevPhoto = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PhotoBase>();
			NewPhoto = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PhotoBase>();

		}
	}
}