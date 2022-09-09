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
    public partial class InvokeWithLayer : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -627372787; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("layer")]
        public int Layer { get; set; }

        [Newtonsoft.Json.JsonProperty("query")]
        public IObject Query { get; set; }


#nullable enable
        public InvokeWithLayer(int layer, IObject query)
        {
            Layer = layer;
            Query = query;
        }
#nullable disable

        internal InvokeWithLayer()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Layer);
            var checkquery = writer.WriteObject(Query);
            if (checkquery.IsError)
            {
                return checkquery;
            }

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trylayer = reader.ReadInt32();
            if (trylayer.IsError)
            {
                return ReadResult<IObject>.Move(trylayer);
            }

            Layer = trylayer.Value;
            var tryquery = reader.ReadObject<IObject>();
            if (tryquery.IsError)
            {
                return ReadResult<IObject>.Move(tryquery);
            }

            Query = tryquery.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "invokeWithLayer";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new InvokeWithLayer();
            newClonedObject.Layer = Layer;
            newClonedObject.Query = Query;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not InvokeWithLayer castedOther)
            {
                return true;
            }

            if (Layer != castedOther.Layer)
            {
                return true;
            }

            if (Query != castedOther.Query)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}