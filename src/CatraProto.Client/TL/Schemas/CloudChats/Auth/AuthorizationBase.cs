using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public abstract class AuthorizationBase : IObject
    {
        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}