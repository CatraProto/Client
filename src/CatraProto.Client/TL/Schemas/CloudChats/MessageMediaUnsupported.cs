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
    public partial class MessageMediaUnsupported : CatraProto.Client.TL.Schemas.CloudChats.MessageMediaBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1618676578; }


        public MessageMediaUnsupported()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messageMediaUnsupported";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new MessageMediaUnsupported();
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not MessageMediaUnsupported castedOther)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}