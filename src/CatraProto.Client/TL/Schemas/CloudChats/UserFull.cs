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
    public partial class UserFull : CatraProto.Client.TL.Schemas.CloudChats.UserFullBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Blocked = 1 << 0,
            PhoneCallsAvailable = 1 << 4,
            PhoneCallsPrivate = 1 << 5,
            CanPinMessage = 1 << 7,
            HasScheduled = 1 << 12,
            VideoCallsAvailable = 1 << 13,
            About = 1 << 1,
            ProfilePhoto = 1 << 2,
            BotInfo = 1 << 3,
            PinnedMsgId = 1 << 6,
            FolderId = 1 << 11,
            TtlPeriod = 1 << 14,
            ThemeEmoticon = 1 << 15,
            PrivateForwardName = 1 << 16,
            BotGroupAdminRights = 1 << 17,
            BotBroadcastAdminRights = 1 << 18
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1938625919; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("blocked")]
        public sealed override bool Blocked { get; set; }

        [Newtonsoft.Json.JsonProperty("phone_calls_available")]
        public sealed override bool PhoneCallsAvailable { get; set; }

        [Newtonsoft.Json.JsonProperty("phone_calls_private")]
        public sealed override bool PhoneCallsPrivate { get; set; }

        [Newtonsoft.Json.JsonProperty("can_pin_message")]
        public sealed override bool CanPinMessage { get; set; }

        [Newtonsoft.Json.JsonProperty("has_scheduled")]
        public sealed override bool HasScheduled { get; set; }

        [Newtonsoft.Json.JsonProperty("video_calls_available")]
        public sealed override bool VideoCallsAvailable { get; set; }

        [Newtonsoft.Json.JsonProperty("id")] public sealed override long Id { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("about")]
        public sealed override string About { get; set; }

        [Newtonsoft.Json.JsonProperty("settings")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.PeerSettingsBase Settings { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("profile_photo")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.PhotoBase ProfilePhoto { get; set; }

        [Newtonsoft.Json.JsonProperty("notify_settings")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.PeerNotifySettingsBase NotifySettings { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("bot_info")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.BotInfoBase BotInfo { get; set; }

        [Newtonsoft.Json.JsonProperty("pinned_msg_id")]
        public sealed override int? PinnedMsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("common_chats_count")]
        public sealed override int CommonChatsCount { get; set; }

        [Newtonsoft.Json.JsonProperty("folder_id")]
        public sealed override int? FolderId { get; set; }

        [Newtonsoft.Json.JsonProperty("ttl_period")]
        public sealed override int? TtlPeriod { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("theme_emoticon")]
        public sealed override string ThemeEmoticon { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("private_forward_name")]
        public sealed override string PrivateForwardName { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("bot_group_admin_rights")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.ChatAdminRightsBase BotGroupAdminRights { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("bot_broadcast_admin_rights")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.ChatAdminRightsBase BotBroadcastAdminRights { get; set; }


#nullable enable
        public UserFull(long id, CatraProto.Client.TL.Schemas.CloudChats.PeerSettingsBase settings, CatraProto.Client.TL.Schemas.CloudChats.PeerNotifySettingsBase notifySettings, int commonChatsCount)
        {
            Id = id;
            Settings = settings;
            NotifySettings = notifySettings;
            CommonChatsCount = commonChatsCount;
        }
#nullable disable
        internal UserFull()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Blocked ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = PhoneCallsAvailable ? FlagsHelper.SetFlag(Flags, 4) : FlagsHelper.UnsetFlag(Flags, 4);
            Flags = PhoneCallsPrivate ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
            Flags = CanPinMessage ? FlagsHelper.SetFlag(Flags, 7) : FlagsHelper.UnsetFlag(Flags, 7);
            Flags = HasScheduled ? FlagsHelper.SetFlag(Flags, 12) : FlagsHelper.UnsetFlag(Flags, 12);
            Flags = VideoCallsAvailable ? FlagsHelper.SetFlag(Flags, 13) : FlagsHelper.UnsetFlag(Flags, 13);
            Flags = About == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = ProfilePhoto == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
            Flags = BotInfo == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
            Flags = PinnedMsgId == null ? FlagsHelper.UnsetFlag(Flags, 6) : FlagsHelper.SetFlag(Flags, 6);
            Flags = FolderId == null ? FlagsHelper.UnsetFlag(Flags, 11) : FlagsHelper.SetFlag(Flags, 11);
            Flags = TtlPeriod == null ? FlagsHelper.UnsetFlag(Flags, 14) : FlagsHelper.SetFlag(Flags, 14);
            Flags = ThemeEmoticon == null ? FlagsHelper.UnsetFlag(Flags, 15) : FlagsHelper.SetFlag(Flags, 15);
            Flags = PrivateForwardName == null ? FlagsHelper.UnsetFlag(Flags, 16) : FlagsHelper.SetFlag(Flags, 16);
            Flags = BotGroupAdminRights == null ? FlagsHelper.UnsetFlag(Flags, 17) : FlagsHelper.SetFlag(Flags, 17);
            Flags = BotBroadcastAdminRights == null ? FlagsHelper.UnsetFlag(Flags, 18) : FlagsHelper.SetFlag(Flags, 18);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt64(Id);
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.WriteString(About);
            }

            var checksettings = writer.WriteObject(Settings);
            if (checksettings.IsError)
            {
                return checksettings;
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var checkprofilePhoto = writer.WriteObject(ProfilePhoto);
                if (checkprofilePhoto.IsError)
                {
                    return checkprofilePhoto;
                }
            }

            var checknotifySettings = writer.WriteObject(NotifySettings);
            if (checknotifySettings.IsError)
            {
                return checknotifySettings;
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                var checkbotInfo = writer.WriteObject(BotInfo);
                if (checkbotInfo.IsError)
                {
                    return checkbotInfo;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 6))
            {
                writer.WriteInt32(PinnedMsgId.Value);
            }

            writer.WriteInt32(CommonChatsCount);
            if (FlagsHelper.IsFlagSet(Flags, 11))
            {
                writer.WriteInt32(FolderId.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 14))
            {
                writer.WriteInt32(TtlPeriod.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 15))
            {
                writer.WriteString(ThemeEmoticon);
            }

            if (FlagsHelper.IsFlagSet(Flags, 16))
            {
                writer.WriteString(PrivateForwardName);
            }

            if (FlagsHelper.IsFlagSet(Flags, 17))
            {
                var checkbotGroupAdminRights = writer.WriteObject(BotGroupAdminRights);
                if (checkbotGroupAdminRights.IsError)
                {
                    return checkbotGroupAdminRights;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 18))
            {
                var checkbotBroadcastAdminRights = writer.WriteObject(BotBroadcastAdminRights);
                if (checkbotBroadcastAdminRights.IsError)
                {
                    return checkbotBroadcastAdminRights;
                }
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
            Blocked = FlagsHelper.IsFlagSet(Flags, 0);
            PhoneCallsAvailable = FlagsHelper.IsFlagSet(Flags, 4);
            PhoneCallsPrivate = FlagsHelper.IsFlagSet(Flags, 5);
            CanPinMessage = FlagsHelper.IsFlagSet(Flags, 7);
            HasScheduled = FlagsHelper.IsFlagSet(Flags, 12);
            VideoCallsAvailable = FlagsHelper.IsFlagSet(Flags, 13);
            var tryid = reader.ReadInt64();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }

            Id = tryid.Value;
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var tryabout = reader.ReadString();
                if (tryabout.IsError)
                {
                    return ReadResult<IObject>.Move(tryabout);
                }

                About = tryabout.Value;
            }

            var trysettings = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PeerSettingsBase>();
            if (trysettings.IsError)
            {
                return ReadResult<IObject>.Move(trysettings);
            }

            Settings = trysettings.Value;
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var tryprofilePhoto = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PhotoBase>();
                if (tryprofilePhoto.IsError)
                {
                    return ReadResult<IObject>.Move(tryprofilePhoto);
                }

                ProfilePhoto = tryprofilePhoto.Value;
            }

            var trynotifySettings = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PeerNotifySettingsBase>();
            if (trynotifySettings.IsError)
            {
                return ReadResult<IObject>.Move(trynotifySettings);
            }

            NotifySettings = trynotifySettings.Value;
            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                var trybotInfo = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.BotInfoBase>();
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

            var trycommonChatsCount = reader.ReadInt32();
            if (trycommonChatsCount.IsError)
            {
                return ReadResult<IObject>.Move(trycommonChatsCount);
            }

            CommonChatsCount = trycommonChatsCount.Value;
            if (FlagsHelper.IsFlagSet(Flags, 11))
            {
                var tryfolderId = reader.ReadInt32();
                if (tryfolderId.IsError)
                {
                    return ReadResult<IObject>.Move(tryfolderId);
                }

                FolderId = tryfolderId.Value;
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
                var trythemeEmoticon = reader.ReadString();
                if (trythemeEmoticon.IsError)
                {
                    return ReadResult<IObject>.Move(trythemeEmoticon);
                }

                ThemeEmoticon = trythemeEmoticon.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 16))
            {
                var tryprivateForwardName = reader.ReadString();
                if (tryprivateForwardName.IsError)
                {
                    return ReadResult<IObject>.Move(tryprivateForwardName);
                }

                PrivateForwardName = tryprivateForwardName.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 17))
            {
                var trybotGroupAdminRights = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ChatAdminRightsBase>();
                if (trybotGroupAdminRights.IsError)
                {
                    return ReadResult<IObject>.Move(trybotGroupAdminRights);
                }

                BotGroupAdminRights = trybotGroupAdminRights.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 18))
            {
                var trybotBroadcastAdminRights = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ChatAdminRightsBase>();
                if (trybotBroadcastAdminRights.IsError)
                {
                    return ReadResult<IObject>.Move(trybotBroadcastAdminRights);
                }

                BotBroadcastAdminRights = trybotBroadcastAdminRights.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "userFull";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UserFull();
            newClonedObject.Flags = Flags;
            newClonedObject.Blocked = Blocked;
            newClonedObject.PhoneCallsAvailable = PhoneCallsAvailable;
            newClonedObject.PhoneCallsPrivate = PhoneCallsPrivate;
            newClonedObject.CanPinMessage = CanPinMessage;
            newClonedObject.HasScheduled = HasScheduled;
            newClonedObject.VideoCallsAvailable = VideoCallsAvailable;
            newClonedObject.Id = Id;
            newClonedObject.About = About;
            var cloneSettings = (CatraProto.Client.TL.Schemas.CloudChats.PeerSettingsBase?)Settings.Clone();
            if (cloneSettings is null)
            {
                return null;
            }

            newClonedObject.Settings = cloneSettings;
            if (ProfilePhoto is not null)
            {
                var cloneProfilePhoto = (CatraProto.Client.TL.Schemas.CloudChats.PhotoBase?)ProfilePhoto.Clone();
                if (cloneProfilePhoto is null)
                {
                    return null;
                }

                newClonedObject.ProfilePhoto = cloneProfilePhoto;
            }

            var cloneNotifySettings = (CatraProto.Client.TL.Schemas.CloudChats.PeerNotifySettingsBase?)NotifySettings.Clone();
            if (cloneNotifySettings is null)
            {
                return null;
            }

            newClonedObject.NotifySettings = cloneNotifySettings;
            if (BotInfo is not null)
            {
                var cloneBotInfo = (CatraProto.Client.TL.Schemas.CloudChats.BotInfoBase?)BotInfo.Clone();
                if (cloneBotInfo is null)
                {
                    return null;
                }

                newClonedObject.BotInfo = cloneBotInfo;
            }

            newClonedObject.PinnedMsgId = PinnedMsgId;
            newClonedObject.CommonChatsCount = CommonChatsCount;
            newClonedObject.FolderId = FolderId;
            newClonedObject.TtlPeriod = TtlPeriod;
            newClonedObject.ThemeEmoticon = ThemeEmoticon;
            newClonedObject.PrivateForwardName = PrivateForwardName;
            if (BotGroupAdminRights is not null)
            {
                var cloneBotGroupAdminRights = (CatraProto.Client.TL.Schemas.CloudChats.ChatAdminRightsBase?)BotGroupAdminRights.Clone();
                if (cloneBotGroupAdminRights is null)
                {
                    return null;
                }

                newClonedObject.BotGroupAdminRights = cloneBotGroupAdminRights;
            }

            if (BotBroadcastAdminRights is not null)
            {
                var cloneBotBroadcastAdminRights = (CatraProto.Client.TL.Schemas.CloudChats.ChatAdminRightsBase?)BotBroadcastAdminRights.Clone();
                if (cloneBotBroadcastAdminRights is null)
                {
                    return null;
                }

                newClonedObject.BotBroadcastAdminRights = cloneBotBroadcastAdminRights;
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not UserFull castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Blocked != castedOther.Blocked)
            {
                return true;
            }

            if (PhoneCallsAvailable != castedOther.PhoneCallsAvailable)
            {
                return true;
            }

            if (PhoneCallsPrivate != castedOther.PhoneCallsPrivate)
            {
                return true;
            }

            if (CanPinMessage != castedOther.CanPinMessage)
            {
                return true;
            }

            if (HasScheduled != castedOther.HasScheduled)
            {
                return true;
            }

            if (VideoCallsAvailable != castedOther.VideoCallsAvailable)
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

            if (Settings.Compare(castedOther.Settings))
            {
                return true;
            }

            if (ProfilePhoto is null && castedOther.ProfilePhoto is not null || ProfilePhoto is not null && castedOther.ProfilePhoto is null)
            {
                return true;
            }

            if (ProfilePhoto is not null && castedOther.ProfilePhoto is not null && ProfilePhoto.Compare(castedOther.ProfilePhoto))
            {
                return true;
            }

            if (NotifySettings.Compare(castedOther.NotifySettings))
            {
                return true;
            }

            if (BotInfo is null && castedOther.BotInfo is not null || BotInfo is not null && castedOther.BotInfo is null)
            {
                return true;
            }

            if (BotInfo is not null && castedOther.BotInfo is not null && BotInfo.Compare(castedOther.BotInfo))
            {
                return true;
            }

            if (PinnedMsgId != castedOther.PinnedMsgId)
            {
                return true;
            }

            if (CommonChatsCount != castedOther.CommonChatsCount)
            {
                return true;
            }

            if (FolderId != castedOther.FolderId)
            {
                return true;
            }

            if (TtlPeriod != castedOther.TtlPeriod)
            {
                return true;
            }

            if (ThemeEmoticon != castedOther.ThemeEmoticon)
            {
                return true;
            }

            if (PrivateForwardName != castedOther.PrivateForwardName)
            {
                return true;
            }

            if (BotGroupAdminRights is null && castedOther.BotGroupAdminRights is not null || BotGroupAdminRights is not null && castedOther.BotGroupAdminRights is null)
            {
                return true;
            }

            if (BotGroupAdminRights is not null && castedOther.BotGroupAdminRights is not null && BotGroupAdminRights.Compare(castedOther.BotGroupAdminRights))
            {
                return true;
            }

            if (BotBroadcastAdminRights is null && castedOther.BotBroadcastAdminRights is not null || BotBroadcastAdminRights is not null && castedOther.BotBroadcastAdminRights is null)
            {
                return true;
            }

            if (BotBroadcastAdminRights is not null && castedOther.BotBroadcastAdminRights is not null && BotBroadcastAdminRights.Compare(castedOther.BotBroadcastAdminRights))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}