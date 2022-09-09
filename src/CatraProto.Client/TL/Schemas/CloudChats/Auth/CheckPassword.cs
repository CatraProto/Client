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
    public partial class CheckPassword : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -779399914; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("password")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase Password { get; set; }


#nullable enable
        public CheckPassword(CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase password)
        {
            Password = password;
        }
#nullable disable

        internal CheckPassword()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkpassword = writer.WriteObject(Password);
            if (checkpassword.IsError)
            {
                return checkpassword;
            }

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trypassword = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase>();
            if (trypassword.IsError)
            {
                return ReadResult<IObject>.Move(trypassword);
            }

            Password = trypassword.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "auth.checkPassword";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new CheckPassword();
            var clonePassword = (CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase?)Password.Clone();
            if (clonePassword is null)
            {
                return null;
            }

            newClonedObject.Password = clonePassword;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not CheckPassword castedOther)
            {
                return true;
            }

            if (Password.Compare(castedOther.Password))
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}