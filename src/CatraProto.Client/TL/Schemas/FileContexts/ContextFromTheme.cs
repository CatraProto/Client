#nullable disable
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

namespace CatraProto.Client.TL.Schemas.FileContexts
{
    public partial class ContextFromTheme : CatraProto.Client.TL.Schemas.FileContexts.ContextBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1124050819; }

        [Newtonsoft.Json.JsonProperty("format")]
        public string Format { get; set; }

        [Newtonsoft.Json.JsonProperty("slug")] public string Slug { get; set; }

        [Newtonsoft.Json.JsonProperty("id")] public long Id { get; set; }

        [Newtonsoft.Json.JsonProperty("access_hash")]
        public long AccessHash { get; set; }


#nullable enable
        public ContextFromTheme(string format, string slug, long id, long accessHash)
        {
            Format = format;
            Slug = slug;
            Id = id;
            AccessHash = accessHash;
        }
#nullable disable
        internal ContextFromTheme()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Format);

            writer.WriteString(Slug);
            writer.WriteInt64(Id);
            writer.WriteInt64(AccessHash);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryformat = reader.ReadString();
            if (tryformat.IsError)
            {
                return ReadResult<IObject>.Move(tryformat);
            }

            Format = tryformat.Value;
            var tryslug = reader.ReadString();
            if (tryslug.IsError)
            {
                return ReadResult<IObject>.Move(tryslug);
            }

            Slug = tryslug.Value;
            var tryid = reader.ReadInt64();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }

            Id = tryid.Value;
            var tryaccessHash = reader.ReadInt64();
            if (tryaccessHash.IsError)
            {
                return ReadResult<IObject>.Move(tryaccessHash);
            }

            AccessHash = tryaccessHash.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "contextFromTheme";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ContextFromTheme();
            newClonedObject.Format = Format;
            newClonedObject.Slug = Slug;
            newClonedObject.Id = Id;
            newClonedObject.AccessHash = AccessHash;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ContextFromTheme castedOther)
            {
                return true;
            }

            if (Format != castedOther.Format)
            {
                return true;
            }

            if (Slug != castedOther.Slug)
            {
                return true;
            }

            if (Id != castedOther.Id)
            {
                return true;
            }

            if (AccessHash != castedOther.AccessHash)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}