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
    public partial class ChannelParticipantSelf : CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase
    {
        [Flags]
        public enum FlagsEnum
        {
            ViaRequest = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 900251559; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("via_request")]
        public bool ViaRequest { get; set; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public long UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("inviter_id")]
        public long InviterId { get; set; }

        [Newtonsoft.Json.JsonProperty("date")] public int Date { get; set; }


#nullable enable
        public ChannelParticipantSelf(long userId, long inviterId, int date)
        {
            UserId = userId;
            InviterId = inviterId;
            Date = date;
        }
#nullable disable
        internal ChannelParticipantSelf()
        {
        }

        public override void UpdateFlags()
        {
            Flags = ViaRequest ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt64(UserId);
            writer.WriteInt64(InviterId);
            writer.WriteInt32(Date);

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
            ViaRequest = FlagsHelper.IsFlagSet(Flags, 0);
            var tryuserId = reader.ReadInt64();
            if (tryuserId.IsError)
            {
                return ReadResult<IObject>.Move(tryuserId);
            }

            UserId = tryuserId.Value;
            var tryinviterId = reader.ReadInt64();
            if (tryinviterId.IsError)
            {
                return ReadResult<IObject>.Move(tryinviterId);
            }

            InviterId = tryinviterId.Value;
            var trydate = reader.ReadInt32();
            if (trydate.IsError)
            {
                return ReadResult<IObject>.Move(trydate);
            }

            Date = trydate.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "channelParticipantSelf";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ChannelParticipantSelf();
            newClonedObject.Flags = Flags;
            newClonedObject.ViaRequest = ViaRequest;
            newClonedObject.UserId = UserId;
            newClonedObject.InviterId = InviterId;
            newClonedObject.Date = Date;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ChannelParticipantSelf castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (ViaRequest != castedOther.ViaRequest)
            {
                return true;
            }

            if (UserId != castedOther.UserId)
            {
                return true;
            }

            if (InviterId != castedOther.InviterId)
            {
                return true;
            }

            if (Date != castedOther.Date)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}