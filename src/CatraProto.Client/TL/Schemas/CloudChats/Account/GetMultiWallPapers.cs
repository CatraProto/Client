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
    public partial class GetMultiWallPapers : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1705865692; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("wallpapers")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.InputWallPaperBase> Wallpapers { get; set; }


#nullable enable
        public GetMultiWallPapers(List<CatraProto.Client.TL.Schemas.CloudChats.InputWallPaperBase> wallpapers)
        {
            Wallpapers = wallpapers;

        }
#nullable disable

        internal GetMultiWallPapers()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkwallpapers = writer.WriteVector(Wallpapers, false);
            if (checkwallpapers.IsError)
            {
                return checkwallpapers;
            }

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trywallpapers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputWallPaperBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trywallpapers.IsError)
            {
                return ReadResult<IObject>.Move(trywallpapers);
            }
            Wallpapers = trywallpapers.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "account.getMultiWallPapers";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetMultiWallPapers
            {
                Wallpapers = new List<CatraProto.Client.TL.Schemas.CloudChats.InputWallPaperBase>()
            };
            foreach (var wallpapers in Wallpapers)
            {
                var clonewallpapers = (CatraProto.Client.TL.Schemas.CloudChats.InputWallPaperBase?)wallpapers.Clone();
                if (clonewallpapers is null)
                {
                    return null;
                }
                newClonedObject.Wallpapers.Add(clonewallpapers);
            }
            return newClonedObject;

        }

        public bool Compare(IObject other)
        {
            if (other is not GetMultiWallPapers castedOther)
            {
                return true;
            }
            var wallpaperssize = castedOther.Wallpapers.Count;
            if (wallpaperssize != Wallpapers.Count)
            {
                return true;
            }
            for (var i = 0; i < wallpaperssize; i++)
            {
                if (castedOther.Wallpapers[i].Compare(Wallpapers[i]))
                {
                    return true;
                }
            }
            return false;

        }
#nullable disable
    }
}