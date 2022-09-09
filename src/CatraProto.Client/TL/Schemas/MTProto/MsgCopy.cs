using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public partial class MsgCopy : CatraProto.Client.TL.Schemas.MTProto.MessageCopyBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -530561358; }

        [Newtonsoft.Json.JsonProperty("orig_message")]
        public sealed override CatraProto.Client.TL.Schemas.MTProto.MessageBase OrigMessage { get; set; }


#nullable enable
        public MsgCopy(CatraProto.Client.TL.Schemas.MTProto.MessageBase origMessage)
        {
            OrigMessage = origMessage;
        }
#nullable disable
        internal MsgCopy()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkorigMessage = writer.WriteObject(OrigMessage);
            if (checkorigMessage.IsError)
            {
                return checkorigMessage;
            }

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryorigMessage = reader.ReadObject<CatraProto.Client.TL.Schemas.MTProto.MessageBase>();
            if (tryorigMessage.IsError)
            {
                return ReadResult<IObject>.Move(tryorigMessage);
            }

            OrigMessage = tryorigMessage.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "msg_copy";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new MsgCopy();
            var cloneOrigMessage = (CatraProto.Client.TL.Schemas.MTProto.MessageBase?)OrigMessage.Clone();
            if (cloneOrigMessage is null)
            {
                return null;
            }

            newClonedObject.OrigMessage = cloneOrigMessage;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not MsgCopy castedOther)
            {
                return true;
            }

            if (OrigMessage.Compare(castedOther.OrigMessage))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}