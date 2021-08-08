using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class SetAccountTTL : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => 608323678; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(bool);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("ttl")]
		public AccountDaysTTLBase Ttl { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Ttl);

		}

		public void Deserialize(Reader reader)
		{
			Ttl = reader.Read<AccountDaysTTLBase>();

		}
	}
}