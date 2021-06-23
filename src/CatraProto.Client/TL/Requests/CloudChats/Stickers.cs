using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections;
using CatraProto.Client.MTProto.Messages;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Stickers;
using StickerSetBase = CatraProto.Client.TL.Schemas.CloudChats.Messages.StickerSetBase;

namespace CatraProto.Client.TL.Requests.CloudChats
{
    public class Stickers
    {
        private MessagesHandler _messagesHandler;

        internal Stickers(MessagesHandler messagesHandler)
        {
            _messagesHandler = messagesHandler;
        }

        public async Task<RpcMessage<StickerSetBase>> CreateStickerSetAsync(InputUserBase userId, string title,
            string shortName, List<InputStickerSetItemBase> stickers, bool masks = true, bool animated = true,
            InputDocumentBase thumb = null, CancellationToken cancellationToken = default)
        {
            if (userId is null)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            if (title is null)
            {
                throw new ArgumentNullException(nameof(title));
            }

            if (shortName is null)
            {
                throw new ArgumentNullException(nameof(shortName));
            }

            if (stickers is null)
            {
                throw new ArgumentNullException(nameof(stickers));
            }

            var rpcResponse = new RpcMessage<StickerSetBase>();
            var methodBody = new CreateStickerSet
            {
                UserId = userId,
                Title = title,
                ShortName = shortName,
                Stickers = stickers,
                Masks = masks,
                Animated = animated,
                Thumb = thumb
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<StickerSetBase>> RemoveStickerFromSetAsync(InputDocumentBase sticker,
            CancellationToken cancellationToken = default)
        {
            if (sticker is null)
            {
                throw new ArgumentNullException(nameof(sticker));
            }

            var rpcResponse = new RpcMessage<StickerSetBase>();
            var methodBody = new RemoveStickerFromSet
            {
                Sticker = sticker
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<StickerSetBase>> ChangeStickerPositionAsync(InputDocumentBase sticker,
            int position, CancellationToken cancellationToken = default)
        {
            if (sticker is null)
            {
                throw new ArgumentNullException(nameof(sticker));
            }

            var rpcResponse = new RpcMessage<StickerSetBase>();
            var methodBody = new ChangeStickerPosition
            {
                Sticker = sticker,
                Position = position
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<StickerSetBase>> AddStickerToSetAsync(InputStickerSetBase stickerset,
            InputStickerSetItemBase sticker, CancellationToken cancellationToken = default)
        {
            if (stickerset is null)
            {
                throw new ArgumentNullException(nameof(stickerset));
            }

            if (sticker is null)
            {
                throw new ArgumentNullException(nameof(sticker));
            }

            var rpcResponse = new RpcMessage<StickerSetBase>();
            var methodBody = new AddStickerToSet
            {
                Stickerset = stickerset,
                Sticker = sticker
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<StickerSetBase>> SetStickerSetThumbAsync(InputStickerSetBase stickerset,
            InputDocumentBase thumb, CancellationToken cancellationToken = default)
        {
            if (stickerset is null)
            {
                throw new ArgumentNullException(nameof(stickerset));
            }

            if (thumb is null)
            {
                throw new ArgumentNullException(nameof(thumb));
            }

            var rpcResponse = new RpcMessage<StickerSetBase>();
            var methodBody = new SetStickerSetThumb
            {
                Stickerset = stickerset,
                Thumb = thumb
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }
    }
}