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
    public partial class InputStickerSetDice : CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -427863538; }

        [Newtonsoft.Json.JsonProperty("emoticon")]
        public string Emoticon { get; set; }


#nullable enable
        public InputStickerSetDice(string emoticon)
        {
            Emoticon = emoticon;
        }
#nullable disable
        internal InputStickerSetDice()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Emoticon);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryemoticon = reader.ReadString();
            if (tryemoticon.IsError)
            {
                return ReadResult<IObject>.Move(tryemoticon);
            }

            Emoticon = tryemoticon.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "inputStickerSetDice";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputStickerSetDice();
            newClonedObject.Emoticon = Emoticon;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not InputStickerSetDice castedOther)
            {
                return true;
            }

            if (Emoticon != castedOther.Emoticon)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}