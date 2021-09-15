namespace CatraProto.Client.Updates.Interfaces
{
    public interface IEventHandler
    {
        public void OnMessage();
        public void OnChannelMessage();
    }
}