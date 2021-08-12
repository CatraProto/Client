using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class SendEncryptedFile : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Silent = 1 << 0
		}

        [JsonIgnore]
        public static int StaticConstructorId { get => 1431914525; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(SentEncryptedMessageBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("silent")]
		public bool Silent { get; set; }

		[JsonPropertyName("peer")] public InputEncryptedChatBase Peer { get; set; }

[JsonPropertyName("random_id")]
		public long RandomId { get; set; }

[JsonPropertyName("data")]
		public byte[] Data { get; set; }

		[JsonPropertyName("file")] public InputEncryptedFileBase File { get; set; }


		public void UpdateFlags() 
		{
			Flags = Silent ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Peer);
			writer.Write(RandomId);
			writer.Write(Data);
			writer.Write(File);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Silent = FlagsHelper.IsFlagSet(Flags, 0);
			Peer = reader.Read<InputEncryptedChatBase>();
			RandomId = reader.Read<long>();
			Data = reader.Read<byte[]>();
			File = reader.Read<InputEncryptedFileBase>();
		}

		public override string ToString()
		{
			return "messages.sendEncryptedFile";
		}
	}
}