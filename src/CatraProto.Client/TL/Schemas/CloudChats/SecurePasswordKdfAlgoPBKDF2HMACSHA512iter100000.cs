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
    public partial class SecurePasswordKdfAlgoPBKDF2HMACSHA512iter100000 : CatraProto.Client.TL.Schemas.CloudChats.SecurePasswordKdfAlgoBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -1141711456; }

        [Newtonsoft.Json.JsonProperty("salt")] public byte[] Salt { get; set; }


#nullable enable
        public SecurePasswordKdfAlgoPBKDF2HMACSHA512iter100000(byte[] salt)
        {
            Salt = salt;
        }
#nullable disable
        internal SecurePasswordKdfAlgoPBKDF2HMACSHA512iter100000()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteBytes(Salt);

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trysalt = reader.ReadBytes();
            if (trysalt.IsError)
            {
                return ReadResult<IObject>.Move(trysalt);
            }

            Salt = trysalt.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "securePasswordKdfAlgoPBKDF2HMACSHA512iter100000";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new SecurePasswordKdfAlgoPBKDF2HMACSHA512iter100000();
            newClonedObject.Salt = Salt;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not SecurePasswordKdfAlgoPBKDF2HMACSHA512iter100000 castedOther)
            {
                return true;
            }

            if (Salt != castedOther.Salt)
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}