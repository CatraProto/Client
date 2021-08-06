using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
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

        public static int StaticConstructorId { get => 295067450; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("id")]
		public override string Id { get; set; }

[JsonPropertyName("type")]
		public override string Type { get; set; }

[JsonPropertyName("title")]
		public override string Title { get; set; }

[JsonPropertyName("description")]
		public override string Description { get; set; }

[JsonPropertyName("url")]
		public string Url { get; set; }

[JsonPropertyName("thumb")]
		public CatraProto.Client.TL.Schemas.CloudChats.WebDocumentBase Thumb { get; set; }

[JsonPropertyName("content")]
		public CatraProto.Client.TL.Schemas.CloudChats.WebDocumentBase Content { get; set; }

[JsonPropertyName("send_message")]
		public override CatraProto.Client.TL.Schemas.CloudChats.BotInlineMessageBase SendMessage { get; set; }

        
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
		    if(ConstructorId != 0) writer.Write(ConstructorId);
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
	}
}