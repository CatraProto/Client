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

using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
    public partial class BlockFromReplies : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            DeleteMessage = 1 << 0,
            DeleteHistory = 1 << 1,
            ReportSpam = 1 << 2
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 698914348; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("delete_message")]
        public bool DeleteMessage { get; set; }

        [Newtonsoft.Json.JsonProperty("delete_history")]
        public bool DeleteHistory { get; set; }

        [Newtonsoft.Json.JsonProperty("report_spam")]
        public bool ReportSpam { get; set; }

        [Newtonsoft.Json.JsonProperty("msg_id")]
        public int MsgId { get; set; }


#nullable enable
        public BlockFromReplies(int msgId)
        {
            MsgId = msgId;

        }
#nullable disable

        internal BlockFromReplies()
        {
        }

        public void UpdateFlags()
        {
            Flags = DeleteMessage ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = DeleteHistory ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = ReportSpam ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt32(MsgId);

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }
            Flags = tryflags.Value;
            DeleteMessage = FlagsHelper.IsFlagSet(Flags, 0);
            DeleteHistory = FlagsHelper.IsFlagSet(Flags, 1);
            ReportSpam = FlagsHelper.IsFlagSet(Flags, 2);
            var trymsgId = reader.ReadInt32();
            if (trymsgId.IsError)
            {
                return ReadResult<IObject>.Move(trymsgId);
            }
            MsgId = trymsgId.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "contacts.blockFromReplies";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new BlockFromReplies
            {
                Flags = Flags,
                DeleteMessage = DeleteMessage,
                DeleteHistory = DeleteHistory,
                ReportSpam = ReportSpam,
                MsgId = MsgId
            };
            return newClonedObject;

        }

        public bool Compare(IObject other)
        {
            if (other is not BlockFromReplies castedOther)
            {
                return true;
            }
            if (Flags != castedOther.Flags)
            {
                return true;
            }
            if (DeleteMessage != castedOther.DeleteMessage)
            {
                return true;
            }
            if (DeleteHistory != castedOther.DeleteHistory)
            {
                return true;
            }
            if (ReportSpam != castedOther.ReportSpam)
            {
                return true;
            }
            if (MsgId != castedOther.MsgId)
            {
                return true;
            }
            return false;

        }
#nullable disable
    }
}