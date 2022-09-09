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
    public partial class Ping : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 2059302892; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("ping_id")]
        public long PingId { get; set; }


#nullable enable
        public Ping(long pingId)
        {
            PingId = pingId;
        }
#nullable disable

        internal Ping()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(PingId);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trypingId = reader.ReadInt64();
            if (trypingId.IsError)
            {
                return ReadResult<IObject>.Move(trypingId);
            }

            PingId = trypingId.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "ping";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new Ping();
            newClonedObject.PingId = PingId;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not Ping castedOther)
            {
                return true;
            }

            if (PingId != castedOther.PingId)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}