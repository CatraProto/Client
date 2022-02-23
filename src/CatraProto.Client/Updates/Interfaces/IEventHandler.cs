using System.Threading.Tasks;
using CatraProto.Client.TL.Schemas.CloudChats;

namespace CatraProto.Client.Updates.Interfaces
{
    public interface IEventHandler
    {
        public Task OnUpdateAsync(UpdateBase update);
    }
}