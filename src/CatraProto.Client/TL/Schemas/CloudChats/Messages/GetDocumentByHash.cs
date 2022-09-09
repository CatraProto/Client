using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class GetDocumentByHash : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1309538785; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("sha256")]
        public byte[] Sha256 { get; set; }

        [Newtonsoft.Json.JsonProperty("size")] public long Size { get; set; }

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
            var newClonedObject = new GetDocumentByHash();
            newClonedObject.Sha256 = Sha256;
            newClonedObject.Size = Size;
            newClonedObject.MimeType = MimeType;
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