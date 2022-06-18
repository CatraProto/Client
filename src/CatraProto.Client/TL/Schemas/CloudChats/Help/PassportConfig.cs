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

using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public partial class PassportConfig : CatraProto.Client.TL.Schemas.CloudChats.Help.PassportConfigBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1600596305; }

        [Newtonsoft.Json.JsonProperty("hash")]
        public int Hash { get; set; }

        [Newtonsoft.Json.JsonProperty("countries_langs")]
        public CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase CountriesLangs { get; set; }


#nullable enable
        public PassportConfig(int hash, CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase countriesLangs)
        {
            Hash = hash;
            CountriesLangs = countriesLangs;

        }
#nullable disable
        internal PassportConfig()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Hash);
            var checkcountriesLangs = writer.WriteObject(CountriesLangs);
            if (checkcountriesLangs.IsError)
            {
                return checkcountriesLangs;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryhash = reader.ReadInt32();
            if (tryhash.IsError)
            {
                return ReadResult<IObject>.Move(tryhash);
            }
            Hash = tryhash.Value;
            var trycountriesLangs = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase>();
            if (trycountriesLangs.IsError)
            {
                return ReadResult<IObject>.Move(trycountriesLangs);
            }
            CountriesLangs = trycountriesLangs.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "help.passportConfig";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PassportConfig
            {
                Hash = Hash
            };
            var cloneCountriesLangs = (CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase?)CountriesLangs.Clone();
            if (cloneCountriesLangs is null)
            {
                return null;
            }
            newClonedObject.CountriesLangs = cloneCountriesLangs;
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not PassportConfig castedOther)
            {
                return true;
            }
            if (Hash != castedOther.Hash)
            {
                return true;
            }
            if (CountriesLangs.Compare(castedOther.CountriesLangs))
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}