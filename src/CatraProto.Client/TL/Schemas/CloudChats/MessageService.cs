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
    public partial class MessageService : CatraProto.Client.TL.Schemas.CloudChats.MessageBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Out = 1 << 1,
            Mentioned = 1 << 4,
            MediaUnread = 1 << 5,
            Silent = 1 << 13,
            Post = 1 << 14,
            Legacy = 1 << 19,
            FromId = 1 << 8,
            ReplyTo = 1 << 3,
            TtlPeriod = 1 << 25
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 721967202; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("out")] public bool Out { get; set; }

        [Newtonsoft.Json.JsonProperty("mentioned")]
        public bool Mentioned { get; set; }

        [Newtonsoft.Json.JsonProperty("media_unread")]
        public bool MediaUnread { get; set; }

        [Newtonsoft.Json.JsonProperty("silent")]
        public bool Silent { get; set; }

        [Newtonsoft.Json.JsonProperty("post")] public bool Post { get; set; }

        [Newtonsoft.Json.JsonProperty("legacy")]
        public bool Legacy { get; set; }

        [Newtonsoft.Json.JsonProperty("id")] public sealed override int Id { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("from_id")]
        public CatraProto.Client.TL.Schemas.CloudChats.PeerBase FromId { get; set; }

        [Newtonsoft.Json.JsonProperty("peer_id")]
        public CatraProto.Client.TL.Schemas.CloudChats.PeerBase PeerId { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("reply_to")]
        public CatraProto.Client.TL.Schemas.CloudChats.MessageReplyHeaderBase ReplyTo { get; set; }

        [Newtonsoft.Json.JsonProperty("date")] public int Date { get; set; }

        [Newtonsoft.Json.JsonProperty("action")]
        public CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase Action { get; set; }

        [Newtonsoft.Json.JsonProperty("ttl_period")]
        public int? TtlPeriod { get; set; }


#nullable enable
        public MessageService(int id, CatraProto.Client.TL.Schemas.CloudChats.PeerBase peerId, int date, CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase action)
        {
            Id = id;
            PeerId = peerId;
            Date = date;
            Action = action;
        }
#nullable disable
        internal MessageService()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Out ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = Mentioned ? FlagsHelper.SetFlag(Flags, 4) : FlagsHelper.UnsetFlag(Flags, 4);
            Flags = MediaUnread ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
            Flags = Silent ? FlagsHelper.SetFlag(Flags, 13) : FlagsHelper.UnsetFlag(Flags, 13);
            Flags = Post ? FlagsHelper.SetFlag(Flags, 14) : FlagsHelper.UnsetFlag(Flags, 14);
            Flags = Legacy ? FlagsHelper.SetFlag(Flags, 19) : FlagsHelper.UnsetFlag(Flags, 19);
            Flags = FromId == null ? FlagsHelper.UnsetFlag(Flags, 8) : FlagsHelper.SetFlag(Flags, 8);
            Flags = ReplyTo == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
            Flags = TtlPeriod == null ? FlagsHelper.UnsetFlag(Flags, 25) : FlagsHelper.SetFlag(Flags, 25);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt32(Id);
            if (FlagsHelper.IsFlagSet(Flags, 8))
            {
                var checkfromId = writer.WriteObject(FromId);
                if (checkfromId.IsError)
                {
                    return checkfromId;
                }
            }

            var checkpeerId = writer.WriteObject(PeerId);
            if (checkpeerId.IsError)
            {
                return checkpeerId;
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                var checkreplyTo = writer.WriteObject(ReplyTo);
                if (checkreplyTo.IsError)
                {
                    return checkreplyTo;
                }
            }

            writer.WriteInt32(Date);
            var checkaction = writer.WriteObject(Action);
            if (checkaction.IsError)
            {
                return checkaction;
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
            Post = FlagsHelper.IsFlagSet(Flags, 14);
            Legacy = FlagsHelper.IsFlagSet(Flags, 19);
            var tryid = reader.ReadInt32();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }

            Id = tryid.Value;
            if (FlagsHelper.IsFlagSet(Flags, 8))
            {
                var tryfromId = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
                if (tryfromId.IsError)
                {
                    return ReadResult<IObject>.Move(tryfromId);
                }

                FromId = tryfromId.Value;
            }

            var trypeerId = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
            if (trypeerId.IsError)
            {
                return ReadResult<IObject>.Move(trypeerId);
            }

            PeerId = trypeerId.Value;
            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                var tryreplyTo = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.MessageReplyHeaderBase>();
                if (tryreplyTo.IsError)
                {
                    return ReadResult<IObject>.Move(tryreplyTo);
                }

                ReplyTo = tryreplyTo.Value;
            }

            var trydate = reader.ReadInt32();
            if (trydate.IsError)
            {
                return ReadResult<IObject>.Move(trydate);
            }

            Date = trydate.Value;
            var tryaction = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase>();
            if (tryaction.IsError)
            {
                return ReadResult<IObject>.Move(tryaction);
            }

            Action = tryaction.Value;
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
            return "messageService";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new MessageService();
            newClonedObject.Flags = Flags;
            newClonedObject.Out = Out;
            newClonedObject.Mentioned = Mentioned;
            newClonedObject.MediaUnread = MediaUnread;
            newClonedObject.Silent = Silent;
            newClonedObject.Post = Post;
            newClonedObject.Legacy = Legacy;
            newClonedObject.Id = Id;
            if (FromId is not null)
            {
                var cloneFromId = (CatraProto.Client.TL.Schemas.CloudChats.PeerBase?)FromId.Clone();
                if (cloneFromId is null)
                {
                    return null;
                }

                newClonedObject.FromId = cloneFromId;
            }

            var clonePeerId = (CatraProto.Client.TL.Schemas.CloudChats.PeerBase?)PeerId.Clone();
            if (clonePeerId is null)
            {
                return null;
            }

            newClonedObject.PeerId = clonePeerId;
            if (ReplyTo is not null)
            {
                var cloneReplyTo = (CatraProto.Client.TL.Schemas.CloudChats.MessageReplyHeaderBase?)ReplyTo.Clone();
                if (cloneReplyTo is null)
                {
                    return null;
                }

                newClonedObject.ReplyTo = cloneReplyTo;
            }

            newClonedObject.Date = Date;
            var cloneAction = (CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase?)Action.Clone();
            if (cloneAction is null)
            {
                return null;
            }

            newClonedObject.Action = cloneAction;
            newClonedObject.TtlPeriod = TtlPeriod;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not MessageService castedOther)
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

            if (Post != castedOther.Post)
            {
                return true;
            }

            if (Legacy != castedOther.Legacy)
            {
                return true;
            }

            if (Id != castedOther.Id)
            {
                return true;
            }

            if (FromId is null && castedOther.FromId is not null || FromId is not null && castedOther.FromId is null)
            {
                return true;
            }

            if (FromId is not null && castedOther.FromId is not null && FromId.Compare(castedOther.FromId))
            {
                return true;
            }

            if (PeerId.Compare(castedOther.PeerId))
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

            if (Date != castedOther.Date)
            {
                return true;
            }

            if (Action.Compare(castedOther.Action))
            {
                return true;
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