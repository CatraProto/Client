using CatraProto.Client.TL.Schemas.CloudChats;

namespace CatraProto.Client.Updates.Interfaces
{
    public interface IEventHandler
    {
        public void OnUpdate(UpdateBase update);
    }
}