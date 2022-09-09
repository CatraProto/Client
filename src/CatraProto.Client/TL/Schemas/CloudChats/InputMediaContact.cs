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
    public partial class InputMediaContact : CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -122978821; }

        [Newtonsoft.Json.JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [Newtonsoft.Json.JsonProperty("first_name")]
        public string FirstName { get; set; }

        [Newtonsoft.Json.JsonProperty("last_name")]
        public string LastName { get; set; }

        [Newtonsoft.Json.JsonProperty("vcard")]
        public string Vcard { get; set; }


#nullable enable
        public InputMediaContact(string phoneNumber, string firstName, string lastName, string vcard)
        {
            PhoneNumber = phoneNumber;
            FirstName = firstName;
            LastName = lastName;
            Vcard = vcard;
        }
#nullable disable
        internal InputMediaContact()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(PhoneNumber);

            writer.WriteString(FirstName);

            writer.WriteString(LastName);

            writer.WriteString(Vcard);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryphoneNumber = reader.ReadString();
            if (tryphoneNumber.IsError)
            {
                return ReadResult<IObject>.Move(tryphoneNumber);
            }

            PhoneNumber = tryphoneNumber.Value;
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
            var tryvcard = reader.ReadString();
            if (tryvcard.IsError)
            {
                return ReadResult<IObject>.Move(tryvcard);
            }

            Vcard = tryvcard.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "inputMediaContact";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new InputMediaContact();
            newClonedObject.PhoneNumber = PhoneNumber;
            newClonedObject.FirstName = FirstName;
            newClonedObject.LastName = LastName;
            newClonedObject.Vcard = Vcard;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not InputMediaContact castedOther)
            {
                return true;
            }

            if (PhoneNumber != castedOther.PhoneNumber)
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

            if (Vcard != castedOther.Vcard)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}