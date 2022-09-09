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
    public partial class GetStrings : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -269862909; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("lang_pack")]
        public string LangPack { get; set; }

        [Newtonsoft.Json.JsonProperty("lang_code")]
        public string LangCode { get; set; }

        [Newtonsoft.Json.JsonProperty("keys")] public List<string> Keys { get; set; }


#nullable enable
        public GetStrings(string langPack, string langCode, List<string> keys)
        {
            LangPack = langPack;
            LangCode = langCode;
            Keys = keys;
        }
#nullable disable

        internal GetStrings()
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

            writer.WriteVector(Keys, false);

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
            var trykeys = reader.ReadVector<string>(ParserTypes.String, nakedVector: false, nakedObjects: false);
            if (trykeys.IsError)
            {
                return ReadResult<IObject>.Move(trykeys);
            }

            Keys = trykeys.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "langpack.getStrings";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetStrings();
            newClonedObject.LangPack = LangPack;
            newClonedObject.LangCode = LangCode;
            newClonedObject.Keys = new List<string>();
            foreach (var keys in Keys)
            {
                newClonedObject.Keys.Add(keys);
            }

            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not GetStrings castedOther)
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

            var keyssize = castedOther.Keys.Count;
            if (keyssize != Keys.Count)
            {
                return true;
            }

            for (var i = 0; i < keyssize; i++)
            {
                if (castedOther.Keys[i] != Keys[i])
                {
                    return true;
                }
            }

            return false;
        }
#nullable disable
    }
}