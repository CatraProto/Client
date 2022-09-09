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
    public partial class InputStickerSetShortName : CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -2044933984; }

        [Newtonsoft.Json.JsonProperty("short_name")]
        public string ShortName { get; set; }


#nullable enable
        public InputStickerSetShortName(string shortName)
        {
            ShortName = shortName;
        }
#nullable disable
        internal InputStickerSetShortName()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(ShortName);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryshortName = reader.ReadString();
            if (tryshortName.IsError)
            {
                return ReadResult<IObject>.Move(tryshortName);
            }

            ShortName = tryshortName.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "inputStickerSetShortName";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputStickerSetShortName();
            newClonedObject.ShortName = ShortName;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not InputStickerSetShortName castedOther)
            {
                return true;
            }

            if (ShortName != castedOther.ShortName)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}