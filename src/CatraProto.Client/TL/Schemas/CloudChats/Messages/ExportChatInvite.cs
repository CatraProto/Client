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
    public partial class ExportChatInvite : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            LegacyRevokePermanent = 1 << 2,
            RequestNeeded = 1 << 3,
            ExpireDate = 1 << 0,
            UsageLimit = 1 << 1,
            Title = 1 << 4
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1607670315; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("legacy_revoke_permanent")]
        public bool LegacyRevokePermanent { get; set; }

        [Newtonsoft.Json.JsonProperty("request_needed")]
        public bool RequestNeeded { get; set; }

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("expire_date")]
        public int? ExpireDate { get; set; }

        [Newtonsoft.Json.JsonProperty("usage_limit")]
        public int? UsageLimit { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("title")]
        public string Title { get; set; }


#nullable enable
        public ExportChatInvite(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer)
        {
            Peer = peer;
        }
#nullable disable

        internal ExportChatInvite()
        {
        }

        public void UpdateFlags()
        {
            Flags = LegacyRevokePermanent ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
            Flags = RequestNeeded ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
            Flags = ExpireDate == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = UsageLimit == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = Title == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
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

            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteInt32(ExpireDate.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.WriteInt32(UsageLimit.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                writer.WriteString(Title);
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
            LegacyRevokePermanent = FlagsHelper.IsFlagSet(Flags, 2);
            RequestNeeded = FlagsHelper.IsFlagSet(Flags, 3);
            var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
            if (trypeer.IsError)
            {
                return ReadResult<IObject>.Move(trypeer);
            }

            Peer = trypeer.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryexpireDate = reader.ReadInt32();
                if (tryexpireDate.IsError)
                {
                    return ReadResult<IObject>.Move(tryexpireDate);
                }

                ExpireDate = tryexpireDate.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var tryusageLimit = reader.ReadInt32();
                if (tryusageLimit.IsError)
                {
                    return ReadResult<IObject>.Move(tryusageLimit);
                }

                UsageLimit = tryusageLimit.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                var trytitle = reader.ReadString();
                if (trytitle.IsError)
                {
                    return ReadResult<IObject>.Move(trytitle);
                }

                Title = trytitle.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.exportChatInvite";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new ExportChatInvite();
            newClonedObject.Flags = Flags;
            newClonedObject.LegacyRevokePermanent = LegacyRevokePermanent;
            newClonedObject.RequestNeeded = RequestNeeded;
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }

            newClonedObject.Peer = clonePeer;
            newClonedObject.ExpireDate = ExpireDate;
            newClonedObject.UsageLimit = UsageLimit;
            newClonedObject.Title = Title;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not ExportChatInvite castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (LegacyRevokePermanent != castedOther.LegacyRevokePermanent)
            {
                return true;
            }

            if (RequestNeeded != castedOther.RequestNeeded)
            {
                return true;
            }

            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }

            if (ExpireDate != castedOther.ExpireDate)
            {
                return true;
            }

            if (UsageLimit != castedOther.UsageLimit)
            {
                return true;
            }

            if (Title != castedOther.Title)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}