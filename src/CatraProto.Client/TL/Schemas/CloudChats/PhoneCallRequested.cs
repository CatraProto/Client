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
    public partial class PhoneCallRequested : CatraProto.Client.TL.Schemas.CloudChats.PhoneCallBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Video = 1 << 6
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 347139340; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("video")]
        public bool Video { get; set; }

        [Newtonsoft.Json.JsonProperty("id")] public sealed override long Id { get; set; }

        [Newtonsoft.Json.JsonProperty("access_hash")]
        public long AccessHash { get; set; }

        [Newtonsoft.Json.JsonProperty("date")] public int Date { get; set; }

        [Newtonsoft.Json.JsonProperty("admin_id")]
        public long AdminId { get; set; }

        [Newtonsoft.Json.JsonProperty("participant_id")]
        public long ParticipantId { get; set; }

        [Newtonsoft.Json.JsonProperty("g_a_hash")]
        public byte[] GAHash { get; set; }

        [Newtonsoft.Json.JsonProperty("protocol")]
        public CatraProto.Client.TL.Schemas.CloudChats.PhoneCallProtocolBase Protocol { get; set; }


#nullable enable
        public PhoneCallRequested(long id, long accessHash, int date, long adminId, long participantId, byte[] gAHash, CatraProto.Client.TL.Schemas.CloudChats.PhoneCallProtocolBase protocol)
        {
            Id = id;
            AccessHash = accessHash;
            Date = date;
            AdminId = adminId;
            ParticipantId = participantId;
            GAHash = gAHash;
            Protocol = protocol;
        }
#nullable disable
        internal PhoneCallRequested()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Video ? FlagsHelper.SetFlag(Flags, 6) : FlagsHelper.UnsetFlag(Flags, 6);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt64(Id);
            writer.WriteInt64(AccessHash);
            writer.WriteInt32(Date);
            writer.WriteInt64(AdminId);
            writer.WriteInt64(ParticipantId);

            writer.WriteBytes(GAHash);
            var checkprotocol = writer.WriteObject(Protocol);
            if (checkprotocol.IsError)
            {
                return checkprotocol;
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
            Video = FlagsHelper.IsFlagSet(Flags, 6);
            var tryid = reader.ReadInt64();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }

            Id = tryid.Value;
            var tryaccessHash = reader.ReadInt64();
            if (tryaccessHash.IsError)
            {
                return ReadResult<IObject>.Move(tryaccessHash);
            }

            AccessHash = tryaccessHash.Value;
            var trydate = reader.ReadInt32();
            if (trydate.IsError)
            {
                return ReadResult<IObject>.Move(trydate);
            }

            Date = trydate.Value;
            var tryadminId = reader.ReadInt64();
            if (tryadminId.IsError)
            {
                return ReadResult<IObject>.Move(tryadminId);
            }

            AdminId = tryadminId.Value;
            var tryparticipantId = reader.ReadInt64();
            if (tryparticipantId.IsError)
            {
                return ReadResult<IObject>.Move(tryparticipantId);
            }

            ParticipantId = tryparticipantId.Value;
            var trygAHash = reader.ReadBytes();
            if (trygAHash.IsError)
            {
                return ReadResult<IObject>.Move(trygAHash);
            }

            GAHash = trygAHash.Value;
            var tryprotocol = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PhoneCallProtocolBase>();
            if (tryprotocol.IsError)
            {
                return ReadResult<IObject>.Move(tryprotocol);
            }

            Protocol = tryprotocol.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "phoneCallRequested";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PhoneCallRequested();
            newClonedObject.Flags = Flags;
            newClonedObject.Video = Video;
            newClonedObject.Id = Id;
            newClonedObject.AccessHash = AccessHash;
            newClonedObject.Date = Date;
            newClonedObject.AdminId = AdminId;
            newClonedObject.ParticipantId = ParticipantId;
            newClonedObject.GAHash = GAHash;
            var cloneProtocol = (CatraProto.Client.TL.Schemas.CloudChats.PhoneCallProtocolBase?)Protocol.Clone();
            if (cloneProtocol is null)
            {
                return null;
            }

            newClonedObject.Protocol = cloneProtocol;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not PhoneCallRequested castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Video != castedOther.Video)
            {
                return true;
            }

            if (Id != castedOther.Id)
            {
                return true;
            }

            if (AccessHash != castedOther.AccessHash)
            {
                return true;
            }

            if (Date != castedOther.Date)
            {
                return true;
            }

            if (AdminId != castedOther.AdminId)
            {
                return true;
            }

            if (ParticipantId != castedOther.ParticipantId)
            {
                return true;
            }

            if (GAHash != castedOther.GAHash)
            {
                return true;
            }

            if (Protocol.Compare(castedOther.Protocol))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}