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
    public partial class PhotoPathSize : CatraProto.Client.TL.Schemas.CloudChats.PhotoSizeBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -668906175; }

        [Newtonsoft.Json.JsonProperty("type")] public sealed override string Type { get; set; }

        [Newtonsoft.Json.JsonProperty("bytes")]
        public byte[] Bytes { get; set; }


#nullable enable
        public PhotoPathSize(string type, byte[] bytes)
        {
            Type = type;
            Bytes = bytes;
        }
#nullable disable
        internal PhotoPathSize()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Type);

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
            return "photoPathSize";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PhotoPathSize();
            newClonedObject.Type = Type;
            newClonedObject.Bytes = Bytes;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not PhotoPathSize castedOther)
            {
                return true;
            }

            if (Type != castedOther.Type)
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