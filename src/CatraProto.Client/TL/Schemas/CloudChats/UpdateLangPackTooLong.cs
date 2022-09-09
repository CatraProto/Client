using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateLangPackTooLong : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1180041828; }

        [Newtonsoft.Json.JsonProperty("lang_code")]
        public string LangCode { get; set; }


#nullable enable
        public UpdateLangPackTooLong(string langCode)
        {
            LangCode = langCode;
        }
#nullable disable
        internal UpdateLangPackTooLong()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(LangCode);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
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
            return "updateLangPackTooLong";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateLangPackTooLong();
            newClonedObject.LangCode = LangCode;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateLangPackTooLong castedOther)
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