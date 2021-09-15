using System.Collections.Generic;
using CatraProto.TL;
using Newtonsoft.Json;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class WebAuthorizations : WebAuthorizationsBase
    {
        public static int StaticConstructorId
        {
            get => -313079300;
        }

        [JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [JsonProperty("authorizations")] public override IList<WebAuthorizationBase> Authorizations { get; set; }

        [JsonProperty("users")] public override IList<UserBase> Users { get; set; }


        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            if (ConstructorId != 0)
            {
                writer.Write(ConstructorId);
            }

            writer.Write(Authorizations);
            writer.Write(Users);
        }

        public override void Deserialize(Reader reader)
        {
            Authorizations = reader.ReadVector<WebAuthorizationBase>();
            Users = reader.ReadVector<UserBase>();
        }

        public override string ToString()
        {
            return "account.webAuthorizations";
        }
    }
}