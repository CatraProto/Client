using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputPhoneContact : CatraProto.Client.TL.Schemas.CloudChats.InputContactBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -208488460; }

        [Newtonsoft.Json.JsonProperty("client_id")]
        public sealed override long ClientId { get; set; }

        [Newtonsoft.Json.JsonProperty("phone")]
        public sealed override string Phone { get; set; }

        [Newtonsoft.Json.JsonProperty("first_name")]
        public sealed override string FirstName { get; set; }

        [Newtonsoft.Json.JsonProperty("last_name")]
        public sealed override string LastName { get; set; }


#nullable enable
        public InputPhoneContact(long clientId, string phone, string firstName, string lastName)
        {
            ClientId = clientId;
            Phone = phone;
            FirstName = firstName;
            LastName = lastName;
        }
#nullable disable
        internal InputPhoneContact()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(ClientId);

            writer.WriteString(Phone);

            writer.WriteString(FirstName);

            writer.WriteString(LastName);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryclientId = reader.ReadInt64();
            if (tryclientId.IsError)
            {
                return ReadResult<IObject>.Move(tryclientId);
            }

            ClientId = tryclientId.Value;
            var tryphone = reader.ReadString();
            if (tryphone.IsError)
            {
                return ReadResult<IObject>.Move(tryphone);
            }

            Phone = tryphone.Value;
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
            return "inputPhoneContact";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputPhoneContact();
            newClonedObject.ClientId = ClientId;
            newClonedObject.Phone = Phone;
            newClonedObject.FirstName = FirstName;
            newClonedObject.LastName = LastName;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not InputPhoneContact castedOther)
            {
                return true;
            }

            if (ClientId != castedOther.ClientId)
            {
                return true;
            }

            if (Phone != castedOther.Phone)
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