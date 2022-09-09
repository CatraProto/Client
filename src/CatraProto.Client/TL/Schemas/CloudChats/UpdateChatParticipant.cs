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
    public partial class UpdateChatParticipant : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Flags]
        public enum FlagsEnum
        {
            PrevParticipant = 1 << 0,
            NewParticipant = 1 << 1,
            Invite = 1 << 2
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -796432838; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("chat_id")]
        public long ChatId { get; set; }

        [Newtonsoft.Json.JsonProperty("date")] public int Date { get; set; }

        [Newtonsoft.Json.JsonProperty("actor_id")]
        public long ActorId { get; set; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public long UserId { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("prev_participant")]
        public CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantBase PrevParticipant { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("new_participant")]
        public CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantBase NewParticipant { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("invite")]
        public CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase Invite { get; set; }

        [Newtonsoft.Json.JsonProperty("qts")] public int Qts { get; set; }


#nullable enable
        public UpdateChatParticipant(long chatId, int date, long actorId, long userId, int qts)
        {
            ChatId = chatId;
            Date = date;
            ActorId = actorId;
            UserId = userId;
            Qts = qts;
        }
#nullable disable
        internal UpdateChatParticipant()
        {
        }

        public override void UpdateFlags()
        {
            Flags = PrevParticipant == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = NewParticipant == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = Invite == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt64(ChatId);
            writer.WriteInt32(Date);
            writer.WriteInt64(ActorId);
            writer.WriteInt64(UserId);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var checkprevParticipant = writer.WriteObject(PrevParticipant);
                if (checkprevParticipant.IsError)
                {
                    return checkprevParticipant;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var checknewParticipant = writer.WriteObject(NewParticipant);
                if (checknewParticipant.IsError)
                {
                    return checknewParticipant;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var checkinvite = writer.WriteObject(Invite);
                if (checkinvite.IsError)
                {
                    return checkinvite;
                }
            }

            writer.WriteInt32(Qts);

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
            var trychatId = reader.ReadInt64();
            if (trychatId.IsError)
            {
                return ReadResult<IObject>.Move(trychatId);
            }

            ChatId = trychatId.Value;
            var trydate = reader.ReadInt32();
            if (trydate.IsError)
            {
                return ReadResult<IObject>.Move(trydate);
            }

            Date = trydate.Value;
            var tryactorId = reader.ReadInt64();
            if (tryactorId.IsError)
            {
                return ReadResult<IObject>.Move(tryactorId);
            }

            ActorId = tryactorId.Value;
            var tryuserId = reader.ReadInt64();
            if (tryuserId.IsError)
            {
                return ReadResult<IObject>.Move(tryuserId);
            }

            UserId = tryuserId.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryprevParticipant = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantBase>();
                if (tryprevParticipant.IsError)
                {
                    return ReadResult<IObject>.Move(tryprevParticipant);
                }

                PrevParticipant = tryprevParticipant.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var trynewParticipant = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantBase>();
                if (trynewParticipant.IsError)
                {
                    return ReadResult<IObject>.Move(trynewParticipant);
                }

                NewParticipant = trynewParticipant.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var tryinvite = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase>();
                if (tryinvite.IsError)
                {
                    return ReadResult<IObject>.Move(tryinvite);
                }

                Invite = tryinvite.Value;
            }

            var tryqts = reader.ReadInt32();
            if (tryqts.IsError)
            {
                return ReadResult<IObject>.Move(tryqts);
            }

            Qts = tryqts.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "updateChatParticipant";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateChatParticipant();
            newClonedObject.Flags = Flags;
            newClonedObject.ChatId = ChatId;
            newClonedObject.Date = Date;
            newClonedObject.ActorId = ActorId;
            newClonedObject.UserId = UserId;
            if (PrevParticipant is not null)
            {
                var clonePrevParticipant = (CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantBase?)PrevParticipant.Clone();
                if (clonePrevParticipant is null)
                {
                    return null;
                }

                newClonedObject.PrevParticipant = clonePrevParticipant;
            }

            if (NewParticipant is not null)
            {
                var cloneNewParticipant = (CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantBase?)NewParticipant.Clone();
                if (cloneNewParticipant is null)
                {
                    return null;
                }

                newClonedObject.NewParticipant = cloneNewParticipant;
            }

            if (Invite is not null)
            {
                var cloneInvite = (CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase?)Invite.Clone();
                if (cloneInvite is null)
                {
                    return null;
                }

                newClonedObject.Invite = cloneInvite;
            }

            newClonedObject.Qts = Qts;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateChatParticipant castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (ChatId != castedOther.ChatId)
            {
                return true;
            }

            if (Date != castedOther.Date)
            {
                return true;
            }

            if (ActorId != castedOther.ActorId)
            {
                return true;
            }

            if (UserId != castedOther.UserId)
            {
                return true;
            }

            if (PrevParticipant is null && castedOther.PrevParticipant is not null || PrevParticipant is not null && castedOther.PrevParticipant is null)
            {
                return true;
            }

            if (PrevParticipant is not null && castedOther.PrevParticipant is not null && PrevParticipant.Compare(castedOther.PrevParticipant))
            {
                return true;
            }

            if (NewParticipant is null && castedOther.NewParticipant is not null || NewParticipant is not null && castedOther.NewParticipant is null)
            {
                return true;
            }

            if (NewParticipant is not null && castedOther.NewParticipant is not null && NewParticipant.Compare(castedOther.NewParticipant))
            {
                return true;
            }

            if (Invite is null && castedOther.Invite is not null || Invite is not null && castedOther.Invite is null)
            {
                return true;
            }

            if (Invite is not null && castedOther.Invite is not null && Invite.Compare(castedOther.Invite))
            {
                return true;
            }

            if (Qts != castedOther.Qts)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}