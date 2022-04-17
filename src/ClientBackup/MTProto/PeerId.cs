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
            return peer switch
            {
                PeerChat peerChat => AsGroup(peerChat.ChatId),
                PeerChannel peerChannel => AsChannel(peerChannel.ChannelId),
                PeerUser peerUser => AsUser(peerUser.UserId),
                _ => throw new InvalidOperationException("Unreachable")
            };
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


        public override int GetHashCode()
        {
            return HashCode.Combine((int)Type, Id);
        }

        public static bool operator ==(PeerId left, PeerId right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PeerId left, PeerId right)
        {
            return !(left == right);
        }
    }
}