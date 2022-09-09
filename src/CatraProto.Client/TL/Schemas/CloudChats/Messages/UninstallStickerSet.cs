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
    public partial class UninstallStickerSet : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -110209570; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("stickerset")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase Stickerset { get; set; }


#nullable enable
        public UninstallStickerSet(CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase stickerset)
        {
            Stickerset = stickerset;
        }
#nullable disable

        internal UninstallStickerSet()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkstickerset = writer.WriteObject(Stickerset);
            if (checkstickerset.IsError)
            {
                return checkstickerset;
            }

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trystickerset = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase>();
            if (trystickerset.IsError)
            {
                return ReadResult<IObject>.Move(trystickerset);
            }

            Stickerset = trystickerset.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.uninstallStickerSet";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new UninstallStickerSet();
            var cloneStickerset = (CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase?)Stickerset.Clone();
            if (cloneStickerset is null)
            {
                return null;
            }

            newClonedObject.Stickerset = cloneStickerset;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not UninstallStickerSet castedOther)
            {
                return true;
            }

            if (Stickerset.Compare(castedOther.Stickerset))
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}