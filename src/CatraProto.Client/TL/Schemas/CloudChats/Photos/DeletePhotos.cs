using System;
using System.Collections.Generic;
using CatraProto.TL;
using System.Text.Json.Serialization;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Photos
{
	public partial class DeletePhotos : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => -2016444625; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(long);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = true;

[JsonPropertyName("id")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.InputPhotoBase> Id { get; set; }


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
			Id = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputPhotoBase>();

		}
	}
}