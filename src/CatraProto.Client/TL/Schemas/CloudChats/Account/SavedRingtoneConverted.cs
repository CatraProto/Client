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
    public partial class SavedRingtoneConverted : CatraProto.Client.TL.Schemas.CloudChats.Account.SavedRingtoneBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 523271863; }

        [Newtonsoft.Json.JsonProperty("document")]
        public CatraProto.Client.TL.Schemas.CloudChats.DocumentBase Document { get; set; }


#nullable enable
        public SavedRingtoneConverted(CatraProto.Client.TL.Schemas.CloudChats.DocumentBase document)
        {
            Document = document;
        }
#nullable disable
        internal SavedRingtoneConverted()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkdocument = writer.WriteObject(Document);
            if (checkdocument.IsError)
            {
                return checkdocument;
            }

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trydocument = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();
            if (trydocument.IsError)
            {
                return ReadResult<IObject>.Move(trydocument);
            }

            Document = trydocument.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "account.savedRingtoneConverted";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new SavedRingtoneConverted();
            var cloneDocument = (CatraProto.Client.TL.Schemas.CloudChats.DocumentBase?)Document.Clone();
            if (cloneDocument is null)
            {
                return null;
            }

            newClonedObject.Document = cloneDocument;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not SavedRingtoneConverted castedOther)
            {
                return true;
            }

            if (Document.Compare(castedOther.Document))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}