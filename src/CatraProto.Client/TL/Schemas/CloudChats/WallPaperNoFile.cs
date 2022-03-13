using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class WallPaperNoFile : CatraProto.Client.TL.Schemas.CloudChats.WallPaperBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Default = 1 << 1,
			Dark = 1 << 4,
			Settings = 1 << 2
		}

        public static int StaticConstructorId { get => -528465642; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonProperty("id")]
		public sealed override long Id { get; set; }

[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("default")]
		public sealed override bool Default { get; set; }

[Newtonsoft.Json.JsonProperty("dark")]
		public sealed override bool Dark { get; set; }

[Newtonsoft.Json.JsonProperty("settings")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.WallPaperSettingsBase Settings { get; set; }


        #nullable enable
 public WallPaperNoFile (long id)
{
 Id = id;
 
}
#nullable disable
        internal WallPaperNoFile() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Default ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = Dark ? FlagsHelper.SetFlag(Flags, 4) : FlagsHelper.UnsetFlag(Flags, 4);
			Flags = Settings == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			writer.Write(Id);
			UpdateFlags();
			writer.Write(Flags);
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(Settings);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Id = reader.Read<long>();
			Flags = reader.Read<int>();
			Default = FlagsHelper.IsFlagSet(Flags, 1);
			Dark = FlagsHelper.IsFlagSet(Flags, 4);
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				Settings = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.WallPaperSettingsBase>();
			}


		}
				
		public override string ToString()
		{
		    return "wallPaperNoFile";
		}
	}
}