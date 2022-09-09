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
    public partial class InputWebDocument : CatraProto.Client.TL.Schemas.CloudChats.InputWebDocumentBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1678949555; }

        [Newtonsoft.Json.JsonProperty("url")] public sealed override string Url { get; set; }

        [Newtonsoft.Json.JsonProperty("size")] public sealed override int Size { get; set; }

        [Newtonsoft.Json.JsonProperty("mime_type")]
        public sealed override string MimeType { get; set; }

        [Newtonsoft.Json.JsonProperty("attributes")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeBase> Attributes { get; set; }


#nullable enable
        public InputWebDocument(string url, int size, string mimeType, List<CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeBase> attributes)
        {
            Url = url;
            Size = size;
            MimeType = mimeType;
            Attributes = attributes;
        }
#nullable disable
        internal InputWebDocument()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Url);
            writer.WriteInt32(Size);

            writer.WriteString(MimeType);
            var checkattributes = writer.WriteVector(Attributes, false);
            if (checkattributes.IsError)
            {
                return checkattributes;
            }

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryurl = reader.ReadString();
            if (tryurl.IsError)
            {
                return ReadResult<IObject>.Move(tryurl);
            }

            Url = tryurl.Value;
            var trysize = reader.ReadInt32();
            if (trysize.IsError)
            {
                return ReadResult<IObject>.Move(trysize);
            }

            Size = trysize.Value;
            var trymimeType = reader.ReadString();
            if (trymimeType.IsError)
            {
                return ReadResult<IObject>.Move(trymimeType);
            }

            MimeType = trymimeType.Value;
            var tryattributes = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryattributes.IsError)
            {
                return ReadResult<IObject>.Move(tryattributes);
            }

            Attributes = tryattributes.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "inputWebDocument";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputWebDocument();
            newClonedObject.Url = Url;
            newClonedObject.Size = Size;
            newClonedObject.MimeType = MimeType;
            newClonedObject.Attributes = new List<CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeBase>();
            foreach (var attributes in Attributes)
            {
                var cloneattributes = (CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeBase?)attributes.Clone();
                if (cloneattributes is null)
                {
                    return null;
                }

                newClonedObject.Attributes.Add(cloneattributes);
            }

            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not InputWebDocument castedOther)
            {
                return true;
            }

            if (Url != castedOther.Url)
            {
                return true;
            }

            if (Size != castedOther.Size)
            {
                return true;
            }

            if (MimeType != castedOther.MimeType)
            {
                return true;
            }

            var attributessize = castedOther.Attributes.Count;
            if (attributessize != Attributes.Count)
            {
                return true;
            }

            for (var i = 0; i < attributessize; i++)
            {
                if (castedOther.Attributes[i].Compare(Attributes[i]))
                {
                    return true;
                }
            }

            return false;
        }

#nullable disable
    }
}