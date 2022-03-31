using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

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
			Videos = 1 << 4,
			Thumb = 1 << 2,
			Software = 1 << 3
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1876841625; }
        
[Newtonsoft.Json.JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase);

[Newtonsoft.Json.JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("masks")]
		public bool Masks { get; set; }

[Newtonsoft.Json.JsonProperty("animated")]
		public bool Animated { get; set; }

[Newtonsoft.Json.JsonProperty("videos")]
		public bool Videos { get; set; }

[Newtonsoft.Json.JsonProperty("user_id")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase UserId { get; set; }

[Newtonsoft.Json.JsonProperty("title")]
		public string Title { get; set; }

[Newtonsoft.Json.JsonProperty("short_name")]
		public string ShortName { get; set; }

[Newtonsoft.Json.JsonProperty("thumb")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase Thumb { get; set; }

[Newtonsoft.Json.JsonProperty("stickers")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetItemBase> Stickers { get; set; }

[Newtonsoft.Json.JsonProperty("software")]
		public string Software { get; set; }

        
        #nullable enable
 public CreateStickerSet (CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId,string title,string shortName,IList<CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetItemBase> stickers)
{
 UserId = userId;
Title = title;
ShortName = shortName;
Stickers = stickers;
 
}
#nullable disable
                
        internal CreateStickerSet() 
        {
        }
        
		public void UpdateFlags() 
		{
			Flags = Masks ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Animated ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = Videos ? FlagsHelper.SetFlag(Flags, 4) : FlagsHelper.UnsetFlag(Flags, 4);
			Flags = Thumb == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = Software == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);

		}

		public void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
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
			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				writer.Write(Software);
			}


		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Masks = FlagsHelper.IsFlagSet(Flags, 0);
			Animated = FlagsHelper.IsFlagSet(Flags, 1);
			Videos = FlagsHelper.IsFlagSet(Flags, 4);
			UserId = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
			Title = reader.Read<string>();
			ShortName = reader.Read<string>();
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				Thumb = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase>();
			}

			Stickers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetItemBase>();
			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				Software = reader.Read<string>();
			}


		}

		public override string ToString()
		{
		    return "stickers.createStickerSet";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}