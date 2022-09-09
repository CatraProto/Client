using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class GetThemes : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1913054296; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("format")]
        public string Format { get; set; }

        [Newtonsoft.Json.JsonProperty("hash")] public long Hash { get; set; }


#nullable enable
        public GetThemes(string format, long hash)
        {
            Format = format;
            Hash = hash;
        }
#nullable disable

        internal GetThemes()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Format);
            writer.WriteInt64(Hash);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryformat = reader.ReadString();
            if (tryformat.IsError)
            {
                return ReadResult<IObject>.Move(tryformat);
            }

            Format = tryformat.Value;
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
            return "account.getThemes";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetThemes();
            newClonedObject.Format = Format;
            newClonedObject.Hash = Hash;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not GetThemes castedOther)
            {
                return true;
            }

            if (Format != castedOther.Format)
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