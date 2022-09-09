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
    public partial class AcceptLoginToken : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -392909491; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("token")]
        public byte[] Token { get; set; }


#nullable enable
        public AcceptLoginToken(byte[] token)
        {
            Token = token;
        }
#nullable disable

        internal AcceptLoginToken()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteBytes(Token);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
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
            return "auth.acceptLoginToken";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new AcceptLoginToken();
            newClonedObject.Token = Token;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not AcceptLoginToken castedOther)
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