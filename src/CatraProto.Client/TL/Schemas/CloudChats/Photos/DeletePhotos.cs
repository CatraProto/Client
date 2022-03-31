using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Photos
{
	public partial class DeletePhotos : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -2016444625; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(long);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = true;

[Newtonsoft.Json.JsonProperty("id")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.InputPhotoBase> Id { get; set; }

        
        #nullable enable
 public DeletePhotos (IList<CatraProto.Client.TL.Schemas.CloudChats.InputPhotoBase> id)
{
 Id = id;
 
}
#nullable disable
                
        internal DeletePhotos() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Id);

		}

		public void Deserialize(Reader reader)
		{
			Id = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputPhotoBase>();

		}

		public override string ToString()
		{
		    return "photos.deletePhotos";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}