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
    public partial class ImportLoginToken : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1783866140; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("token")]
        public byte[] Token { get; set; }


#nullable enable
        public ImportLoginToken(byte[] token)
        {
            Token = token;
        }
#nullable disable

        internal ImportLoginToken()
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
            return "auth.importLoginToken";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new ImportLoginToken();
            newClonedObject.Token = Token;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not ImportLoginToken castedOther)
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