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
    public partial class InputWallPaperSlug : CatraProto.Client.TL.Schemas.CloudChats.InputWallPaperBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1913199744; }

        [Newtonsoft.Json.JsonProperty("slug")] public string Slug { get; set; }


#nullable enable
        public InputWallPaperSlug(string slug)
        {
            Slug = slug;
        }
#nullable disable
        internal InputWallPaperSlug()
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
            return "inputWallPaperSlug";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputWallPaperSlug();
            newClonedObject.Slug = Slug;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not InputWallPaperSlug castedOther)
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