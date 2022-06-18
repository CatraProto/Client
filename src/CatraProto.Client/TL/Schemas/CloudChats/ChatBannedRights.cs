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
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ChatBannedRights : CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase
    {
        [Flags]
        public enum FlagsEnum
        {
            ViewMessages = 1 << 0,
            SendMessages = 1 << 1,
            SendMedia = 1 << 2,
            SendStickers = 1 << 3,
            SendGifs = 1 << 4,
            SendGames = 1 << 5,
            SendInline = 1 << 6,
            EmbedLinks = 1 << 7,
            SendPolls = 1 << 8,
            ChangeInfo = 1 << 10,
            InviteUsers = 1 << 15,
            PinMessages = 1 << 17
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1626209256; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("view_messages")]
        public sealed override bool ViewMessages { get; set; }

        [Newtonsoft.Json.JsonProperty("send_messages")]
        public sealed override bool SendMessages { get; set; }

        [Newtonsoft.Json.JsonProperty("send_media")]
        public sealed override bool SendMedia { get; set; }

        [Newtonsoft.Json.JsonProperty("send_stickers")]
        public sealed override bool SendStickers { get; set; }

        [Newtonsoft.Json.JsonProperty("send_gifs")]
        public sealed override bool SendGifs { get; set; }

        [Newtonsoft.Json.JsonProperty("send_games")]
        public sealed override bool SendGames { get; set; }

        [Newtonsoft.Json.JsonProperty("send_inline")]
        public sealed override bool SendInline { get; set; }

        [Newtonsoft.Json.JsonProperty("embed_links")]
        public sealed override bool EmbedLinks { get; set; }

        [Newtonsoft.Json.JsonProperty("send_polls")]
        public sealed override bool SendPolls { get; set; }

        [Newtonsoft.Json.JsonProperty("change_info")]
        public sealed override bool ChangeInfo { get; set; }

        [Newtonsoft.Json.JsonProperty("invite_users")]
        public sealed override bool InviteUsers { get; set; }

        [Newtonsoft.Json.JsonProperty("pin_messages")]
        public sealed override bool PinMessages { get; set; }

        [Newtonsoft.Json.JsonProperty("until_date")]
        public sealed override int UntilDate { get; set; }


#nullable enable
        public ChatBannedRights(int untilDate)
        {
            UntilDate = untilDate;

        }
#nullable disable
        internal ChatBannedRights()
        {
        }

        public override void UpdateFlags()
        {
            Flags = ViewMessages ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = SendMessages ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = SendMedia ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
            Flags = SendStickers ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
            Flags = SendGifs ? FlagsHelper.SetFlag(Flags, 4) : FlagsHelper.UnsetFlag(Flags, 4);
            Flags = SendGames ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
            Flags = SendInline ? FlagsHelper.SetFlag(Flags, 6) : FlagsHelper.UnsetFlag(Flags, 6);
            Flags = EmbedLinks ? FlagsHelper.SetFlag(Flags, 7) : FlagsHelper.UnsetFlag(Flags, 7);
            Flags = SendPolls ? FlagsHelper.SetFlag(Flags, 8) : FlagsHelper.UnsetFlag(Flags, 8);
            Flags = ChangeInfo ? FlagsHelper.SetFlag(Flags, 10) : FlagsHelper.UnsetFlag(Flags, 10);
            Flags = InviteUsers ? FlagsHelper.SetFlag(Flags, 15) : FlagsHelper.UnsetFlag(Flags, 15);
            Flags = PinMessages ? FlagsHelper.SetFlag(Flags, 17) : FlagsHelper.UnsetFlag(Flags, 17);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt32(UntilDate);

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
            ViewMessages = FlagsHelper.IsFlagSet(Flags, 0);
            SendMessages = FlagsHelper.IsFlagSet(Flags, 1);
            SendMedia = FlagsHelper.IsFlagSet(Flags, 2);
            SendStickers = FlagsHelper.IsFlagSet(Flags, 3);
            SendGifs = FlagsHelper.IsFlagSet(Flags, 4);
            SendGames = FlagsHelper.IsFlagSet(Flags, 5);
            SendInline = FlagsHelper.IsFlagSet(Flags, 6);
            EmbedLinks = FlagsHelper.IsFlagSet(Flags, 7);
            SendPolls = FlagsHelper.IsFlagSet(Flags, 8);
            ChangeInfo = FlagsHelper.IsFlagSet(Flags, 10);
            InviteUsers = FlagsHelper.IsFlagSet(Flags, 15);
            PinMessages = FlagsHelper.IsFlagSet(Flags, 17);
            var tryuntilDate = reader.ReadInt32();
            if (tryuntilDate.IsError)
            {
                return ReadResult<IObject>.Move(tryuntilDate);
            }
            UntilDate = tryuntilDate.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "chatBannedRights";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ChatBannedRights
            {
                Flags = Flags,
                ViewMessages = ViewMessages,
                SendMessages = SendMessages,
                SendMedia = SendMedia,
                SendStickers = SendStickers,
                SendGifs = SendGifs,
                SendGames = SendGames,
                SendInline = SendInline,
                EmbedLinks = EmbedLinks,
                SendPolls = SendPolls,
                ChangeInfo = ChangeInfo,
                InviteUsers = InviteUsers,
                PinMessages = PinMessages,
                UntilDate = UntilDate
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not ChatBannedRights castedOther)
            {
                return true;
            }
            if (Flags != castedOther.Flags)
            {
                return true;
            }
            if (ViewMessages != castedOther.ViewMessages)
            {
                return true;
            }
            if (SendMessages != castedOther.SendMessages)
            {
                return true;
            }
            if (SendMedia != castedOther.SendMedia)
            {
                return true;
            }
            if (SendStickers != castedOther.SendStickers)
            {
                return true;
            }
            if (SendGifs != castedOther.SendGifs)
            {
                return true;
            }
            if (SendGames != castedOther.SendGames)
            {
                return true;
            }
            if (SendInline != castedOther.SendInline)
            {
                return true;
            }
            if (EmbedLinks != castedOther.EmbedLinks)
            {
                return true;
            }
            if (SendPolls != castedOther.SendPolls)
            {
                return true;
            }
            if (ChangeInfo != castedOther.ChangeInfo)
            {
                return true;
            }
            if (InviteUsers != castedOther.InviteUsers)
            {
                return true;
            }
            if (PinMessages != castedOther.PinMessages)
            {
                return true;
            }
            if (UntilDate != castedOther.UntilDate)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}