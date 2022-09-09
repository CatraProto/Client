using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

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

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1107543535; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("country_code")]
        public sealed override string CountryCodeField { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("prefixes")]
        public sealed override List<string> Prefixes { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("patterns")]
        public sealed override List<string> Patterns { get; set; }


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

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);

            writer.WriteString(CountryCodeField);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteVector(Prefixes, false);
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.WriteVector(Patterns, false);
            }


            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }

            Flags = tryflags.Value;
            var trycountryCodeField = reader.ReadString();
            if (trycountryCodeField.IsError)
            {
                return ReadResult<IObject>.Move(trycountryCodeField);
            }

            CountryCodeField = trycountryCodeField.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryprefixes = reader.ReadVector<string>(ParserTypes.String, nakedVector: false, nakedObjects: false);
                if (tryprefixes.IsError)
                {
                    return ReadResult<IObject>.Move(tryprefixes);
                }

                Prefixes = tryprefixes.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var trypatterns = reader.ReadVector<string>(ParserTypes.String, nakedVector: false, nakedObjects: false);
                if (trypatterns.IsError)
                {
                    return ReadResult<IObject>.Move(trypatterns);
                }

                Patterns = trypatterns.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "help.countryCode";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new CountryCode();
            newClonedObject.Flags = Flags;
            newClonedObject.CountryCodeField = CountryCodeField;
            if (Prefixes is not null)
            {
                newClonedObject.Prefixes = new List<string>();
                foreach (var prefixes in Prefixes)
                {
                    newClonedObject.Prefixes.Add(prefixes);
                }
            }

            if (Patterns is not null)
            {
                newClonedObject.Patterns = new List<string>();
                foreach (var patterns in Patterns)
                {
                    newClonedObject.Patterns.Add(patterns);
                }
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not CountryCode castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (CountryCodeField != castedOther.CountryCodeField)
            {
                return true;
            }

            if (Prefixes is null && castedOther.Prefixes is not null || Prefixes is not null && castedOther.Prefixes is null)
            {
                return true;
            }

            if (Prefixes is not null && castedOther.Prefixes is not null)
            {
                var prefixessize = castedOther.Prefixes.Count;
                if (prefixessize != Prefixes.Count)
                {
                    return true;
                }

                for (var i = 0; i < prefixessize; i++)
                {
                    if (castedOther.Prefixes[i] != Prefixes[i])
                    {
                        return true;
                    }
                }
            }

            if (Patterns is null && castedOther.Patterns is not null || Patterns is not null && castedOther.Patterns is null)
            {
                return true;
            }

            if (Patterns is not null && castedOther.Patterns is not null)
            {
                var patternssize = castedOther.Patterns.Count;
                if (patternssize != Patterns.Count)
                {
                    return true;
                }

                for (var i = 0; i < patternssize; i++)
                {
                    if (castedOther.Patterns[i] != Patterns[i])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

#nullable disable
    }
}