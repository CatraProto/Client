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
    public partial class CountriesList : CatraProto.Client.TL.Schemas.CloudChats.Help.CountriesListBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -2016381538; }

        [Newtonsoft.Json.JsonProperty("countries")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.Help.CountryBase> Countries { get; set; }

        [Newtonsoft.Json.JsonProperty("hash")] public int Hash { get; set; }


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
            var newClonedObject = new CountriesList();
            newClonedObject.Countries = new List<CatraProto.Client.TL.Schemas.CloudChats.Help.CountryBase>();
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

        public override bool Compare(IObject other)
        {
            if (other is not CountriesList castedOther)
            {
                return true;
            }

            var countriessize = castedOther.Countries.Count;
            if (countriessize != Countries.Count)
            {
                return true;
            }

            for (var i = 0; i < countriessize; i++)
            {
                if (castedOther.Countries[i].Compare(Countries[i]))
                {
                    return true;
                }
            }

            if (Hash != castedOther.Hash)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}