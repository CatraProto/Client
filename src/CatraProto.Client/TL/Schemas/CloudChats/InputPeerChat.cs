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
    public partial class InputPeerChat : CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 900291769; }

        [Newtonsoft.Json.JsonProperty("chat_id")]
        public long ChatId { get; set; }


#nullable enable
        public InputPeerChat(long chatId)
        {
            ChatId = chatId;
        }
#nullable disable
        internal InputPeerChat()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(ChatId);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
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
            return "inputPeerChat";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputPeerChat();
            newClonedObject.ChatId = ChatId;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not InputPeerChat castedOther)
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