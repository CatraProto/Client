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
    public partial class WebDocumentNoProxy : CatraProto.Client.TL.Schemas.CloudChats.WebDocumentBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -104284986; }

        [Newtonsoft.Json.JsonProperty("url")]
        public sealed override string Url { get; set; }

        [Newtonsoft.Json.JsonProperty("size")]
        public sealed override int Size { get; set; }

        [Newtonsoft.Json.JsonProperty("mime_type")]
        public sealed override string MimeType { get; set; }

        [Newtonsoft.Json.JsonProperty("attributes")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeBase> Attributes { get; set; }


#nullable enable
        public WebDocumentNoProxy(string url, int size, string mimeType, List<CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeBase> attributes)
        {
            Url = url;
            Size = size;
            MimeType = mimeType;
            Attributes = attributes;

        }
#nullable disable
        internal WebDocumentNoProxy()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Url);
            writer.WriteInt32(Size);

            writer.WriteString(MimeType);
            var checkattributes = writer.WriteVector(Attributes, false);
            if (checkattributes.IsError)
            {
                return checkattributes;
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
            var trysize = reader.ReadInt32();
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
            var tryattributes = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryattributes.IsError)
            {
                return ReadResult<IObject>.Move(tryattributes);
            }
            Attributes = tryattributes.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "webDocumentNoProxy";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new WebDocumentNoProxy
            {
                Url = Url,
                Size = Size,
                MimeType = MimeType,
                Attributes = new List<CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeBase>()
            };
            foreach (var attributes in Attributes)
            {
                var cloneattributes = (CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeBase?)attributes.Clone();
                if (cloneattributes is null)
                {
                    return null;
                }
                newClonedObject.Attributes.Add(cloneattributes);
            }
            return newClonedObject;

        }
#nullable disable
    }
}