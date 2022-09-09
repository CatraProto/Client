using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class Dialog : CatraProto.Client.TL.Schemas.CloudChats.DialogBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Pinned = 1 << 2,
            UnreadMark = 1 << 3,
            Pts = 1 << 0,
            Draft = 1 << 1,
            FolderId = 1 << 4
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1460809483; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("pinned")]
        public sealed override bool Pinned { get; set; }

        [Newtonsoft.Json.JsonProperty("unread_mark")]
        public bool UnreadMark { get; set; }

        [Newtonsoft.Json.JsonProperty("peer")] public sealed override CatraProto.Client.TL.Schemas.CloudChats.PeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("top_message")]
        public sealed override int TopMessage { get; set; }

        [Newtonsoft.Json.JsonProperty("read_inbox_max_id")]
        public int ReadInboxMaxId { get; set; }

        [Newtonsoft.Json.JsonProperty("read_outbox_max_id")]
        public int ReadOutboxMaxId { get; set; }

        [Newtonsoft.Json.JsonProperty("unread_count")]
        public int UnreadCount { get; set; }

        [Newtonsoft.Json.JsonProperty("unread_mentions_count")]
        public int UnreadMentionsCount { get; set; }

        [Newtonsoft.Json.JsonProperty("unread_reactions_count")]
        public int UnreadReactionsCount { get; set; }

        [Newtonsoft.Json.JsonProperty("notify_settings")]
        public CatraProto.Client.TL.Schemas.CloudChats.PeerNotifySettingsBase NotifySettings { get; set; }

        [Newtonsoft.Json.JsonProperty("pts")] public int? Pts { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("draft")]
        public CatraProto.Client.TL.Schemas.CloudChats.DraftMessageBase Draft { get; set; }

        [Newtonsoft.Json.JsonProperty("folder_id")]
        public int? FolderId { get; set; }


#nullable enable
        public Dialog(CatraProto.Client.TL.Schemas.CloudChats.PeerBase peer, int topMessage, int readInboxMaxId, int readOutboxMaxId, int unreadCount, int unreadMentionsCount, int unreadReactionsCount, CatraProto.Client.TL.Schemas.CloudChats.PeerNotifySettingsBase notifySettings)
        {
            Peer = peer;
            TopMessage = topMessage;
            ReadInboxMaxId = readInboxMaxId;
            ReadOutboxMaxId = readOutboxMaxId;
            UnreadCount = unreadCount;
            UnreadMentionsCount = unreadMentionsCount;
            UnreadReactionsCount = unreadReactionsCount;
            NotifySettings = notifySettings;
        }
#nullable disable
        internal Dialog()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Pinned ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
            Flags = UnreadMark ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
            Flags = Pts == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = Draft == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = FolderId == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkpeer = writer.WriteObject(Peer);
            if (checkpeer.IsError)
            {
                return checkpeer;
            }

            writer.WriteInt32(TopMessage);
            writer.WriteInt32(ReadInboxMaxId);
            writer.WriteInt32(ReadOutboxMaxId);
            writer.WriteInt32(UnreadCount);
            writer.WriteInt32(UnreadMentionsCount);
            writer.WriteInt32(UnreadReactionsCount);
            var checknotifySettings = writer.WriteObject(NotifySettings);
            if (checknotifySettings.IsError)
            {
                return checknotifySettings;
            }

            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteInt32(Pts.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var checkdraft = writer.WriteObject(Draft);
                if (checkdraft.IsError)
                {
                    return checkdraft;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                writer.WriteInt32(FolderId.Value);
            }


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
            UnreadMark = FlagsHelper.IsFlagSet(Flags, 3);
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
            var tryreadInboxMaxId = reader.ReadInt32();
            if (tryreadInboxMaxId.IsError)
            {
                return ReadResult<IObject>.Move(tryreadInboxMaxId);
            }

            ReadInboxMaxId = tryreadInboxMaxId.Value;
            var tryreadOutboxMaxId = reader.ReadInt32();
            if (tryreadOutboxMaxId.IsError)
            {
                return ReadResult<IObject>.Move(tryreadOutboxMaxId);
            }

            ReadOutboxMaxId = tryreadOutboxMaxId.Value;
            var tryunreadCount = reader.ReadInt32();
            if (tryunreadCount.IsError)
            {
                return ReadResult<IObject>.Move(tryunreadCount);
            }

            UnreadCount = tryunreadCount.Value;
            var tryunreadMentionsCount = reader.ReadInt32();
            if (tryunreadMentionsCount.IsError)
            {
                return ReadResult<IObject>.Move(tryunreadMentionsCount);
            }

            UnreadMentionsCount = tryunreadMentionsCount.Value;
            var tryunreadReactionsCount = reader.ReadInt32();
            if (tryunreadReactionsCount.IsError)
            {
                return ReadResult<IObject>.Move(tryunreadReactionsCount);
            }

            UnreadReactionsCount = tryunreadReactionsCount.Value;
            var trynotifySettings = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PeerNotifySettingsBase>();
            if (trynotifySettings.IsError)
            {
                return ReadResult<IObject>.Move(trynotifySettings);
            }

            NotifySettings = trynotifySettings.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var trypts = reader.ReadInt32();
                if (trypts.IsError)
                {
                    return ReadResult<IObject>.Move(trypts);
                }

                Pts = trypts.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var trydraft = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.DraftMessageBase>();
                if (trydraft.IsError)
                {
                    return ReadResult<IObject>.Move(trydraft);
                }

                Draft = trydraft.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                var tryfolderId = reader.ReadInt32();
                if (tryfolderId.IsError)
                {
                    return ReadResult<IObject>.Move(tryfolderId);
                }

                FolderId = tryfolderId.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "dialog";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new Dialog();
            newClonedObject.Flags = Flags;
            newClonedObject.Pinned = Pinned;
            newClonedObject.UnreadMark = UnreadMark;
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.PeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }

            newClonedObject.Peer = clonePeer;
            newClonedObject.TopMessage = TopMessage;
            newClonedObject.ReadInboxMaxId = ReadInboxMaxId;
            newClonedObject.ReadOutboxMaxId = ReadOutboxMaxId;
            newClonedObject.UnreadCount = UnreadCount;
            newClonedObject.UnreadMentionsCount = UnreadMentionsCount;
            newClonedObject.UnreadReactionsCount = UnreadReactionsCount;
            var cloneNotifySettings = (CatraProto.Client.TL.Schemas.CloudChats.PeerNotifySettingsBase?)NotifySettings.Clone();
            if (cloneNotifySettings is null)
            {
                return null;
            }

            newClonedObject.NotifySettings = cloneNotifySettings;
            newClonedObject.Pts = Pts;
            if (Draft is not null)
            {
                var cloneDraft = (CatraProto.Client.TL.Schemas.CloudChats.DraftMessageBase?)Draft.Clone();
                if (cloneDraft is null)
                {
                    return null;
                }

                newClonedObject.Draft = cloneDraft;
            }

            newClonedObject.FolderId = FolderId;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not Dialog castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Pinned != castedOther.Pinned)
            {
                return true;
            }

            if (UnreadMark != castedOther.UnreadMark)
            {
                return true;
            }

            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }

            if (TopMessage != castedOther.TopMessage)
            {
                return true;
            }

            if (ReadInboxMaxId != castedOther.ReadInboxMaxId)
            {
                return true;
            }

            if (ReadOutboxMaxId != castedOther.ReadOutboxMaxId)
            {
                return true;
            }

            if (UnreadCount != castedOther.UnreadCount)
            {
                return true;
            }

            if (UnreadMentionsCount != castedOther.UnreadMentionsCount)
            {
                return true;
            }

            if (UnreadReactionsCount != castedOther.UnreadReactionsCount)
            {
                return true;
            }

            if (NotifySettings.Compare(castedOther.NotifySettings))
            {
                return true;
            }

            if (Pts != castedOther.Pts)
            {
                return true;
            }

            if (Draft is null && castedOther.Draft is not null || Draft is not null && castedOther.Draft is null)
            {
                return true;
            }

            if (Draft is not null && castedOther.Draft is not null && Draft.Compare(castedOther.Draft))
            {
                return true;
            }

            if (FolderId != castedOther.FolderId)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}