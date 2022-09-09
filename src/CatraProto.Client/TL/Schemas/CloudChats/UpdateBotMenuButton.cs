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
    public partial class UpdateBotMenuButton : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 347625491; }

        [Newtonsoft.Json.JsonProperty("bot_id")]
        public long BotId { get; set; }

        [Newtonsoft.Json.JsonProperty("button")]
        public CatraProto.Client.TL.Schemas.CloudChats.BotMenuButtonBase Button { get; set; }


#nullable enable
        public UpdateBotMenuButton(long botId, CatraProto.Client.TL.Schemas.CloudChats.BotMenuButtonBase button)
        {
            BotId = botId;
            Button = button;
        }
#nullable disable
        internal UpdateBotMenuButton()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(BotId);
            var checkbutton = writer.WriteObject(Button);
            if (checkbutton.IsError)
            {
                return checkbutton;
            }

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trybotId = reader.ReadInt64();
            if (trybotId.IsError)
            {
                return ReadResult<IObject>.Move(trybotId);
            }

            BotId = trybotId.Value;
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
            return "updateBotMenuButton";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateBotMenuButton();
            newClonedObject.BotId = BotId;
            var cloneButton = (CatraProto.Client.TL.Schemas.CloudChats.BotMenuButtonBase?)Button.Clone();
            if (cloneButton is null)
            {
                return null;
            }

            newClonedObject.Button = cloneButton;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateBotMenuButton castedOther)
            {
                return true;
            }

            if (BotId != castedOther.BotId)
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