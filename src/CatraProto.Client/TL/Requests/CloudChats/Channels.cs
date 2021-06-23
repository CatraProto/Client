using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CatraProto.Client.Connections;
using CatraProto.Client.MTProto.Messages;
using CatraProto.Client.MTProto.Rpc;
using CatraProto.Client.TL.Schemas.CloudChats;
using CatraProto.Client.TL.Schemas.CloudChats.Channels;
using CatraProto.Client.TL.Schemas.CloudChats.Messages;
using ChannelParticipantBase = CatraProto.Client.TL.Schemas.CloudChats.Channels.ChannelParticipantBase;
using ChatFullBase = CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatFullBase;
using DeleteHistory = CatraProto.Client.TL.Schemas.CloudChats.Channels.DeleteHistory;
using DeleteMessages = CatraProto.Client.TL.Schemas.CloudChats.Channels.DeleteMessages;
using GetMessages = CatraProto.Client.TL.Schemas.CloudChats.Channels.GetMessages;
using ReadHistory = CatraProto.Client.TL.Schemas.CloudChats.Channels.ReadHistory;
using ReadMessageContents = CatraProto.Client.TL.Schemas.CloudChats.Channels.ReadMessageContents;
using ReportSpam = CatraProto.Client.TL.Schemas.CloudChats.Channels.ReportSpam;

namespace CatraProto.Client.TL.Requests.CloudChats
{
    public class Channels
    {
        private MessagesHandler _messagesHandler;

        internal Channels(MessagesHandler messagesHandler)
        {
            _messagesHandler = messagesHandler;
        }

        public async Task<RpcMessage<bool>> ReadHistoryAsync(InputChannelBase channel, int maxId,
            CancellationToken cancellationToken = default)
        {
            if (channel is null)
            {
                throw new ArgumentNullException(nameof(channel));
            }

            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new ReadHistory
            {
                Channel = channel,
                MaxId = maxId
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<AffectedMessagesBase>> DeleteMessagesAsync(InputChannelBase channel, List<int> id,
            CancellationToken cancellationToken = default)
        {
            if (channel is null)
            {
                throw new ArgumentNullException(nameof(channel));
            }

            var rpcResponse = new RpcMessage<AffectedMessagesBase>();
            var methodBody = new DeleteMessages
            {
                Channel = channel,
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

        public async Task<RpcMessage<AffectedHistoryBase>> DeleteUserHistoryAsync(InputChannelBase channel,
            InputUserBase userId, CancellationToken cancellationToken = default)
        {
            if (channel is null)
            {
                throw new ArgumentNullException(nameof(channel));
            }

            if (userId is null)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            var rpcResponse = new RpcMessage<AffectedHistoryBase>();
            var methodBody = new DeleteUserHistory
            {
                Channel = channel,
                UserId = userId
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> ReportSpamAsync(InputChannelBase channel, InputUserBase userId,
            List<int> id, CancellationToken cancellationToken = default)
        {
            if (channel is null)
            {
                throw new ArgumentNullException(nameof(channel));
            }

            if (userId is null)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new ReportSpam
            {
                Channel = channel,
                UserId = userId,
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

        public async Task<RpcMessage<MessagesBase>> GetMessagesAsync(InputChannelBase channel,
            List<InputMessageBase> id, CancellationToken cancellationToken = default)
        {
            if (channel is null)
            {
                throw new ArgumentNullException(nameof(channel));
            }

            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var rpcResponse = new RpcMessage<MessagesBase>();
            var methodBody = new GetMessages
            {
                Channel = channel,
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

        public async Task<RpcMessage<ChannelParticipantsBase>> GetParticipantsAsync(InputChannelBase channel,
            ChannelParticipantsFilterBase filter, int offset, int limit, int hash,
            CancellationToken cancellationToken = default)
        {
            if (channel is null)
            {
                throw new ArgumentNullException(nameof(channel));
            }

            if (filter is null)
            {
                throw new ArgumentNullException(nameof(filter));
            }

            var rpcResponse = new RpcMessage<ChannelParticipantsBase>();
            var methodBody = new GetParticipants
            {
                Channel = channel,
                Filter = filter,
                Offset = offset,
                Limit = limit,
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

        public async Task<RpcMessage<ChannelParticipantBase>> GetParticipantAsync(InputChannelBase channel,
            InputUserBase userId, CancellationToken cancellationToken = default)
        {
            if (channel is null)
            {
                throw new ArgumentNullException(nameof(channel));
            }

            if (userId is null)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            var rpcResponse = new RpcMessage<ChannelParticipantBase>();
            var methodBody = new GetParticipant
            {
                Channel = channel,
                UserId = userId
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<ChatsBase>> GetChannelsAsync(List<InputChannelBase> id,
            CancellationToken cancellationToken = default)
        {
            if (id is null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var rpcResponse = new RpcMessage<ChatsBase>();
            var methodBody = new GetChannels
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

        public async Task<RpcMessage<ChatFullBase>> GetFullChannelAsync(InputChannelBase channel,
            CancellationToken cancellationToken = default)
        {
            if (channel is null)
            {
                throw new ArgumentNullException(nameof(channel));
            }

            var rpcResponse = new RpcMessage<ChatFullBase>();
            var methodBody = new GetFullChannel
            {
                Channel = channel
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<UpdatesBase>> CreateChannelAsync(string title, string about, bool broadcast = true,
            bool megagroup = true, bool forImport = true, InputGeoPointBase geoPoint = null, string address = null,
            CancellationToken cancellationToken = default)
        {
            if (title is null)
            {
                throw new ArgumentNullException(nameof(title));
            }

            if (about is null)
            {
                throw new ArgumentNullException(nameof(about));
            }

            var rpcResponse = new RpcMessage<UpdatesBase>();
            var methodBody = new CreateChannel
            {
                Title = title,
                About = about,
                Broadcast = broadcast,
                Megagroup = megagroup,
                ForImport = forImport,
                GeoPoint = geoPoint,
                Address = address
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<UpdatesBase>> EditAdminAsync(InputChannelBase channel, InputUserBase userId,
            ChatAdminRightsBase adminRights, string rank, CancellationToken cancellationToken = default)
        {
            if (channel is null)
            {
                throw new ArgumentNullException(nameof(channel));
            }

            if (userId is null)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            if (adminRights is null)
            {
                throw new ArgumentNullException(nameof(adminRights));
            }

            if (rank is null)
            {
                throw new ArgumentNullException(nameof(rank));
            }

            var rpcResponse = new RpcMessage<UpdatesBase>();
            var methodBody = new EditAdmin
            {
                Channel = channel,
                UserId = userId,
                AdminRights = adminRights,
                Rank = rank
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<UpdatesBase>> EditTitleAsync(InputChannelBase channel, string title,
            CancellationToken cancellationToken = default)
        {
            if (channel is null)
            {
                throw new ArgumentNullException(nameof(channel));
            }

            if (title is null)
            {
                throw new ArgumentNullException(nameof(title));
            }

            var rpcResponse = new RpcMessage<UpdatesBase>();
            var methodBody = new EditTitle
            {
                Channel = channel,
                Title = title
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<UpdatesBase>> EditPhotoAsync(InputChannelBase channel, InputChatPhotoBase photo,
            CancellationToken cancellationToken = default)
        {
            if (channel is null)
            {
                throw new ArgumentNullException(nameof(channel));
            }

            if (photo is null)
            {
                throw new ArgumentNullException(nameof(photo));
            }

            var rpcResponse = new RpcMessage<UpdatesBase>();
            var methodBody = new EditPhoto
            {
                Channel = channel,
                Photo = photo
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> CheckUsernameAsync(InputChannelBase channel, string username,
            CancellationToken cancellationToken = default)
        {
            if (channel is null)
            {
                throw new ArgumentNullException(nameof(channel));
            }

            if (username is null)
            {
                throw new ArgumentNullException(nameof(username));
            }

            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new CheckUsername
            {
                Channel = channel,
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

        public async Task<RpcMessage<bool>> UpdateUsernameAsync(InputChannelBase channel, string username,
            CancellationToken cancellationToken = default)
        {
            if (channel is null)
            {
                throw new ArgumentNullException(nameof(channel));
            }

            if (username is null)
            {
                throw new ArgumentNullException(nameof(username));
            }

            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new UpdateUsername
            {
                Channel = channel,
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

        public async Task<RpcMessage<UpdatesBase>> JoinChannelAsync(InputChannelBase channel,
            CancellationToken cancellationToken = default)
        {
            if (channel is null)
            {
                throw new ArgumentNullException(nameof(channel));
            }

            var rpcResponse = new RpcMessage<UpdatesBase>();
            var methodBody = new JoinChannel
            {
                Channel = channel
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<UpdatesBase>> LeaveChannelAsync(InputChannelBase channel,
            CancellationToken cancellationToken = default)
        {
            if (channel is null)
            {
                throw new ArgumentNullException(nameof(channel));
            }

            var rpcResponse = new RpcMessage<UpdatesBase>();
            var methodBody = new LeaveChannel
            {
                Channel = channel
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<UpdatesBase>> InviteToChannelAsync(InputChannelBase channel,
            List<InputUserBase> users, CancellationToken cancellationToken = default)
        {
            if (channel is null)
            {
                throw new ArgumentNullException(nameof(channel));
            }

            if (users is null)
            {
                throw new ArgumentNullException(nameof(users));
            }

            var rpcResponse = new RpcMessage<UpdatesBase>();
            var methodBody = new InviteToChannel
            {
                Channel = channel,
                Users = users
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<UpdatesBase>> DeleteChannelAsync(InputChannelBase channel,
            CancellationToken cancellationToken = default)
        {
            if (channel is null)
            {
                throw new ArgumentNullException(nameof(channel));
            }

            var rpcResponse = new RpcMessage<UpdatesBase>();
            var methodBody = new DeleteChannel
            {
                Channel = channel
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<ExportedMessageLinkBase>> ExportMessageLinkAsync(InputChannelBase channel, int id,
            bool grouped = true, bool thread = true, CancellationToken cancellationToken = default)
        {
            if (channel is null)
            {
                throw new ArgumentNullException(nameof(channel));
            }

            var rpcResponse = new RpcMessage<ExportedMessageLinkBase>();
            var methodBody = new ExportMessageLink
            {
                Channel = channel,
                Id = id,
                Grouped = grouped,
                Thread = thread
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<UpdatesBase>> ToggleSignaturesAsync(InputChannelBase channel, bool enabled,
            CancellationToken cancellationToken = default)
        {
            if (channel is null)
            {
                throw new ArgumentNullException(nameof(channel));
            }

            var rpcResponse = new RpcMessage<UpdatesBase>();
            var methodBody = new ToggleSignatures
            {
                Channel = channel,
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

        public async Task<RpcMessage<ChatsBase>> GetAdminedPublicChannelsAsync(bool byLocation = true,
            bool checkLimit = true, CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<ChatsBase>();
            var methodBody = new GetAdminedPublicChannels
            {
                ByLocation = byLocation,
                CheckLimit = checkLimit
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<UpdatesBase>> EditBannedAsync(InputChannelBase channel, InputUserBase userId,
            ChatBannedRightsBase bannedRights, CancellationToken cancellationToken = default)
        {
            if (channel is null)
            {
                throw new ArgumentNullException(nameof(channel));
            }

            if (userId is null)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            if (bannedRights is null)
            {
                throw new ArgumentNullException(nameof(bannedRights));
            }

            var rpcResponse = new RpcMessage<UpdatesBase>();
            var methodBody = new EditBanned
            {
                Channel = channel,
                UserId = userId,
                BannedRights = bannedRights
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<AdminLogResultsBase>> GetAdminLogAsync(InputChannelBase channel, string q,
            long maxId, long minId, int limit, ChannelAdminLogEventsFilterBase eventsFilter = null,
            List<InputUserBase> admins = null, CancellationToken cancellationToken = default)
        {
            if (channel is null)
            {
                throw new ArgumentNullException(nameof(channel));
            }

            if (q is null)
            {
                throw new ArgumentNullException(nameof(q));
            }

            var rpcResponse = new RpcMessage<AdminLogResultsBase>();
            var methodBody = new GetAdminLog
            {
                Channel = channel,
                Q = q,
                MaxId = maxId,
                MinId = minId,
                Limit = limit,
                EventsFilter = eventsFilter,
                Admins = admins
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> SetStickersAsync(InputChannelBase channel, InputStickerSetBase stickerset,
            CancellationToken cancellationToken = default)
        {
            if (channel is null)
            {
                throw new ArgumentNullException(nameof(channel));
            }

            if (stickerset is null)
            {
                throw new ArgumentNullException(nameof(stickerset));
            }

            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new SetStickers
            {
                Channel = channel,
                Stickerset = stickerset
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> ReadMessageContentsAsync(InputChannelBase channel, List<int> id,
            CancellationToken cancellationToken = default)
        {
            if (channel is null)
            {
                throw new ArgumentNullException(nameof(channel));
            }

            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new ReadMessageContents
            {
                Channel = channel,
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

        public async Task<RpcMessage<bool>> DeleteHistoryAsync(InputChannelBase channel, int maxId,
            CancellationToken cancellationToken = default)
        {
            if (channel is null)
            {
                throw new ArgumentNullException(nameof(channel));
            }

            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new DeleteHistory
            {
                Channel = channel,
                MaxId = maxId
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<UpdatesBase>> TogglePreHistoryHiddenAsync(InputChannelBase channel, bool enabled,
            CancellationToken cancellationToken = default)
        {
            if (channel is null)
            {
                throw new ArgumentNullException(nameof(channel));
            }

            var rpcResponse = new RpcMessage<UpdatesBase>();
            var methodBody = new TogglePreHistoryHidden
            {
                Channel = channel,
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

        public async Task<RpcMessage<ChatsBase>> GetLeftChannelsAsync(int offset,
            CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<ChatsBase>();
            var methodBody = new GetLeftChannels
            {
                Offset = offset
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<ChatsBase>> GetGroupsForDiscussionAsync(
            CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<ChatsBase>();
            var methodBody = new GetGroupsForDiscussion();

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> SetDiscussionGroupAsync(InputChannelBase broadcast, InputChannelBase group,
            CancellationToken cancellationToken = default)
        {
            if (broadcast is null)
            {
                throw new ArgumentNullException(nameof(broadcast));
            }

            if (group is null)
            {
                throw new ArgumentNullException(nameof(group));
            }

            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new SetDiscussionGroup
            {
                Broadcast = broadcast,
                Group = group
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<UpdatesBase>> EditCreatorAsync(InputChannelBase channel, InputUserBase userId,
            InputCheckPasswordSRPBase password, CancellationToken cancellationToken = default)
        {
            if (channel is null)
            {
                throw new ArgumentNullException(nameof(channel));
            }

            if (userId is null)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            if (password is null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            var rpcResponse = new RpcMessage<UpdatesBase>();
            var methodBody = new EditCreator
            {
                Channel = channel,
                UserId = userId,
                Password = password
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<bool>> EditLocationAsync(InputChannelBase channel, InputGeoPointBase geoPoint,
            string address, CancellationToken cancellationToken = default)
        {
            if (channel is null)
            {
                throw new ArgumentNullException(nameof(channel));
            }

            if (geoPoint is null)
            {
                throw new ArgumentNullException(nameof(geoPoint));
            }

            if (address is null)
            {
                throw new ArgumentNullException(nameof(address));
            }

            var rpcResponse = new RpcMessage<bool>();
            var methodBody = new EditLocation
            {
                Channel = channel,
                GeoPoint = geoPoint,
                Address = address
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<UpdatesBase>> ToggleSlowModeAsync(InputChannelBase channel, int seconds,
            CancellationToken cancellationToken = default)
        {
            if (channel is null)
            {
                throw new ArgumentNullException(nameof(channel));
            }

            var rpcResponse = new RpcMessage<UpdatesBase>();
            var methodBody = new ToggleSlowMode
            {
                Channel = channel,
                Seconds = seconds
            };

            await await _messagesHandler.EnqueueMessage(new OutgoingMessage
            {
                Body = methodBody,
                CancellationToken = cancellationToken,
                IsEncrypted = true
            }, rpcResponse);
            return rpcResponse;
        }

        public async Task<RpcMessage<InactiveChatsBase>> GetInactiveChannelsAsync(
            CancellationToken cancellationToken = default)
        {
            var rpcResponse = new RpcMessage<InactiveChatsBase>();
            var methodBody = new GetInactiveChannels();

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