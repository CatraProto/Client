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
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ChatParticipantsForbidden : CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantsBase
    {
        [Flags]
        public enum FlagsEnum
        {
            SelfParticipant = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -2023500831; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("chat_id")]
        public sealed override long ChatId { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("self_participant")]
        public CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantBase SelfParticipant { get; set; }


#nullable enable
        public ChatParticipantsForbidden(long chatId)
        {
            ChatId = chatId;

        }
#nullable disable
        internal ChatParticipantsForbidden()
        {
        }

        public override void UpdateFlags()
        {
            Flags = SelfParticipant == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt64(ChatId);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var checkselfParticipant = writer.WriteObject(SelfParticipant);
                if (checkselfParticipant.IsError)
                {
                    return checkselfParticipant;
                }
            }


            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }
            Flags = tryflags.Value;
            var trychatId = reader.ReadInt64();
            if (trychatId.IsError)
            {
                return ReadResult<IObject>.Move(trychatId);
            }
            ChatId = trychatId.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryselfParticipant = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantBase>();
                if (tryselfParticipant.IsError)
                {
                    return ReadResult<IObject>.Move(tryselfParticipant);
                }
                SelfParticipant = tryselfParticipant.Value;
            }

            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "chatParticipantsForbidden";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ChatParticipantsForbidden
            {
                Flags = Flags,
                ChatId = ChatId
            };
            if (SelfParticipant is not null)
            {
                var cloneSelfParticipant = (CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantBase?)SelfParticipant.Clone();
                if (cloneSelfParticipant is null)
                {
                    return null;
                }
                newClonedObject.SelfParticipant = cloneSelfParticipant;
            }
            return newClonedObject;

        }
#nullable disable
    }
}