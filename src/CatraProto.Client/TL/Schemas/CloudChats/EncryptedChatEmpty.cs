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
    public partial class EncryptedChatEmpty : CatraProto.Client.TL.Schemas.CloudChats.EncryptedChatBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1417756512; }

        [Newtonsoft.Json.JsonProperty("id")] public sealed override int Id { get; set; }


#nullable enable
        public EncryptedChatEmpty(int id)
        {
            Id = id;
        }
#nullable disable
        internal EncryptedChatEmpty()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Id);

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
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "encryptedChatEmpty";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new EncryptedChatEmpty();
            newClonedObject.Id = Id;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not EncryptedChatEmpty castedOther)
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