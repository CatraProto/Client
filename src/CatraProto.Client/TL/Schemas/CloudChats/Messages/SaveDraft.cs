using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class SaveDraft : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            NoWebpage = 1 << 1,
            ReplyToMsgId = 1 << 0,
            Entities = 1 << 3
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1137057461; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("no_webpage")]
        public bool NoWebpage { get; set; }

        [Newtonsoft.Json.JsonProperty("reply_to_msg_id")]
        public int? ReplyToMsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("message")]
        public string Message { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("entities")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> Entities { get; set; }


#nullable enable
        public SaveDraft(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, string message)
        {
            Peer = peer;
            Message = message;
        }
#nullable disable

        internal SaveDraft()
        {
        }

        public void UpdateFlags()
        {
            Flags = NoWebpage ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = ReplyToMsgId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = Entities == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteInt32(ReplyToMsgId.Value);
            }

            var checkpeer = writer.WriteObject(Peer);
            if (checkpeer.IsError)
            {
                return checkpeer;
            }

            writer.WriteString(Message);
            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                var checkentities = writer.WriteVector(Entities, false);
                if (checkentities.IsError)
                {
                    return checkentities;
                }
            }


            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }

            Flags = tryflags.Value;
            NoWebpage = FlagsHelper.IsFlagSet(Flags, 1);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryreplyToMsgId = reader.ReadInt32();
                if (tryreplyToMsgId.IsError)
                {
                    return ReadResult<IObject>.Move(tryreplyToMsgId);
                }

                ReplyToMsgId = tryreplyToMsgId.Value;
            }

            var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
            if (trypeer.IsError)
            {
                return ReadResult<IObject>.Move(trypeer);
            }

            Peer = trypeer.Value;
            var trymessage = reader.ReadString();
            if (trymessage.IsError)
            {
                return ReadResult<IObject>.Move(trymessage);
            }

            Message = trymessage.Value;
            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                var tryentities = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
                if (tryentities.IsError)
                {
                    return ReadResult<IObject>.Move(tryentities);
                }

                Entities = tryentities.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.saveDraft";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new SaveDraft();
            newClonedObject.Flags = Flags;
            newClonedObject.NoWebpage = NoWebpage;
            newClonedObject.ReplyToMsgId = ReplyToMsgId;
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }

            newClonedObject.Peer = clonePeer;
            newClonedObject.Message = Message;
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

            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not SaveDraft castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (NoWebpage != castedOther.NoWebpage)
            {
                return true;
            }

            if (ReplyToMsgId != castedOther.ReplyToMsgId)
            {
                return true;
            }

            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }

            if (Message != castedOther.Message)
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

            return false;
        }
#nullable disable
    }
}