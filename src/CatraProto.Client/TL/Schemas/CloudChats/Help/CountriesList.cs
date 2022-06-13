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

using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public partial class CountriesList : CatraProto.Client.TL.Schemas.CloudChats.Help.CountriesListBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -2016381538; }

        [Newtonsoft.Json.JsonProperty("countries")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.Help.CountryBase> Countries { get; set; }

        [Newtonsoft.Json.JsonProperty("hash")]
        public int Hash { get; set; }


#nullable enable
        public CountriesList(List<CatraProto.Client.TL.Schemas.CloudChats.Help.CountryBase> countries, int hash)
        {
            Countries = countries;
            Hash = hash;

        }
#nullable disable
        internal CountriesList()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkcountries = writer.WriteVector(Countries, false);
            if (checkcountries.IsError)
            {
                return checkcountries;
            }
            writer.WriteInt32(Hash);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trycountries = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.Help.CountryBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trycountries.IsError)
            {
                return ReadResult<IObject>.Move(trycountries);
            }
            Countries = trycountries.Value;
            var tryhash = reader.ReadInt32();
            if (tryhash.IsError)
            {
                return ReadResult<IObject>.Move(tryhash);
            }
            Hash = tryhash.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "help.countriesList";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new CountriesList
            {
                Countries = new List<CatraProto.Client.TL.Schemas.CloudChats.Help.CountryBase>()
            };
            foreach (var countries in Countries)
            {
                var clonecountries = (CatraProto.Client.TL.Schemas.CloudChats.Help.CountryBase?)countries.Clone();
                if (clonecountries is null)
                {
                    return null;
                }
                newClonedObject.Countries.Add(clonecountries);
            }
            newClonedObject.Hash = Hash;
            return newClonedObject;

        }
#nullable disable
    }
}