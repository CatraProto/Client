using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ReplyInlineMarkup : CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1218642516; }

        [Newtonsoft.Json.JsonProperty("rows")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonRowBase> Rows { get; set; }


#nullable enable
        public ReplyInlineMarkup(List<CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonRowBase> rows)
        {
            Rows = rows;

        }
#nullable disable
        internal ReplyInlineMarkup()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkrows = writer.WriteVector(Rows, false);
            if (checkrows.IsError)
            {
                return checkrows;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryrows = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonRowBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryrows.IsError)
            {
                return ReadResult<IObject>.Move(tryrows);
            }
            Rows = tryrows.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "replyInlineMarkup";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}