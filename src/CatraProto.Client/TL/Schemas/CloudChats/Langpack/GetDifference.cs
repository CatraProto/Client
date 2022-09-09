using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Langpack
{
    public partial class GetDifference : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -845657435; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("lang_pack")]
        public string LangPack { get; set; }

        [Newtonsoft.Json.JsonProperty("lang_code")]
        public string LangCode { get; set; }

        [Newtonsoft.Json.JsonProperty("from_version")]
        public int FromVersion { get; set; }


#nullable enable
        public GetDifference(string langPack, string langCode, int fromVersion)
        {
            LangPack = langPack;
            LangCode = langCode;
            FromVersion = fromVersion;
        }
#nullable disable

        internal GetDifference()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(LangPack);

            writer.WriteString(LangCode);
            writer.WriteInt32(FromVersion);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trylangPack = reader.ReadString();
            if (trylangPack.IsError)
            {
                return ReadResult<IObject>.Move(trylangPack);
            }

            LangPack = trylangPack.Value;
            var trylangCode = reader.ReadString();
            if (trylangCode.IsError)
            {
                return ReadResult<IObject>.Move(trylangCode);
            }

            LangCode = trylangCode.Value;
            var tryfromVersion = reader.ReadInt32();
            if (tryfromVersion.IsError)
            {
                return ReadResult<IObject>.Move(tryfromVersion);
            }

            FromVersion = tryfromVersion.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "langpack.getDifference";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetDifference();
            newClonedObject.LangPack = LangPack;
            newClonedObject.LangCode = LangCode;
            newClonedObject.FromVersion = FromVersion;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not GetDifference castedOther)
            {
                return true;
            }

            if (LangPack != castedOther.LangPack)
            {
                return true;
            }

            if (LangCode != castedOther.LangCode)
            {
                return true;
            }

            if (FromVersion != castedOther.FromVersion)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}