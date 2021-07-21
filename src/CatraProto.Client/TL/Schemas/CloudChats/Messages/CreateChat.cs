using System;
using System.Collections.Generic;
using CatraProto.TL;
using System.Text.Json.Serialization;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class CreateChat : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => 164303470; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("users")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase> Users { get; set; }

[JsonPropertyName("title")]
		public string Title { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Users);
			writer.Write(Title);

		}

		public void Deserialize(Reader reader)
		{
			Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
			Title = reader.Read<string>();

		}
	}
}