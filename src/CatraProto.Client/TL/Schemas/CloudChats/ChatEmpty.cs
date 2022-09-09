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
    public partial class ChatEmpty : CatraProto.Client.TL.Schemas.CloudChats.ChatBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 693512293; }

        [Newtonsoft.Json.JsonProperty("id")] public sealed override long Id { get; set; }


#nullable enable
        public ChatEmpty(long id)
        {
            Id = id;
        }
#nullable disable
        internal ChatEmpty()
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
            return "chatEmpty";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ChatEmpty();
            newClonedObject.Id = Id;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ChatEmpty castedOther)
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