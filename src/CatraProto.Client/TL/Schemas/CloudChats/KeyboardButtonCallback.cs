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
    public partial class KeyboardButtonCallback : CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonBase
    {
        [Flags]
        public enum FlagsEnum
        {
            RequiresPassword = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 901503851; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("requires_password")]
        public bool RequiresPassword { get; set; }

        [Newtonsoft.Json.JsonProperty("text")] public sealed override string Text { get; set; }

        [Newtonsoft.Json.JsonProperty("data")] public byte[] Data { get; set; }


#nullable enable
        public KeyboardButtonCallback(string text, byte[] data)
        {
            Text = text;
            Data = data;
        }
#nullable disable
        internal KeyboardButtonCallback()
        {
        }

        public override void UpdateFlags()
        {
            Flags = RequiresPassword ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);

            writer.WriteString(Text);

            writer.WriteBytes(Data);

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
            RequiresPassword = FlagsHelper.IsFlagSet(Flags, 0);
            var trytext = reader.ReadString();
            if (trytext.IsError)
            {
                return ReadResult<IObject>.Move(trytext);
            }

            Text = trytext.Value;
            var trydata = reader.ReadBytes();
            if (trydata.IsError)
            {
                return ReadResult<IObject>.Move(trydata);
            }

            Data = trydata.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "keyboardButtonCallback";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new KeyboardButtonCallback();
            newClonedObject.Flags = Flags;
            newClonedObject.RequiresPassword = RequiresPassword;
            newClonedObject.Text = Text;
            newClonedObject.Data = Data;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not KeyboardButtonCallback castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (RequiresPassword != castedOther.RequiresPassword)
            {
                return true;
            }

            if (Text != castedOther.Text)
            {
                return true;
            }

            if (Data != castedOther.Data)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}