using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class UpdateServiceNotification : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Popup = 1 << 0,
			InboxDate = 1 << 1
		}

        public static int StaticConstructorId { get => -337352679; }
        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("popup")]
		public bool Popup { get; set; }

[Newtonsoft.Json.JsonProperty("inbox_date")]
		public int? InboxDate { get; set; }

[Newtonsoft.Json.JsonProperty("type")]
		public string Type { get; set; }

[Newtonsoft.Json.JsonProperty("message")]
		public string Message { get; set; }

[Newtonsoft.Json.JsonProperty("media")]
		public CatraProto.Client.TL.Schemas.CloudChats.MessageMediaBase Media { get; set; }

[Newtonsoft.Json.JsonProperty("entities")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> Entities { get; set; }


        #nullable enable
 public UpdateServiceNotification (string type,string message,CatraProto.Client.TL.Schemas.CloudChats.MessageMediaBase media,IList<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> entities)
{
 Type = type;
Message = message;
Media = media;
Entities = entities;
 
}
#nullable disable
        internal UpdateServiceNotification() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Popup ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = InboxDate == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(InboxDate.Value);
			}

			writer.Write(Type);
			writer.Write(Message);
			writer.Write(Media);
			writer.Write(Entities);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Popup = FlagsHelper.IsFlagSet(Flags, 0);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				InboxDate = reader.Read<int>();
			}

			Type = reader.Read<string>();
			Message = reader.Read<string>();
			Media = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.MessageMediaBase>();
			Entities = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>();

		}
				
		public override string ToString()
		{
		    return "updateServiceNotification";
		}
	}
}