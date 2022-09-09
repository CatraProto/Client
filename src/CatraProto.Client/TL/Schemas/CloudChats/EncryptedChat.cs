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
    public partial class EncryptedChat : CatraProto.Client.TL.Schemas.CloudChats.EncryptedChatBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1643173063; }

        [Newtonsoft.Json.JsonProperty("id")] public sealed override int Id { get; set; }

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


#nullable enable
        public EncryptedChat(int id, long accessHash, int date, long adminId, long participantId, byte[] gAOrB, long keyFingerprint)
        {
            Id = id;
            AccessHash = accessHash;
            Date = date;
            AdminId = adminId;
            ParticipantId = participantId;
            GAOrB = gAOrB;
            KeyFingerprint = keyFingerprint;
        }
#nullable disable
        internal EncryptedChat()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Id);
            writer.WriteInt64(AccessHash);
            writer.WriteInt32(Date);
            writer.WriteInt64(AdminId);
            writer.WriteInt64(ParticipantId);

            writer.WriteBytes(GAOrB);
            writer.WriteInt64(KeyFingerprint);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryid = reader.ReadInt32();
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
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "encryptedChat";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new EncryptedChat();
            newClonedObject.Id = Id;
            newClonedObject.AccessHash = AccessHash;
            newClonedObject.Date = Date;
            newClonedObject.AdminId = AdminId;
            newClonedObject.ParticipantId = ParticipantId;
            newClonedObject.GAOrB = GAOrB;
            newClonedObject.KeyFingerprint = KeyFingerprint;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not EncryptedChat castedOther)
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

            return false;
        }

#nullable disable
    }
}