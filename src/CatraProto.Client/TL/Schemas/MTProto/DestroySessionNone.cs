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
    public partial class DestroySessionNone : CatraProto.Client.TL.Schemas.MTProto.DestroySessionResBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1658015945; }

        [Newtonsoft.Json.JsonProperty("session_id")]
        public sealed override long SessionId { get; set; }


#nullable enable
        public DestroySessionNone(long sessionId)
        {
            SessionId = sessionId;
        }
#nullable disable
        internal DestroySessionNone()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(SessionId);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trysessionId = reader.ReadInt64();
            if (trysessionId.IsError)
            {
                return ReadResult<IObject>.Move(trysessionId);
            }

            SessionId = trysessionId.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "destroy_session_none";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new DestroySessionNone();
            newClonedObject.SessionId = SessionId;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not DestroySessionNone castedOther)
            {
                return true;
            }

            if (SessionId != castedOther.SessionId)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}