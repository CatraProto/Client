using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatraProto.Client.MTProto
{
    public class IdTools
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

                if (ZeroSecretChatId - int.MinValue <= id && id != ZeroSecretChatId)
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
    }
}
