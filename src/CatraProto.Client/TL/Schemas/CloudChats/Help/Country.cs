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
    public partial class Country : CatraProto.Client.TL.Schemas.CloudChats.Help.CountryBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Hidden = 1 << 0,
            Name = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1014526429; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("hidden")]
        public sealed override bool Hidden { get; set; }

        [Newtonsoft.Json.JsonProperty("iso2")] public sealed override string Iso2 { get; set; }

        [Newtonsoft.Json.JsonProperty("default_name")]
        public sealed override string DefaultName { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("name")]
        public sealed override string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("country_codes")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.Help.CountryCodeBase> CountryCodes { get; set; }


#nullable enable
        public Country(string iso2, string defaultName, List<CatraProto.Client.TL.Schemas.CloudChats.Help.CountryCodeBase> countryCodes)
        {
            Iso2 = iso2;
            DefaultName = defaultName;
            CountryCodes = countryCodes;
        }
#nullable disable
        internal Country()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Hidden ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = Name == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);

            writer.WriteString(Iso2);

            writer.WriteString(DefaultName);
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.WriteString(Name);
            }

            var checkcountryCodes = writer.WriteVector(CountryCodes, false);
            if (checkcountryCodes.IsError)
            {
                return checkcountryCodes;
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
            Hidden = FlagsHelper.IsFlagSet(Flags, 0);
            var tryiso2 = reader.ReadString();
            if (tryiso2.IsError)
            {
                return ReadResult<IObject>.Move(tryiso2);
            }

            Iso2 = tryiso2.Value;
            var trydefaultName = reader.ReadString();
            if (trydefaultName.IsError)
            {
                return ReadResult<IObject>.Move(trydefaultName);
            }

            DefaultName = trydefaultName.Value;
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var tryname = reader.ReadString();
                if (tryname.IsError)
                {
                    return ReadResult<IObject>.Move(tryname);
                }

                Name = tryname.Value;
            }

            var trycountryCodes = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.Help.CountryCodeBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trycountryCodes.IsError)
            {
                return ReadResult<IObject>.Move(trycountryCodes);
            }

            CountryCodes = trycountryCodes.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "help.country";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new Country();
            newClonedObject.Flags = Flags;
            newClonedObject.Hidden = Hidden;
            newClonedObject.Iso2 = Iso2;
            newClonedObject.DefaultName = DefaultName;
            newClonedObject.Name = Name;
            newClonedObject.CountryCodes = new List<CatraProto.Client.TL.Schemas.CloudChats.Help.CountryCodeBase>();
            foreach (var countryCodes in CountryCodes)
            {
                var clonecountryCodes = (CatraProto.Client.TL.Schemas.CloudChats.Help.CountryCodeBase?)countryCodes.Clone();
                if (clonecountryCodes is null)
                {
                    return null;
                }

                newClonedObject.CountryCodes.Add(clonecountryCodes);
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not Country castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Hidden != castedOther.Hidden)
            {
                return true;
            }

            if (Iso2 != castedOther.Iso2)
            {
                return true;
            }

            if (DefaultName != castedOther.DefaultName)
            {
                return true;
            }

            if (Name != castedOther.Name)
            {
                return true;
            }

            var countryCodessize = castedOther.CountryCodes.Count;
            if (countryCodessize != CountryCodes.Count)
            {
                return true;
            }

            for (var i = 0; i < countryCodessize; i++)
            {
                if (castedOther.CountryCodes[i].Compare(CountryCodes[i]))
                {
                    return true;
                }
            }

            return false;
        }

#nullable disable
    }
}