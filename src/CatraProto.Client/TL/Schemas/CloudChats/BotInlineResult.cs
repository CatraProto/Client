using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class BotInlineResult : CatraProto.Client.TL.Schemas.CloudChats.BotInlineResultBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Title = 1 << 1,
			Description = 1 << 2,
			Url = 1 << 3,
			Thumb = 1 << 4,
			Content = 1 << 5
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 295067450; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("id")]
		public sealed override string Id { get; set; }

[Newtonsoft.Json.JsonProperty("type")]
		public sealed override string Type { get; set; }

[Newtonsoft.Json.JsonProperty("title")]
		public string Title { get; set; }

[Newtonsoft.Json.JsonProperty("description")]
		public string Description { get; set; }

[Newtonsoft.Json.JsonProperty("url")]
		public string Url { get; set; }

[Newtonsoft.Json.JsonProperty("thumb")]
		public CatraProto.Client.TL.Schemas.CloudChats.WebDocumentBase Thumb { get; set; }

[Newtonsoft.Json.JsonProperty("content")]
		public CatraProto.Client.TL.Schemas.CloudChats.WebDocumentBase Content { get; set; }

[Newtonsoft.Json.JsonProperty("send_message")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.BotInlineMessageBase SendMessage { get; set; }


        #nullable enable
 public BotInlineResult (string id,string type,CatraProto.Client.TL.Schemas.CloudChats.BotInlineMessageBase sendMessage)
{
 Id = id;
Type = type;
SendMessage = sendMessage;
 
}
#nullable disable
        internal BotInlineResult() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Title == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = Description == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = Url == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
			Flags = Thumb == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
			Flags = Content == null ? FlagsHelper.UnsetFlag(Flags, 5) : FlagsHelper.SetFlag(Flags, 5);

		}

		public override void Serialize(Writer writer)
		{
writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Id);
			writer.Write(Type);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(Title);
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(Description);
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				writer.Write(Url);
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				writer.Write(Thumb);
			}

			if(FlagsHelper.IsFlagSet(Flags, 5))
			{
				writer.Write(Content);
			}

			writer.Write(SendMessage);

		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Id = reader.Read<string>();
			Type = reader.Read<string>();
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				Title = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				Description = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				Url = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				Thumb = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.WebDocumentBase>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 5))
			{
				Content = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.WebDocumentBase>();
			}

			SendMessage = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.BotInlineMessageBase>();

		}
		
		public override string ToString()
		{
		    return "botInlineResult";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}