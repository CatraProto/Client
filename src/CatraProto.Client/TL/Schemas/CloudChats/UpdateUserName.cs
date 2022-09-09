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
    public partial class UpdateUserName : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1007549728; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public long UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("first_name")]
        public string FirstName { get; set; }

        [Newtonsoft.Json.JsonProperty("last_name")]
        public string LastName { get; set; }

        [Newtonsoft.Json.JsonProperty("username")]
        public string Username { get; set; }


#nullable enable
        public UpdateUserName(long userId, string firstName, string lastName, string username)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            Username = username;
        }
#nullable disable
        internal UpdateUserName()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(UserId);

            writer.WriteString(FirstName);

            writer.WriteString(LastName);

            writer.WriteString(Username);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryuserId = reader.ReadInt64();
            if (tryuserId.IsError)
            {
                return ReadResult<IObject>.Move(tryuserId);
            }

            UserId = tryuserId.Value;
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
            return "updateUserName";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateUserName();
            newClonedObject.UserId = UserId;
            newClonedObject.FirstName = FirstName;
            newClonedObject.LastName = LastName;
            newClonedObject.Username = Username;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateUserName castedOther)
            {
                return true;
            }

            if (UserId != castedOther.UserId)
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

            if (Username != castedOther.Username)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}