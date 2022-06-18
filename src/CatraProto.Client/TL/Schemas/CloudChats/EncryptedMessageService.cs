/*
CatraProto, a C# library that implements the MTProto protocol and the Telegram API.
Copyright (C) 2022 Aquatica <aquathing@protonmail.com>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class EncryptedMessageService : CatraProto.Client.TL.Schemas.CloudChats.EncryptedMessageBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 594758406; }

        [Newtonsoft.Json.JsonProperty("random_id")]
        public sealed override long RandomId { get; set; }

        [Newtonsoft.Json.JsonProperty("chat_id")]
        public sealed override int ChatId { get; set; }

        [Newtonsoft.Json.JsonProperty("date")]
        public sealed override int Date { get; set; }

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
            var newClonedObject = new EncryptedMessageService
            {
                RandomId = RandomId,
                ChatId = ChatId,
                Date = Date,
                Bytes = Bytes
            };
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