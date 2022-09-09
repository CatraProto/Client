using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class GetTheme : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1919060949; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("format")]
        public string Format { get; set; }

        [Newtonsoft.Json.JsonProperty("theme")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputThemeBase Theme { get; set; }

        [Newtonsoft.Json.JsonProperty("document_id")]
        public long DocumentId { get; set; }


#nullable enable
        public GetTheme(string format, CatraProto.Client.TL.Schemas.CloudChats.InputThemeBase theme, long documentId)
        {
            Format = format;
            Theme = theme;
            DocumentId = documentId;
        }
#nullable disable

        internal GetTheme()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Format);
            var checktheme = writer.WriteObject(Theme);
            if (checktheme.IsError)
            {
                return checktheme;
            }

            writer.WriteInt64(DocumentId);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryformat = reader.ReadString();
            if (tryformat.IsError)
            {
                return ReadResult<IObject>.Move(tryformat);
            }

            Format = tryformat.Value;
            var trytheme = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputThemeBase>();
            if (trytheme.IsError)
            {
                return ReadResult<IObject>.Move(trytheme);
            }

            Theme = trytheme.Value;
            var trydocumentId = reader.ReadInt64();
            if (trydocumentId.IsError)
            {
                return ReadResult<IObject>.Move(trydocumentId);
            }

            DocumentId = trydocumentId.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "account.getTheme";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetTheme();
            newClonedObject.Format = Format;
            var cloneTheme = (CatraProto.Client.TL.Schemas.CloudChats.InputThemeBase?)Theme.Clone();
            if (cloneTheme is null)
            {
                return null;
            }

            newClonedObject.Theme = cloneTheme;
            newClonedObject.DocumentId = DocumentId;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not GetTheme castedOther)
            {
                return true;
            }

            if (Format != castedOther.Format)
            {
                return true;
            }

            if (Theme.Compare(castedOther.Theme))
            {
                return true;
            }

            if (DocumentId != castedOther.DocumentId)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}