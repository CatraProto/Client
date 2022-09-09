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
    public partial class ReplyKeyboardForceReply : CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase
    {
        [Flags]
        public enum FlagsEnum
        {
            SingleUse = 1 << 1,
            Selective = 1 << 2,
            Placeholder = 1 << 3
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -2035021048; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("single_use")]
        public bool SingleUse { get; set; }

        [Newtonsoft.Json.JsonProperty("selective")]
        public bool Selective { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("placeholder")]
        public string Placeholder { get; set; }


        public ReplyKeyboardForceReply()
        {
        }

        public override void UpdateFlags()
        {
            Flags = SingleUse ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = Selective ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
            Flags = Placeholder == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                writer.WriteString(Placeholder);
            }


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
            SingleUse = FlagsHelper.IsFlagSet(Flags, 1);
            Selective = FlagsHelper.IsFlagSet(Flags, 2);
            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                var tryplaceholder = reader.ReadString();
                if (tryplaceholder.IsError)
                {
                    return ReadResult<IObject>.Move(tryplaceholder);
                }

                Placeholder = tryplaceholder.Value;
            }

            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "replyKeyboardForceReply";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ReplyKeyboardForceReply();
            newClonedObject.Flags = Flags;
            newClonedObject.SingleUse = SingleUse;
            newClonedObject.Selective = Selective;
            newClonedObject.Placeholder = Placeholder;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not ReplyKeyboardForceReply castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (SingleUse != castedOther.SingleUse)
            {
                return true;
            }

            if (Selective != castedOther.Selective)
            {
                return true;
            }

            if (Placeholder != castedOther.Placeholder)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}