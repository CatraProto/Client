using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
	public partial class CountryCode : CatraProto.Client.TL.Schemas.CloudChats.Help.CountryCodeBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Prefixes = 1 << 0,
			Patterns = 1 << 1
		}

        public static int StaticConstructorId { get => 1107543535; }
        [JsonIgnore]
        public int ConstructorId { get => StaticConstructorId; }
        
[JsonIgnore]
		public int Flags { get; set; }

[JsonPropertyName("CountryCode_")]
		public override string CountryCode_ { get; set; }

[JsonPropertyName("prefixes")]
		public override IList<string> Prefixes { get; set; }

[JsonPropertyName("patterns")]
		public override IList<string> Patterns { get; set; }

        
		public override void UpdateFlags() 
		{
			Flags = Prefixes == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = Patterns == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public override void Serialize(Writer writer)
		{
		    if(ConstructorId != 0) writer.Write(ConstructorId);
			UpdateFlags();
			writer.Write(Flags);
			writer.Write(CountryCode_);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				writer.Write(Prefixes);
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				writer.Write(Patterns);
			}


		}

		public override void Deserialize(Reader reader)
		{
			Flags = reader.Read<int>();
			CountryCode_ = reader.Read<string>();
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				Prefixes = reader.ReadVector<string>();
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				Patterns = reader.ReadVector<string>();
			}


		}
	}
}