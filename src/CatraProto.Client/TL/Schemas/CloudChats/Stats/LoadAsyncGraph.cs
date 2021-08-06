using System;
using System.Collections.Generic;
using CatraProto.TL;
using System.Text.Json.Serialization;
using CatraProto.TL.Interfaces;
#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Stats
{
	public partial class LoadAsyncGraph : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			X = 1 << 0
		}

        [JsonIgnore]
        public static int StaticConstructorId { get => 1646092192; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.StatsGraphBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("token")]
		public string Token { get; set; }

[JsonPropertyName("x")]
		public long? X { get; set; }


		public void UpdateFlags() 
		{
			Flags = X == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Token);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(X.Value);
			}


		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Token = reader.Read<string>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				X = reader.Read<long>();
			}


		}
	}
}