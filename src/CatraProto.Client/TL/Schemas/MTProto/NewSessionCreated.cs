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
    public partial class NewSessionCreated : CatraProto.Client.TL.Schemas.MTProto.NewSessionBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1631450872; }

        [Newtonsoft.Json.JsonProperty("first_msg_id")]
        public sealed override long FirstMsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("unique_id")]
        public sealed override long UniqueId { get; set; }

        [Newtonsoft.Json.JsonProperty("server_salt")]
        public sealed override long ServerSalt { get; set; }


#nullable enable
        public NewSessionCreated(long firstMsgId, long uniqueId, long serverSalt)
        {
            FirstMsgId = firstMsgId;
            UniqueId = uniqueId;
            ServerSalt = serverSalt;
        }
#nullable disable
        internal NewSessionCreated()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(FirstMsgId);
            writer.WriteInt64(UniqueId);
            writer.WriteInt64(ServerSalt);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryfirstMsgId = reader.ReadInt64();
            if (tryfirstMsgId.IsError)
            {
                return ReadResult<IObject>.Move(tryfirstMsgId);
            }

            FirstMsgId = tryfirstMsgId.Value;
            var tryuniqueId = reader.ReadInt64();
            if (tryuniqueId.IsError)
            {
                return ReadResult<IObject>.Move(tryuniqueId);
            }

            UniqueId = tryuniqueId.Value;
            var tryserverSalt = reader.ReadInt64();
            if (tryserverSalt.IsError)
            {
                return ReadResult<IObject>.Move(tryserverSalt);
            }

            ServerSalt = tryserverSalt.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "new_session_created";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new NewSessionCreated();
            newClonedObject.FirstMsgId = FirstMsgId;
            newClonedObject.UniqueId = UniqueId;
            newClonedObject.ServerSalt = ServerSalt;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not NewSessionCreated castedOther)
            {
                return true;
            }

            if (FirstMsgId != castedOther.FirstMsgId)
            {
                return true;
            }

            if (UniqueId != castedOther.UniqueId)
            {
                return true;
            }

            if (ServerSalt != castedOther.ServerSalt)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}