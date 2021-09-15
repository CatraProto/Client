using System.Collections.Generic;
using CatraProto.TL;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class Authorizations : AuthorizationsBase
    {
        public static int StaticConstructorId
        {
            get => 307276766;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonProperty("authorizations")] public override IList<AuthorizationBase> AuthorizationsField { get; set; }


        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(AuthorizationsField);
        }

        public override void Deserialize(Reader reader)
        {
            AuthorizationsField = reader.ReadVector<AuthorizationBase>();
        }

        public override string ToString()
        {
            return "account.authorizations";
        }
    }
}