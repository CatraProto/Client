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
    public partial class DeleteChat : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1540419152; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("chat_id")]
        public long ChatId { get; set; }


#nullable enable
        public DeleteChat(long chatId)
        {
            ChatId = chatId;
        }
#nullable disable

        internal DeleteChat()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(ChatId);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trychatId = reader.ReadInt64();
            if (trychatId.IsError)
            {
                return ReadResult<IObject>.Move(trychatId);
            }

            ChatId = trychatId.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "messages.deleteChat";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new DeleteChat();
            newClonedObject.ChatId = ChatId;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not DeleteChat castedOther)
            {
                return true;
            }

            if (ChatId != castedOther.ChatId)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}