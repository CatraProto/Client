using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public partial class RpcError : CatraProto.Client.TL.Schemas.MTProto.RpcErrorBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 558156313; }

        [Newtonsoft.Json.JsonProperty("error_code")]
        public sealed override int ErrorCode { get; set; }

        [Newtonsoft.Json.JsonProperty("error_message")]
        public sealed override string ErrorMessage { get; set; }


#nullable enable
        public RpcError(int errorCode, string errorMessage)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }
#nullable disable
        internal RpcError()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(ErrorCode);

            writer.WriteString(ErrorMessage);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryerrorCode = reader.ReadInt32();
            if (tryerrorCode.IsError)
            {
                return ReadResult<IObject>.Move(tryerrorCode);
            }

            ErrorCode = tryerrorCode.Value;
            var tryerrorMessage = reader.ReadString();
            if (tryerrorMessage.IsError)
            {
                return ReadResult<IObject>.Move(tryerrorMessage);
            }

            ErrorMessage = tryerrorMessage.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "rpc_error";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new RpcError();
            newClonedObject.ErrorCode = ErrorCode;
            newClonedObject.ErrorMessage = ErrorMessage;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not RpcError castedOther)
            {
                return true;
            }

            if (ErrorCode != castedOther.ErrorCode)
            {
                return true;
            }

            if (ErrorMessage != castedOther.ErrorMessage)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}