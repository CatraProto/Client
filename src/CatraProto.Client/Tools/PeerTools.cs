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