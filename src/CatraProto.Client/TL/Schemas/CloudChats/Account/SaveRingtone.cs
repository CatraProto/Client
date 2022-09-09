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
    public partial class SaveRingtone : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1038768899; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("id")] public CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase Id { get; set; }

        [Newtonsoft.Json.JsonProperty("unsave")]
        public bool Unsave { get; set; }


#nullable enable
        public SaveRingtone(CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase id, bool unsave)
        {
            Id = id;
            Unsave = unsave;
        }
#nullable disable

        internal SaveRingtone()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkid = writer.WriteObject(Id);
            if (checkid.IsError)
            {
                return checkid;
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
            var tryid = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase>();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }

            Id = tryid.Value;
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
            return "account.saveRingtone";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new SaveRingtone();
            var cloneId = (CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase?)Id.Clone();
            if (cloneId is null)
            {
                return null;
            }

            newClonedObject.Id = cloneId;
            newClonedObject.Unsave = Unsave;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not SaveRingtone castedOther)
            {
                return true;
            }

            if (Id.Compare(castedOther.Id))
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