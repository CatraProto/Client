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
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class DialogFolder : CatraProto.Client.TL.Schemas.CloudChats.DialogBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Pinned = 1 << 2
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1908216652; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("pinned")]
        public sealed override bool Pinned { get; set; }

        [Newtonsoft.Json.JsonProperty("folder")]
        public CatraProto.Client.TL.Schemas.CloudChats.FolderBase Folder { get; set; }

        [Newtonsoft.Json.JsonProperty("peer")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.PeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("top_message")]
        public sealed override int TopMessage { get; set; }

        [Newtonsoft.Json.JsonProperty("unread_muted_peers_count")]
        public int UnreadMutedPeersCount { get; set; }

        [Newtonsoft.Json.JsonProperty("unread_unmuted_peers_count")]
        public int UnreadUnmutedPeersCount { get; set; }

        [Newtonsoft.Json.JsonProperty("unread_muted_messages_count")]
        public int UnreadMutedMessagesCount { get; set; }

        [Newtonsoft.Json.JsonProperty("unread_unmuted_messages_count")]
        public int UnreadUnmutedMessagesCount { get; set; }


#nullable enable
        public DialogFolder(CatraProto.Client.TL.Schemas.CloudChats.FolderBase folder, CatraProto.Client.TL.Schemas.CloudChats.PeerBase peer, int topMessage, int unreadMutedPeersCount, int unreadUnmutedPeersCount, int unreadMutedMessagesCount, int unreadUnmutedMessagesCount)
        {
            Folder = folder;
            Peer = peer;
            TopMessage = topMessage;
            UnreadMutedPeersCount = unreadMutedPeersCount;
            UnreadUnmutedPeersCount = unreadUnmutedPeersCount;
            UnreadMutedMessagesCount = unreadMutedMessagesCount;
            UnreadUnmutedMessagesCount = unreadUnmutedMessagesCount;

        }
#nullable disable
        internal DialogFolder()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Pinned ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkfolder = writer.WriteObject(Folder);
            if (checkfolder.IsError)
            {
                return checkfolder;
            }
            var checkpeer = writer.WriteObject(Peer);
            if (checkpeer.IsError)
            {
                return checkpeer;
            }
            writer.WriteInt32(TopMessage);
            writer.WriteInt32(UnreadMutedPeersCount);
            writer.WriteInt32(UnreadUnmutedPeersCount);
            writer.WriteInt32(UnreadMutedMessagesCount);
            writer.WriteInt32(UnreadUnmutedMessagesCount);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }
            Flags = tryflags.Value;
            Pinned = FlagsHelper.IsFlagSet(Flags, 2);
            var tryfolder = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.FolderBase>();
            if (tryfolder.IsError)
            {
                return ReadResult<IObject>.Move(tryfolder);
            }
            Folder = tryfolder.Value;
            var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
            if (trypeer.IsError)
            {
                return ReadResult<IObject>.Move(trypeer);
            }
            Peer = trypeer.Value;
            var trytopMessage = reader.ReadInt32();
            if (trytopMessage.IsError)
            {
                return ReadResult<IObject>.Move(trytopMessage);
            }
            TopMessage = trytopMessage.Value;
            var tryunreadMutedPeersCount = reader.ReadInt32();
            if (tryunreadMutedPeersCount.IsError)
            {
                return ReadResult<IObject>.Move(tryunreadMutedPeersCount);
            }
            UnreadMutedPeersCount = tryunreadMutedPeersCount.Value;
            var tryunreadUnmutedPeersCount = reader.ReadInt32();
            if (tryunreadUnmutedPeersCount.IsError)
            {
                return ReadResult<IObject>.Move(tryunreadUnmutedPeersCount);
            }
            UnreadUnmutedPeersCount = tryunreadUnmutedPeersCount.Value;
            var tryunreadMutedMessagesCount = reader.ReadInt32();
            if (tryunreadMutedMessagesCount.IsError)
            {
                return ReadResult<IObject>.Move(tryunreadMutedMessagesCount);
            }
            UnreadMutedMessagesCount = tryunreadMutedMessagesCount.Value;
            var tryunreadUnmutedMessagesCount = reader.ReadInt32();
            if (tryunreadUnmutedMessagesCount.IsError)
            {
                return ReadResult<IObject>.Move(tryunreadUnmutedMessagesCount);
            }
            UnreadUnmutedMessagesCount = tryunreadUnmutedMessagesCount.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "dialogFolder";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new DialogFolder
            {
                Flags = Flags,
                Pinned = Pinned
            };
            var cloneFolder = (CatraProto.Client.TL.Schemas.CloudChats.FolderBase?)Folder.Clone();
            if (cloneFolder is null)
            {
                return null;
            }
            newClonedObject.Folder = cloneFolder;
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.PeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }
            newClonedObject.Peer = clonePeer;
            newClonedObject.TopMessage = TopMessage;
            newClonedObject.UnreadMutedPeersCount = UnreadMutedPeersCount;
            newClonedObject.UnreadUnmutedPeersCount = UnreadUnmutedPeersCount;
            newClonedObject.UnreadMutedMessagesCount = UnreadMutedMessagesCount;
            newClonedObject.UnreadUnmutedMessagesCount = UnreadUnmutedMessagesCount;
            return newClonedObject;

        }
#nullable disable
    }
}