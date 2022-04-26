using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class CheckHistoryImport : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1140726259; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

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
            var newClonedObject = new CheckHistoryImport
            {
                ImportHead = ImportHead
            };
            return newClonedObject;

        }
#nullable disable
    }
}