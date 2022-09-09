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
    public partial class UpdateUsername : IMethod
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => 1040964988; }

        [Newtonsoft.Json.JsonIgnore] ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("username")]
        public string Username { get; set; }


#nullable enable
        public UpdateUsername(string username)
        {
            Username = username;
        }
#nullable disable

        internal UpdateUsername()
        {
        }

        public void UpdateFlags()
        {
        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Username);

            return new WriteResult();
        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryusername = reader.ReadString();
            if (tryusername.IsError)
            {
                return ReadResult<IObject>.Move(tryusername);
            }

            Username = tryusername.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "account.updateUsername";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new UpdateUsername();
            newClonedObject.Username = Username;
            return newClonedObject;
        }

        public bool Compare(IObject other)
        {
            if (other is not UpdateUsername castedOther)
            {
                return true;
            }

            if (Username != castedOther.Username)
            {
                return true;
            }

            return false;
        }
#nullable disable
    }
}