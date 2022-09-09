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
    public partial class DocumentAttributeImageSize : CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1815593308; }

        [Newtonsoft.Json.JsonProperty("w")] public int W { get; set; }

        [Newtonsoft.Json.JsonProperty("h")] public int H { get; set; }


#nullable enable
        public DocumentAttributeImageSize(int w, int h)
        {
            W = w;
            H = h;
        }
#nullable disable
        internal DocumentAttributeImageSize()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(W);
            writer.WriteInt32(H);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
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
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "documentAttributeImageSize";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new DocumentAttributeImageSize();
            newClonedObject.W = W;
            newClonedObject.H = H;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not DocumentAttributeImageSize castedOther)
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

            return false;
        }

#nullable disable
    }
}