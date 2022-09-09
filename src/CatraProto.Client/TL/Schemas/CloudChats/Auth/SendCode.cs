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
    public partial class SendCode : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1502141361; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [Newtonsoft.Json.JsonProperty("api_id")]
        public int ApiId { get; set; }

        [Newtonsoft.Json.JsonProperty("api_hash")]
        public string ApiHash { get; set; }

        [Newtonsoft.Json.JsonProperty("settings")]
        public CatraProto.Client.TL.Schemas.CloudChats.CodeSettingsBase Settings { get; set; }


#nullable enable
        public SendCode(string phoneNumber, int apiId, string apiHash, CatraProto.Client.TL.Schemas.CloudChats.CodeSettingsBase settings)
        {
            PhoneNumber = phoneNumber;
            ApiId = apiId;
            ApiHash = apiHash;
            Settings = settings;
        }
#nullable disable

        internal SendCode()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(PhoneNumber);
            writer.WriteInt32(ApiId);

            writer.WriteString(ApiHash);
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
            var tryapiId = reader.ReadInt32();
            if (tryapiId.IsError)
            {
                return ReadResult<IObject>.Move(tryapiId);
            }

            ApiId = tryapiId.Value;
            var tryapiHash = reader.ReadString();
            if (tryapiHash.IsError)
            {
                return ReadResult<IObject>.Move(tryapiHash);
            }

            ApiHash = tryapiHash.Value;
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
            return "auth.sendCode";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new SendCode();
            newClonedObject.PhoneNumber = PhoneNumber;
            newClonedObject.ApiId = ApiId;
            newClonedObject.ApiHash = ApiHash;
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
            if (other is not SendCode castedOther)
            {
                return true;
            }

            if (PhoneNumber != castedOther.PhoneNumber)
            {
                return true;
            }

            if (ApiId != castedOther.ApiId)
            {
                return true;
            }

            if (ApiHash != castedOther.ApiHash)
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