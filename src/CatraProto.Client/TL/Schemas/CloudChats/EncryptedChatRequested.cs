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
    public partial class EncryptedChatRequested : CatraProto.Client.TL.Schemas.CloudChats.EncryptedChatBase
    {
        [Flags]
        public enum FlagsEnum
        {
            FolderId = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1223809356; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("folder_id")]
        public int? FolderId { get; set; }

        [Newtonsoft.Json.JsonProperty("id")] public sealed override int Id { get; set; }

        [Newtonsoft.Json.JsonProperty("access_hash")]
        public long AccessHash { get; set; }

        [Newtonsoft.Json.JsonProperty("date")] public int Date { get; set; }

        [Newtonsoft.Json.JsonProperty("admin_id")]
        public long AdminId { get; set; }

        [Newtonsoft.Json.JsonProperty("participant_id")]
        public long ParticipantId { get; set; }

        [Newtonsoft.Json.JsonProperty("g_a")] public byte[] GA { get; set; }


#nullable enable
        public EncryptedChatRequested(int id, long accessHash, int date, long adminId, long participantId, byte[] gA)
        {
            Id = id;
            AccessHash = accessHash;
            Date = date;
            AdminId = adminId;
            ParticipantId = participantId;
            GA = gA;
        }
#nullable disable
        internal EncryptedChatRequested()
        {
        }

        public override void UpdateFlags()
        {
            Flags = FolderId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.WriteInt32(FolderId.Value);
            }

            writer.WriteInt32(Id);
            writer.WriteInt64(AccessHash);
            writer.WriteInt32(Date);
            writer.WriteInt64(AdminId);
            writer.WriteInt64(ParticipantId);

            writer.WriteBytes(GA);

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
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryfolderId = reader.ReadInt32();
                if (tryfolderId.IsError)
                {
                    return ReadResult<IObject>.Move(tryfolderId);
                }

                FolderId = tryfolderId.Value;
            }

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
            var trygA = reader.ReadBytes();
            if (trygA.IsError)
            {
                return ReadResult<IObject>.Move(trygA);
            }

            GA = trygA.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "encryptedChatRequested";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new EncryptedChatRequested();
            newClonedObject.Flags = Flags;
            newClonedObject.FolderId = FolderId;
            newClonedObject.Id = Id;
            newClonedObject.AccessHash = AccessHash;
            newClonedObject.Date = Date;
            newClonedObject.AdminId = AdminId;
            newClonedObject.ParticipantId = ParticipantId;
            newClonedObject.GA = GA;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not EncryptedChatRequested castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (FolderId != castedOther.FolderId)
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

            if (GA != castedOther.GA)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}