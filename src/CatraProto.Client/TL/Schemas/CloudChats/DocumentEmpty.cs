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
    public partial class DocumentEmpty : CatraProto.Client.TL.Schemas.CloudChats.DocumentBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 922273905; }

        [Newtonsoft.Json.JsonProperty("id")] public sealed override long Id { get; set; }


#nullable enable
        public DocumentEmpty(long id)
        {
            Id = id;
        }
#nullable disable
        internal DocumentEmpty()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(Id);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryid = reader.ReadInt64();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }

            Id = tryid.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "documentEmpty";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new DocumentEmpty();
            newClonedObject.Id = Id;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not DocumentEmpty castedOther)
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