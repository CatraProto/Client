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
    public partial class GetCdnFile : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 962554330; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("file_token")]
        public byte[] FileToken { get; set; }

        [Newtonsoft.Json.JsonProperty("offset")]
        public long Offset { get; set; }

        [Newtonsoft.Json.JsonProperty("limit")]
        public int Limit { get; set; }


#nullable enable
        public GetCdnFile(byte[] fileToken, long offset, int limit)
        {
            FileToken = fileToken;
            Offset = offset;
            Limit = limit;
        }
#nullable disable

        internal GetCdnFile()
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
            writer.WriteInt32(Limit);

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
            var trylimit = reader.ReadInt32();
            if (trylimit.IsError)
            {
                return ReadResult<IObject>.Move(trylimit);
            }

            Limit = trylimit.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "upload.getCdnFile";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetCdnFile();
            newClonedObject.FileToken = FileToken;
            newClonedObject.Offset = Offset;
            newClonedObject.Limit = Limit;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not GetCdnFile castedOther)
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

            if (Limit != castedOther.Limit)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}