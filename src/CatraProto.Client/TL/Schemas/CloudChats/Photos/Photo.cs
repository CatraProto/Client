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


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 539045032; }
        
[Newtonsoft.Json.JsonProperty("photo")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.PhotoBase PhotoField { get; set; }

[Newtonsoft.Json.JsonProperty("users")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


        #nullable enable
 public Photo (CatraProto.Client.TL.Schemas.CloudChats.PhotoBase photoField,IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
{
 PhotoField = photoField;
Users = users;
 
}
#nullable disable
        internal Photo() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}