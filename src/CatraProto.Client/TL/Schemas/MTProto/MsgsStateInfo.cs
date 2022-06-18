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
    public partial class MsgsStateInfo : CatraProto.Client.TL.Schemas.MTProto.MsgsStateInfoBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 81704317; }

        [Newtonsoft.Json.JsonProperty("req_msg_id")]
        public sealed override long ReqMsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("info")]
        public sealed override byte[] Info { get; set; }


#nullable enable
        public MsgsStateInfo(long reqMsgId, byte[] info)
        {
            ReqMsgId = reqMsgId;
            Info = info;

        }
#nullable disable
        internal MsgsStateInfo()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(ReqMsgId);

            writer.WriteBytes(Info);

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
            var tryinfo = reader.ReadBytes();
            if (tryinfo.IsError)
            {
                return ReadResult<IObject>.Move(tryinfo);
            }
            Info = tryinfo.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "msgs_state_info";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new MsgsStateInfo
            {
                ReqMsgId = ReqMsgId,
                Info = Info
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not MsgsStateInfo castedOther)
            {
                return true;
            }
            if (ReqMsgId != castedOther.ReqMsgId)
            {
                return true;
            }
            if (Info != castedOther.Info)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}