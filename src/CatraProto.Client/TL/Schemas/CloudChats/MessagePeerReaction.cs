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
    public partial class MessagePeerReaction : CatraProto.Client.TL.Schemas.CloudChats.MessagePeerReactionBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Big = 1 << 0,
            Unread = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1370914559; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("big")] public sealed override bool Big { get; set; }

        [Newtonsoft.Json.JsonProperty("unread")]
        public sealed override bool Unread { get; set; }

        [Newtonsoft.Json.JsonProperty("peer_id")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.PeerBase PeerId { get; set; }

        [Newtonsoft.Json.JsonProperty("reaction")]
        public sealed override string Reaction { get; set; }


#nullable enable
        public MessagePeerReaction(CatraProto.Client.TL.Schemas.CloudChats.PeerBase peerId, string reaction)
        {
            PeerId = peerId;
            Reaction = reaction;
        }
#nullable disable
        internal MessagePeerReaction()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Big ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = Unread ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkpeerId = writer.WriteObject(PeerId);
            if (checkpeerId.IsError)
            {
                return checkpeerId;
            }

            writer.WriteString(Reaction);

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
            Big = FlagsHelper.IsFlagSet(Flags, 0);
            Unread = FlagsHelper.IsFlagSet(Flags, 1);
            var trypeerId = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
            if (trypeerId.IsError)
            {
                return ReadResult<IObject>.Move(trypeerId);
            }

            PeerId = trypeerId.Value;
            var tryreaction = reader.ReadString();
            if (tryreaction.IsError)
            {
                return ReadResult<IObject>.Move(tryreaction);
            }

            Reaction = tryreaction.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messagePeerReaction";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new MessagePeerReaction();
            newClonedObject.Flags = Flags;
            newClonedObject.Big = Big;
            newClonedObject.Unread = Unread;
            var clonePeerId = (CatraProto.Client.TL.Schemas.CloudChats.PeerBase?)PeerId.Clone();
            if (clonePeerId is null)
            {
                return null;
            }

            newClonedObject.PeerId = clonePeerId;
            newClonedObject.Reaction = Reaction;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not MessagePeerReaction castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Big != castedOther.Big)
            {
                return true;
            }

            if (Unread != castedOther.Unread)
            {
                return true;
            }

            if (PeerId.Compare(castedOther.PeerId))
            {
                return true;
            }

            if (Reaction != castedOther.Reaction)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}