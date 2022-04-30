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
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class StickerSetMultiCovered : CatraProto.Client.TL.Schemas.CloudChats.StickerSetCoveredBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 872932635; }

        [Newtonsoft.Json.JsonProperty("set")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase Set { get; set; }

        [Newtonsoft.Json.JsonProperty("covers")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> Covers { get; set; }


#nullable enable
        public StickerSetMultiCovered(CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase set, List<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> covers)
        {
            Set = set;
            Covers = covers;

        }
#nullable disable
        internal StickerSetMultiCovered()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkset = writer.WriteObject(Set);
            if (checkset.IsError)
            {
                return checkset;
            }
            var checkcovers = writer.WriteVector(Covers, false);
            if (checkcovers.IsError)
            {
                return checkcovers;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryset = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase>();
            if (tryset.IsError)
            {
                return ReadResult<IObject>.Move(tryset);
            }
            Set = tryset.Value;
            var trycovers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trycovers.IsError)
            {
                return ReadResult<IObject>.Move(trycovers);
            }
            Covers = trycovers.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "stickerSetMultiCovered";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new StickerSetMultiCovered();
            var cloneSet = (CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase?)Set.Clone();
            if (cloneSet is null)
            {
                return null;
            }
            newClonedObject.Set = cloneSet;
            foreach (var covers in Covers)
            {
                var clonecovers = (CatraProto.Client.TL.Schemas.CloudChats.DocumentBase?)covers.Clone();
                if (clonecovers is null)
                {
                    return null;
                }
                newClonedObject.Covers.Add(clonecovers);
            }
            return newClonedObject;

        }
#nullable disable
    }
}