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
    public partial class SaveTheme : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -229175188; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("theme")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputThemeBase Theme { get; set; }

        [Newtonsoft.Json.JsonProperty("unsave")]
        public bool Unsave { get; set; }


#nullable enable
        public SaveTheme(CatraProto.Client.TL.Schemas.CloudChats.InputThemeBase theme, bool unsave)
        {
            Theme = theme;
            Unsave = unsave;
        }
#nullable disable

        internal SaveTheme()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checktheme = writer.WriteObject(Theme);
            if (checktheme.IsError)
            {
                return checktheme;
            }

            var checkunsave = writer.WriteBool(Unsave);
            if (checkunsave.IsError)
            {
                return checkunsave;
            }

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trytheme = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputThemeBase>();
            if (trytheme.IsError)
            {
                return ReadResult<IObject>.Move(trytheme);
            }

            Theme = trytheme.Value;
            var tryunsave = reader.ReadBool();
            if (tryunsave.IsError)
            {
                return ReadResult<IObject>.Move(tryunsave);
            }

            Unsave = tryunsave.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "account.saveTheme";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new SaveTheme();
            var cloneTheme = (CatraProto.Client.TL.Schemas.CloudChats.InputThemeBase?)Theme.Clone();
            if (cloneTheme is null)
            {
                return null;
            }

            newClonedObject.Theme = cloneTheme;
            newClonedObject.Unsave = Unsave;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not SaveTheme castedOther)
            {
                return true;
            }

            if (Theme.Compare(castedOther.Theme))
            {
                return true;
            }

            if (Unsave != castedOther.Unsave)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}