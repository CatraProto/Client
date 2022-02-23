using System.Collections.Generic;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputPrivacyValueAllowUsers : CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyRuleBase
    {
        public static int StaticConstructorId
        {
            get => 320652927;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("users")]
        public IList<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase> Users { get; set; }


    #nullable enable
        public InputPrivacyValueAllowUsers(IList<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase> users)
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

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Users);
        }

        public override void Deserialize(Reader reader)
        {
            Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputUserBase>();
        }

        public override string ToString()
        {
            return "inputPrivacyValueAllowUsers";
        }
    }
}