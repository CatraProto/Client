using System;
using System.Collections.Generic;
using CatraProto.TL;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public partial class CountryCode : CountryCodeBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Prefixes = 1 << 0,
            Patterns = 1 << 1
        }

        public static int StaticConstructorId
        {
            get => 1107543535;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonIgnore] public int Flags { get; set; }

        [JsonProperty("country_code")] public override string CountryCodeField { get; set; }

        [JsonProperty("prefixes")] public override IList<string> Prefixes { get; set; }

        [JsonProperty("patterns")] public override IList<string> Patterns { get; set; }


        public override void UpdateFlags()
        {
            Flags = Prefixes == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = Patterns == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            UpdateFlags();
            writer.Write(Flags);
            writer.Write(CountryCodeField);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.Write(Prefixes);
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.Write(Patterns);
            }
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            CountryCodeField = reader.Read<string>();
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                Prefixes = reader.ReadVector<string>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                Patterns = reader.ReadVector<string>();
            }
        }

        public override string ToString()
        {
            return "help.countryCode";
        }
    }
}