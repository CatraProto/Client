using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Bots
{
    public partial class SetBotMenuButton : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1157944655; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("user_id")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("button")]
        public CatraProto.Client.TL.Schemas.CloudChats.BotMenuButtonBase Button { get; set; }


#nullable enable
        public SetBotMenuButton(CatraProto.Client.TL.Schemas.CloudChats.InputUserBase userId, CatraProto.Client.TL.Schemas.CloudChats.BotMenuButtonBase button)
        {
            UserId = userId;
            Button = button;
        }
#nullable disable

        internal SetBotMenuButton()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkuserId = writer.WriteObject(UserId);
            if (checkuserId.IsError)
            {
                return checkuserId;
            }

            var checkbutton = writer.WriteObject(Button);
            if (checkbutton.IsError)
            {
                return checkbutton;
            }

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryuserId = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
            if (tryuserId.IsError)
            {
                return ReadResult<IObject>.Move(tryuserId);
            }

            UserId = tryuserId.Value;
            var trybutton = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.BotMenuButtonBase>();
            if (trybutton.IsError)
            {
                return ReadResult<IObject>.Move(trybutton);
            }

            Button = trybutton.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "bots.setBotMenuButton";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new SetBotMenuButton();
            var cloneUserId = (CatraProto.Client.TL.Schemas.CloudChats.InputUserBase?)UserId.Clone();
            if (cloneUserId is null)
            {
                return null;
            }

            newClonedObject.UserId = cloneUserId;
            var cloneButton = (CatraProto.Client.TL.Schemas.CloudChats.BotMenuButtonBase?)Button.Clone();
            if (cloneButton is null)
            {
                return null;
            }

            newClonedObject.Button = cloneButton;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not SetBotMenuButton castedOther)
            {
                return true;
            }

            if (UserId.Compare(castedOther.UserId))
            {
                return true;
            }

            if (Button.Compare(castedOther.Button))
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}