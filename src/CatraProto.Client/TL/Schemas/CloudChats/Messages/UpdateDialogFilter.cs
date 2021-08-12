using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class UpdateDialogFilter : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Filter = 1 << 0
		}

        [JsonIgnore]
        public static int StaticConstructorId { get => 450142282; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(bool);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("id")]
		public int Id { get; set; }

		[JsonPropertyName("filter")] public DialogFilterBase Filter { get; set; }


		public void UpdateFlags() 
		{
			Flags = Filter == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Id);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Filter);
			}


		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Id = reader.Read<int>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Filter = reader.Read<DialogFilterBase>();
			}
		}

		public override string ToString()
		{
			return "messages.updateDialogFilter";
		}
	}
}