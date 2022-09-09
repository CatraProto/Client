using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public partial class BindAuthKeyInner : CatraProto.Client.TL.Schemas.MTProto.BindAuthKeyInnerBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1973679973; }

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
            var newClonedObject = new BindAuthKeyInner();
            newClonedObject.Nonce = Nonce;
            newClonedObject.TempAuthKeyId = TempAuthKeyId;
            newClonedObject.PermAuthKeyId = PermAuthKeyId;
            newClonedObject.TempSessionId = TempSessionId;
            newClonedObject.ExpiresAt = ExpiresAt;
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