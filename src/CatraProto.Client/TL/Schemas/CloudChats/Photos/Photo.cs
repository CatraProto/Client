using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Photos
{
	public partial class Photo : CatraProto.Client.TL.Schemas.CloudChats.Photos.PhotoBase
	{


        public static int StaticConstructorId { get => 539045032; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("photo")]
		public override CatraProto.Client.TL.Schemas.CloudChats.PhotoBase PhotoField { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(PhotoField);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			PhotoField = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.PhotoBase>();
			Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();

		}
				
		public override string ToString()
		{
		    return "photos.photo";
		}
	}
}