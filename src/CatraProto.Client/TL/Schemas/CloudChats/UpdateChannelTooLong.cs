using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateChannelTooLong : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Pts = 1 << 0
		}

        public static int StaticConstructorId { get => -352032773; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("channel_id")]
		public int ChannelId { get; set; }

[Newtonsoft.Json.JsonProperty("pts")]
		public int? Pts { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Pts == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(ChannelId);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Pts.Value);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			ChannelId = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Pts = reader.Read<int>();
			}


		}
				
		public override string ToString()
		{
		    return "updateChannelTooLong";
		}
	}
}