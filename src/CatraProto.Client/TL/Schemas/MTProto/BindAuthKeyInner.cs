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
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public partial class BindAuthKeyInner : CatraProto.Client.TL.Schemas.MTProto.BindAuthKeyInnerBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1973679973; }

        [Newtonsoft.Json.JsonProperty("nonce")]
        public sealed override long Nonce { get; set; }

        [Newtonsoft.Json.JsonProperty("temp_auth_key_id")]
        public sealed override long TempAuthKeyId { get; set; }

        [Newtonsoft.Json.JsonProperty("perm_auth_key_id")]
        public sealed override long PermAuthKeyId { get; set; }

        [Newtonsoft.Json.JsonProperty("temp_session_id")]
        public sealed override long TempSessionId { get; set; }

        [Newtonsoft.Json.JsonProperty("expires_at")]
        public sealed override int ExpiresAt { get; set; }


#nullable enable
        public BindAuthKeyInner(long nonce, long tempAuthKeyId, long permAuthKeyId, long tempSessionId, int expiresAt)
        {
            Nonce = nonce;
            TempAuthKeyId = tempAuthKeyId;
            PermAuthKeyId = permAuthKeyId;
            TempSessionId = tempSessionId;
            ExpiresAt = expiresAt;

        }
#nullable disable
        internal BindAuthKeyInner()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(Nonce);
            writer.WriteInt64(TempAuthKeyId);
            writer.WriteInt64(PermAuthKeyId);
            writer.WriteInt64(TempSessionId);
            writer.WriteInt32(ExpiresAt);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trynonce = reader.ReadInt64();
            if (trynonce.IsError)
            {
                return ReadResult<IObject>.Move(trynonce);
            }
            Nonce = trynonce.Value;
            var trytempAuthKeyId = reader.ReadInt64();
            if (trytempAuthKeyId.IsError)
            {
                return ReadResult<IObject>.Move(trytempAuthKeyId);
            }
            TempAuthKeyId = trytempAuthKeyId.Value;
            var trypermAuthKeyId = reader.ReadInt64();
            if (trypermAuthKeyId.IsError)
            {
                return ReadResult<IObject>.Move(trypermAuthKeyId);
            }
            PermAuthKeyId = trypermAuthKeyId.Value;
            var trytempSessionId = reader.ReadInt64();
            if (trytempSessionId.IsError)
            {
                return ReadResult<IObject>.Move(trytempSessionId);
            }
            TempSessionId = trytempSessionId.Value;
            var tryexpiresAt = reader.ReadInt32();
            if (tryexpiresAt.IsError)
            {
                return ReadResult<IObject>.Move(tryexpiresAt);
            }
            ExpiresAt = tryexpiresAt.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "bind_auth_key_inner";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new BindAuthKeyInner
            {
                Nonce = Nonce,
                TempAuthKeyId = TempAuthKeyId,
                PermAuthKeyId = PermAuthKeyId,
                TempSessionId = TempSessionId,
                ExpiresAt = ExpiresAt
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not BindAuthKeyInner castedOther)
            {
                return true;
            }
            if (Nonce != castedOther.Nonce)
            {
                return true;
            }
            if (TempAuthKeyId != castedOther.TempAuthKeyId)
            {
                return true;
            }
            if (PermAuthKeyId != castedOther.PermAuthKeyId)
            {
                return true;
            }
            if (TempSessionId != castedOther.TempSessionId)
            {
                return true;
            }
            if (ExpiresAt != castedOther.ExpiresAt)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}