using System;
using System.Collections.Generic;
using CatraProto.TL;
using System.Text.Json.Serialization;
using CatraProto.TL.Interfaces;
#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class DeleteAccount : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => 1099779595; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(bool);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("reason")]
		public string Reason { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Reason);

		}

		public void Deserialize(Reader reader)
		{
			Reason = reader.Read<string>();

		}
	}
}