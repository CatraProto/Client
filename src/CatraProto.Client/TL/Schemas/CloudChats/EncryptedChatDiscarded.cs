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
    public partial class EncryptedChatDiscarded : CatraProto.Client.TL.Schemas.CloudChats.EncryptedChatBase
    {
        [Flags]
        public enum FlagsEnum
        {
            HistoryDeleted = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 505183301; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("history_deleted")]
        public bool HistoryDeleted { get; set; }

        [Newtonsoft.Json.JsonProperty("id")] public sealed override int Id { get; set; }


#nullable enable
        public EncryptedChatDiscarded(int id)
        {
            Id = id;
        }
#nullable disable
        internal EncryptedChatDiscarded()
        {
        }

        public override void UpdateFlags()
        {
            Flags = HistoryDeleted ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt32(Id);

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
            HistoryDeleted = FlagsHelper.IsFlagSet(Flags, 0);
            var tryid = reader.ReadInt32();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }

            Id = tryid.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "encryptedChatDiscarded";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new EncryptedChatDiscarded();
            newClonedObject.Flags = Flags;
            newClonedObject.HistoryDeleted = HistoryDeleted;
            newClonedObject.Id = Id;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not EncryptedChatDiscarded castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (HistoryDeleted != castedOther.HistoryDeleted)
            {
                return true;
            }

            if (Id != castedOther.Id)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}