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
    public partial class PeerChat : CatraProto.Client.TL.Schemas.CloudChats.PeerBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 918946202; }

        [Newtonsoft.Json.JsonProperty("chat_id")]
        public long ChatId { get; set; }


#nullable enable
        public PeerChat(long chatId)
        {
            ChatId = chatId;
        }
#nullable disable
        internal PeerChat()
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
            return "peerChat";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PeerChat();
            newClonedObject.ChatId = ChatId;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not PeerChat castedOther)
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