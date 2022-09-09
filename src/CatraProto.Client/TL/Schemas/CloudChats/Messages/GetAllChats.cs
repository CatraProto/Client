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
    public partial class GetAllChats : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -2023787330; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("except_ids")]
        public List<long> ExceptIds { get; set; }


#nullable enable
        public GetAllChats(List<long> exceptIds)
        {
            ExceptIds = exceptIds;
        }
#nullable disable

        internal GetAllChats()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteVector(ExceptIds, false);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryexceptIds = reader.ReadVector<long>(ParserTypes.Int64);
            if (tryexceptIds.IsError)
            {
                return ReadResult<IObject>.Move(tryexceptIds);
            }

            ExceptIds = tryexceptIds.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.getAllChats";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetAllChats();
            newClonedObject.ExceptIds = new List<long>();
            foreach (var exceptIds in ExceptIds)
            {
                newClonedObject.ExceptIds.Add(exceptIds);
            }

            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not GetAllChats castedOther)
            {
                return true;
            }

            var exceptIdssize = castedOther.ExceptIds.Count;
            if (exceptIdssize != ExceptIds.Count)
            {
                return true;
            }

            for (var i = 0; i < exceptIdssize; i++)
            {
                if (castedOther.ExceptIds[i] != ExceptIds[i])
                {
                    return true;
                }
            }

            return false;
        }
#nullable disable
    }
}