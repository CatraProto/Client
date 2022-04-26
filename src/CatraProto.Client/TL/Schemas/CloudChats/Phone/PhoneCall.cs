using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
    public partial class PhoneCall : CatraProto.Client.TL.Schemas.CloudChats.Phone.PhoneCallBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -326966976; }

        [Newtonsoft.Json.JsonProperty("phone_call")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.PhoneCallBase PhoneCallField { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


#nullable enable
        public PhoneCall(CatraProto.Client.TL.Schemas.CloudChats.PhoneCallBase phoneCallField, List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
        {
            PhoneCallField = phoneCallField;
            Users = users;

        }
#nullable disable
        internal PhoneCall()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkphoneCallField = writer.WriteObject(PhoneCallField);
            if (checkphoneCallField.IsError)
            {
                return checkphoneCallField;
            }
            var checkusers = writer.WriteVector(Users, false);
            if (checkusers.IsError)
            {
                return checkusers;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryphoneCallField = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PhoneCallBase>();
            if (tryphoneCallField.IsError)
            {
                return ReadResult<IObject>.Move(tryphoneCallField);
            }
            PhoneCallField = tryphoneCallField.Value;
            var tryusers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryusers.IsError)
            {
                return ReadResult<IObject>.Move(tryusers);
            }
            Users = tryusers.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "phone.phoneCall";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PhoneCall();
            var clonePhoneCallField = (CatraProto.Client.TL.Schemas.CloudChats.PhoneCallBase?)PhoneCallField.Clone();
            if (clonePhoneCallField is null)
            {
                return null;
            }
            newClonedObject.PhoneCallField = clonePhoneCallField;
            foreach (var users in Users)
            {
                var cloneusers = (CatraProto.Client.TL.Schemas.CloudChats.UserBase?)users.Clone();
                if (cloneusers is null)
                {
                    return null;
                }
                newClonedObject.Users.Add(cloneusers);
            }
            return newClonedObject;

        }
#nullable disable
    }
}