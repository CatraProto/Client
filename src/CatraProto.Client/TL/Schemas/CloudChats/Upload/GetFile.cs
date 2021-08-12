using System;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Upload
{
	public partial class GetFile : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Precise = 1 << 0,
			CdnSupported = 1 << 1
		}

        [JsonIgnore]
        public static int StaticConstructorId { get => -1319462148; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		Type IMethod.Type { get; init; } = typeof(FileBase);

[JsonIgnore]
		bool IMethod.IsVector { get; init; } = false;

[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("precise")]
		public bool Precise { get; set; }

[JsonPropertyName("cdn_supported")]
		public bool CdnSupported { get; set; }

[JsonPropertyName("location")]
		public InputFileLocationBase Location { get; set; }

[JsonPropertyName("offset")]
		public int Offset { get; set; }

[JsonPropertyName("limit")]
		public int Limit { get; set; }


		public void UpdateFlags() 
		{
			Flags = Precise ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = CdnSupported ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);

		}

		public void Serialize(Writer writer)
		{
            if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(Location);
			writer.Write(Offset);
			writer.Write(Limit);

		}

		public void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			Precise = FlagsHelper.IsFlagSet(Flags, 0);
			CdnSupported = FlagsHelper.IsFlagSet(Flags, 1);
			Location = reader.Read<InputFileLocationBase>();
			Offset = reader.Read<int>();
			Limit = reader.Read<int>();
		}

		public override string ToString()
		{
			return "upload.getFile";
		}
	}
}