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
    public partial class PhotoCachedSize : CatraProto.Client.TL.Schemas.CloudChats.PhotoSizeBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 35527382; }

        [Newtonsoft.Json.JsonProperty("type")] public sealed override string Type { get; set; }

        [Newtonsoft.Json.JsonProperty("w")] public int W { get; set; }

        [Newtonsoft.Json.JsonProperty("h")] public int H { get; set; }

        [Newtonsoft.Json.JsonProperty("bytes")]
        public byte[] Bytes { get; set; }


#nullable enable
        public PhotoCachedSize(string type, int w, int h, byte[] bytes)
        {
            Type = type;
            W = w;
            H = h;
            Bytes = bytes;
        }
#nullable disable
        internal PhotoCachedSize()
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

            writer.WriteBytes(Bytes);

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
            var trybytes = reader.ReadBytes();
            if (trybytes.IsError)
            {
                return ReadResult<IObject>.Move(trybytes);
            }

            Bytes = trybytes.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "photoCachedSize";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PhotoCachedSize();
            newClonedObject.Type = Type;
            newClonedObject.W = W;
            newClonedObject.H = H;
            newClonedObject.Bytes = Bytes;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not PhotoCachedSize castedOther)
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

            if (Bytes != castedOther.Bytes)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}