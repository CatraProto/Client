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
    public partial class UpdateShortMessage : CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Out = 1 << 1,
            Mentioned = 1 << 4,
            MediaUnread = 1 << 5,
            Silent = 1 << 13,
            FwdFrom = 1 << 2,
            ViaBotId = 1 << 11,
            ReplyTo = 1 << 3,
            Entities = 1 << 7,
            TtlPeriod = 1 << 25
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 826001400; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("out")] public bool Out { get; set; }

        [Newtonsoft.Json.JsonProperty("mentioned")]
        public bool Mentioned { get; set; }

        [Newtonsoft.Json.JsonProperty("media_unread")]
        public bool MediaUnread { get; set; }

        [Newtonsoft.Json.JsonProperty("silent")]
        public bool Silent { get; set; }

        [Newtonsoft.Json.JsonProperty("id")] public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public long UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("message")]
        public string Message { get; set; }

        [Newtonsoft.Json.JsonProperty("pts")] public int Pts { get; set; }

        [Newtonsoft.Json.JsonProperty("pts_count")]
        public int PtsCount { get; set; }

        [Newtonsoft.Json.JsonProperty("date")] public int Date { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("fwd_from")]
        public CatraProto.Client.TL.Schemas.CloudChats.MessageFwdHeaderBase FwdFrom { get; set; }

        [Newtonsoft.Json.JsonProperty("via_bot_id")]
        public long? ViaBotId { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("reply_to")]
        public CatraProto.Client.TL.Schemas.CloudChats.MessageReplyHeaderBase ReplyTo { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("entities")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> Entities { get; set; }

        [Newtonsoft.Json.JsonProperty("ttl_period")]
        public int? TtlPeriod { get; set; }


#nullable enable
        public UpdateShortMessage(int id, long userId, string message, int pts, int ptsCount, int date)
        {
            Id = id;
            UserId = userId;
            Message = message;
            Pts = pts;
            PtsCount = ptsCount;
            Date = date;
        }
#nullable disable
        internal UpdateShortMessage()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Out ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = Mentioned ? FlagsHelper.SetFlag(Flags, 4) : FlagsHelper.UnsetFlag(Flags, 4);
            Flags = MediaUnread ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
            Flags = Silent ? FlagsHelper.SetFlag(Flags, 13) : FlagsHelper.UnsetFlag(Flags, 13);
            Flags = FwdFrom == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
            Flags = ViaBotId == null ? FlagsHelper.UnsetFlag(Flags, 11) : FlagsHelper.SetFlag(Flags, 11);
            Flags = ReplyTo == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
            Flags = Entities == null ? FlagsHelper.UnsetFlag(Flags, 7) : FlagsHelper.SetFlag(Flags, 7);
            Flags = TtlPeriod == null ? FlagsHelper.UnsetFlag(Flags, 25) : FlagsHelper.SetFlag(Flags, 25);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt32(Id);
            writer.WriteInt64(UserId);

            writer.WriteString(Message);
            writer.WriteInt32(Pts);
            writer.WriteInt32(PtsCount);
            writer.WriteInt32(Date);
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var checkfwdFrom = writer.WriteObject(FwdFrom);
                if (checkfwdFrom.IsError)
                {
                    return checkfwdFrom;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 11))
            {
                writer.WriteInt64(ViaBotId.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                var checkreplyTo = writer.WriteObject(ReplyTo);
                if (checkreplyTo.IsError)
                {
                    return checkreplyTo;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 7))
            {
                var checkentities = writer.WriteVector(Entities, false);
                if (checkentities.IsError)
                {
                    return checkentities;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 25))
            {
                writer.WriteInt32(TtlPeriod.Value);
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
            Out = FlagsHelper.IsFlagSet(Flags, 1);
            Mentioned = FlagsHelper.IsFlagSet(Flags, 4);
            MediaUnread = FlagsHelper.IsFlagSet(Flags, 5);
            Silent = FlagsHelper.IsFlagSet(Flags, 13);
            var tryid = reader.ReadInt32();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }

            Id = tryid.Value;
            var tryuserId = reader.ReadInt64();
            if (tryuserId.IsError)
            {
                return ReadResult<IObject>.Move(tryuserId);
            }

            UserId = tryuserId.Value;
            var trymessage = reader.ReadString();
            if (trymessage.IsError)
            {
                return ReadResult<IObject>.Move(trymessage);
            }

            Message = trymessage.Value;
            var trypts = reader.ReadInt32();
            if (trypts.IsError)
            {
                return ReadResult<IObject>.Move(trypts);
            }

            Pts = trypts.Value;
            var tryptsCount = reader.ReadInt32();
            if (tryptsCount.IsError)
            {
                return ReadResult<IObject>.Move(tryptsCount);
            }

            PtsCount = tryptsCount.Value;
            var trydate = reader.ReadInt32();
            if (trydate.IsError)
            {
                return ReadResult<IObject>.Move(trydate);
            }

            Date = trydate.Value;
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var tryfwdFrom = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.MessageFwdHeaderBase>();
                if (tryfwdFrom.IsError)
                {
                    return ReadResult<IObject>.Move(tryfwdFrom);
                }

                FwdFrom = tryfwdFrom.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 11))
            {
                var tryviaBotId = reader.ReadInt64();
                if (tryviaBotId.IsError)
                {
                    return ReadResult<IObject>.Move(tryviaBotId);
                }

                ViaBotId = tryviaBotId.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                var tryreplyTo = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.MessageReplyHeaderBase>();
                if (tryreplyTo.IsError)
                {
                    return ReadResult<IObject>.Move(tryreplyTo);
                }

                ReplyTo = tryreplyTo.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 7))
            {
                var tryentities = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
                if (tryentities.IsError)
                {
                    return ReadResult<IObject>.Move(tryentities);
                }

                Entities = tryentities.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 25))
            {
                var tryttlPeriod = reader.ReadInt32();
                if (tryttlPeriod.IsError)
                {
                    return ReadResult<IObject>.Move(tryttlPeriod);
                }

                TtlPeriod = tryttlPeriod.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "updateShortMessage";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateShortMessage();
            newClonedObject.Flags = Flags;
            newClonedObject.Out = Out;
            newClonedObject.Mentioned = Mentioned;
            newClonedObject.MediaUnread = MediaUnread;
            newClonedObject.Silent = Silent;
            newClonedObject.Id = Id;
            newClonedObject.UserId = UserId;
            newClonedObject.Message = Message;
            newClonedObject.Pts = Pts;
            newClonedObject.PtsCount = PtsCount;
            newClonedObject.Date = Date;
            if (FwdFrom is not null)
            {
                var cloneFwdFrom = (CatraProto.Client.TL.Schemas.CloudChats.MessageFwdHeaderBase?)FwdFrom.Clone();
                if (cloneFwdFrom is null)
                {
                    return null;
                }

                newClonedObject.FwdFrom = cloneFwdFrom;
            }

            newClonedObject.ViaBotId = ViaBotId;
            if (ReplyTo is not null)
            {
                var cloneReplyTo = (CatraProto.Client.TL.Schemas.CloudChats.MessageReplyHeaderBase?)ReplyTo.Clone();
                if (cloneReplyTo is null)
                {
                    return null;
                }

                newClonedObject.ReplyTo = cloneReplyTo;
            }

            if (Entities is not null)
            {
                newClonedObject.Entities = new List<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>();
                foreach (var entities in Entities)
                {
                    var cloneentities = (CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase?)entities.Clone();
                    if (cloneentities is null)
                    {
                        return null;
                    }

                    newClonedObject.Entities.Add(cloneentities);
                }
            }

            newClonedObject.TtlPeriod = TtlPeriod;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateShortMessage castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Out != castedOther.Out)
            {
                return true;
            }

            if (Mentioned != castedOther.Mentioned)
            {
                return true;
            }

            if (MediaUnread != castedOther.MediaUnread)
            {
                return true;
            }

            if (Silent != castedOther.Silent)
            {
                return true;
            }

            if (Id != castedOther.Id)
            {
                return true;
            }

            if (UserId != castedOther.UserId)
            {
                return true;
            }

            if (Message != castedOther.Message)
            {
                return true;
            }

            if (Pts != castedOther.Pts)
            {
                return true;
            }

            if (PtsCount != castedOther.PtsCount)
            {
                return true;
            }

            if (Date != castedOther.Date)
            {
                return true;
            }

            if (FwdFrom is null && castedOther.FwdFrom is not null || FwdFrom is not null && castedOther.FwdFrom is null)
            {
                return true;
            }

            if (FwdFrom is not null && castedOther.FwdFrom is not null && FwdFrom.Compare(castedOther.FwdFrom))
            {
                return true;
            }

            if (ViaBotId != castedOther.ViaBotId)
            {
                return true;
            }

            if (ReplyTo is null && castedOther.ReplyTo is not null || ReplyTo is not null && castedOther.ReplyTo is null)
            {
                return true;
            }

            if (ReplyTo is not null && castedOther.ReplyTo is not null && ReplyTo.Compare(castedOther.ReplyTo))
            {
                return true;
            }

            if (Entities is null && castedOther.Entities is not null || Entities is not null && castedOther.Entities is null)
            {
                return true;
            }

            if (Entities is not null && castedOther.Entities is not null)
            {
                var entitiessize = castedOther.Entities.Count;
                if (entitiessize != Entities.Count)
                {
                    return true;
                }

                for (var i = 0; i < entitiessize; i++)
                {
                    if (castedOther.Entities[i].Compare(Entities[i]))
                    {
                        return true;
                    }
                }
            }

            if (TtlPeriod != castedOther.TtlPeriod)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}