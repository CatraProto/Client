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
    public partial class SendChangePhoneCode : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -2108208411; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [Newtonsoft.Json.JsonProperty("settings")]
        public CatraProto.Client.TL.Schemas.CloudChats.CodeSettingsBase Settings { get; set; }


#nullable enable
        public SendChangePhoneCode(string phoneNumber, CatraProto.Client.TL.Schemas.CloudChats.CodeSettingsBase settings)
        {
            PhoneNumber = phoneNumber;
            Settings = settings;
        }
#nullable disable

        internal SendChangePhoneCode()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(PhoneNumber);
            var checksettings = writer.WriteObject(Settings);
            if (checksettings.IsError)
            {
                return checksettings;
            }

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
            var trysettings = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.CodeSettingsBase>();
            if (trysettings.IsError)
            {
                return ReadResult<IObject>.Move(trysettings);
            }

            Settings = trysettings.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "account.sendChangePhoneCode";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new SendChangePhoneCode();
            newClonedObject.PhoneNumber = PhoneNumber;
            var cloneSettings = (CatraProto.Client.TL.Schemas.CloudChats.CodeSettingsBase?)Settings.Clone();
            if (cloneSettings is null)
            {
                return null;
            }

            newClonedObject.Settings = cloneSettings;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not SendChangePhoneCode castedOther)
            {
                return true;
            }

            if (PhoneNumber != castedOther.PhoneNumber)
            {
                return true;
            }

            if (Settings.Compare(castedOther.Settings))
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}