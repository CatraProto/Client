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
    public partial class ReplyInlineMarkup : CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1218642516; }

        [Newtonsoft.Json.JsonProperty("rows")] public List<CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonRowBase> Rows { get; set; }


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

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ReplyInlineMarkup();
            newClonedObject.Rows = new List<CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonRowBase>();
            foreach (var rows in Rows)
            {
                var clonerows = (CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonRowBase?)rows.Clone();
                if (clonerows is null)
                {
                    return null;
                }

                newClonedObject.Rows.Add(clonerows);
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ReplyInlineMarkup castedOther)
            {
                return true;
            }

            var rowssize = castedOther.Rows.Count;
            if (rowssize != Rows.Count)
            {
                return true;
            }

            for (var i = 0; i < rowssize; i++)
            {
                if (castedOther.Rows[i].Compare(Rows[i]))
                {
                    return true;
                }
            }

            return false;
        }

#nullable disable
    }
}