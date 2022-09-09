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
    public partial class CdnFileReuploadNeeded : CatraProto.Client.TL.Schemas.CloudChats.Upload.CdnFileBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -290921362; }

        [Newtonsoft.Json.JsonProperty("request_token")]
        public byte[] RequestToken { get; set; }


#nullable enable
        public CdnFileReuploadNeeded(byte[] requestToken)
        {
            RequestToken = requestToken;
        }
#nullable disable
        internal CdnFileReuploadNeeded()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteBytes(RequestToken);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
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
            return "upload.cdnFileReuploadNeeded";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new CdnFileReuploadNeeded();
            newClonedObject.RequestToken = RequestToken;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not CdnFileReuploadNeeded castedOther)
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