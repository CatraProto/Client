using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class BotInlineMessageMediaGeo : CatraProto.Client.TL.Schemas.CloudChats.BotInlineMessageBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Heading = 1 << 0,
			Period = 1 << 1,
			ProximityNotificationRadius = 1 << 3,
			ReplyMarkup = 1 << 2
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 85477117; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("geo")]
		public CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase Geo { get; set; }

[Newtonsoft.Json.JsonProperty("heading")]
		public int? Heading { get; set; }

[Newtonsoft.Json.JsonProperty("period")]
		public int? Period { get; set; }

[Newtonsoft.Json.JsonProperty("proximity_notification_radius")]
		public int? ProximityNotificationRadius { get; set; }

[Newtonsoft.Json.JsonProperty("reply_markup")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase ReplyMarkup { get; set; }


        #nullable enable
 public BotInlineMessageMediaGeo (CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase geo)
{
 Geo = geo;
 
}
#nullable disable
        internal BotInlineMessageMediaGeo() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Heading == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = Period == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = ProximityNotificationRadius == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
			Flags = ReplyMarkup == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Geo);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Heading.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(Period.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				writer.Write(ProximityNotificationRadius.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(ReplyMarkup);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Geo = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.GeoPointBase>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Heading = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				Period = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				ProximityNotificationRadius = reader.Read<int>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				ReplyMarkup = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase>();
			}


		}
		
		public override string ToString()
		{
		    return "botInlineMessageMediaGeo";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}