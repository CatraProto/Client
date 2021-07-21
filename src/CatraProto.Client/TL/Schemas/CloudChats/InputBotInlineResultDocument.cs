using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputBotInlineResultDocument : CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineResultBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Title = 1 << 1,
			Description = 1 << 2
		}

        public static int StaticConstructorId { get => -459324; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("id")]
		public override string Id { get; set; }

[JsonPropertyName("type")]
		public string Type { get; set; }

[JsonPropertyName("title")]
		public string Title { get; set; }

[JsonPropertyName("description")]
		public string Description { get; set; }

[JsonPropertyName("document")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase Document { get; set; }

[JsonPropertyName("send_message")]
		public override CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageBase SendMessage { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Title == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = Description == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

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

			writer.Write(Document);
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

			Document = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase>();
			SendMessage = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineMessageBase>();

		}
	}
}