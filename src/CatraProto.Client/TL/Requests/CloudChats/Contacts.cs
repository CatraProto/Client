using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections;
using CatraProto.Client.MTProto.Messages;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Contacts;

namespace CatraProto.Client.TL.Requests.CloudChats
{
    public class Contacts
    {
        private MessagesHandler _messagesHandler;

        internal Contacts(MessagesHandler messagesHandler)
        {
            _messagesHandler = messagesHandler;
        }

        public async Task<RpcMessage<int>> GetContactIDsAsync(int hash, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<int>();
            var methodBody = new GetContactIDs
            {
                Hash = hash
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<ContactStatusBase>> GetStatusesAsync(CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<ContactStatusBase>();
            var methodBody = new GetStatuses();

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<ContactsBase>> GetContactsAsync(int hash,
            CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<ContactsBase>();
            var methodBody = new GetContacts
            {
                Hash = hash
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<ImportedContactsBase>> ImportContactsAsync(List<InputContactBase> contacts,
            CancellationToken cancellationToken = default)
        {
            if (contacts is null)
            {
                throw new ArgumentNullException(nameof(contacts));
            }

            var rpcResponse = new RpcMessage<ImportedContactsBase>();
            var methodBody = new ImportContacts
            {
                Contacts = contacts
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<UpdatesBase>> DeleteContactsAsync(List<InputUserBase> id,
            CancellationToken cancellationToken = default)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var rpcResponse = new RpcMessage<UpdatesBase>();
            var methodBody = new DeleteContacts
            {
                Id = id
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> DeleteByPhonesAsync(List<string> phones,
            CancellationToken cancellationToken = default)
        {
            if (phones is null)
            {
                throw new ArgumentNullException(nameof(phones));
            }

            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new DeleteByPhones
            {
                Phones = phones
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> BlockAsync(InputPeerBase id, CancellationToken cancellationToken = default)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new Block
            {
                Id = id
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> UnblockAsync(InputPeerBase id,
            CancellationToken cancellationToken = default)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new Unblock
            {
                Id = id
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<BlockedBase>> GetBlockedAsync(int offset, int limit,
            CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<BlockedBase>();
            var methodBody = new GetBlocked
            {
                Offset = offset,
                Limit = limit
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<FoundBase>> SearchAsync(string q, int limit,
            CancellationToken cancellationToken = default)
        {
            if (q is null)
            {
                throw new ArgumentNullException(nameof(q));
            }

            var rpcResponse = new RpcMessage<FoundBase>();
            var methodBody = new Search
            {
                Q = q,
                Limit = limit
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<ResolvedPeerBase>> ResolveUsernameAsync(string username,
            CancellationToken cancellationToken = default)
        {
            if (username is null)
            {
                throw new ArgumentNullException(nameof(username));
            }

            var rpcResponse = new RpcMessage<ResolvedPeerBase>();
            var methodBody = new ResolveUsername
            {
                Username = username
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<TopPeersBase>> GetTopPeersAsync(int offset, int limit, int hash,
            bool correspondents = true, bool botsPm = true, bool botsInline = true, bool phoneCalls = true,
            bool forwardUsers = true, bool forwardChats = true, bool groups = true, bool channels = true,
            CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<TopPeersBase>();
            var methodBody = new GetTopPeers
            {
                Offset = offset,
                Limit = limit,
                Hash = hash,
                Correspondents = correspondents,
                BotsPm = botsPm,
                BotsInline = botsInline,
                PhoneCalls = phoneCalls,
                ForwardUsers = forwardUsers,
                ForwardChats = forwardChats,
                Groups = groups,
                Channels = channels
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> ResetTopPeerRatingAsync(TopPeerCategoryBase category, InputPeerBase peer,
            CancellationToken cancellationToken = default)
        {
            if (category is null)
            {
                throw new ArgumentNullException(nameof(category));
            }

            if (peer is null)
            {
                throw new ArgumentNullException(nameof(peer));
            }

            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new ResetTopPeerRating
            {
                Category = category,
                Peer = peer
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> ResetSavedAsync(CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new ResetSaved();

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<SavedContactBase>> GetSavedAsync(CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<SavedContactBase>();
            var methodBody = new GetSaved();

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> ToggleTopPeersAsync(bool enabled,
            CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new ToggleTopPeers
            {
                Enabled = enabled
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<UpdatesBase>> AddContactAsync(InputUserBase id, string firstName, string lastName,
            string phone, bool addPhonePrivacyException = true, CancellationToken cancellationToken = default)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            if (firstName is null)
            {
                throw new ArgumentNullException(nameof(firstName));
            }

            if (lastName is null)
            {
                throw new ArgumentNullException(nameof(lastName));
            }

            if (phone is null)
            {
                throw new ArgumentNullException(nameof(phone));
            }

            var rpcResponse = new RpcMessage<UpdatesBase>();
            var methodBody = new AddContact
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                Phone = phone,
                AddPhonePrivacyException = addPhonePrivacyException
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<UpdatesBase>> AcceptContactAsync(InputUserBase id,
            CancellationToken cancellationToken = default)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var rpcResponse = new RpcMessage<UpdatesBase>();
            var methodBody = new AcceptContact
            {
                Id = id
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<UpdatesBase>> GetLocatedAsync(InputGeoPointBase geoPoint, bool background = true,
            int? selfExpires = null, CancellationToken cancellationToken = default)
        {
            if (geoPoint is null)
            {
                throw new ArgumentNullException(nameof(geoPoint));
            }

            var rpcResponse = new RpcMessage<UpdatesBase>();
            var methodBody = new GetLocated
            {
                GeoPoint = geoPoint,
                Background = background,
                SelfExpires = selfExpires
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<UpdatesBase>> BlockFromRepliesAsync(int msgId, bool deleteMessage = true,
            bool deleteHistory = true, bool reportSpam = true, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<UpdatesBase>();
            var methodBody = new BlockFromReplies
            {
                MsgId = msgId,
                DeleteMessage = deleteMessage,
                DeleteHistory = deleteHistory,
                ReportSpam = reportSpam
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