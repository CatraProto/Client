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
    public partial class UpdateEncryptedMessagesRead : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 956179895; }

        [Newtonsoft.Json.JsonProperty("chat_id")]
        public int ChatId { get; set; }

        [Newtonsoft.Json.JsonProperty("max_date")]
        public int MaxDate { get; set; }

        [Newtonsoft.Json.JsonProperty("date")] public int Date { get; set; }


#nullable enable
        public UpdateEncryptedMessagesRead(int chatId, int maxDate, int date)
        {
            ChatId = chatId;
            MaxDate = maxDate;
            Date = date;
        }
#nullable disable
        internal UpdateEncryptedMessagesRead()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(ChatId);
            writer.WriteInt32(MaxDate);
            writer.WriteInt32(Date);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trychatId = reader.ReadInt32();
            if (trychatId.IsError)
            {
                return ReadResult<IObject>.Move(trychatId);
            }

            ChatId = trychatId.Value;
            var trymaxDate = reader.ReadInt32();
            if (trymaxDate.IsError)
            {
                return ReadResult<IObject>.Move(trymaxDate);
            }

            MaxDate = trymaxDate.Value;
            var trydate = reader.ReadInt32();
            if (trydate.IsError)
            {
                return ReadResult<IObject>.Move(trydate);
            }

            Date = trydate.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "updateEncryptedMessagesRead";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateEncryptedMessagesRead();
            newClonedObject.ChatId = ChatId;
            newClonedObject.MaxDate = MaxDate;
            newClonedObject.Date = Date;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateEncryptedMessagesRead castedOther)
            {
                return true;
            }

            if (ChatId != castedOther.ChatId)
            {
                return true;
            }

            if (MaxDate != castedOther.MaxDate)
            {
                return true;
            }

            if (Date != castedOther.Date)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}