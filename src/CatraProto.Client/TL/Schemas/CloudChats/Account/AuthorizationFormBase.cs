using CatraProto.TL;
using CatraProto.TL.Interfaces;
using System.Collections.Generic;
using CatraProto.Client.TL.Schemas.CloudChats;


namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public abstract class AuthorizationFormBase : IObject
    {
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.SecureRequiredTypeBase> RequiredTypes { get; set; }
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.SecureValueBase> Values { get; set; }
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.SecureValueErrorBase> Errors { get; set; }
		public abstract IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }
		public abstract string PrivacyPolicyUrl { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
