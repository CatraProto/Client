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
    public partial class SendConfirmPhoneCode : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 457157256; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("hash")] public string Hash { get; set; }

        [Newtonsoft.Json.JsonProperty("settings")]
        public CatraProto.Client.TL.Schemas.CloudChats.CodeSettingsBase Settings { get; set; }


#nullable enable
        public SendConfirmPhoneCode(string hash, CatraProto.Client.TL.Schemas.CloudChats.CodeSettingsBase settings)
        {
            Hash = hash;
            Settings = settings;
        }
#nullable disable

        internal SendConfirmPhoneCode()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Hash);
            var checksettings = writer.WriteObject(Settings);
            if (checksettings.IsError)
            {
                return checksettings;
            }

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryhash = reader.ReadString();
            if (tryhash.IsError)
            {
                return ReadResult<IObject>.Move(tryhash);
            }

            Hash = tryhash.Value;
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
            return "account.sendConfirmPhoneCode";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new SendConfirmPhoneCode();
            newClonedObject.Hash = Hash;
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
            if (other is not SendConfirmPhoneCode castedOther)
            {
                return true;
            }

            if (Hash != castedOther.Hash)
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