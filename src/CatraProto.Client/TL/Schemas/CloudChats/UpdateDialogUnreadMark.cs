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
    public partial class UpdateDialogUnreadMark : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Unread = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -513517117; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("unread")]
        public bool Unread { get; set; }

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.DialogPeerBase Peer { get; set; }


#nullable enable
        public UpdateDialogUnreadMark(CatraProto.Client.TL.Schemas.CloudChats.DialogPeerBase peer)
        {
            Peer = peer;
        }
#nullable disable
        internal UpdateDialogUnreadMark()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Unread ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkpeer = writer.WriteObject(Peer);
            if (checkpeer.IsError)
            {
                return checkpeer;
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
            Unread = FlagsHelper.IsFlagSet(Flags, 0);
            var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.DialogPeerBase>();
            if (trypeer.IsError)
            {
                return ReadResult<IObject>.Move(trypeer);
            }

            Peer = trypeer.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "updateDialogUnreadMark";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateDialogUnreadMark();
            newClonedObject.Flags = Flags;
            newClonedObject.Unread = Unread;
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.DialogPeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }

            newClonedObject.Peer = clonePeer;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateDialogUnreadMark castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Unread != castedOther.Unread)
            {
                return true;
            }

            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}