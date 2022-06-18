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

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class DiscardEncryption : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            DeleteHistory = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -208425312; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("delete_history")]
        public bool DeleteHistory { get; set; }

        [Newtonsoft.Json.JsonProperty("chat_id")]
        public int ChatId { get; set; }


#nullable enable
        public DiscardEncryption(int chatId)
        {
            ChatId = chatId;

        }
#nullable disable

        internal DiscardEncryption()
        {
        }

        public void UpdateFlags()
        {
            Flags = DeleteHistory ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt32(ChatId);

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
            DeleteHistory = FlagsHelper.IsFlagSet(Flags, 0);
            var trychatId = reader.ReadInt32();
            if (trychatId.IsError)
            {
                return ReadResult<IObject>.Move(trychatId);
            }
            ChatId = trychatId.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messages.discardEncryption";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new DiscardEncryption
            {
                Flags = Flags,
                DeleteHistory = DeleteHistory,
                ChatId = ChatId
            };
            return newClonedObject;

        }

        public bool Compare(IObject other)
        {
            if (other is not DiscardEncryption castedOther)
            {
                return true;
            }
            if (Flags != castedOther.Flags)
            {
                return true;
            }
            if (DeleteHistory != castedOther.DeleteHistory)
            {
                return true;
            }
            if (ChatId != castedOther.ChatId)
            {
                return true;
            }
            return false;

        }
#nullable disable
    }
}