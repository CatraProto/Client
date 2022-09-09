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
    public partial class GetLanguages : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1120311183; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("lang_pack")]
        public string LangPack { get; set; }


#nullable enable
        public GetLanguages(string langPack)
        {
            LangPack = langPack;
        }
#nullable disable

        internal GetLanguages()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(LangPack);

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
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "langpack.getLanguages";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetLanguages();
            newClonedObject.LangPack = LangPack;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not GetLanguages castedOther)
            {
                return true;
            }

            if (LangPack != castedOther.LangPack)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}