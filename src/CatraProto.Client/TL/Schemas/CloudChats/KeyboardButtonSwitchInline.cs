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
    public partial class KeyboardButtonSwitchInline : CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonBase
    {
        [Flags]
        public enum FlagsEnum
        {
            SamePeer = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 90744648; }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("same_peer")]
        public bool SamePeer { get; set; }

        [Newtonsoft.Json.JsonProperty("text")] public sealed override string Text { get; set; }

        [Newtonsoft.Json.JsonProperty("query")]
        public string Query { get; set; }


#nullable enable
        public KeyboardButtonSwitchInline(string text, string query)
        {
            Text = text;
            Query = query;
        }
#nullable disable
        internal KeyboardButtonSwitchInline()
        {
        }

        public override void UpdateFlags()
        {
            Flags = SamePeer ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);

            writer.WriteString(Text);

            writer.WriteString(Query);

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
            SamePeer = FlagsHelper.IsFlagSet(Flags, 0);
            var trytext = reader.ReadString();
            if (trytext.IsError)
            {
                return ReadResult<IObject>.Move(trytext);
            }

            Text = trytext.Value;
            var tryquery = reader.ReadString();
            if (tryquery.IsError)
            {
                return ReadResult<IObject>.Move(tryquery);
            }

            Query = tryquery.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "keyboardButtonSwitchInline";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new KeyboardButtonSwitchInline();
            newClonedObject.Flags = Flags;
            newClonedObject.SamePeer = SamePeer;
            newClonedObject.Text = Text;
            newClonedObject.Query = Query;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not KeyboardButtonSwitchInline castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (SamePeer != castedOther.SamePeer)
            {
                return true;
            }

            if (Text != castedOther.Text)
            {
                return true;
            }

            if (Query != castedOther.Query)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}