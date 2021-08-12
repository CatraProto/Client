using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class UploadEncryptedFile : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => 1347929239; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(EncryptedFileBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

		[JsonPropertyName("peer")] public InputEncryptedChatBase Peer { get; set; }

		[JsonPropertyName("file")] public InputEncryptedFileBase File { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Peer);
			writer.Write(File);

		}

		public void Deserialize(Reader reader)
		{
			Peer = reader.Read<InputEncryptedChatBase>();
			File = reader.Read<InputEncryptedFileBase>();
		}

		public override string ToString()
		{
			return "messages.uploadEncryptedFile";
		}
	}
}