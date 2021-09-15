using System;
using CatraProto.Client.TL.Schemas.CloudChats;

namespace CatraProto.Client.MTProto
{
    public static class Extensions
    {
        public static int ExtractPeerId(this PeerBase peer)
        {
            return peer switch
            {
                PeerChannel peerChannel => peerChannel.ChannelId,
                PeerUser peerUser => peerUser.UserId,
                PeerChat peerChat => peerChat.ChatId,
                _ => throw new InvalidOperationException("Invalid peer type")
            };
        }
    }
}