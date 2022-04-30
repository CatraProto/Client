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
using CatraProto.Client.TL.Schemas.CloudChats.Messages;
using CatraProto.TL.Interfaces;

namespace CatraProto.Client.Tools
{
    public static class PeerTools
    {
        public static PeerBase ExtractPeerFromMethod(IMethod method)
        {
            switch (method)
            {
                case SendMessage sendMessage:
                    return FromInputToPeer(sendMessage.Peer)!;
                default:
                    throw new InvalidOperationException($"Type {method} is not supported");
            }
        }

        public static PeerBase? FromInputToPeer(InputPeerBase peerBase)
        {
            switch (peerBase)
            {
                case InputPeerUserFromMessage inputPeerUserFromMessage:
                    return new PeerUser() { UserId = inputPeerUserFromMessage.UserId };
                case InputPeerChannelFromMessage inputPeerChannelFromMessage:
                    return new PeerChannel() { ChannelId = inputPeerChannelFromMessage.ChannelId };
                case InputPeerChannel inputPeerChannel:
                    return new PeerChannel() { ChannelId = inputPeerChannel.ChannelId };
                case InputPeerChat inputPeerChat:
                    return new PeerChat() { ChatId = inputPeerChat.ChatId };
                case InputPeerUser inputPeerUser:
                    return new PeerUser() { UserId = inputPeerUser.UserId };
                default:
                    return null;
            }
        }
    }
}