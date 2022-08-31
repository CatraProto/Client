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
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.MTProto
{
    internal class IdTools
    {
        private const long MaxChatId = 999999999999;
        private const long MaxChannelId = 997852516352;
        private const long MaxUserId = 1099511627775;
        private const long ZeroSecretChatId = -2000000000000;
        private const long ZeroChannelId = -1000000000000;

        public static long FromApiToTd(long id, PeerType type)
        {
            //https://github.com/tdlib/td/blob/master/td/telegram/DialogId.cpp
            switch (type)
            {
                case PeerType.User:
                    return id;
                case PeerType.Channel:
                    return ZeroChannelId - id;
                case PeerType.Group:
                    return -id;
                case PeerType.Secret:
                    return ZeroSecretChatId + id;
                default:
                    //unreachable
                    return -1;
            }
        }

        public static long FromApiToTd(PeerId peerId)
        {
            return FromApiToTd(peerId.Id, peerId.Type);
        }

        public static PeerId FromTdToApi(long id)
        {
            if (id < 0)
            {
                if (-MaxChatId <= id)
                {
                    return PeerId.AsGroup(-id);
                }

                if (ZeroChannelId - MaxChannelId <= id && id != ZeroChannelId)
                {
                    return PeerId.AsChannel(ZeroChannelId - id);
                }

                if (ZeroSecretChatId + int.MinValue <= id && id != ZeroSecretChatId)
                {
                    return PeerId.AsSecret(id - ZeroSecretChatId);
                }
            }
            else if (id > 0 && MaxUserId >= id)
            {
                return PeerId.AsUser(id);
            }

            return new PeerId(-1, PeerType.Unrecognized);
        }

        public static PeerId GetPeerFromObject(IObject obj)
        {
            switch (obj)
            {
                case Chat:
                case ChatForbidden:
                case ChatEmpty:
                    return PeerId.AsGroup(((ChatBase)obj).Id);
                case Channel:
                case ChannelForbidden:
                    return PeerId.AsChannel(((ChatBase)obj).Id);
                case UserBase user:
                    return PeerId.AsUser(user.Id);
                case UserFull fullUser:
                    return PeerId.AsUser(fullUser.Id);
                case ChatFull chatFull:
                    return PeerId.AsGroup(chatFull.Id);
                case ChannelFull channelFull:
                    return PeerId.AsChannel(channelFull.Id);
                default:
                    return new PeerId(-1, PeerType.Unrecognized);
            }
        }
    }
}
