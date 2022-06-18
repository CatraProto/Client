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
    public partial class TextImage : CatraProto.Client.TL.Schemas.CloudChats.RichTextBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 136105807; }

        [Newtonsoft.Json.JsonProperty("document_id")]
        public long DocumentId { get; set; }

        [Newtonsoft.Json.JsonProperty("w")]
        public int W { get; set; }

        [Newtonsoft.Json.JsonProperty("h")]
        public int H { get; set; }


#nullable enable
        public TextImage(long documentId, int w, int h)
        {
            DocumentId = documentId;
            W = w;
            H = h;

        }
#nullable disable
        internal TextImage()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(DocumentId);
            writer.WriteInt32(W);
            writer.WriteInt32(H);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trydocumentId = reader.ReadInt64();
            if (trydocumentId.IsError)
            {
                return ReadResult<IObject>.Move(trydocumentId);
            }
            DocumentId = trydocumentId.Value;
            var tryw = reader.ReadInt32();
            if (tryw.IsError)
            {
                return ReadResult<IObject>.Move(tryw);
            }
            W = tryw.Value;
            var tryh = reader.ReadInt32();
            if (tryh.IsError)
            {
                return ReadResult<IObject>.Move(tryh);
            }
            H = tryh.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "textImage";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new TextImage
            {
                DocumentId = DocumentId,
                W = W,
                H = H
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not TextImage castedOther)
            {
                return true;
            }
            if (DocumentId != castedOther.DocumentId)
            {
                return true;
            }
            if (W != castedOther.W)
            {
                return true;
            }
            if (H != castedOther.H)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}