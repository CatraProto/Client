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
    public partial class BadMsgNotification : CatraProto.Client.TL.Schemas.MTProto.BadMsgNotificationBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1477445615; }

        [Newtonsoft.Json.JsonProperty("bad_msg_id")]
        public sealed override long BadMsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("bad_msg_seqno")]
        public sealed override int BadMsgSeqno { get; set; }

        [Newtonsoft.Json.JsonProperty("error_code")]
        public sealed override int ErrorCode { get; set; }


#nullable enable
        public BadMsgNotification(long badMsgId, int badMsgSeqno, int errorCode)
        {
            BadMsgId = badMsgId;
            BadMsgSeqno = badMsgSeqno;
            ErrorCode = errorCode;

        }
#nullable disable
        internal BadMsgNotification()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(BadMsgId);
            writer.WriteInt32(BadMsgSeqno);
            writer.WriteInt32(ErrorCode);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trybadMsgId = reader.ReadInt64();
            if (trybadMsgId.IsError)
            {
                return ReadResult<IObject>.Move(trybadMsgId);
            }
            BadMsgId = trybadMsgId.Value;
            var trybadMsgSeqno = reader.ReadInt32();
            if (trybadMsgSeqno.IsError)
            {
                return ReadResult<IObject>.Move(trybadMsgSeqno);
            }
            BadMsgSeqno = trybadMsgSeqno.Value;
            var tryerrorCode = reader.ReadInt32();
            if (tryerrorCode.IsError)
            {
                return ReadResult<IObject>.Move(tryerrorCode);
            }
            ErrorCode = tryerrorCode.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "bad_msg_notification";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new BadMsgNotification
            {
                BadMsgId = BadMsgId,
                BadMsgSeqno = BadMsgSeqno,
                ErrorCode = ErrorCode
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not BadMsgNotification castedOther)
            {
                return true;
            }
            if (BadMsgId != castedOther.BadMsgId)
            {
                return true;
            }
            if (BadMsgSeqno != castedOther.BadMsgSeqno)
            {
                return true;
            }
            if (ErrorCode != castedOther.ErrorCode)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}