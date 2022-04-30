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
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public partial class RpcError : CatraProto.Client.TL.Schemas.MTProto.RpcErrorBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 558156313; }

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
            var newClonedObject = new RpcError
            {
                ErrorCode = ErrorCode,
                ErrorMessage = ErrorMessage
            };
            return newClonedObject;

        }
#nullable disable
    }
}