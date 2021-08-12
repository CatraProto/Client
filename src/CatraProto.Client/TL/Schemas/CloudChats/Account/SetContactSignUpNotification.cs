using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class SetContactSignUpNotification : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => -806076575; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(bool);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("silent")]
		public bool Silent { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Silent);

		}

		public void Deserialize(Reader reader)
		{
			Silent = reader.Read<bool>();
		}

		public override string ToString()
		{
			return "account.setContactSignUpNotification";
		}
	}
}