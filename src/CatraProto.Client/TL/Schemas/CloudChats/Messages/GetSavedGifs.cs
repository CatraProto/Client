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
    public partial class GetSavedGifs : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1559270965; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("hash")] public long Hash { get; set; }


#nullable enable
        public GetSavedGifs(long hash)
        {
            Hash = hash;
        }
#nullable disable

        internal GetSavedGifs()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(Hash);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryhash = reader.ReadInt64();
            if (tryhash.IsError)
            {
                return ReadResult<IObject>.Move(tryhash);
            }

            Hash = tryhash.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.getSavedGifs";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetSavedGifs();
            newClonedObject.Hash = Hash;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not GetSavedGifs castedOther)
            {
                return true;
            }

            if (Hash != castedOther.Hash)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}