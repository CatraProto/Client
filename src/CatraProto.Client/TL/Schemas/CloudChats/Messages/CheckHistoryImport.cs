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
    public partial class CheckHistoryImport : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1140726259; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("import_head")]
        public string ImportHead { get; set; }


#nullable enable
        public CheckHistoryImport(string importHead)
        {
            ImportHead = importHead;
        }
#nullable disable

        internal CheckHistoryImport()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(ImportHead);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryimportHead = reader.ReadString();
            if (tryimportHead.IsError)
            {
                return ReadResult<IObject>.Move(tryimportHead);
            }

            ImportHead = tryimportHead.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.checkHistoryImport";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new CheckHistoryImport();
            newClonedObject.ImportHead = ImportHead;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not CheckHistoryImport castedOther)
            {
                return true;
            }

            if (ImportHead != castedOther.ImportHead)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}