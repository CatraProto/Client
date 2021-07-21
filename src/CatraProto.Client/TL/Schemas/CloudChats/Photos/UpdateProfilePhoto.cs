using System;
using System.Collections.Generic;
using CatraProto.TL;
using System.Text.Json.Serialization;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Photos
{
	public partial class UpdateProfilePhoto : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => 1926525996; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Photos.PhotoBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("id")]
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
	}
}