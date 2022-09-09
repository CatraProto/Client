using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class AcceptAuthorization : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -202552205; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("bot_id")]
        public long BotId { get; set; }

        [Newtonsoft.Json.JsonProperty("scope")]
        public string Scope { get; set; }

        [Newtonsoft.Json.JsonProperty("public_key")]
        public string PublicKey { get; set; }

        [Newtonsoft.Json.JsonProperty("value_hashes")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.SecureValueHashBase> ValueHashes { get; set; }

        [Newtonsoft.Json.JsonProperty("credentials")]
        public CatraProto.Client.TL.Schemas.CloudChats.SecureCredentialsEncryptedBase Credentials { get; set; }


#nullable enable
        public AcceptAuthorization(long botId, string scope, string publicKey, List<CatraProto.Client.TL.Schemas.CloudChats.SecureValueHashBase> valueHashes, CatraProto.Client.TL.Schemas.CloudChats.SecureCredentialsEncryptedBase credentials)
        {
            BotId = botId;
            Scope = scope;
            PublicKey = publicKey;
            ValueHashes = valueHashes;
            Credentials = credentials;
        }
#nullable disable

        internal AcceptAuthorization()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(BotId);

            writer.WriteString(Scope);

            writer.WriteString(PublicKey);
            var checkvalueHashes = writer.WriteVector(ValueHashes, false);
            if (checkvalueHashes.IsError)
            {
                return checkvalueHashes;
            }

            var checkcredentials = writer.WriteObject(Credentials);
            if (checkcredentials.IsError)
            {
                return checkcredentials;
            }

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trybotId = reader.ReadInt64();
            if (trybotId.IsError)
            {
                return ReadResult<IObject>.Move(trybotId);
            }

            BotId = trybotId.Value;
            var tryscope = reader.ReadString();
            if (tryscope.IsError)
            {
                return ReadResult<IObject>.Move(tryscope);
            }

            Scope = tryscope.Value;
            var trypublicKey = reader.ReadString();
            if (trypublicKey.IsError)
            {
                return ReadResult<IObject>.Move(trypublicKey);
            }

            PublicKey = trypublicKey.Value;
            var tryvalueHashes = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.SecureValueHashBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryvalueHashes.IsError)
            {
                return ReadResult<IObject>.Move(tryvalueHashes);
            }

            ValueHashes = tryvalueHashes.Value;
            var trycredentials = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.SecureCredentialsEncryptedBase>();
            if (trycredentials.IsError)
            {
                return ReadResult<IObject>.Move(trycredentials);
            }

            Credentials = trycredentials.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "account.acceptAuthorization";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new AcceptAuthorization();
            newClonedObject.BotId = BotId;
            newClonedObject.Scope = Scope;
            newClonedObject.PublicKey = PublicKey;
            newClonedObject.ValueHashes = new List<CatraProto.Client.TL.Schemas.CloudChats.SecureValueHashBase>();
            foreach (var valueHashes in ValueHashes)
            {
                var clonevalueHashes = (CatraProto.Client.TL.Schemas.CloudChats.SecureValueHashBase?)valueHashes.Clone();
                if (clonevalueHashes is null)
                {
                    return null;
                }

                newClonedObject.ValueHashes.Add(clonevalueHashes);
            }

            var cloneCredentials = (CatraProto.Client.TL.Schemas.CloudChats.SecureCredentialsEncryptedBase?)Credentials.Clone();
            if (cloneCredentials is null)
            {
                return null;
            }

            newClonedObject.Credentials = cloneCredentials;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not AcceptAuthorization castedOther)
            {
                return true;
            }

            if (BotId != castedOther.BotId)
            {
                return true;
            }

            if (Scope != castedOther.Scope)
            {
                return true;
            }

            if (PublicKey != castedOther.PublicKey)
            {
                return true;
            }

            var valueHashessize = castedOther.ValueHashes.Count;
            if (valueHashessize != ValueHashes.Count)
            {
                return true;
            }

            for (var i = 0; i < valueHashessize; i++)
            {
                if (castedOther.ValueHashes[i].Compare(ValueHashes[i]))
                {
                    return true;
                }
            }

            if (Credentials.Compare(castedOther.Credentials))
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}