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
    public partial class EncryptedMessageService : CatraProto.Client.TL.Schemas.CloudChats.EncryptedMessageBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 594758406; }

        [Newtonsoft.Json.JsonProperty("random_id")]
        public sealed override long RandomId { get; set; }

        [Newtonsoft.Json.JsonProperty("chat_id")]
        public sealed override int ChatId { get; set; }

        [Newtonsoft.Json.JsonProperty("date")] public sealed override int Date { get; set; }

        [Newtonsoft.Json.JsonProperty("bytes")]
        public sealed override byte[] Bytes { get; set; }


#nullable enable
        public EncryptedMessageService(long randomId, int chatId, int date, byte[] bytes)
        {
            RandomId = randomId;
            ChatId = chatId;
            Date = date;
            Bytes = bytes;
        }
#nullable disable
        internal EncryptedMessageService()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(RandomId);
            writer.WriteInt32(ChatId);
            writer.WriteInt32(Date);

            writer.WriteBytes(Bytes);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryrandomId = reader.ReadInt64();
            if (tryrandomId.IsError)
            {
                return ReadResult<IObject>.Move(tryrandomId);
            }

            RandomId = tryrandomId.Value;
            var trychatId = reader.ReadInt32();
            if (trychatId.IsError)
            {
                return ReadResult<IObject>.Move(trychatId);
            }

            ChatId = trychatId.Value;
            var trydate = reader.ReadInt32();
            if (trydate.IsError)
            {
                return ReadResult<IObject>.Move(trydate);
            }

            Date = trydate.Value;
            var trybytes = reader.ReadBytes();
            if (trybytes.IsError)
            {
                return ReadResult<IObject>.Move(trybytes);
            }

            Bytes = trybytes.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "encryptedMessageService";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new EncryptedMessageService();
            newClonedObject.RandomId = RandomId;
            newClonedObject.ChatId = ChatId;
            newClonedObject.Date = Date;
            newClonedObject.Bytes = Bytes;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not EncryptedMessageService castedOther)
            {
                return true;
            }

            if (RandomId != castedOther.RandomId)
            {
                return true;
            }

            if (ChatId != castedOther.ChatId)
            {
                return true;
            }

            if (Date != castedOther.Date)
            {
                return true;
            }

            if (Bytes != castedOther.Bytes)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}