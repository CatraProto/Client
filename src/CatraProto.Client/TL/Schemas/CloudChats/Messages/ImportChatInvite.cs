using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class ImportChatInvite : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => 1817183516; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(UpdatesBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonPropertyName("hash")]
		public string Hash { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Hash);

		}

		public void Deserialize(Reader reader)
		{
			Hash = reader.Read<string>();
		}

		public override string ToString()
		{
			return "messages.importChatInvite";
		}
	}
}