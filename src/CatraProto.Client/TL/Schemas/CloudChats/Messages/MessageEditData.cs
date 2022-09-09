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
    public partial class MessageEditData : CatraProto.Client.TL.Schemas.CloudChats.Messages.MessageEditDataBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Caption = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 649453030; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("caption")]
        public sealed override bool Caption { get; set; }


        public MessageEditData()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Caption ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
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
            Caption = FlagsHelper.IsFlagSet(Flags, 0);
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.messageEditData";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new MessageEditData();
            newClonedObject.Flags = Flags;
            newClonedObject.Caption = Caption;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not MessageEditData castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (Caption != castedOther.Caption)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}