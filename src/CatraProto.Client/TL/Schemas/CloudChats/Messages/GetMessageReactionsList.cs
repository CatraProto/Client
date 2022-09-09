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
    public partial class GetMessageReactionsList : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Reaction = 1 << 0,
            Offset = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -521245833; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("id")] public int Id { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("reaction")]
        public string Reaction { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("offset")]
        public string Offset { get; set; }

        [Newtonsoft.Json.JsonProperty("limit")]
        public int Limit { get; set; }


#nullable enable
        public GetMessageReactionsList(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int id, int limit)
        {
            Peer = peer;
            Id = id;
            Limit = limit;
        }
#nullable disable

        internal GetMessageReactionsList()
        {
        }

        public void UpdateFlags()
        {
            Flags = Reaction == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = Offset == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkpeer = writer.WriteObject(Peer);
            if (checkpeer.IsError)
            {
                return checkpeer;
            }

            writer.WriteInt32(Id);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteString(Reaction);
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.WriteString(Offset);
            }

            writer.WriteInt32(Limit);

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
            var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
            if (trypeer.IsError)
            {
                return ReadResult<IObject>.Move(trypeer);
            }

            Peer = trypeer.Value;
            var tryid = reader.ReadInt32();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }

            Id = tryid.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryreaction = reader.ReadString();
                if (tryreaction.IsError)
                {
                    return ReadResult<IObject>.Move(tryreaction);
                }

                Reaction = tryreaction.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var tryoffset = reader.ReadString();
                if (tryoffset.IsError)
                {
                    return ReadResult<IObject>.Move(tryoffset);
                }

                Offset = tryoffset.Value;
            }

            var trylimit = reader.ReadInt32();
            if (trylimit.IsError)
            {
                return ReadResult<IObject>.Move(trylimit);
            }

            Limit = trylimit.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.getMessageReactionsList";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetMessageReactionsList();
            newClonedObject.Flags = Flags;
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }

            newClonedObject.Peer = clonePeer;
            newClonedObject.Id = Id;
            newClonedObject.Reaction = Reaction;
            newClonedObject.Offset = Offset;
            newClonedObject.Limit = Limit;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not GetMessageReactionsList castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }

            if (Id != castedOther.Id)
            {
                return true;
            }

            if (Reaction != castedOther.Reaction)
            {
                return true;
            }

            if (Offset != castedOther.Offset)
            {
                return true;
            }

            if (Limit != castedOther.Limit)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}