using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Stickers
{
	public partial class CreateStickerSet : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Masks = 1 << 0,
			Animated = 1 << 1,
			Thumb = 1 << 2
		}

        [JsonIgnore]
        public static int StaticConstructorId { get => -251435136; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore] Type IMethod.Type { get; init; } = typeof(Messages.StickerSetBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("masks")]
		public bool Masks { get; set; }

[JsonPropertyName("animated")]
		public bool Animated { get; set; }

[JsonPropertyName("user_id")] public InputUserBase UserId { get; set; }

[JsonPropertyName("title")]
		public string Title { get; set; }

[JsonPropertyName("short_name")]
		public string ShortName { get; set; }

[JsonPropertyName("thumb")] public InputDocumentBase Thumb { get; set; }

[JsonPropertyName("stickers")] public IList<InputStickerSetItemBase> Stickers { get; set; }


		public void UpdateFlags() 
		{
			Flags = Masks ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Animated ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = Thumb == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(UserId);
			writer.Write(Title);
			writer.Write(ShortName);
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(Thumb);
			}

			writer.Write(Stickers);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Masks = FlagsHelper.IsFlagSet(Flags, 0);
			Animated = FlagsHelper.IsFlagSet(Flags, 1);
			UserId = reader.Read<InputUserBase>();
			Title = reader.Read<string>();
			ShortName = reader.Read<string>();
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				Thumb = reader.Read<InputDocumentBase>();
			}

			Stickers = reader.ReadVector<InputStickerSetItemBase>();

		}
	}
}