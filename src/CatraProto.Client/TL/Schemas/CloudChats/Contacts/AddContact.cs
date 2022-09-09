using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
    public partial class AddContact : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            AddPhonePrivacyException = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -386636848; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("add_phone_privacy_exception")]
        public bool AddPhonePrivacyException { get; set; }

        [Newtonsoft.Json.JsonProperty("id")] public CatraProto.Client.TL.Schemas.CloudChats.InputUserBase Id { get; set; }

        [Newtonsoft.Json.JsonProperty("first_name")]
        public string FirstName { get; set; }

        [Newtonsoft.Json.JsonProperty("last_name")]
        public string LastName { get; set; }

        [Newtonsoft.Json.JsonProperty("phone")]
        public string Phone { get; set; }


#nullable enable
        public AddContact(CatraProto.Client.TL.Schemas.CloudChats.InputUserBase id, string firstName, string lastName, string phone)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
        }
#nullable disable

        internal AddContact()
        {
        }

        public void UpdateFlags()
        {
            Flags = AddPhonePrivacyException ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkid = writer.WriteObject(Id);
            if (checkid.IsError)
            {
                return checkid;
            }

            writer.WriteString(FirstName);

            writer.WriteString(LastName);

            writer.WriteString(Phone);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }

            Flags = tryflags.Value;
            AddPhonePrivacyException = FlagsHelper.IsFlagSet(Flags, 0);
            var tryid = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }

            Id = tryid.Value;
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
            var tryphone = reader.ReadString();
            if (tryphone.IsError)
            {
                return ReadResult<IObject>.Move(tryphone);
            }

            Phone = tryphone.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "contacts.addContact";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new AddContact();
            newClonedObject.Flags = Flags;
            newClonedObject.AddPhonePrivacyException = AddPhonePrivacyException;
            var cloneId = (CatraProto.Client.TL.Schemas.CloudChats.InputUserBase?)Id.Clone();
            if (cloneId is null)
            {
                return null;
            }

            newClonedObject.Id = cloneId;
            newClonedObject.FirstName = FirstName;
            newClonedObject.LastName = LastName;
            newClonedObject.Phone = Phone;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not AddContact castedOther)
            {
                return true;
            }

            if (Flags != castedOther.Flags)
            {
                return true;
            }

            if (AddPhonePrivacyException != castedOther.AddPhonePrivacyException)
            {
                return true;
            }

            if (Id.Compare(castedOther.Id))
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

            if (Phone != castedOther.Phone)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}