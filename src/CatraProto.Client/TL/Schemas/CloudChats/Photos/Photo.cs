using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Photos
{
	public partial class Photo : CatraProto.Client.TL.Schemas.CloudChats.Photos.PhotoBase
	{


        public static int StaticConstructorId { get => 539045032; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonPropertyName("Photo_")]
		public override CatraProto.Client.TL.Schemas.CloudChats.PhotoBase Photo_ { get; set; }

[JsonPropertyName("users")]
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Photo_);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			Photo_ = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PhotoBase>();
			Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();

		}
	}
}