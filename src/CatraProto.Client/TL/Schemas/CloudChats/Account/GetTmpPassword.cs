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
    public partial class GetTmpPassword : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1151208273; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("password")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase Password { get; set; }

        [Newtonsoft.Json.JsonProperty("period")]
        public int Period { get; set; }


#nullable enable
        public GetTmpPassword(CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase password, int period)
        {
            Password = password;
            Period = period;
        }
#nullable disable

        internal GetTmpPassword()
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

            writer.WriteInt32(Period);

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
            var tryperiod = reader.ReadInt32();
            if (tryperiod.IsError)
            {
                return ReadResult<IObject>.Move(tryperiod);
            }

            Period = tryperiod.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "account.getTmpPassword";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetTmpPassword();
            var clonePassword = (CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase?)Password.Clone();
            if (clonePassword is null)
            {
                return null;
            }

            newClonedObject.Password = clonePassword;
            newClonedObject.Period = Period;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not GetTmpPassword castedOther)
            {
                return true;
            }

            if (Password.Compare(castedOther.Password))
            {
                return true;
            }

            if (Period != castedOther.Period)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}