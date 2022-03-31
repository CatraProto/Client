using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class WallPaperSettings : CatraProto.Client.TL.Schemas.CloudChats.WallPaperSettingsBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Blur = 1 << 1,
			Motion = 1 << 2,
			BackgroundColor = 1 << 0,
			SecondBackgroundColor = 1 << 4,
			ThirdBackgroundColor = 1 << 5,
			FourthBackgroundColor = 1 << 6,
			Intensity = 1 << 3,
			Rotation = 1 << 4
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 499236004; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("blur")]
		public sealed override bool Blur { get; set; }

[Newtonsoft.Json.JsonProperty("motion")]
		public sealed override bool Motion { get; set; }

[Newtonsoft.Json.JsonProperty("background_color")]
		public sealed override int? BackgroundColor { get; set; }

[Newtonsoft.Json.JsonProperty("second_background_color")]
		public sealed override int? SecondBackgroundColor { get; set; }

[Newtonsoft.Json.JsonProperty("third_background_color")]
		public sealed override int? ThirdBackgroundColor { get; set; }

[Newtonsoft.Json.JsonProperty("fourth_background_color")]
		public sealed override int? FourthBackgroundColor { get; set; }

[Newtonsoft.Json.JsonProperty("intensity")]
		public sealed override int? Intensity { get; set; }

[Newtonsoft.Json.JsonProperty("rotation")]
		public sealed override int? Rotation { get; set; }


        
        public WallPaperSettings() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Blur ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = Motion ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
			Flags = BackgroundColor == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = SecondBackgroundColor == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
			Flags = ThirdBackgroundColor == null ? FlagsHelper.UnsetFlag(Flags, 5) : FlagsHelper.SetFlag(Flags, 5);
			Flags = FourthBackgroundColor == null ? FlagsHelper.UnsetFlag(Flags, 6) : FlagsHelper.SetFlag(Flags, 6);
			Flags = Intensity == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
			Flags = Rotation == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(BackgroundColor.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				writer.Write(SecondBackgroundColor.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 5))
			{
				writer.Write(ThirdBackgroundColor.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 6))
			{
				writer.Write(FourthBackgroundColor.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				writer.Write(Intensity.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				writer.Write(Rotation.Value);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Blur = FlagsHelper.IsFlagSet(Flags, 1);
			Motion = FlagsHelper.IsFlagSet(Flags, 2);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				BackgroundColor = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				SecondBackgroundColor = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 5))
			{
				ThirdBackgroundColor = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 6))
			{
				FourthBackgroundColor = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				Intensity = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				Rotation = reader.Read<int>();
			}


		}
		
		public override string ToString()
		{
		    return "wallPaperSettings";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}