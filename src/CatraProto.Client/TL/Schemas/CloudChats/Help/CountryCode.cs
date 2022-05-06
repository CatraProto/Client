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
    public partial class CountryCode : CatraProto.Client.TL.Schemas.CloudChats.Help.CountryCodeBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Prefixes = 1 << 0,
            Patterns = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1107543535; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

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
#nullable disable
    }
}