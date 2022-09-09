using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Upload
{
    public partial class GetCdnFileHashes : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1847836879; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("file_token")]
        public byte[] FileToken { get; set; }

        [Newtonsoft.Json.JsonProperty("offset")]
        public long Offset { get; set; }


#nullable enable
        public GetCdnFileHashes(byte[] fileToken, long offset)
        {
            FileToken = fileToken;
            Offset = offset;
        }
#nullable disable

        internal GetCdnFileHashes()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteBytes(FileToken);
            writer.WriteInt64(Offset);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryfileToken = reader.ReadBytes();
            if (tryfileToken.IsError)
            {
                return ReadResult<IObject>.Move(tryfileToken);
            }

            FileToken = tryfileToken.Value;
            var tryoffset = reader.ReadInt64();
            if (tryoffset.IsError)
            {
                return ReadResult<IObject>.Move(tryoffset);
            }

            Offset = tryoffset.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "upload.getCdnFileHashes";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetCdnFileHashes();
            newClonedObject.FileToken = FileToken;
            newClonedObject.Offset = Offset;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not GetCdnFileHashes castedOther)
            {
                return true;
            }

            if (FileToken != castedOther.FileToken)
            {
                return true;
            }

            if (Offset != castedOther.Offset)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}