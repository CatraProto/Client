using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class TextConcat : CatraProto.Client.TL.Schemas.CloudChats.RichTextBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 2120376535; }

        [Newtonsoft.Json.JsonProperty("texts")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.RichTextBase> Texts { get; set; }


#nullable enable
        public TextConcat(List<CatraProto.Client.TL.Schemas.CloudChats.RichTextBase> texts)
        {
            Texts = texts;

        }
#nullable disable
        internal TextConcat()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checktexts = writer.WriteVector(Texts, false);
            if (checktexts.IsError)
            {
                return checktexts;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trytexts = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.RichTextBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trytexts.IsError)
            {
                return ReadResult<IObject>.Move(trytexts);
            }
            Texts = trytexts.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "textConcat";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}