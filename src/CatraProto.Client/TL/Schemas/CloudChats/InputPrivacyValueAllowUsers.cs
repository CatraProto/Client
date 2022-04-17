using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputPrivacyValueAllowUsers : CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyRuleBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 320652927; }

        [Newtonsoft.Json.JsonProperty("users")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase> Users { get; set; }


#nullable enable
        public InputPrivacyValueAllowUsers(List<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase> users)
        {
            Users = users;

        }
#nullable disable
        internal InputPrivacyValueAllowUsers()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkusers = writer.WriteVector(Users, false);
            if (checkusers.IsError)
            {
                return checkusers;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryusers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryusers.IsError)
            {
                return ReadResult<IObject>.Move(tryusers);
            }
            Users = tryusers.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "inputPrivacyValueAllowUsers";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}