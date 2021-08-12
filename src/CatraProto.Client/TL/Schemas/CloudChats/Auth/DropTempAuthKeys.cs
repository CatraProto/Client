using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
	public partial class DropTempAuthKeys : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => -1907842680; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(bool);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("except_auth_keys")]
		public IList<long> ExceptAuthKeys { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(ExceptAuthKeys);

		}

		public void Deserialize(Reader reader)
		{
			ExceptAuthKeys = reader.ReadVector<long>();
		}

		public override string ToString()
		{
			return "auth.dropTempAuthKeys";
		}
	}
}