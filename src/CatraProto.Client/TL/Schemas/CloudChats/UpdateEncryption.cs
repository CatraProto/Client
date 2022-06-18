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
    public partial class UpdateEncryption : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1264392051; }

        [Newtonsoft.Json.JsonProperty("chat")]
        public CatraProto.Client.TL.Schemas.CloudChats.EncryptedChatBase Chat { get; set; }

        [Newtonsoft.Json.JsonProperty("date")]
        public int Date { get; set; }


#nullable enable
        public UpdateEncryption(CatraProto.Client.TL.Schemas.CloudChats.EncryptedChatBase chat, int date)
        {
            Chat = chat;
            Date = date;

        }
#nullable disable
        internal UpdateEncryption()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkchat = writer.WriteObject(Chat);
            if (checkchat.IsError)
            {
                return checkchat;
            }
            writer.WriteInt32(Date);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trychat = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.EncryptedChatBase>();
            if (trychat.IsError)
            {
                return ReadResult<IObject>.Move(trychat);
            }
            Chat = trychat.Value;
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
            return "updateEncryption";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateEncryption();
            var cloneChat = (CatraProto.Client.TL.Schemas.CloudChats.EncryptedChatBase?)Chat.Clone();
            if (cloneChat is null)
            {
                return null;
            }
            newClonedObject.Chat = cloneChat;
            newClonedObject.Date = Date;
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateEncryption castedOther)
            {
                return true;
            }
            if (Chat.Compare(castedOther.Chat))
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