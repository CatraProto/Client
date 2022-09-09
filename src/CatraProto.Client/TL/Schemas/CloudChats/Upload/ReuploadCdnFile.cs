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
    public partial class ReuploadCdnFile : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1691921240; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("file_token")]
        public byte[] FileToken { get; set; }

        [Newtonsoft.Json.JsonProperty("request_token")]
        public byte[] RequestToken { get; set; }


#nullable enable
        public ReuploadCdnFile(byte[] fileToken, byte[] requestToken)
        {
            FileToken = fileToken;
            RequestToken = requestToken;
        }
#nullable disable

        internal ReuploadCdnFile()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteBytes(FileToken);

            writer.WriteBytes(RequestToken);

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
            var tryrequestToken = reader.ReadBytes();
            if (tryrequestToken.IsError)
            {
                return ReadResult<IObject>.Move(tryrequestToken);
            }

            RequestToken = tryrequestToken.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "upload.reuploadCdnFile";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new ReuploadCdnFile();
            newClonedObject.FileToken = FileToken;
            newClonedObject.RequestToken = RequestToken;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not ReuploadCdnFile castedOther)
            {
                return true;
            }

            if (FileToken != castedOther.FileToken)
            {
                return true;
            }

            if (RequestToken != castedOther.RequestToken)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}