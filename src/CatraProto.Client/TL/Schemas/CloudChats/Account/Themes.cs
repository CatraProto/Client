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
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class Themes : CatraProto.Client.TL.Schemas.CloudChats.Account.ThemesBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1707242387; }

        [Newtonsoft.Json.JsonProperty("hash")]
        public long Hash { get; set; }

        [Newtonsoft.Json.JsonProperty("themes")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.ThemeBase> ThemesField { get; set; }


#nullable enable
        public Themes(long hash, List<CatraProto.Client.TL.Schemas.CloudChats.ThemeBase> themesField)
        {
            Hash = hash;
            ThemesField = themesField;

        }
#nullable disable
        internal Themes()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(Hash);
            var checkthemesField = writer.WriteVector(ThemesField, false);
            if (checkthemesField.IsError)
            {
                return checkthemesField;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryhash = reader.ReadInt64();
            if (tryhash.IsError)
            {
                return ReadResult<IObject>.Move(tryhash);
            }
            Hash = tryhash.Value;
            var trythemesField = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ThemeBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trythemesField.IsError)
            {
                return ReadResult<IObject>.Move(trythemesField);
            }
            ThemesField = trythemesField.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "account.themes";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new Themes
            {
                Hash = Hash,
                ThemesField = new List<CatraProto.Client.TL.Schemas.CloudChats.ThemeBase>()
            };
            foreach (var themesField in ThemesField)
            {
                var clonethemesField = (CatraProto.Client.TL.Schemas.CloudChats.ThemeBase?)themesField.Clone();
                if (clonethemesField is null)
                {
                    return null;
                }
                newClonedObject.ThemesField.Add(clonethemesField);
            }
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not Themes castedOther)
            {
                return true;
            }
            if (Hash != castedOther.Hash)
            {
                return true;
            }
            var themesFieldsize = castedOther.ThemesField.Count;
            if (themesFieldsize != ThemesField.Count)
            {
                return true;
            }
            for (var i = 0; i < themesFieldsize; i++)
            {
                if (castedOther.ThemesField[i].Compare(ThemesField[i]))
                {
                    return true;
                }
            }
            return false;

        }

#nullable disable
    }
}