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
    public partial class ToggleBotInAttachMenu : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 451818415; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("bot")] public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase Bot { get; set; }

        [Newtonsoft.Json.JsonProperty("enabled")]
        public bool Enabled { get; set; }


#nullable enable
        public ToggleBotInAttachMenu(CatraProto.Client.TL.Schemas.CloudChats.InputUserBase bot, bool enabled)
        {
            Bot = bot;
            Enabled = enabled;
        }
#nullable disable

        internal ToggleBotInAttachMenu()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkbot = writer.WriteObject(Bot);
            if (checkbot.IsError)
            {
                return checkbot;
            }

            var checkenabled = writer.WriteBool(Enabled);
            if (checkenabled.IsError)
            {
                return checkenabled;
            }

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trybot = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
            if (trybot.IsError)
            {
                return ReadResult<IObject>.Move(trybot);
            }

            Bot = trybot.Value;
            var tryenabled = reader.ReadBool();
            if (tryenabled.IsError)
            {
                return ReadResult<IObject>.Move(tryenabled);
            }

            Enabled = tryenabled.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.toggleBotInAttachMenu";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new ToggleBotInAttachMenu();
            var cloneBot = (CatraProto.Client.TL.Schemas.CloudChats.InputUserBase?)Bot.Clone();
            if (cloneBot is null)
            {
                return null;
            }

            newClonedObject.Bot = cloneBot;
            newClonedObject.Enabled = Enabled;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not ToggleBotInAttachMenu castedOther)
            {
                return true;
            }

            if (Bot.Compare(castedOther.Bot))
            {
                return true;
            }

            if (Enabled != castedOther.Enabled)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}