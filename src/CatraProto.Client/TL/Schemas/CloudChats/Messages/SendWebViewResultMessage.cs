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
    public partial class SendWebViewResultMessage : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 172168437; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("bot_query_id")]
        public string BotQueryId { get; set; }

        [Newtonsoft.Json.JsonProperty("result")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineResultBase Result { get; set; }


#nullable enable
        public SendWebViewResultMessage(string botQueryId, CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineResultBase result)
        {
            BotQueryId = botQueryId;
            Result = result;
        }
#nullable disable

        internal SendWebViewResultMessage()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(BotQueryId);
            var checkresult = writer.WriteObject(Result);
            if (checkresult.IsError)
            {
                return checkresult;
            }

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trybotQueryId = reader.ReadString();
            if (trybotQueryId.IsError)
            {
                return ReadResult<IObject>.Move(trybotQueryId);
            }

            BotQueryId = trybotQueryId.Value;
            var tryresult = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineResultBase>();
            if (tryresult.IsError)
            {
                return ReadResult<IObject>.Move(tryresult);
            }

            Result = tryresult.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.sendWebViewResultMessage";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new SendWebViewResultMessage();
            newClonedObject.BotQueryId = BotQueryId;
            var cloneResult = (CatraProto.Client.TL.Schemas.CloudChats.InputBotInlineResultBase?)Result.Clone();
            if (cloneResult is null)
            {
                return null;
            }

            newClonedObject.Result = cloneResult;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not SendWebViewResultMessage castedOther)
            {
                return true;
            }

            if (BotQueryId != castedOther.BotQueryId)
            {
                return true;
            }

            if (Result.Compare(castedOther.Result))
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}