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
    public partial class PeerSettings : CatraProto.Client.TL.Schemas.CloudChats.PeerSettingsBase
    {
        [Flags]
        public enum FlagsEnum
        {
            ReportSpam = 1 << 0,
            AddContact = 1 << 1,
            BlockContact = 1 << 2,
            ShareContact = 1 << 3,
            NeedContactsException = 1 << 4,
            ReportGeo = 1 << 5,
            Autoarchived = 1 << 7,
            InviteMembers = 1 << 8,
            RequestChatBroadcast = 1 << 10,
            GeoDistance = 1 << 6,
            RequestChatTitle = 1 << 9,
            RequestChatDate = 1 << 9
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1525149427; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("report_spam")]
        public sealed override bool ReportSpam { get; set; }

        [Newtonsoft.Json.JsonProperty("add_contact")]
        public sealed override bool AddContact { get; set; }

        [Newtonsoft.Json.JsonProperty("block_contact")]
        public sealed override bool BlockContact { get; set; }

        [Newtonsoft.Json.JsonProperty("share_contact")]
        public sealed override bool ShareContact { get; set; }

        [Newtonsoft.Json.JsonProperty("need_contacts_exception")]
        public sealed override bool NeedContactsException { get; set; }

        [Newtonsoft.Json.JsonProperty("report_geo")]
        public sealed override bool ReportGeo { get; set; }

        [Newtonsoft.Json.JsonProperty("autoarchived")]
        public sealed override bool Autoarchived { get; set; }

        [Newtonsoft.Json.JsonProperty("invite_members")]
        public sealed override bool InviteMembers { get; set; }

        [Newtonsoft.Json.JsonProperty("request_chat_broadcast")]
        public sealed override bool RequestChatBroadcast { get; set; }

        [Newtonsoft.Json.JsonProperty("geo_distance")]
        public sealed override int? GeoDistance { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("request_chat_title")]
        public sealed override string RequestChatTitle { get; set; }

        [Newtonsoft.Json.JsonProperty("request_chat_date")]
        public sealed override int? RequestChatDate { get; set; }


        public PeerSettings()
        {
        }

        public override void UpdateFlags()
        {
            Flags = ReportSpam ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = AddContact ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = BlockContact ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
            Flags = ShareContact ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
            Flags = NeedContactsException ? FlagsHelper.SetFlag(Flags, 4) : FlagsHelper.UnsetFlag(Flags, 4);
            Flags = ReportGeo ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
            Flags = Autoarchived ? FlagsHelper.SetFlag(Flags, 7) : FlagsHelper.UnsetFlag(Flags, 7);
            Flags = InviteMembers ? FlagsHelper.SetFlag(Flags, 8) : FlagsHelper.UnsetFlag(Flags, 8);
            Flags = RequestChatBroadcast ? FlagsHelper.SetFlag(Flags, 10) : FlagsHelper.UnsetFlag(Flags, 10);
            Flags = GeoDistance == null ? FlagsHelper.UnsetFlag(Flags, 6) : FlagsHelper.SetFlag(Flags, 6);
            Flags = RequestChatTitle == null ? FlagsHelper.UnsetFlag(Flags, 9) : FlagsHelper.SetFlag(Flags, 9);
            Flags = RequestChatDate == null ? FlagsHelper.UnsetFlag(Flags, 9) : FlagsHelper.SetFlag(Flags, 9);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 6))
            {
                writer.WriteInt32(GeoDistance.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 9))
            {
                writer.WriteString(RequestChatTitle);
            }

            if (FlagsHelper.IsFlagSet(Flags, 9))
            {
                writer.WriteInt32(RequestChatDate.Value);
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
            ReportSpam = FlagsHelper.IsFlagSet(Flags, 0);
            AddContact = FlagsHelper.IsFlagSet(Flags, 1);
            BlockContact = FlagsHelper.IsFlagSet(Flags, 2);
            ShareContact = FlagsHelper.IsFlagSet(Flags, 3);
            NeedContactsException = FlagsHelper.IsFlagSet(Flags, 4);
            ReportGeo = FlagsHelper.IsFlagSet(Flags, 5);
            Autoarchived = FlagsHelper.IsFlagSet(Flags, 7);
            InviteMembers = FlagsHelper.IsFlagSet(Flags, 8);
            RequestChatBroadcast = FlagsHelper.IsFlagSet(Flags, 10);
            if (FlagsHelper.IsFlagSet(Flags, 6))
            {
                var trygeoDistance = reader.ReadInt32();
                if (trygeoDistance.IsError)
                {
                    return ReadResult<IObject>.Move(trygeoDistance);
                }

                GeoDistance = trygeoDistance.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 9))
            {
                var tryrequestChatTitle = reader.ReadString();
                if (tryrequestChatTitle.IsError)
                {
                    return ReadResult<IObject>.Move(tryrequestChatTitle);
                }

                RequestChatTitle = tryrequestChatTitle.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 9))
            {
                var tryrequestChatDate = reader.ReadInt32();
                if (tryrequestChatDate.IsError)
                {
                    return ReadResult<IObject>.Move(tryrequestChatDate);
                }

                RequestChatDate = tryrequestChatDate.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "peerSettings";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PeerSettings();
            newClonedObject.Flags = Flags;
            newClonedObject.ReportSpam = ReportSpam;
            newClonedObject.AddContact = AddContact;
            newClonedObject.BlockContact = BlockContact;
            newClonedObject.ShareContact = ShareContact;
            newClonedObject.NeedContactsException = NeedContactsException;
            newClonedObject.ReportGeo = ReportGeo;
            newClonedObject.Autoarchived = Autoarchived;
            newClonedObject.InviteMembers = InviteMembers;
            newClonedObject.RequestChatBroadcast = RequestChatBroadcast;
            newClonedObject.GeoDistance = GeoDistance;
            newClonedObject.RequestChatTitle = RequestChatTitle;
            newClonedObject.RequestChatDate = RequestChatDate;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not PeerSettings castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (ReportSpam != castedOther.ReportSpam)
            {
                return true;
            }

            if (AddContact != castedOther.AddContact)
            {
                return true;
            }

            if (BlockContact != castedOther.BlockContact)
            {
                return true;
            }

            if (ShareContact != castedOther.ShareContact)
            {
                return true;
            }

            if (NeedContactsException != castedOther.NeedContactsException)
            {
                return true;
            }

            if (ReportGeo != castedOther.ReportGeo)
            {
                return true;
            }

            if (Autoarchived != castedOther.Autoarchived)
            {
                return true;
            }

            if (InviteMembers != castedOther.InviteMembers)
            {
                return true;
            }

            if (RequestChatBroadcast != castedOther.RequestChatBroadcast)
            {
                return true;
            }

            if (GeoDistance != castedOther.GeoDistance)
            {
                return true;
            }

            if (RequestChatTitle != castedOther.RequestChatTitle)
            {
                return true;
            }

            if (RequestChatDate != castedOther.RequestChatDate)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}