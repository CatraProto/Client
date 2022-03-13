using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class StickerSet : CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Archived = 1 << 1,
			Official = 1 << 2,
			Masks = 1 << 3,
			Animated = 1 << 5,
			Videos = 1 << 6,
			InstalledDate = 1 << 0,
			Thumbs = 1 << 4,
			ThumbDcId = 1 << 4,
			ThumbVersion = 1 << 4
		}

        public static int StaticConstructorId { get => -673242758; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("archived")]
		public sealed override bool Archived { get; set; }

[Newtonsoft.Json.JsonProperty("official")]
		public sealed override bool Official { get; set; }

[Newtonsoft.Json.JsonProperty("masks")]
		public sealed override bool Masks { get; set; }

[Newtonsoft.Json.JsonProperty("animated")]
		public sealed override bool Animated { get; set; }

[Newtonsoft.Json.JsonProperty("videos")]
		public sealed override bool Videos { get; set; }

[Newtonsoft.Json.JsonProperty("installed_date")]
		public sealed override int? InstalledDate { get; set; }

[Newtonsoft.Json.JsonProperty("id")]
		public sealed override long Id { get; set; }

[Newtonsoft.Json.JsonProperty("access_hash")]
		public sealed override long AccessHash { get; set; }

[Newtonsoft.Json.JsonProperty("title")]
		public sealed override string Title { get; set; }

[Newtonsoft.Json.JsonProperty("short_name")]
		public sealed override string ShortName { get; set; }

[Newtonsoft.Json.JsonProperty("thumbs")]
		public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.PhotoSizeBase> Thumbs { get; set; }

[Newtonsoft.Json.JsonProperty("thumb_dc_id")]
		public sealed override int? ThumbDcId { get; set; }

[Newtonsoft.Json.JsonProperty("thumb_version")]
		public sealed override int? ThumbVersion { get; set; }

[Newtonsoft.Json.JsonProperty("count")]
		public sealed override int Count { get; set; }

[Newtonsoft.Json.JsonProperty("hash")]
		public sealed override int Hash { get; set; }


        #nullable enable
 public StickerSet (long id,long accessHash,string title,string shortName,int count,int hash)
{
 Id = id;
AccessHash = accessHash;
Title = title;
ShortName = shortName;
Count = count;
Hash = hash;
 
}
#nullable disable
        internal StickerSet() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Archived ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = Official ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
			Flags = Masks ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
			Flags = Animated ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
			Flags = Videos ? FlagsHelper.SetFlag(Flags, 6) : FlagsHelper.UnsetFlag(Flags, 6);
			Flags = InstalledDate == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = Thumbs == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
			Flags = ThumbDcId == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
			Flags = ThumbVersion == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(InstalledDate.Value);
			}

			writer.Write(Id);
			writer.Write(AccessHash);
			writer.Write(Title);
			writer.Write(ShortName);
			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				writer.Write(Thumbs);
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				writer.Write(ThumbDcId.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				writer.Write(ThumbVersion.Value);
			}

			writer.Write(Count);
			writer.Write(Hash);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Archived = FlagsHelper.IsFlagSet(Flags, 1);
			Official = FlagsHelper.IsFlagSet(Flags, 2);
			Masks = FlagsHelper.IsFlagSet(Flags, 3);
			Animated = FlagsHelper.IsFlagSet(Flags, 5);
			Videos = FlagsHelper.IsFlagSet(Flags, 6);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				InstalledDate = reader.Read<int>();
			}

			Id = reader.Read<long>();
			AccessHash = reader.Read<long>();
			Title = reader.Read<string>();
			ShortName = reader.Read<string>();
			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				Thumbs = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PhotoSizeBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				ThumbDcId = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				ThumbVersion = reader.Read<int>();
			}

			Count = reader.Read<int>();
			Hash = reader.Read<int>();

		}
				
		public override string ToString()
		{
		    return "stickerSet";
		}
	}
}