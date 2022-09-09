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
    public partial class InputInvoiceSlug : CatraProto.Client.TL.Schemas.CloudChats.InputInvoiceBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1020867857; }

        [Newtonsoft.Json.JsonProperty("slug")] public string Slug { get; set; }


#nullable enable
        public InputInvoiceSlug(string slug)
        {
            Slug = slug;
        }
#nullable disable
        internal InputInvoiceSlug()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Slug);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryslug = reader.ReadString();
            if (tryslug.IsError)
            {
                return ReadResult<IObject>.Move(tryslug);
            }

            Slug = tryslug.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "inputInvoiceSlug";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputInvoiceSlug();
            newClonedObject.Slug = Slug;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not InputInvoiceSlug castedOther)
            {
                return true;
            }

            if (Slug != castedOther.Slug)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}