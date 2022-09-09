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
    public partial class ChatFull : CatraProto.Client.TL.Schemas.CloudChats.ChatFullBase
    {
        [Flags]
        public enum FlagsEnum
        {
            CanSetUsername = 1 << 7,
            HasScheduled = 1 << 8,
            ChatPhoto = 1 << 2,
            ExportedInvite = 1 << 13,
            BotInfo = 1 << 3,
            PinnedMsgId = 1 << 6,
            FolderId = 1 << 11,
            Call = 1 << 12,
            TtlPeriod = 1 << 14,
            GroupcallDefaultJoinAs = 1 << 15,
            ThemeEmoticon = 1 << 16,
            RequestsPending = 1 << 17,
            RecentRequesters = 1 << 17,
            AvailableReactions = 1 << 18
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -779165146; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("can_set_username")]
        public bool CanSetUsername { get; set; }

        [Newtonsoft.Json.JsonProperty("has_scheduled")]
        public bool HasScheduled { get; set; }

        [Newtonsoft.Json.JsonProperty("id")] public sealed override long Id { get; set; }

        [Newtonsoft.Json.JsonProperty("about")]
        public sealed override string About { get; set; }

        [Newtonsoft.Json.JsonProperty("participants")]
        public CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantsBase Participants { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("chat_photo")]
        public CatraProto.Client.TL.Schemas.CloudChats.PhotoBase ChatPhoto { get; set; }

        [Newtonsoft.Json.JsonProperty("notify_settings")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.PeerNotifySettingsBase NotifySettings { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("exported_invite")]
        public CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase ExportedInvite { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("bot_info")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.BotInfoBase> BotInfo { get; set; }

        [Newtonsoft.Json.JsonProperty("pinned_msg_id")]
        public int? PinnedMsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("folder_id")]
        public sealed override int? FolderId { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("call")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase Call { get; set; }

        [Newtonsoft.Json.JsonProperty("ttl_period")]
        public int? TtlPeriod { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("groupcall_default_join_as")]
        public CatraProto.Client.TL.Schemas.CloudChats.PeerBase GroupcallDefaultJoinAs { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("theme_emoticon")]
        public string ThemeEmoticon { get; set; }

        [Newtonsoft.Json.JsonProperty("requests_pending")]
        public int? RequestsPending { get; set; }

        [Newtonsoft.Json.JsonProperty("recent_requesters")]
        public List<long> RecentRequesters { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("available_reactions")]
        public List<string> AvailableReactions { get; set; }


#nullable enable
        public ChatFull(long id, string about, CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantsBase participants, CatraProto.Client.TL.Schemas.CloudChats.PeerNotifySettingsBase notifySettings)
        {
            Id = id;
            About = about;
            Participants = participants;
            NotifySettings = notifySettings;
        }
#nullable disable
        internal ChatFull()
        {
        }

        public override void UpdateFlags()
        {
            Flags = CanSetUsername ? FlagsHelper.SetFlag(Flags, 7) : FlagsHelper.UnsetFlag(Flags, 7);
            Flags = HasScheduled ? FlagsHelper.SetFlag(Flags, 8) : FlagsHelper.UnsetFlag(Flags, 8);
            Flags = ChatPhoto == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
            Flags = ExportedInvite == null ? FlagsHelper.UnsetFlag(Flags, 13) : FlagsHelper.SetFlag(Flags, 13);
            Flags = BotInfo == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
            Flags = PinnedMsgId == null ? FlagsHelper.UnsetFlag(Flags, 6) : FlagsHelper.SetFlag(Flags, 6);
            Flags = FolderId == null ? FlagsHelper.UnsetFlag(Flags, 11) : FlagsHelper.SetFlag(Flags, 11);
            Flags = Call == null ? FlagsHelper.UnsetFlag(Flags, 12) : FlagsHelper.SetFlag(Flags, 12);
            Flags = TtlPeriod == null ? FlagsHelper.UnsetFlag(Flags, 14) : FlagsHelper.SetFlag(Flags, 14);
            Flags = GroupcallDefaultJoinAs == null ? FlagsHelper.UnsetFlag(Flags, 15) : FlagsHelper.SetFlag(Flags, 15);
            Flags = ThemeEmoticon == null ? FlagsHelper.UnsetFlag(Flags, 16) : FlagsHelper.SetFlag(Flags, 16);
            Flags = RequestsPending == null ? FlagsHelper.UnsetFlag(Flags, 17) : FlagsHelper.SetFlag(Flags, 17);
            Flags = RecentRequesters == null ? FlagsHelper.UnsetFlag(Flags, 17) : FlagsHelper.SetFlag(Flags, 17);
            Flags = AvailableReactions == null ? FlagsHelper.UnsetFlag(Flags, 18) : FlagsHelper.SetFlag(Flags, 18);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt64(Id);

            writer.WriteString(About);
            var checkparticipants = writer.WriteObject(Participants);
            if (checkparticipants.IsError)
            {
                return checkparticipants;
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var checkchatPhoto = writer.WriteObject(ChatPhoto);
                if (checkchatPhoto.IsError)
                {
                    return checkchatPhoto;
                }
            }

            var checknotifySettings = writer.WriteObject(NotifySettings);
            if (checknotifySettings.IsError)
            {
                return checknotifySettings;
            }

            if (FlagsHelper.IsFlagSet(Flags, 13))
            {
                var checkexportedInvite = writer.WriteObject(ExportedInvite);
                if (checkexportedInvite.IsError)
                {
                    return checkexportedInvite;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                var checkbotInfo = writer.WriteVector(BotInfo, false);
                if (checkbotInfo.IsError)
                {
                    return checkbotInfo;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 6))
            {
                writer.WriteInt32(PinnedMsgId.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 11))
            {
                writer.WriteInt32(FolderId.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 12))
            {
                var checkcall = writer.WriteObject(Call);
                if (checkcall.IsError)
                {
                    return checkcall;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 14))
            {
                writer.WriteInt32(TtlPeriod.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 15))
            {
                var checkgroupcallDefaultJoinAs = writer.WriteObject(GroupcallDefaultJoinAs);
                if (checkgroupcallDefaultJoinAs.IsError)
                {
                    return checkgroupcallDefaultJoinAs;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 16))
            {
                writer.WriteString(ThemeEmoticon);
            }

            if (FlagsHelper.IsFlagSet(Flags, 17))
            {
                writer.WriteInt32(RequestsPending.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 17))
            {
                writer.WriteVector(RecentRequesters, false);
            }

            if (FlagsHelper.IsFlagSet(Flags, 18))
            {
                writer.WriteVector(AvailableReactions, false);
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
            CanSetUsername = FlagsHelper.IsFlagSet(Flags, 7);
            HasScheduled = FlagsHelper.IsFlagSet(Flags, 8);
            var tryid = reader.ReadInt64();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }

            Id = tryid.Value;
            var tryabout = reader.ReadString();
            if (tryabout.IsError)
            {
                return ReadResult<IObject>.Move(tryabout);
            }

            About = tryabout.Value;
            var tryparticipants = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantsBase>();
            if (tryparticipants.IsError)
            {
                return ReadResult<IObject>.Move(tryparticipants);
            }

            Participants = tryparticipants.Value;
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var trychatPhoto = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PhotoBase>();
                if (trychatPhoto.IsError)
                {
                    return ReadResult<IObject>.Move(trychatPhoto);
                }

                ChatPhoto = trychatPhoto.Value;
            }

            var trynotifySettings = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PeerNotifySettingsBase>();
            if (trynotifySettings.IsError)
            {
                return ReadResult<IObject>.Move(trynotifySettings);
            }

            NotifySettings = trynotifySettings.Value;
            if (FlagsHelper.IsFlagSet(Flags, 13))
            {
                var tryexportedInvite = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase>();
                if (tryexportedInvite.IsError)
                {
                    return ReadResult<IObject>.Move(tryexportedInvite);
                }

                ExportedInvite = tryexportedInvite.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                var trybotInfo = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.BotInfoBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
                if (trybotInfo.IsError)
                {
                    return ReadResult<IObject>.Move(trybotInfo);
                }

                BotInfo = trybotInfo.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 6))
            {
                var trypinnedMsgId = reader.ReadInt32();
                if (trypinnedMsgId.IsError)
                {
                    return ReadResult<IObject>.Move(trypinnedMsgId);
                }

                PinnedMsgId = trypinnedMsgId.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 11))
            {
                var tryfolderId = reader.ReadInt32();
                if (tryfolderId.IsError)
                {
                    return ReadResult<IObject>.Move(tryfolderId);
                }

                FolderId = tryfolderId.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 12))
            {
                var trycall = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase>();
                if (trycall.IsError)
                {
                    return ReadResult<IObject>.Move(trycall);
                }

                Call = trycall.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 14))
            {
                var tryttlPeriod = reader.ReadInt32();
                if (tryttlPeriod.IsError)
                {
                    return ReadResult<IObject>.Move(tryttlPeriod);
                }

                TtlPeriod = tryttlPeriod.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 15))
            {
                var trygroupcallDefaultJoinAs = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
                if (trygroupcallDefaultJoinAs.IsError)
                {
                    return ReadResult<IObject>.Move(trygroupcallDefaultJoinAs);
                }

                GroupcallDefaultJoinAs = trygroupcallDefaultJoinAs.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 16))
            {
                var trythemeEmoticon = reader.ReadString();
                if (trythemeEmoticon.IsError)
                {
                    return ReadResult<IObject>.Move(trythemeEmoticon);
                }

                ThemeEmoticon = trythemeEmoticon.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 17))
            {
                var tryrequestsPending = reader.ReadInt32();
                if (tryrequestsPending.IsError)
                {
                    return ReadResult<IObject>.Move(tryrequestsPending);
                }

                RequestsPending = tryrequestsPending.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 17))
            {
                var tryrecentRequesters = reader.ReadVector<long>(ParserTypes.Int64);
                if (tryrecentRequesters.IsError)
                {
                    return ReadResult<IObject>.Move(tryrecentRequesters);
                }

                RecentRequesters = tryrecentRequesters.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 18))
            {
                var tryavailableReactions = reader.ReadVector<string>(ParserTypes.String, nakedVector: false, nakedObjects: false);
                if (tryavailableReactions.IsError)
                {
                    return ReadResult<IObject>.Move(tryavailableReactions);
                }

                AvailableReactions = tryavailableReactions.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "chatFull";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ChatFull();
            newClonedObject.Flags = Flags;
            newClonedObject.CanSetUsername = CanSetUsername;
            newClonedObject.HasScheduled = HasScheduled;
            newClonedObject.Id = Id;
            newClonedObject.About = About;
            var cloneParticipants = (CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantsBase?)Participants.Clone();
            if (cloneParticipants is null)
            {
                return null;
            }

            newClonedObject.Participants = cloneParticipants;
            if (ChatPhoto is not null)
            {
                var cloneChatPhoto = (CatraProto.Client.TL.Schemas.CloudChats.PhotoBase?)ChatPhoto.Clone();
                if (cloneChatPhoto is null)
                {
                    return null;
                }

                newClonedObject.ChatPhoto = cloneChatPhoto;
            }

            var cloneNotifySettings = (CatraProto.Client.TL.Schemas.CloudChats.PeerNotifySettingsBase?)NotifySettings.Clone();
            if (cloneNotifySettings is null)
            {
                return null;
            }

            newClonedObject.NotifySettings = cloneNotifySettings;
            if (ExportedInvite is not null)
            {
                var cloneExportedInvite = (CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase?)ExportedInvite.Clone();
                if (cloneExportedInvite is null)
                {
                    return null;
                }

                newClonedObject.ExportedInvite = cloneExportedInvite;
            }

            if (BotInfo is not null)
            {
                newClonedObject.BotInfo = new List<CatraProto.Client.TL.Schemas.CloudChats.BotInfoBase>();
                foreach (var botInfo in BotInfo)
                {
                    var clonebotInfo = (CatraProto.Client.TL.Schemas.CloudChats.BotInfoBase?)botInfo.Clone();
                    if (clonebotInfo is null)
                    {
                        return null;
                    }

                    newClonedObject.BotInfo.Add(clonebotInfo);
                }
            }

            newClonedObject.PinnedMsgId = PinnedMsgId;
            newClonedObject.FolderId = FolderId;
            if (Call is not null)
            {
                var cloneCall = (CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase?)Call.Clone();
                if (cloneCall is null)
                {
                    return null;
                }

                newClonedObject.Call = cloneCall;
            }

            newClonedObject.TtlPeriod = TtlPeriod;
            if (GroupcallDefaultJoinAs is not null)
            {
                var cloneGroupcallDefaultJoinAs = (CatraProto.Client.TL.Schemas.CloudChats.PeerBase?)GroupcallDefaultJoinAs.Clone();
                if (cloneGroupcallDefaultJoinAs is null)
                {
                    return null;
                }

                newClonedObject.GroupcallDefaultJoinAs = cloneGroupcallDefaultJoinAs;
            }

            newClonedObject.ThemeEmoticon = ThemeEmoticon;
            newClonedObject.RequestsPending = RequestsPending;
            if (RecentRequesters is not null)
            {
                newClonedObject.RecentRequesters = new List<long>();
                foreach (var recentRequesters in RecentRequesters)
                {
                    newClonedObject.RecentRequesters.Add(recentRequesters);
                }
            }

            if (AvailableReactions is not null)
            {
                newClonedObject.AvailableReactions = new List<string>();
                foreach (var availableReactions in AvailableReactions)
                {
                    newClonedObject.AvailableReactions.Add(availableReactions);
                }
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ChatFull castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (CanSetUsername != castedOther.CanSetUsername)
            {
                return true;
            }

            if (HasScheduled != castedOther.HasScheduled)
            {
                return true;
            }

            if (Id != castedOther.Id)
            {
                return true;
            }

            if (About != castedOther.About)
            {
                return true;
            }

            if (Participants.Compare(castedOther.Participants))
            {
                return true;
            }

            if (ChatPhoto is null && castedOther.ChatPhoto is not null || ChatPhoto is not null && castedOther.ChatPhoto is null)
            {
                return true;
            }

            if (ChatPhoto is not null && castedOther.ChatPhoto is not null && ChatPhoto.Compare(castedOther.ChatPhoto))
            {
                return true;
            }

            if (NotifySettings.Compare(castedOther.NotifySettings))
            {
                return true;
            }

            if (ExportedInvite is null && castedOther.ExportedInvite is not null || ExportedInvite is not null && castedOther.ExportedInvite is null)
            {
                return true;
            }

            if (ExportedInvite is not null && castedOther.ExportedInvite is not null && ExportedInvite.Compare(castedOther.ExportedInvite))
            {
                return true;
            }

            if (BotInfo is null && castedOther.BotInfo is not null || BotInfo is not null && castedOther.BotInfo is null)
            {
                return true;
            }

            if (BotInfo is not null && castedOther.BotInfo is not null)
            {
                var botInfosize = castedOther.BotInfo.Count;
                if (botInfosize != BotInfo.Count)
                {
                    return true;
                }

                for (var i = 0; i < botInfosize; i++)
                {
                    if (castedOther.BotInfo[i].Compare(BotInfo[i]))
                    {
                        return true;
                    }
                }
            }

            if (PinnedMsgId != castedOther.PinnedMsgId)
            {
                return true;
            }

            if (FolderId != castedOther.FolderId)
            {
                return true;
            }

            if (Call is null && castedOther.Call is not null || Call is not null && castedOther.Call is null)
            {
                return true;
            }

            if (Call is not null && castedOther.Call is not null && Call.Compare(castedOther.Call))
            {
                return true;
            }

            if (TtlPeriod != castedOther.TtlPeriod)
            {
                return true;
            }

            if (GroupcallDefaultJoinAs is null && castedOther.GroupcallDefaultJoinAs is not null || GroupcallDefaultJoinAs is not null && castedOther.GroupcallDefaultJoinAs is null)
            {
                return true;
            }

            if (GroupcallDefaultJoinAs is not null && castedOther.GroupcallDefaultJoinAs is not null && GroupcallDefaultJoinAs.Compare(castedOther.GroupcallDefaultJoinAs))
            {
                return true;
            }

            if (ThemeEmoticon != castedOther.ThemeEmoticon)
            {
                return true;
            }

            if (RequestsPending != castedOther.RequestsPending)
            {
                return true;
            }

            if (RecentRequesters is null && castedOther.RecentRequesters is not null || RecentRequesters is not null && castedOther.RecentRequesters is null)
            {
                return true;
            }

            if (RecentRequesters is not null && castedOther.RecentRequesters is not null)
            {
                var recentRequesterssize = castedOther.RecentRequesters.Count;
                if (recentRequesterssize != RecentRequesters.Count)
                {
                    return true;
                }

                for (var i = 0; i < recentRequesterssize; i++)
                {
                    if (castedOther.RecentRequesters[i] != RecentRequesters[i])
                    {
                        return true;
                    }
                }
            }

            if (AvailableReactions is null && castedOther.AvailableReactions is not null || AvailableReactions is not null && castedOther.AvailableReactions is null)
            {
                return true;
            }

            if (AvailableReactions is not null && castedOther.AvailableReactions is not null)
            {
                var availableReactionssize = castedOther.AvailableReactions.Count;
                if (availableReactionssize != AvailableReactions.Count)
                {
                    return true;
                }

                for (var i = 0; i < availableReactionssize; i++)
                {
                    if (castedOther.AvailableReactions[i] != AvailableReactions[i])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

#nullable disable
    }
}