using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class InstallStickerSet : IMethod
	{


        [JsonIgnore]
        public static int StaticConstructorId { get => -946871200; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(StickerSetInstallResultBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

		[JsonPropertyName("stickerset")] public InputStickerSetBase Stickerset { get; set; }

[JsonPropertyName("archived")]
		public bool Archived { get; set; }


		public void UpdateFlags() 
		{

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			writer.Write(Stickerset);
			writer.Write(Archived);

		}

		public void Deserialize(Reader reader)
		{
			Stickerset = reader.Read<InputStickerSetBase>();
			Archived = reader.Read<bool>();
		}

		public override string ToString()
		{
			return "messages.installStickerSet";
		}
	}
}