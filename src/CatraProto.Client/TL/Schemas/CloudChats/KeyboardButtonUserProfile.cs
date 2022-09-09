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
    public partial class KeyboardButtonUserProfile : CatraProto.Client.TL.Schemas.CloudChats.KeyboardButtonBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 814112961; }

        [Newtonsoft.Json.JsonProperty("text")] public sealed override string Text { get; set; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public long UserId { get; set; }


#nullable enable
        public KeyboardButtonUserProfile(string text, long userId)
        {
            Text = text;
            UserId = userId;
        }
#nullable disable
        internal KeyboardButtonUserProfile()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Text);
            writer.WriteInt64(UserId);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trytext = reader.ReadString();
            if (trytext.IsError)
            {
                return ReadResult<IObject>.Move(trytext);
            }

            Text = trytext.Value;
            var tryuserId = reader.ReadInt64();
            if (tryuserId.IsError)
            {
                return ReadResult<IObject>.Move(tryuserId);
            }

            UserId = tryuserId.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "keyboardButtonUserProfile";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new KeyboardButtonUserProfile();
            newClonedObject.Text = Text;
            newClonedObject.UserId = UserId;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not KeyboardButtonUserProfile castedOther)
            {
                return true;
            }

            if (Text != castedOther.Text)
            {
                return true;
            }

            if (UserId != castedOther.UserId)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}