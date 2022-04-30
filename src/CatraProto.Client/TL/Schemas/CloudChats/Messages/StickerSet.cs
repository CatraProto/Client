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
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class StickerSet : CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1240849242; }

        [Newtonsoft.Json.JsonProperty("set")]
        public CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase Set { get; set; }

        [Newtonsoft.Json.JsonProperty("packs")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.StickerPackBase> Packs { get; set; }

        [Newtonsoft.Json.JsonProperty("documents")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> Documents { get; set; }


#nullable enable
        public StickerSet(CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase set, List<CatraProto.Client.TL.Schemas.CloudChats.StickerPackBase> packs, List<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> documents)
        {
            Set = set;
            Packs = packs;
            Documents = documents;

        }
#nullable disable
        internal StickerSet()
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
            var checkpacks = writer.WriteVector(Packs, false);
            if (checkpacks.IsError)
            {
                return checkpacks;
            }
            var checkdocuments = writer.WriteVector(Documents, false);
            if (checkdocuments.IsError)
            {
                return checkdocuments;
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
            var trypacks = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.StickerPackBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trypacks.IsError)
            {
                return ReadResult<IObject>.Move(trypacks);
            }
            Packs = trypacks.Value;
            var trydocuments = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trydocuments.IsError)
            {
                return ReadResult<IObject>.Move(trydocuments);
            }
            Documents = trydocuments.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messages.stickerSet";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new StickerSet();
            var cloneSet = (CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase?)Set.Clone();
            if (cloneSet is null)
            {
                return null;
            }
            newClonedObject.Set = cloneSet;
            foreach (var packs in Packs)
            {
                var clonepacks = (CatraProto.Client.TL.Schemas.CloudChats.StickerPackBase?)packs.Clone();
                if (clonepacks is null)
                {
                    return null;
                }
                newClonedObject.Packs.Add(clonepacks);
            }
            foreach (var documents in Documents)
            {
                var clonedocuments = (CatraProto.Client.TL.Schemas.CloudChats.DocumentBase?)documents.Clone();
                if (clonedocuments is null)
                {
                    return null;
                }
                newClonedObject.Documents.Add(clonedocuments);
            }
            return newClonedObject;

        }
#nullable disable
    }
}