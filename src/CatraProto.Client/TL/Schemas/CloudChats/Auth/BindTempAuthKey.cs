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

namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public partial class BindTempAuthKey : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -841733627; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("perm_auth_key_id")]
        public long PermAuthKeyId { get; set; }

        [Newtonsoft.Json.JsonProperty("nonce")]
        public long Nonce { get; set; }

        [Newtonsoft.Json.JsonProperty("expires_at")]
        public int ExpiresAt { get; set; }

        [Newtonsoft.Json.JsonProperty("encrypted_message")]
        public byte[] EncryptedMessage { get; set; }


#nullable enable
        public BindTempAuthKey(long permAuthKeyId, long nonce, int expiresAt, byte[] encryptedMessage)
        {
            PermAuthKeyId = permAuthKeyId;
            Nonce = nonce;
            ExpiresAt = expiresAt;
            EncryptedMessage = encryptedMessage;

        }
#nullable disable

        internal BindTempAuthKey()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(PermAuthKeyId);
            writer.WriteInt64(Nonce);
            writer.WriteInt32(ExpiresAt);

            writer.WriteBytes(EncryptedMessage);

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trypermAuthKeyId = reader.ReadInt64();
            if (trypermAuthKeyId.IsError)
            {
                return ReadResult<IObject>.Move(trypermAuthKeyId);
            }
            PermAuthKeyId = trypermAuthKeyId.Value;
            var trynonce = reader.ReadInt64();
            if (trynonce.IsError)
            {
                return ReadResult<IObject>.Move(trynonce);
            }
            Nonce = trynonce.Value;
            var tryexpiresAt = reader.ReadInt32();
            if (tryexpiresAt.IsError)
            {
                return ReadResult<IObject>.Move(tryexpiresAt);
            }
            ExpiresAt = tryexpiresAt.Value;
            var tryencryptedMessage = reader.ReadBytes();
            if (tryencryptedMessage.IsError)
            {
                return ReadResult<IObject>.Move(tryencryptedMessage);
            }
            EncryptedMessage = tryencryptedMessage.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "auth.bindTempAuthKey";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new BindTempAuthKey
            {
                PermAuthKeyId = PermAuthKeyId,
                Nonce = Nonce,
                ExpiresAt = ExpiresAt,
                EncryptedMessage = EncryptedMessage
            };
            return newClonedObject;

        }
#nullable disable
    }
}