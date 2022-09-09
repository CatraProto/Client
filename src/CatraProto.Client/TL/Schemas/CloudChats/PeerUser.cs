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
    public partial class PeerUser : CatraProto.Client.TL.Schemas.CloudChats.PeerBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1498486562; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public long UserId { get; set; }


#nullable enable
        public PeerUser(long userId)
        {
            UserId = userId;
        }
#nullable disable
        internal PeerUser()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(UserId);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryuserId = reader.ReadInt64();
            if (tryuserId.IsError)
            {
                return ReadResult<IObject>.Move(tryuserId);
            }

            UserId = tryuserId.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "peerUser";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PeerUser();
            newClonedObject.UserId = UserId;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not PeerUser castedOther)
            {
                return true;
            }

            if (UserId != castedOther.UserId)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}