using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class GetCommonChats : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -468934396; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("user_id")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("max_id")]
        public long MaxId { get; set; }

        [Newtonsoft.Json.JsonProperty("limit")]
        public int Limit { get; set; }


#nullable enable
        public GetCommonChats(CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, long maxId, int limit)
        {
            UserId = userId;
            MaxId = maxId;
            Limit = limit;
        }
#nullable disable

        internal GetCommonChats()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkuserId = writer.WriteObject(UserId);
            if (checkuserId.IsError)
            {
                return checkuserId;
            }

            writer.WriteInt64(MaxId);
            writer.WriteInt32(Limit);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryuserId = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
            if (tryuserId.IsError)
            {
                return ReadResult<IObject>.Move(tryuserId);
            }

            UserId = tryuserId.Value;
            var trymaxId = reader.ReadInt64();
            if (trymaxId.IsError)
            {
                return ReadResult<IObject>.Move(trymaxId);
            }

            MaxId = trymaxId.Value;
            var trylimit = reader.ReadInt32();
            if (trylimit.IsError)
            {
                return ReadResult<IObject>.Move(trylimit);
            }

            Limit = trylimit.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.getCommonChats";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetCommonChats();
            var cloneUserId = (CatraProto.Client.TL.Schemas.CloudChats.InputUserBase?)UserId.Clone();
            if (cloneUserId is null)
            {
                return null;
            }

            newClonedObject.UserId = cloneUserId;
            newClonedObject.MaxId = MaxId;
            newClonedObject.Limit = Limit;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not GetCommonChats castedOther)
            {
                return true;
            }

            if (UserId.Compare(castedOther.UserId))
            {
                return true;
            }

            if (MaxId != castedOther.MaxId)
            {
                return true;
            }

            if (Limit != castedOther.Limit)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}