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
    public partial class GetPasswordSettings : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1663767815; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("password")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase Password { get; set; }


#nullable enable
        public GetPasswordSettings(CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase password)
        {
            Password = password;
        }
#nullable disable

        internal GetPasswordSettings()
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
            return "account.getPasswordSettings";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetPasswordSettings();
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
            if (other is not GetPasswordSettings castedOther)
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