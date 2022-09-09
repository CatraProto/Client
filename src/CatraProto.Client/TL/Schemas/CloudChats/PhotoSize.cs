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
    public partial class PhotoSize : CatraProto.Client.TL.Schemas.CloudChats.PhotoSizeBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1976012384; }

        [Newtonsoft.Json.JsonProperty("type")] public sealed override string Type { get; set; }

        [Newtonsoft.Json.JsonProperty("w")] public int W { get; set; }

        [Newtonsoft.Json.JsonProperty("h")] public int H { get; set; }

        [Newtonsoft.Json.JsonProperty("size")] public int Size { get; set; }


#nullable enable
        public PhotoSize(string type, int w, int h, int size)
        {
            Type = type;
            W = w;
            H = h;
            Size = size;
        }
#nullable disable
        internal PhotoSize()
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
            writer.WriteInt32(Size);

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
            var trysize = reader.ReadInt32();
            if (trysize.IsError)
            {
                return ReadResult<IObject>.Move(trysize);
            }

            Size = trysize.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "photoSize";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PhotoSize();
            newClonedObject.Type = Type;
            newClonedObject.W = W;
            newClonedObject.H = H;
            newClonedObject.Size = Size;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not PhotoSize castedOther)
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

            if (Size != castedOther.Size)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}