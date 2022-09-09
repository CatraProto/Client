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
    public partial class GetDhConfig : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 651135312; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("version")]
        public int Version { get; set; }

        [Newtonsoft.Json.JsonProperty("random_length")]
        public int RandomLength { get; set; }


#nullable enable
        public GetDhConfig(int version, int randomLength)
        {
            Version = version;
            RandomLength = randomLength;
        }
#nullable disable

        internal GetDhConfig()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Version);
            writer.WriteInt32(RandomLength);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryversion = reader.ReadInt32();
            if (tryversion.IsError)
            {
                return ReadResult<IObject>.Move(tryversion);
            }

            Version = tryversion.Value;
            var tryrandomLength = reader.ReadInt32();
            if (tryrandomLength.IsError)
            {
                return ReadResult<IObject>.Move(tryrandomLength);
            }

            RandomLength = tryrandomLength.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.getDhConfig";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetDhConfig();
            newClonedObject.Version = Version;
            newClonedObject.RandomLength = RandomLength;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not GetDhConfig castedOther)
            {
                return true;
            }

            if (Version != castedOther.Version)
            {
                return true;
            }

            if (RandomLength != castedOther.RandomLength)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}