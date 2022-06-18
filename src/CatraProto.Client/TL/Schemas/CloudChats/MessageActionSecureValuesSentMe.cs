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

using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class MessageActionSecureValuesSentMe : CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 455635795; }

        [Newtonsoft.Json.JsonProperty("values")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.SecureValueBase> Values { get; set; }

        [Newtonsoft.Json.JsonProperty("credentials")]
        public CatraProto.Client.TL.Schemas.CloudChats.SecureCredentialsEncryptedBase Credentials { get; set; }


#nullable enable
        public MessageActionSecureValuesSentMe(List<CatraProto.Client.TL.Schemas.CloudChats.SecureValueBase> values, CatraProto.Client.TL.Schemas.CloudChats.SecureCredentialsEncryptedBase credentials)
        {
            Values = values;
            Credentials = credentials;

        }
#nullable disable
        internal MessageActionSecureValuesSentMe()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkvalues = writer.WriteVector(Values, false);
            if (checkvalues.IsError)
            {
                return checkvalues;
            }
            var checkcredentials = writer.WriteObject(Credentials);
            if (checkcredentials.IsError)
            {
                return checkcredentials;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryvalues = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.SecureValueBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryvalues.IsError)
            {
                return ReadResult<IObject>.Move(tryvalues);
            }
            Values = tryvalues.Value;
            var trycredentials = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.SecureCredentialsEncryptedBase>();
            if (trycredentials.IsError)
            {
                return ReadResult<IObject>.Move(trycredentials);
            }
            Credentials = trycredentials.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messageActionSecureValuesSentMe";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new MessageActionSecureValuesSentMe
            {
                Values = new List<CatraProto.Client.TL.Schemas.CloudChats.SecureValueBase>()
            };
            foreach (var values in Values)
            {
                var clonevalues = (CatraProto.Client.TL.Schemas.CloudChats.SecureValueBase?)values.Clone();
                if (clonevalues is null)
                {
                    return null;
                }
                newClonedObject.Values.Add(clonevalues);
            }
            var cloneCredentials = (CatraProto.Client.TL.Schemas.CloudChats.SecureCredentialsEncryptedBase?)Credentials.Clone();
            if (cloneCredentials is null)
            {
                return null;
            }
            newClonedObject.Credentials = cloneCredentials;
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not MessageActionSecureValuesSentMe castedOther)
            {
                return true;
            }
            var valuessize = castedOther.Values.Count;
            if (valuessize != Values.Count)
            {
                return true;
            }
            for (var i = 0; i < valuessize; i++)
            {
                if (castedOther.Values[i].Compare(Values[i]))
                {
                    return true;
                }
            }
            if (Credentials.Compare(castedOther.Credentials))
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}