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
    public partial class TextEmail : CatraProto.Client.TL.Schemas.CloudChats.RichTextBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -564523562; }

        [Newtonsoft.Json.JsonProperty("text")] public CatraProto.Client.TL.Schemas.CloudChats.RichTextBase Text { get; set; }

        [Newtonsoft.Json.JsonProperty("email")]
        public string Email { get; set; }


#nullable enable
        public TextEmail(CatraProto.Client.TL.Schemas.CloudChats.RichTextBase text, string email)
        {
            Text = text;
            Email = email;
        }
#nullable disable
        internal TextEmail()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checktext = writer.WriteObject(Text);
            if (checktext.IsError)
            {
                return checktext;
            }

            writer.WriteString(Email);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trytext = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.RichTextBase>();
            if (trytext.IsError)
            {
                return ReadResult<IObject>.Move(trytext);
            }

            Text = trytext.Value;
            var tryemail = reader.ReadString();
            if (tryemail.IsError)
            {
                return ReadResult<IObject>.Move(tryemail);
            }

            Email = tryemail.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "textEmail";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new TextEmail();
            var cloneText = (CatraProto.Client.TL.Schemas.CloudChats.RichTextBase?)Text.Clone();
            if (cloneText is null)
            {
                return null;
            }

            newClonedObject.Text = cloneText;
            newClonedObject.Email = Email;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not TextEmail castedOther)
            {
                return true;
            }

            if (Text.Compare(castedOther.Text))
            {
                return true;
            }

            if (Email != castedOther.Email)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}