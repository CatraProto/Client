using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class InputBotInlineResultDocument : InputBotInlineResultBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Title = 1 << 1,
			Description = 1 << 2
		}

        public static int ConstructorId { get; } = -459324;
		public int Flags { get; set; }
		public override string Id { get; set; }
		public string Type { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public InputDocumentBase Document { get; set; }
		public override InputBotInlineMessageBase SendMessage { get; set; }

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

			Document = reader.Read<InputDocumentBase>();
			SendMessage = reader.Read<InputBotInlineMessageBase>();

		}
	}
}