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
    public partial class SignUp : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -2131827673; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [Newtonsoft.Json.JsonProperty("phone_code_hash")]
        public string PhoneCodeHash { get; set; }

        [Newtonsoft.Json.JsonProperty("first_name")]
        public string FirstName { get; set; }

        [Newtonsoft.Json.JsonProperty("last_name")]
        public string LastName { get; set; }


#nullable enable
        public SignUp(string phoneNumber, string phoneCodeHash, string firstName, string lastName)
        {
            PhoneNumber = phoneNumber;
            PhoneCodeHash = phoneCodeHash;
            FirstName = firstName;
            LastName = lastName;
        }
#nullable disable

        internal SignUp()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(PhoneNumber);

            writer.WriteString(PhoneCodeHash);

            writer.WriteString(FirstName);

            writer.WriteString(LastName);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryphoneNumber = reader.ReadString();
            if (tryphoneNumber.IsError)
            {
                return ReadResult<IObject>.Move(tryphoneNumber);
            }

            PhoneNumber = tryphoneNumber.Value;
            var tryphoneCodeHash = reader.ReadString();
            if (tryphoneCodeHash.IsError)
            {
                return ReadResult<IObject>.Move(tryphoneCodeHash);
            }

            PhoneCodeHash = tryphoneCodeHash.Value;
            var tryfirstName = reader.ReadString();
            if (tryfirstName.IsError)
            {
                return ReadResult<IObject>.Move(tryfirstName);
            }

            FirstName = tryfirstName.Value;
            var trylastName = reader.ReadString();
            if (trylastName.IsError)
            {
                return ReadResult<IObject>.Move(trylastName);
            }

            LastName = trylastName.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "auth.signUp";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new SignUp();
            newClonedObject.PhoneNumber = PhoneNumber;
            newClonedObject.PhoneCodeHash = PhoneCodeHash;
            newClonedObject.FirstName = FirstName;
            newClonedObject.LastName = LastName;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not SignUp castedOther)
            {
                return true;
            }

            if (PhoneNumber != castedOther.PhoneNumber)
            {
                return true;
            }

            if (PhoneCodeHash != castedOther.PhoneCodeHash)
            {
                return true;
            }

            if (FirstName != castedOther.FirstName)
            {
                return true;
            }

            if (LastName != castedOther.LastName)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}