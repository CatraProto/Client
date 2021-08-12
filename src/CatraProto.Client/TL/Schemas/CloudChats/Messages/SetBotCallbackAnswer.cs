using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class SetBotCallbackAnswer : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Alert = 1 << 1,
			Message = 1 << 0,
			Url = 1 << 2
		}

        [JsonIgnore]
        public static int StaticConstructorId { get => -712043766; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }

        [JsonIgnore] Type IMethod.Type { get; init; } = typeof(bool);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("alert")]
		public bool Alert { get; set; }

[JsonPropertyName("query_id")]
		public long QueryId { get; set; }

[JsonPropertyName("message")]
		public string Message { get; set; }

[JsonPropertyName("url")]
		public string Url { get; set; }

[JsonPropertyName("cache_time")]
		public int CacheTime { get; set; }


		public void UpdateFlags() 
		{
			Flags = Alert ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = Message == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = Url == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(QueryId);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Message);
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				writer.Write(Url);
			}

			writer.Write(CacheTime);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Alert = FlagsHelper.IsFlagSet(Flags, 1);
			QueryId = reader.Read<long>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Message = reader.Read<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				Url = reader.Read<string>();
			}

			CacheTime = reader.Read<int>();
		}

		public override string ToString()
		{
			return "messages.setBotCallbackAnswer";
		}
	}
}