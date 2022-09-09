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
    public partial class GetLanguage : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1784243458; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("lang_pack")]
        public string LangPack { get; set; }

        [Newtonsoft.Json.JsonProperty("lang_code")]
        public string LangCode { get; set; }


#nullable enable
        public GetLanguage(string langPack, string langCode)
        {
            LangPack = langPack;
            LangCode = langCode;
        }
#nullable disable

        internal GetLanguage()
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
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "langpack.getLanguage";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetLanguage();
            newClonedObject.LangPack = LangPack;
            newClonedObject.LangCode = LangCode;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not GetLanguage castedOther)
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

            return false;
        }
#nullable disable
    }
}