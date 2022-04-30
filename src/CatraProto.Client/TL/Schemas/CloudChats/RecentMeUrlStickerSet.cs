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
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class RecentMeUrlStickerSet : CatraProto.Client.TL.Schemas.CloudChats.RecentMeUrlBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1140172836; }

        [Newtonsoft.Json.JsonProperty("url")]
        public sealed override string Url { get; set; }

        [Newtonsoft.Json.JsonProperty("set")]
        public CatraProto.Client.TL.Schemas.CloudChats.StickerSetCoveredBase Set { get; set; }


#nullable enable
        public RecentMeUrlStickerSet(string url, CatraProto.Client.TL.Schemas.CloudChats.StickerSetCoveredBase set)
        {
            Url = url;
            Set = set;

        }
#nullable disable
        internal RecentMeUrlStickerSet()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Url);
            var checkset = writer.WriteObject(Set);
            if (checkset.IsError)
            {
                return checkset;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryurl = reader.ReadString();
            if (tryurl.IsError)
            {
                return ReadResult<IObject>.Move(tryurl);
            }
            Url = tryurl.Value;
            var tryset = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.StickerSetCoveredBase>();
            if (tryset.IsError)
            {
                return ReadResult<IObject>.Move(tryset);
            }
            Set = tryset.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "recentMeUrlStickerSet";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new RecentMeUrlStickerSet
            {
                Url = Url
            };
            var cloneSet = (CatraProto.Client.TL.Schemas.CloudChats.StickerSetCoveredBase?)Set.Clone();
            if (cloneSet is null)
            {
                return null;
            }
            newClonedObject.Set = cloneSet;
            return newClonedObject;

        }
#nullable disable
    }
}