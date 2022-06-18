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
    public partial class RpcResult : CatraProto.Client.TL.Schemas.MTProto.RpcResultBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -212046591; }

        [Newtonsoft.Json.JsonProperty("req_msg_id")]
        public sealed override long ReqMsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("result")]
        public sealed override object Result { get; set; }


#nullable enable
        public RpcResult(long reqMsgId, object result)
        {
            ReqMsgId = reqMsgId;
            Result = result;

        }
#nullable disable
        internal RpcResult()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(ReqMsgId);
            var checkresult = writer.Write(Result);
            if (checkresult.IsError)
            {
                return checkresult;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryreqMsgId = reader.ReadInt64();
            if (tryreqMsgId.IsError)
            {
                return ReadResult<IObject>.Move(tryreqMsgId);
            }
            ReqMsgId = tryreqMsgId.Value;
            var tryresult = reader.ReadObject();
            if (tryresult.IsError)
            {
                return ReadResult<IObject>.Move(tryresult);
            }
            Result = tryresult.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "rpc_result";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new RpcResult
            {
                ReqMsgId = ReqMsgId,
                Result = Result
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not RpcResult castedOther)
            {
                return true;
            }
            if (ReqMsgId != castedOther.ReqMsgId)
            {
                return true;
            }
            if (Result != castedOther.Result)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}