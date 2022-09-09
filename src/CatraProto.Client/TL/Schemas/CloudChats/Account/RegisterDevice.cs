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
    public partial class RegisterDevice : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            NoMuted = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -326762118; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("no_muted")]
        public bool NoMuted { get; set; }

        [Newtonsoft.Json.JsonProperty("token_type")]
        public int TokenType { get; set; }

        [Newtonsoft.Json.JsonProperty("token")]
        public string Token { get; set; }

        [Newtonsoft.Json.JsonProperty("app_sandbox")]
        public bool AppSandbox { get; set; }

        [Newtonsoft.Json.JsonProperty("secret")]
        public byte[] Secret { get; set; }

        [Newtonsoft.Json.JsonProperty("other_uids")]
        public List<long> OtherUids { get; set; }


#nullable enable
        public RegisterDevice(int tokenType, string token, bool appSandbox, byte[] secret, List<long> otherUids)
        {
            TokenType = tokenType;
            Token = token;
            AppSandbox = appSandbox;
            Secret = secret;
            OtherUids = otherUids;
        }
#nullable disable

        internal RegisterDevice()
        {
        }

        public void UpdateFlags()
        {
            Flags = NoMuted ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt32(TokenType);

            writer.WriteString(Token);
            var checkappSandbox = writer.WriteBool(AppSandbox);
            if (checkappSandbox.IsError)
            {
                return checkappSandbox;
            }

            writer.WriteBytes(Secret);

            writer.WriteVector(OtherUids, false);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }

            Flags = tryflags.Value;
            NoMuted = FlagsHelper.IsFlagSet(Flags, 0);
            var trytokenType = reader.ReadInt32();
            if (trytokenType.IsError)
            {
                return ReadResult<IObject>.Move(trytokenType);
            }

            TokenType = trytokenType.Value;
            var trytoken = reader.ReadString();
            if (trytoken.IsError)
            {
                return ReadResult<IObject>.Move(trytoken);
            }

            Token = trytoken.Value;
            var tryappSandbox = reader.ReadBool();
            if (tryappSandbox.IsError)
            {
                return ReadResult<IObject>.Move(tryappSandbox);
            }

            AppSandbox = tryappSandbox.Value;
            var trysecret = reader.ReadBytes();
            if (trysecret.IsError)
            {
                return ReadResult<IObject>.Move(trysecret);
            }

            Secret = trysecret.Value;
            var tryotherUids = reader.ReadVector<long>(ParserTypes.Int64);
            if (tryotherUids.IsError)
            {
                return ReadResult<IObject>.Move(tryotherUids);
            }

            OtherUids = tryotherUids.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "account.registerDevice";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new RegisterDevice();
            newClonedObject.Flags = Flags;
            newClonedObject.NoMuted = NoMuted;
            newClonedObject.TokenType = TokenType;
            newClonedObject.Token = Token;
            newClonedObject.AppSandbox = AppSandbox;
            newClonedObject.Secret = Secret;
            newClonedObject.OtherUids = new List<long>();
            foreach (var otherUids in OtherUids)
            {
                newClonedObject.OtherUids.Add(otherUids);
            }

            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not RegisterDevice castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (NoMuted != castedOther.NoMuted)
            {
                return true;
            }

            if (TokenType != castedOther.TokenType)
            {
                return true;
            }

            if (Token != castedOther.Token)
            {
                return true;
            }

            if (AppSandbox != castedOther.AppSandbox)
            {
                return true;
            }

            if (Secret != castedOther.Secret)
            {
                return true;
            }

            var otherUidssize = castedOther.OtherUids.Count;
            if (otherUidssize != OtherUids.Count)
            {
                return true;
            }

            for (var i = 0; i < otherUidssize; i++)
            {
                if (castedOther.OtherUids[i] != OtherUids[i])
                {
                    return true;
                }
            }

            return false;
        }
#nullable disable
    }
}