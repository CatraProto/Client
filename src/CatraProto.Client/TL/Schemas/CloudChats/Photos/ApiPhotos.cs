using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Photos
{
	public partial class ApiPhotos : CatraProto.Client.TL.Schemas.CloudChats.Photos.PhotosBase
	{


        public static int StaticConstructorId { get => -1916114267; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("photos")]
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.PhotoBase> Photos { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public override IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

        
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Photos);
			writer.Write(Users);

		}

		public override void Deserialize(Reader reader)
		{
			Photos = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PhotoBase>();
			Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();

		}
				
		public override string ToString()
		{
		    return "photos.photos";
		}
	}
}