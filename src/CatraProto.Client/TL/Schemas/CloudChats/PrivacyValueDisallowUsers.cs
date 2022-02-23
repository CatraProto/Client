using System.Collections.Generic;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PrivacyValueDisallowUsers : CatraProto.Client.TL.Schemas.CloudChats.PrivacyRuleBase
    {
        public static int StaticConstructorId
        {
            get => -463335103;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("users")]
        public IList<long> Users { get; set; }


    #nullable enable
        public PrivacyValueDisallowUsers(IList<long> users)
        {
            Users = users;
        }
    #nullable disable
        internal PrivacyValueDisallowUsers()
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
            Users = reader.ReadVector<long>();
        }

        public override string ToString()
        {
            return "privacyValueDisallowUsers";
        }
    }
}