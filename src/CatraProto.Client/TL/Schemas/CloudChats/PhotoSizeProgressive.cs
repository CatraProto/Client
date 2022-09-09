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
    public partial class PhotoSizeProgressive : CatraProto.Client.TL.Schemas.CloudChats.PhotoSizeBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -96535659; }

        [Newtonsoft.Json.JsonProperty("type")] public sealed override string Type { get; set; }

        [Newtonsoft.Json.JsonProperty("w")] public int W { get; set; }

        [Newtonsoft.Json.JsonProperty("h")] public int H { get; set; }

        [Newtonsoft.Json.JsonProperty("sizes")]
        public List<int> Sizes { get; set; }


#nullable enable
        public PhotoSizeProgressive(string type, int w, int h, List<int> sizes)
        {
            Type = type;
            W = w;
            H = h;
            Sizes = sizes;
        }
#nullable disable
        internal PhotoSizeProgressive()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Type);
            writer.WriteInt32(W);
            writer.WriteInt32(H);

            writer.WriteVector(Sizes, false);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trytype = reader.ReadString();
            if (trytype.IsError)
            {
                return ReadResult<IObject>.Move(trytype);
            }

            Type = trytype.Value;
            var tryw = reader.ReadInt32();
            if (tryw.IsError)
            {
                return ReadResult<IObject>.Move(tryw);
            }

            W = tryw.Value;
            var tryh = reader.ReadInt32();
            if (tryh.IsError)
            {
                return ReadResult<IObject>.Move(tryh);
            }

            H = tryh.Value;
            var trysizes = reader.ReadVector<int>(ParserTypes.Int);
            if (trysizes.IsError)
            {
                return ReadResult<IObject>.Move(trysizes);
            }

            Sizes = trysizes.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "photoSizeProgressive";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PhotoSizeProgressive();
            newClonedObject.Type = Type;
            newClonedObject.W = W;
            newClonedObject.H = H;
            newClonedObject.Sizes = new List<int>();
            foreach (var sizes in Sizes)
            {
                newClonedObject.Sizes.Add(sizes);
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not PhotoSizeProgressive castedOther)
            {
                return true;
            }

            if (Type != castedOther.Type)
            {
                return true;
            }

            if (W != castedOther.W)
            {
                return true;
            }

            if (H != castedOther.H)
            {
                return true;
            }

            var sizessize = castedOther.Sizes.Count;
            if (sizessize != Sizes.Count)
            {
                return true;
            }

            for (var i = 0; i < sizessize; i++)
            {
                if (castedOther.Sizes[i] != Sizes[i])
                {
                    return true;
                }
            }

            return false;
        }

#nullable disable
    }
}