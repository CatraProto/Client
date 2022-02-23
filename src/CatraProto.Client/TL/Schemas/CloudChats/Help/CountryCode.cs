using System;
using System.Collections.Generic;
using CatraProto.TL;

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

        public static int StaticConstructorId
        {
            get => 1107543535;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("country_code")]
        public sealed override string CountryCodeField { get; set; }

        [Newtonsoft.Json.JsonProperty("prefixes")]
        public sealed override IList<string> Prefixes { get; set; }

        [Newtonsoft.Json.JsonProperty("patterns")]
        public sealed override IList<string> Patterns { get; set; }


    #nullable enable
        public CountryCode(string countryCodeField)
        {
            CountryCodeField = countryCodeField;
        }
    #nullable disable
        internal CountryCode()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Prefixes == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = Patterns == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
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