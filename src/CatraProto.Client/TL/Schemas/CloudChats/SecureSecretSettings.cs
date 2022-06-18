/*
CatraProto, a C# library that implements the MTProto protocol and the Telegram API.
Copyright (C) 2022 Aquatica <aquathing@protonmail.com>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class SecureSecretSettings : CatraProto.Client.TL.Schemas.CloudChats.SecureSecretSettingsBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 354925740; }

        [Newtonsoft.Json.JsonProperty("secure_algo")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.SecurePasswordKdfAlgoBase SecureAlgo { get; set; }

        [Newtonsoft.Json.JsonProperty("secure_secret")]
        public sealed override byte[] SecureSecret { get; set; }

        [Newtonsoft.Json.JsonProperty("secure_secret_id")]
        public sealed override long SecureSecretId { get; set; }


#nullable enable
        public SecureSecretSettings(CatraProto.Client.TL.Schemas.CloudChats.SecurePasswordKdfAlgoBase secureAlgo, byte[] secureSecret, long secureSecretId)
        {
            SecureAlgo = secureAlgo;
            SecureSecret = secureSecret;
            SecureSecretId = secureSecretId;

        }
#nullable disable
        internal SecureSecretSettings()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checksecureAlgo = writer.WriteObject(SecureAlgo);
            if (checksecureAlgo.IsError)
            {
                return checksecureAlgo;
            }

            writer.WriteBytes(SecureSecret);
            writer.WriteInt64(SecureSecretId);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trysecureAlgo = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.SecurePasswordKdfAlgoBase>();
            if (trysecureAlgo.IsError)
            {
                return ReadResult<IObject>.Move(trysecureAlgo);
            }
            SecureAlgo = trysecureAlgo.Value;
            var trysecureSecret = reader.ReadBytes();
            if (trysecureSecret.IsError)
            {
                return ReadResult<IObject>.Move(trysecureSecret);
            }
            SecureSecret = trysecureSecret.Value;
            var trysecureSecretId = reader.ReadInt64();
            if (trysecureSecretId.IsError)
            {
                return ReadResult<IObject>.Move(trysecureSecretId);
            }
            SecureSecretId = trysecureSecretId.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "secureSecretSettings";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new SecureSecretSettings();
            var cloneSecureAlgo = (CatraProto.Client.TL.Schemas.CloudChats.SecurePasswordKdfAlgoBase?)SecureAlgo.Clone();
            if (cloneSecureAlgo is null)
            {
                return null;
            }
            newClonedObject.SecureAlgo = cloneSecureAlgo;
            newClonedObject.SecureSecret = SecureSecret;
            newClonedObject.SecureSecretId = SecureSecretId;
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not SecureSecretSettings castedOther)
            {
                return true;
            }
            if (SecureAlgo.Compare(castedOther.SecureAlgo))
            {
                return true;
            }
            if (SecureSecret != castedOther.SecureSecret)
            {
                return true;
            }
            if (SecureSecretId != castedOther.SecureSecretId)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}