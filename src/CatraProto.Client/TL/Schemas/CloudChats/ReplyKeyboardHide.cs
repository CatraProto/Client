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
    public partial class ReplyKeyboardHide : CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Selective = 1 << 2
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1606526075; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("selective")]
        public bool Selective { get; set; }


        public ReplyKeyboardHide()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Selective ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }

            Flags = tryflags.Value;
            Selective = FlagsHelper.IsFlagSet(Flags, 2);
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "replyKeyboardHide";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ReplyKeyboardHide();
            newClonedObject.Flags = Flags;
            newClonedObject.Selective = Selective;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ReplyKeyboardHide castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Selective != castedOther.Selective)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}