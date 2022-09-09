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
    public partial class PhoneCall : CatraProto.Client.TL.Schemas.CloudChats.PhoneCallBase
    {
        [Flags]
        public enum FlagsEnum
        {
            P2pAllowed = 1 << 5,
            Video = 1 << 6
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1770029977; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("p2p_allowed")]
        public bool P2pAllowed { get; set; }

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

        [Newtonsoft.Json.JsonProperty("g_a_or_b")]
        public byte[] GAOrB { get; set; }

        [Newtonsoft.Json.JsonProperty("key_fingerprint")]
        public long KeyFingerprint { get; set; }

        [Newtonsoft.Json.JsonProperty("protocol")]
        public CatraProto.Client.TL.Schemas.CloudChats.PhoneCallProtocolBase Protocol { get; set; }

        [Newtonsoft.Json.JsonProperty("connections")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.PhoneConnectionBase> Connections { get; set; }

        [Newtonsoft.Json.JsonProperty("start_date")]
        public int StartDate { get; set; }


#nullable enable
        public PhoneCall(long id, long accessHash, int date, long adminId, long participantId, byte[] gAOrB, long keyFingerprint, CatraProto.Client.TL.Schemas.CloudChats.PhoneCallProtocolBase protocol, List<CatraProto.Client.TL.Schemas.CloudChats.PhoneConnectionBase> connections, int startDate)
        {
            Id = id;
            AccessHash = accessHash;
            Date = date;
            AdminId = adminId;
            ParticipantId = participantId;
            GAOrB = gAOrB;
            KeyFingerprint = keyFingerprint;
            Protocol = protocol;
            Connections = connections;
            StartDate = startDate;
        }
#nullable disable
        internal PhoneCall()
        {
        }

        public override void UpdateFlags()
        {
            Flags = P2pAllowed ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
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

            writer.WriteBytes(GAOrB);
            writer.WriteInt64(KeyFingerprint);
            var checkprotocol = writer.WriteObject(Protocol);
            if (checkprotocol.IsError)
            {
                return checkprotocol;
            }

            var checkconnections = writer.WriteVector(Connections, false);
            if (checkconnections.IsError)
            {
                return checkconnections;
            }

            writer.WriteInt32(StartDate);

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
            P2pAllowed = FlagsHelper.IsFlagSet(Flags, 5);
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
            var trygAOrB = reader.ReadBytes();
            if (trygAOrB.IsError)
            {
                return ReadResult<IObject>.Move(trygAOrB);
            }

            GAOrB = trygAOrB.Value;
            var trykeyFingerprint = reader.ReadInt64();
            if (trykeyFingerprint.IsError)
            {
                return ReadResult<IObject>.Move(trykeyFingerprint);
            }

            KeyFingerprint = trykeyFingerprint.Value;
            var tryprotocol = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PhoneCallProtocolBase>();
            if (tryprotocol.IsError)
            {
                return ReadResult<IObject>.Move(tryprotocol);
            }

            Protocol = tryprotocol.Value;
            var tryconnections = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PhoneConnectionBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryconnections.IsError)
            {
                return ReadResult<IObject>.Move(tryconnections);
            }

            Connections = tryconnections.Value;
            var trystartDate = reader.ReadInt32();
            if (trystartDate.IsError)
            {
                return ReadResult<IObject>.Move(trystartDate);
            }

            StartDate = trystartDate.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "phoneCall";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PhoneCall();
            newClonedObject.Flags = Flags;
            newClonedObject.P2pAllowed = P2pAllowed;
            newClonedObject.Video = Video;
            newClonedObject.Id = Id;
            newClonedObject.AccessHash = AccessHash;
            newClonedObject.Date = Date;
            newClonedObject.AdminId = AdminId;
            newClonedObject.ParticipantId = ParticipantId;
            newClonedObject.GAOrB = GAOrB;
            newClonedObject.KeyFingerprint = KeyFingerprint;
            var cloneProtocol = (CatraProto.Client.TL.Schemas.CloudChats.PhoneCallProtocolBase?)Protocol.Clone();
            if (cloneProtocol is null)
            {
                return null;
            }

            newClonedObject.Protocol = cloneProtocol;
            newClonedObject.Connections = new List<CatraProto.Client.TL.Schemas.CloudChats.PhoneConnectionBase>();
            foreach (var connections in Connections)
            {
                var cloneconnections = (CatraProto.Client.TL.Schemas.CloudChats.PhoneConnectionBase?)connections.Clone();
                if (cloneconnections is null)
                {
                    return null;
                }

                newClonedObject.Connections.Add(cloneconnections);
            }

            newClonedObject.StartDate = StartDate;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not PhoneCall castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (P2pAllowed != castedOther.P2pAllowed)
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

            if (GAOrB != castedOther.GAOrB)
            {
                return true;
            }

            if (KeyFingerprint != castedOther.KeyFingerprint)
            {
                return true;
            }

            if (Protocol.Compare(castedOther.Protocol))
            {
                return true;
            }

            var connectionssize = castedOther.Connections.Count;
            if (connectionssize != Connections.Count)
            {
                return true;
            }

            for (var i = 0; i < connectionssize; i++)
            {
                if (castedOther.Connections[i].Compare(Connections[i]))
                {
                    return true;
                }
            }

            if (StartDate != castedOther.StartDate)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}