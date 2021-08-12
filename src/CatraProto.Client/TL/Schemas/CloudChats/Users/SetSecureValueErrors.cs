using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Users
{
	public partial class SetSecureValueErrors : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => -1865902923; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(bool);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("id")]
		public InputUserBase Id { get; set; }

[JsonPropertyName("errors")]
		public IList<SecureValueErrorBase> Errors { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Id);
			writer.Write(Errors);

		}

		public void Deserialize(Reader reader)
		{
			Id = reader.Read<InputUserBase>();
			Errors = reader.ReadVector<SecureValueErrorBase>();
		}

		public override string ToString()
		{
			return "users.setSecureValueErrors";
		}
	}
}