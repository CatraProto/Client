using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
	public partial class ResolveUsername : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => -113456221; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(ResolvedPeerBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("username")]
		public string Username { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Username);

		}

		public void Deserialize(Reader reader)
		{
			Username = reader.Read<string>();
		}

		public override string ToString()
		{
			return "contacts.resolveUsername";
		}
	}
}