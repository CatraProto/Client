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

namespace CatraProto.Client.MTProto
{
    public enum PeerType
    {
        Unrecognized = -1,
        User,
        Channel,
        Group,
        Secret
    }

    public readonly struct PeerId
    {
        public PeerType Type { get; }
        public long Id { get; }

        internal PeerId(long id, PeerType peerType)
        {
            Id = id;
            Type = peerType;
        }

        public long ToDatabase()
        {
            return IdTools.FromApiToTd(Id, Type);
        }

        public static PeerId AsUser(long id)
        {
            return new PeerId(id, PeerType.User);
        }

        public static PeerId AsChannel(long id)
        {
            return new PeerId(id, PeerType.Channel);
        }

        public static PeerId AsGroup(long id)
        {
            return new PeerId(id, PeerType.Group);
        }

        public static PeerId AsSecret(long id)
        {
            return new PeerId(id, PeerType.Secret);
        }

        public static PeerId FromPeer(PeerBase peer)
        {
            if (peer == null)
            {
                throw new ArgumentNullException(nameof(peer));
            }

            return peer switch
            {
                PeerChat peerChat => AsGroup(peerChat.ChatId),
                PeerChannel peerChannel => AsChannel(peerChannel.ChannelId),
                PeerUser peerUser => AsUser(peerUser.UserId),
                _ => throw new InvalidOperationException("Unreachable")
            };
        }

        public static PeerId FromDatabase(long id)
        {
            return IdTools.FromTdToApi(id);
        }

        public override string ToString()
        {
            return Type switch
            {
                PeerType.User => "user#" + Id,
                PeerType.Channel => "channel#" + Id,
                PeerType.Group => "group#" + Id,
                PeerType.Secret => "secret#" + Id,
                _ => "unknown#-1",
            };
        }

        public override bool Equals(object? obj)
        {
            if (obj is not PeerId other)
            {
                return false;
            }

            return other.Type == Type && other.Id == Id;
        }

        public static bool operator ==(PeerId left, PeerId right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PeerId left, PeerId right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine((int)Type, Id);
        }
    }
}