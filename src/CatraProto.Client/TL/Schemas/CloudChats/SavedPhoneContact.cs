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
    public partial class SavedPhoneContact : CatraProto.Client.TL.Schemas.CloudChats.SavedContactBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 289586518; }

        [Newtonsoft.Json.JsonProperty("phone")]
        public sealed override string Phone { get; set; }

        [Newtonsoft.Json.JsonProperty("first_name")]
        public sealed override string FirstName { get; set; }

        [Newtonsoft.Json.JsonProperty("last_name")]
        public sealed override string LastName { get; set; }

        [Newtonsoft.Json.JsonProperty("date")] public sealed override int Date { get; set; }


#nullable enable
        public SavedPhoneContact(string phone, string firstName, string lastName, int date)
        {
            Phone = phone;
            FirstName = firstName;
            LastName = lastName;
            Date = date;
        }
#nullable disable
        internal SavedPhoneContact()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Phone);

            writer.WriteString(FirstName);

            writer.WriteString(LastName);
            writer.WriteInt32(Date);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
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
            var trydate = reader.ReadInt32();
            if (trydate.IsError)
            {
                return ReadResult<IObject>.Move(trydate);
            }

            Date = trydate.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "savedPhoneContact";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new SavedPhoneContact();
            newClonedObject.Phone = Phone;
            newClonedObject.FirstName = FirstName;
            newClonedObject.LastName = LastName;
            newClonedObject.Date = Date;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not SavedPhoneContact castedOther)
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

            if (Date != castedOther.Date)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}