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
    public partial class LoginToken : CatraProto.Client.TL.Schemas.CloudChats.Auth.LoginTokenBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1654593920; }

        [Newtonsoft.Json.JsonProperty("expires")]
        public int Expires { get; set; }

        [Newtonsoft.Json.JsonProperty("token")]
        public byte[] Token { get; set; }


#nullable enable
        public LoginToken(int expires, byte[] token)
        {
            Expires = expires;
            Token = token;
        }
#nullable disable
        internal LoginToken()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Expires);

            writer.WriteBytes(Token);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryexpires = reader.ReadInt32();
            if (tryexpires.IsError)
            {
                return ReadResult<IObject>.Move(tryexpires);
            }

            Expires = tryexpires.Value;
            var trytoken = reader.ReadBytes();
            if (trytoken.IsError)
            {
                return ReadResult<IObject>.Move(trytoken);
            }

            Token = trytoken.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "auth.loginToken";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new LoginToken();
            newClonedObject.Expires = Expires;
            newClonedObject.Token = Token;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not LoginToken castedOther)
            {
                return true;
            }

            if (Expires != castedOther.Expires)
            {
                return true;
            }

            if (Token != castedOther.Token)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}