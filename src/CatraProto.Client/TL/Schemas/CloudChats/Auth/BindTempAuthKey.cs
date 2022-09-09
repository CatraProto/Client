using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public partial class BindTempAuthKey : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -841733627; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

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
            var newClonedObject = new BindTempAuthKey();
            newClonedObject.PermAuthKeyId = PermAuthKeyId;
            newClonedObject.Nonce = Nonce;
            newClonedObject.ExpiresAt = ExpiresAt;
            newClonedObject.EncryptedMessage = EncryptedMessage;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not BindTempAuthKey castedOther)
            {
                return true;
            }

            if (PermAuthKeyId != castedOther.PermAuthKeyId)
            {
                return true;
            }

            if (Nonce != castedOther.Nonce)
            {
                return true;
            }

            if (ExpiresAt != castedOther.ExpiresAt)
            {
                return true;
            }

            if (EncryptedMessage != castedOther.EncryptedMessage)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}