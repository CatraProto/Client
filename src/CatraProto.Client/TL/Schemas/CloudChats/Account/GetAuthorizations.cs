using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
	public partial class GetAuthorizations : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => -484392616; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(AuthorizationsBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);

		}

		public void Deserialize(Reader reader)
		{
		}

		public override string ToString()
		{
			return "account.getAuthorizations";
		}
	}
}