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
    public partial class StickerPack : CatraProto.Client.TL.Schemas.CloudChats.StickerPackBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 313694676; }

        [Newtonsoft.Json.JsonProperty("emoticon")]
        public sealed override string Emoticon { get; set; }

        [Newtonsoft.Json.JsonProperty("documents")]
        public sealed override List<long> Documents { get; set; }


#nullable enable
        public StickerPack(string emoticon, List<long> documents)
        {
            Emoticon = emoticon;
            Documents = documents;

        }
#nullable disable
        internal StickerPack()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Emoticon);

            writer.WriteVector(Documents, false);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryemoticon = reader.ReadString();
            if (tryemoticon.IsError)
            {
                return ReadResult<IObject>.Move(tryemoticon);
            }
            Emoticon = tryemoticon.Value;
            var trydocuments = reader.ReadVector<long>(ParserTypes.Int64);
            if (trydocuments.IsError)
            {
                return ReadResult<IObject>.Move(trydocuments);
            }
            Documents = trydocuments.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "stickerPack";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new StickerPack
            {
                Emoticon = Emoticon,
                Documents = new List<long>()
            };
            foreach (var documents in Documents)
            {
                newClonedObject.Documents.Add(documents);
            }
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not StickerPack castedOther)
            {
                return true;
            }
            if (Emoticon != castedOther.Emoticon)
            {
                return true;
            }
            var documentssize = castedOther.Documents.Count;
            if (documentssize != Documents.Count)
            {
                return true;
            }
            for (var i = 0; i < documentssize; i++)
            {
                if (castedOther.Documents[i] != Documents[i])
                {
                    return true;
                }
            }
            return false;

        }

#nullable disable
    }
}