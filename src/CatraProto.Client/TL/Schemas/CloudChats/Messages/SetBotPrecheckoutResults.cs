using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class SetBotPrecheckoutResults : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Success = 1 << 1,
			Error = 1 << 0
		}

        [JsonIgnore]
        public static int StaticConstructorId { get => 163765653; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore] Type IMethod.Type { get; init; } = typeof(bool);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("success")]
		public bool Success { get; set; }

[JsonPropertyName("query_id")]
		public long QueryId { get; set; }

[JsonPropertyName("error")]
		public string Error { get; set; }


		public void UpdateFlags() 
		{
			Flags = Success ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = Error == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(QueryId);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Error);
			}


		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Success = FlagsHelper.IsFlagSet(Flags, 1);
			QueryId = reader.Read<long>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Error = reader.Read<string>();
			}


		}
	}
}