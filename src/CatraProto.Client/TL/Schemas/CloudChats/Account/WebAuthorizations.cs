using System.Collections.Generic;
using CatraProto.TL;

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public class WebAuthorizations : WebAuthorizationsBase
    {
        public static int ConstructorId { get; } = -313079300;
        public override IList<WebAuthorizationBase> Authorizations { get; set; }
        public override IList<UserBase> Users { get; set; }

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
    }
}