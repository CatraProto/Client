using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class BotInlineMessageText : CatraProto.Client.TL.Schemas.CloudChats.BotInlineMessageBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			NoWebpage = 1 << 0,
			Entities = 1 << 1,
			ReplyMarkup = 1 << 2
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1937807902; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("no_webpage")]
		public bool NoWebpage { get; set; }

[Newtonsoft.Json.JsonProperty("message")]
		public string Message { get; set; }

[Newtonsoft.Json.JsonProperty("entities")]
		public IList<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> Entities { get; set; }

[Newtonsoft.Json.JsonProperty("reply_markup")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase ReplyMarkup { get; set; }


        #nullable enable
 public BotInlineMessageText (string message)
{
 Message = message;
 
}
#nullable disable
        internal BotInlineMessageText() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = NoWebpage ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Entities == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = ReplyMarkup == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Message);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(Entities);
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(ReplyMarkup);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			NoWebpage = FlagsHelper.IsFlagSet(Flags, 0);
			Message = reader.Read<string>();
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				Entities = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				ReplyMarkup = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase>();
			}


		}
		
		public override string ToString()
		{
		    return "botInlineMessageText";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}