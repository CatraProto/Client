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
    public partial class PhotoSizeEmpty : CatraProto.Client.TL.Schemas.CloudChats.PhotoSizeBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 236446268; }

        [Newtonsoft.Json.JsonProperty("type")] public sealed override string Type { get; set; }


#nullable enable
        public PhotoSizeEmpty(string type)
        {
            Type = type;
        }
#nullable disable
        internal PhotoSizeEmpty()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Type);

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
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "photoSizeEmpty";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PhotoSizeEmpty();
            newClonedObject.Type = Type;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not PhotoSizeEmpty castedOther)
            {
                return true;
            }

            if (Type != castedOther.Type)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}