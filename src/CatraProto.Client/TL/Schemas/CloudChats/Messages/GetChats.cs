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
    public partial class GetChats : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1240027791; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("id")] public List<long> Id { get; set; }


#nullable enable
        public GetChats(List<long> id)
        {
            Id = id;
        }
#nullable disable

        internal GetChats()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteVector(Id, false);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryid = reader.ReadVector<long>(ParserTypes.Int64);
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }

            Id = tryid.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.getChats";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetChats();
            newClonedObject.Id = new List<long>();
            foreach (var id in Id)
            {
                newClonedObject.Id.Add(id);
            }

            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not GetChats castedOther)
            {
                return true;
            }

            var idsize = castedOther.Id.Count;
            if (idsize != Id.Count)
            {
                return true;
            }

            for (var i = 0; i < idsize; i++)
            {
                if (castedOther.Id[i] != Id[i])
                {
                    return true;
                }
            }

            return false;
        }
#nullable disable
    }
}