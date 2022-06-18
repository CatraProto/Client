/*
CatraProto, a C# library that implements the MTProto protocol and the Telegram API.
Copyright (C) 2022 Aquatica <aquathing@protonmail.com>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

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

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1014526429; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("hidden")]
        public sealed override bool Hidden { get; set; }

        [Newtonsoft.Json.JsonProperty("iso2")]
        public sealed override string Iso2 { get; set; }

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
            var newClonedObject = new Country
            {
                Flags = Flags,
                Hidden = Hidden,
                Iso2 = Iso2,
                DefaultName = DefaultName,
                Name = Name,
                CountryCodes = new List<CatraProto.Client.TL.Schemas.CloudChats.Help.CountryCodeBase>()
            };
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