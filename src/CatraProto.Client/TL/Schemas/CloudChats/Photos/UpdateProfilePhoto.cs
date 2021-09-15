using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Photos
{
	public partial class UpdateProfilePhoto : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId { get => 1926525996; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Photos.PhotoBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonProperty("id")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputPhotoBase Id { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Id);

		}

		public void Deserialize(Reader reader)
		{
			Id = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPhotoBase>();

		}
		
		public override string ToString()
		{
		    return "photos.updateProfilePhoto";
		}
	}
}