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
    public partial class SendWebViewData : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -603831608; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("bot")] public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase Bot { get; set; }

        [Newtonsoft.Json.JsonProperty("random_id")]
        public long RandomId { get; set; }

        [Newtonsoft.Json.JsonProperty("button_text")]
        public string ButtonText { get; set; }

        [Newtonsoft.Json.JsonProperty("data")] public string Data { get; set; }


#nullable enable
        public SendWebViewData(CatraProto.Client.TL.Schemas.CloudChats.InputUserBase bot, long randomId, string buttonText, string data)
        {
            Bot = bot;
            RandomId = randomId;
            ButtonText = buttonText;
            Data = data;
        }
#nullable disable

        internal SendWebViewData()
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

            writer.WriteInt64(RandomId);

            writer.WriteString(ButtonText);

            writer.WriteString(Data);

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
            var tryrandomId = reader.ReadInt64();
            if (tryrandomId.IsError)
            {
                return ReadResult<IObject>.Move(tryrandomId);
            }

            RandomId = tryrandomId.Value;
            var trybuttonText = reader.ReadString();
            if (trybuttonText.IsError)
            {
                return ReadResult<IObject>.Move(trybuttonText);
            }

            ButtonText = trybuttonText.Value;
            var trydata = reader.ReadString();
            if (trydata.IsError)
            {
                return ReadResult<IObject>.Move(trydata);
            }

            Data = trydata.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.sendWebViewData";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new SendWebViewData();
            var cloneBot = (CatraProto.Client.TL.Schemas.CloudChats.InputUserBase?)Bot.Clone();
            if (cloneBot is null)
            {
                return null;
            }

            newClonedObject.Bot = cloneBot;
            newClonedObject.RandomId = RandomId;
            newClonedObject.ButtonText = ButtonText;
            newClonedObject.Data = Data;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not SendWebViewData castedOther)
            {
                return true;
            }

            if (Bot.Compare(castedOther.Bot))
            {
                return true;
            }

            if (RandomId != castedOther.RandomId)
            {
                return true;
            }

            if (ButtonText != castedOther.ButtonText)
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