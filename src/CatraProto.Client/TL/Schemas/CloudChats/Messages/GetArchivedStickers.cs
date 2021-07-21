using System;
using System.Collections.Generic;
using CatraProto.TL;
using System.Text.Json.Serialization;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetArchivedStickers : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Masks = 1 << 0
		}

        [JsonIgnore]
        public static int StaticConstructorId { get => 1475442322; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.ArchivedStickersBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("masks")]
		public bool Masks { get; set; }

[JsonPropertyName("offset_id")]
		public long OffsetId { get; set; }

[JsonPropertyName("limit")]
		public int Limit { get; set; }


		public void UpdateFlags() 
		{
			Flags = Masks ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(OffsetId);
			writer.Write(Limit);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Masks = FlagsHelper.IsFlagSet(Flags, 0);
			OffsetId = reader.Read<long>();
			Limit = reader.Read<int>();

		}
	}
}