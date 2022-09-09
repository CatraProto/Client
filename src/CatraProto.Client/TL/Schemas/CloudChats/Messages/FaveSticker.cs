using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class FaveSticker : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1174420133; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("id")] public CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase Id { get; set; }

        [Newtonsoft.Json.JsonProperty("unfave")]
        public bool Unfave { get; set; }


#nullable enable
        public FaveSticker(CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase id, bool unfave)
        {
            Id = id;
            Unfave = unfave;
        }
#nullable disable

        internal FaveSticker()
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

            var checkunfave = writer.WriteBool(Unfave);
            if (checkunfave.IsError)
            {
                return checkunfave;
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
            var tryunfave = reader.ReadBool();
            if (tryunfave.IsError)
            {
                return ReadResult<IObject>.Move(tryunfave);
            }

            Unfave = tryunfave.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.faveSticker";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new FaveSticker();
            var cloneId = (CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase?)Id.Clone();
            if (cloneId is null)
            {
                return null;
            }

            newClonedObject.Id = cloneId;
            newClonedObject.Unfave = Unfave;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not FaveSticker castedOther)
            {
                return true;
            }

            if (Id.Compare(castedOther.Id))
            {
                return true;
            }

            if (Unfave != castedOther.Unfave)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}