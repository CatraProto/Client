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
    public partial class TextConcat : CatraProto.Client.TL.Schemas.CloudChats.RichTextBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 2120376535; }

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

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new TextConcat();
            newClonedObject.Texts = new List<CatraProto.Client.TL.Schemas.CloudChats.RichTextBase>();
            foreach (var texts in Texts)
            {
                var clonetexts = (CatraProto.Client.TL.Schemas.CloudChats.RichTextBase?)texts.Clone();
                if (clonetexts is null)
                {
                    return null;
                }

                newClonedObject.Texts.Add(clonetexts);
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not TextConcat castedOther)
            {
                return true;
            }

            var textssize = castedOther.Texts.Count;
            if (textssize != Texts.Count)
            {
                return true;
            }

            for (var i = 0; i < textssize; i++)
            {
                if (castedOther.Texts[i].Compare(Texts[i]))
                {
                    return true;
                }
            }

            return false;
        }

#nullable disable
    }
}