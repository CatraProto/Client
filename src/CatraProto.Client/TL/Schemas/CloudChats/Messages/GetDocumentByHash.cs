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

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class GetDocumentByHash : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1309538785; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("sha256")]
        public byte[] Sha256 { get; set; }

        [Newtonsoft.Json.JsonProperty("size")]
        public long Size { get; set; }

        [Newtonsoft.Json.JsonProperty("mime_type")]
        public string MimeType { get; set; }


#nullable enable
        public GetDocumentByHash(byte[] sha256, long size, string mimeType)
        {
            Sha256 = sha256;
            Size = size;
            MimeType = mimeType;

        }
#nullable disable

        internal GetDocumentByHash()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteBytes(Sha256);
            writer.WriteInt64(Size);

            writer.WriteString(MimeType);

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trysha256 = reader.ReadBytes();
            if (trysha256.IsError)
            {
                return ReadResult<IObject>.Move(trysha256);
            }
            Sha256 = trysha256.Value;
            var trysize = reader.ReadInt64();
            if (trysize.IsError)
            {
                return ReadResult<IObject>.Move(trysize);
            }
            Size = trysize.Value;
            var trymimeType = reader.ReadString();
            if (trymimeType.IsError)
            {
                return ReadResult<IObject>.Move(trymimeType);
            }
            MimeType = trymimeType.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messages.getDocumentByHash";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetDocumentByHash
            {
                Sha256 = Sha256,
                Size = Size,
                MimeType = MimeType
            };
            return newClonedObject;

        }

        public bool Compare(IObject other)
        {
            if (other is not GetDocumentByHash castedOther)
            {
                return true;
            }
            if (Sha256 != castedOther.Sha256)
            {
                return true;
            }
            if (Size != castedOther.Size)
            {
                return true;
            }
            if (MimeType != castedOther.MimeType)
            {
                return true;
            }
            return false;

        }
#nullable disable
    }
}